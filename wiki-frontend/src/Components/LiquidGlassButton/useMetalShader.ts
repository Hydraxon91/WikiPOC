import { useEffect, useRef } from 'react';

const VERTEX_SHADER = `#version 300 es
in vec2 a_pos;
out vec2 v_uv;
void main() {
  v_uv = a_pos * 0.5 + 0.5;
  gl_Position = vec4(a_pos, 0.0, 1.0);
}`;

const FRAGMENT_SHADER = `#version 300 es
precision highp float;
in vec2 v_uv;
out vec4 outColor;

uniform float u_time;
uniform vec2  u_resolution;
uniform float u_phase;
uniform float u_evolution;
uniform float u_repeats;
uniform float u_scale;
uniform float u_stretch;
uniform float u_angle;
uniform float u_rgbSplit;
uniform float u_light;
uniform vec3  u_colorA;
uniform vec3  u_colorB;

float band(vec2 uv, float t) {
  float rad = radians(u_angle);
  vec2 dir = vec2(cos(rad), sin(rad));
  float u = dot(uv, dir) + t * 0.6;
  float v = dot(uv, vec2(-dir.y, dir.x)) * u_stretch;
  float phase = u * 14.0 * u_repeats + v * 2.0;
  return 0.5 + 0.5 * sin(phase);
}

void main() {
  vec2 uv = v_uv;
  uv.y = 1.0 - uv.y;

  float t = u_time * u_phase + u_evolution * 0.3;

  float r = band(uv + vec2(u_rgbSplit * 0.5, 0.0), t);
  float g = band(uv, t);
  float b = band(uv - vec2(u_rgbSplit * 0.5, 0.0), t);

  float bandAvg = (r + g + b) / 3.0;

  float sharp = smoothstep(0.35, 0.5, bandAvg) - smoothstep(0.5, 0.65, bandAvg);

  vec3 base = mix(u_colorA, u_colorB, sharp);

  float vignette = smoothstep(0.95, 0.4, length(uv - 0.5));
  base += u_light * 0.18 * vignette;

  float edge = smoothstep(0.45, 0.5, max(abs(uv.x - 0.5), abs(uv.y - 0.5)));
  base += vec3(u_light * 0.25 * edge);

  outColor = vec4(base, sharp * 0.55 + 0.25);
}`;

interface UseMetalShaderOptions {
  enabled: boolean;
  repeats: number;
  scale: number;
  stretch: number;
  angle: number;
  rgbSplit: number;
  light: number;
  phase: number;
  evolution: number;
  colorA: [number, number, number];
  colorB: [number, number, number];
}

