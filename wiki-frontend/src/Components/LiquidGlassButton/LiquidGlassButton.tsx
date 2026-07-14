import { useEffect, useId, useRef, useState, CSSProperties } from 'react';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { useMetalShader } from './useMetalShader';
import SVGDisplacement from './SVGDisplacement';
import './LiquidGlassButton.css';

export interface LiquidGlassButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  light?: number;
  refraction?: number;
  depth?: number;
  dispersion?: number;
  frost?: number;
  splay?: number;
  rgbSplit?: number;
  scale?: number;
  stretch?: number;
  angle?: number;
  gradient?: string[];
  repeats?: number;
  offset?: number;
  phase?: number;
  evolution?: number;
  rounding?: number;
  metalEnabled?: boolean;
  svgEnabled?: boolean;
}

const hexToRgb = (hex: string): [number, number, number] => {
  const m = hex.replace('#', '').match(/.{1,2}/g);
  if (!m) return [0.5, 0.5, 0.5];
  const [r, g, b] = m.map((h) => parseInt(h.length === 1 ? h + h : h, 16) / 255);
  return [r, g, b];
};

const LiquidGlassButton = ({
  light = 0.5,
  refraction = 15,
  depth = 0.5,
  dispersion = 0.3,
  frost,
  splay = 0.6,
  rgbSplit = 0.02,
  scale = 1.5,
  stretch = 1.0,
  angle = 45,
  gradient,
  repeats = 3,
  _offset = 0,
  phase = 0.5,
  evolution = 0.3,
  rounding,
  metalEnabled = true,
  svgEnabled = true,
  className = '',
  style,
  children,
  ...rest
}: LiquidGlassButtonProps) => {
  const { styles } = useStyleContext();
  const era = styles.interfaceEra || 'wikipedia';

  const canvasRef = useRef<HTMLCanvasElement>(null);
  const fallbackRef = useRef<HTMLDivElement>(null);
  const [webglOk, setWebglOk] = useState<boolean | null>(null);

  const reactId = useId();
  const filterId = `lg-filter-${reactId.replace(/:/g, '')}`;

  const cssBlurPx = frost ?? 12;
  const cssOpacity = styles.glassBgOpacity ?? 0.35;
  const cssRadius = rounding ?? 12;
  const gradientStops = gradient && gradient.length > 0
    ? gradient
    : [styles.articleRightColor || '#3c5fb8', styles.articleRightInnerColor || '#2b4ea6'];

  useEffect(() => {
    if (canvasRef.current) {
      const gl = canvasRef.current.getContext('webgl2');
      setWebglOk(!!gl);
    }
  }, [metalEnabled]);

  useMetalShader(canvasRef, {
    enabled: metalEnabled && webglOk === true,
    repeats,
    scale,
    stretch,
    angle,
    rgbSplit,
    light,
    phase,
    evolution,
    colorA: hexToRgb(gradientStops[0]),
    colorB: hexToRgb(gradientStops[1] || gradientStops[0]),
  });

  const showSvg = svgEnabled && (era === 'glass' || era === 'frutiger');
  const showMetal = metalEnabled && era === 'glass' && webglOk === true;

  const glassVarStyle = {
    '--lg-blur': `${cssBlurPx}px`,
    '--lg-opacity': String(cssOpacity),
    '--lg-radius': `${cssRadius}px`,
    '--lg-refraction': String(refraction),
    '--lg-dispersion': String(dispersion),
    '--lg-light': String(light),
    '--lg-depth': String(depth),
    '--lg-border-color': `conic-gradient(from var(--lg-angle, 0deg), ${gradientStops.join(', ')}, ${gradientStops[0]})`,
    ...style,
  } as CSSProperties;

  return (
    <button
      {...rest}
      data-liquid-glass
      data-era={era}
      className={`liquid-glass-button ${className}`}
      style={glassVarStyle}
    >
      {showSvg && (
        <SVGDisplacement
          id={filterId}
          refraction={refraction}
          dispersion={dispersion}
          splay={splay}
          scale={scale}
          stretch={stretch}
          angle={angle}
          repeats={repeats}
          frost={frost ?? cssBlurPx}
        />
      )}

      <span
        className="lg-svg-layer"
        style={{ filter: showSvg ? `url(#${filterId})` : undefined }}
        aria-hidden="true"
      >
        <span
          className="lg-lens"
          style={{ background: `radial-gradient(circle at 30% 30%, rgba(255,255,255,0.25), transparent 60%)` }}
        />
        <span
          className="lg-frost"
          style={{
            background: `rgba(255, 255, 255, ${cssOpacity * 0.15})`,
            backdropFilter: `blur(${cssBlurPx}px) saturate(160%)`,
            WebkitBackdropFilter: `blur(${cssBlurPx}px) saturate(160%)`,
          }}
        />
      </span>

      {showMetal && (
        <canvas
          ref={canvasRef}
          className="lg-metal-canvas"
          aria-hidden="true"
          style={{ mixBlendMode: 'screen' }}
        />
      )}

      {(!showMetal || webglOk !== true) && (
        <div ref={fallbackRef} className="lg-fallback" aria-hidden="true" />
      )}

      <span
        className="lg-border"
        style={{
          background: `conic-gradient(from var(--lg-angle, 0deg), ${gradientStops[0]}, ${gradientStops[1] || gradientStops[0]}, white, ${gradientStops[0]})`,
        }}
      />

      <span className="lg-content">{children}</span>
    </button>
  );
};

export default LiquidGlassButton;
