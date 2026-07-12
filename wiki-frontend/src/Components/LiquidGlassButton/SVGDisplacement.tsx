import { useMemo } from 'react';

interface SVGDisplacementProps {
  refraction?: number;
  dispersion?: number;
  splay?: number;
  scale?: number;
  stretch?: number;
  angle?: number;
  repeats?: number;
  frost?: number;
  id: string;
}

const SVGDisplacement = ({
  refraction = 15,
  dispersion = 0.3,
  splay = 0.6,
  scale = 1.5,
  stretch = 1.0,
  angle = 45,
  repeats = 3,
  frost = 0,
  id,
}: SVGDisplacementProps) => {
  const filter = useMemo(() => {
    const cx = 50 + Math.cos((angle * Math.PI) / 180) * 30 * stretch;
    const cy = 50 + Math.sin((angle * Math.PI) / 180) * 30 * stretch;
    return { cx, cy };
  }, [angle, stretch]);

  return (
    <svg
      style={{ position: 'absolute', width: 0, height: 0, pointerEvents: 'none' }}
      aria-hidden="true"
    >
      <defs>
        <filter id={id} x="-20%" y="-20%" width="140%" height="140%">
          <feTurbulence
            type="fractalNoise"
            baseFrequency="0.008 0.012"
            numOctaves="2"
            seed="3"
            result="noise"
          />
          <feGaussianBlur in="noise" stdDeviation={splay * 0.4} result="blurredNoise" />
          <feDisplacementMap
            in="SourceGraphic"
            in2="blurredNoise"
            scale={refraction}
            xChannelSelector="R"
            yChannelSelector="G"
            result="displaced"
          />
          <feGaussianBlur
            in="displaced"
            stdDeviation={frost / 8}
            result="frosted"
          />
          <feColorMatrix
            in="frosted"
            type="matrix"
            values={`
              1 0 0 0 ${dispersion * 0.15}
              0 1 0 0 ${dispersion * 0.08}
              0 0 1 0 ${dispersion * -0.08}
              0 0 0 1 0
            `}
            result="dispersed"
          />
          <feComposite in="dispersed" in2="SourceAlpha" operator="in" />
        </filter>
        <radialGradient id={`${id}-lens`} cx={`${filter.cx}%`} cy={`${filter.cy}%`} r="60%">
          <stop offset="0%" stopColor="white" stopOpacity="0.15" />
          <stop offset="50%" stopColor="white" stopOpacity="0.05" />
          <stop offset="100%" stopColor="white" stopOpacity="0" />
        </radialGradient>
        <pattern
          id={`${id}-bands`}
          patternUnits="userSpaceOnUse"
          width={`${repeats * 20 * scale}`}
          height={`${repeats * 20 * scale * stretch}`}
          patternTransform={`rotate(${angle})`}
        >
          <rect width="100%" height="100%" fill="rgba(255,255,255,0.02)" />
          <line
            x1="0"
            y1="0"
            x2={`${repeats * 20 * scale}`}
            y2="0"
            stroke="rgba(255,255,255,0.06)"
            strokeWidth="0.5"
          />
        </pattern>
      </defs>
    </svg>
  );
};

export default SVGDisplacement;