export const useMetalShader = (
  canvasRef: React.RefObject<HTMLCanvasElement>,
  options: UseMetalShaderOptions
) => {
  const stateRef = useRef<{
    gl: WebGL2RenderingContext | null;
    program: WebGLProgram | null;
    vbo: WebGLBuffer | null;
    uniforms: Record<string, WebGLUniformLocation | null>;
    rafId: number;
    ro: ResizeObserver | null;
    start: number;
  }>({
    gl: null,
    program: null,
    vbo: null,
    uniforms: {},
    rafId: 0,
    ro: null,
    start: 0,
  });

  useEffect(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;
    if (!options.enabled) return;

    const gl = canvas.getContext('webgl2');
    if (!gl) {
      console.warn('[LiquidGlassButton] WebGL 2 not available, using CSS fallback');
      return;
    }

    const compile = (type: number, src: string) => {
      const sh = gl.createShader(type)!;
      gl.shaderSource(sh, src);
      gl.compileShader(sh);
      if (!gl.getShaderParameter(sh, gl.COMPILE_STATUS)) {
        const log = gl.getShaderInfoLog(sh);
        console.error('[LiquidGlassButton] Shader compile error:', log);
        gl.deleteShader(sh);
        return null;
      }
      return sh;
    };

    const vs = compile(gl.VERTEX_SHADER, VERTEX_SHADER);
    const fs = compile(gl.FRAGMENT_SHADER, FRAGMENT_SHADER);
    if (!vs || !fs) {
      return;
    }

    const program = gl.createProgram()!;
    gl.attachShader(program, vs);
    gl.attachShader(program, fs);
    gl.linkProgram(program);
    if (!gl.getProgramParameter(program, gl.LINK_STATUS)) {
      console.error('[LiquidGlassButton] Program link error:', gl.getProgramInfoLog(program));
      gl.deleteProgram(program);
      return;
    }
    gl.deleteShader(vs);
    gl.deleteShader(fs);

    gl.useProgram(program);

    const vbo = gl.createBuffer()!;
    gl.bindBuffer(gl.ARRAY_BUFFER, vbo);
    gl.bufferData(
      gl.ARRAY_BUFFER,
      new Float32Array([-1, -1, 1, -1, -1, 1, -1, 1, 1, -1, 1, 1]),
      gl.STATIC_DRAW
    );
    const aPos = gl.getAttribLocation(program, 'a_pos');
    gl.enableVertexAttribArray(aPos);
    gl.vertexAttribPointer(aPos, 2, gl.FLOAT, false, 0, 0);

    const getU = (name: string) => gl.getUniformLocation(program, name);
    const uniforms = {
      u_time: getU('u_time'),
      u_resolution: getU('u_resolution'),
      u_phase: getU('u_phase'),
      u_evolution: getU('u_evolution'),
      u_repeats: getU('u_repeats'),
      u_scale: getU('u_scale'),
      u_stretch: getU('u_stretch'),
      u_angle: getU('u_angle'),
      u_rgbSplit: getU('u_rgbSplit'),
      u_light: getU('u_light'),
      u_colorA: getU('u_colorA'),
      u_colorB: getU('u_colorB'),
    };

    const st = stateRef.current;
    st.gl = gl;
    st.program = program;
    st.vbo = vbo;
    st.uniforms = uniforms;
    st.start = performance.now();

    const dpr = window.devicePixelRatio || 1;

    const resize = () => {
      const w = canvas.clientWidth;
      const h = canvas.clientHeight;
      if (w === 0 || h === 0) return;
      const pw = Math.max(1, Math.round(w * dpr));
      const ph = Math.max(1, Math.round(h * dpr));
      if (canvas.width !== pw) canvas.width = pw;
      if (canvas.height !== ph) canvas.height = ph;
      gl.viewport(0, 0, pw, ph);
      gl.uniform2f(uniforms.u_resolution, pw, ph);
    };

    resize();
    const ro = new ResizeObserver(resize);
    ro.observe(canvas);
    st.ro = ro;

    const render = () => {
      const t = (performance.now() - st.start) / 1000;
      gl.useProgram(program);
      gl.uniform1f(uniforms.u_time, t);
      gl.uniform1f(uniforms.u_phase, options.phase);
      gl.uniform1f(uniforms.u_evolution, options.evolution);
      gl.uniform1f(uniforms.u_repeats, options.repeats);
      gl.uniform1f(uniforms.u_scale, options.scale);
      gl.uniform1f(uniforms.u_stretch, options.stretch);
      gl.uniform1f(uniforms.u_angle, options.angle);
      gl.uniform1f(uniforms.u_rgbSplit, options.rgbSplit);
      gl.uniform1f(uniforms.u_light, options.light);
      gl.uniform3f(uniforms.u_colorA, options.colorA[0], options.colorA[1], options.colorA[2]);
      gl.uniform3f(uniforms.u_colorB, options.colorB[0], options.colorB[1], options.colorB[2]);
      gl.drawArrays(gl.TRIANGLES, 0, 6);
      st.rafId = requestAnimationFrame(render);
    };
    st.rafId = requestAnimationFrame(render);

    return () => {
      cancelAnimationFrame(st.rafId);
      st.ro?.disconnect();
      const ext = gl.getExtension('WEBGL_lose_context');
      ext?.loseContext();
      if (st.vbo) gl.deleteBuffer(st.vbo);
      if (st.program) gl.deleteProgram(st.program);
    };
  }, [
    canvasRef,
    options.enabled,
    options.repeats,
    options.scale,
    options.stretch,
    options.angle,
    options.rgbSplit,
    options.light,
    options.phase,
    options.evolution,
    options.colorA[0], options.colorA[1], options.colorA[2],
    options.colorB[0], options.colorB[1], options.colorB[2],
  ]);

  return stateRef;
};
