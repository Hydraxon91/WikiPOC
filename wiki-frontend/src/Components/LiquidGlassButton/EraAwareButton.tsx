import { useStyleContext } from '../../Components/contexts/StyleContext';
import LiquidGlassButton, { LiquidGlassButtonProps } from './LiquidGlassButton';

interface EraAwareButtonProps extends Omit<LiquidGlassButtonProps, 'metalEnabled' | 'svgEnabled'> {
  metalEnabled?: boolean;
  svgEnabled?: boolean;
}

const EraAwareButton = (props: EraAwareButtonProps) => {
  const { styles } = useStyleContext();
  const era = styles.interfaceEra || 'wikipedia';

  if (era !== 'glass' && era !== 'frutiger') {
    const { metalEnabled: _metalEnabled, svgEnabled: _svgEnabled, light: _light, refraction: _refraction, depth: _depth, dispersion: _dispersion,
            frost: _frost, splay: _splay, rgbSplit: _rgbSplit, scale: _scale, stretch: _stretch, angle: _angle, gradient: _gradient, repeats: _repeats,
            offset: _offset, phase: _phase, evolution: _evolution, rounding: _rounding, ...buttonProps } = props;
    return <button {...buttonProps} />;
  }

  const glassDefaults: Partial<LiquidGlassButtonProps> = era === 'frutiger'
    ? { refraction: 8, dispersion: 0.2, splay: 0.7, rgbSplit: 0.01,
        light: 0.6, frost: 14, scale: 1.2, stretch: 1.1, angle: 30,
        repeats: 4, metalEnabled: false, rounding: 24 }
    : { refraction: 15, dispersion: 0.3, splay: 0.6, rgbSplit: 0.02,
        light: 0.5, scale: 1.5, stretch: 1.0, angle: 45,
        repeats: 3, metalEnabled: true, rounding: 12 };

  return <LiquidGlassButton {...glassDefaults} {...props} />;
};

export default EraAwareButton;
