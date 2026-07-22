import { useMemo } from 'react';
import { useStyleContext } from '../contexts/StyleContext';
import './LiquidGlassBackground.css';

interface BubbleSpec {
  size: number;
  left: number;
  duration: number;
  delay: number;
}

const generateBubbles = (count: number): BubbleSpec[] =>
  Array.from({ length: count }, () => ({
    size: 20 + Math.random() * 70,
    left: Math.random() * 100,
    duration: 15 + Math.random() * 10,
    delay: -Math.random() * 25,
  }));

const LiquidGlassBackground = () => {
  const { styles } = useStyleContext();
  const era = styles.interfaceEra || 'glass';
  const desktopCount = styles.bubbleCountDesktop ?? 0;
  const mobileCount = styles.bubbleCountMobile ?? 0;
  const showBlobs = era === 'glass';

  const mobileBubbles = useMemo(() => generateBubbles(mobileCount), [mobileCount]);
  const desktopBubbles = useMemo(() => generateBubbles(Math.max(0, desktopCount - mobileCount)), [desktopCount, mobileCount]);

  return (
    <div className={`liquid-glass-bg lgb-era-${era}`} aria-hidden="true">
      {showBlobs && (
        <>
          <div className="lgb-blob lgb-blob-1" />
          <div className="lgb-blob lgb-blob-2" />
          <div className="lgb-blob lgb-blob-3" />
        </>
      )}
      {mobileBubbles.map((b, i) => (
        <span
          key={`m-${i}`}
          className="lgb-bubble"
          style={{
            width: `${b.size}px`,
            height: `${b.size}px`,
            left: `${b.left}%`,
            animationDuration: `${b.duration}s`,
            animationDelay: `${b.delay}s`,
          }}
        />
      ))}
      {desktopBubbles.map((b, i) => (
        <span
          key={`d-${i}`}
          className="lgb-bubble lgb-bubble-desk"
          style={{
            width: `${b.size}px`,
            height: `${b.size}px`,
            left: `${b.left}%`,
            animationDuration: `${b.duration}s`,
            animationDelay: `${b.delay}s`,
          }}
        />
      ))}
    </div>
  );
};

export default LiquidGlassBackground;
