import { createContext, useContext, useState, useEffect, useCallback } from 'react';
import { fetchCurrentStyles, fetchSystemPresets, fetchUserThemes, updateStyles } from '../../Api/wikiApi';
import { StyleModel } from '../../types/models';
import { StyleContextType } from '../../types/contexts';
import { useUserContext } from './UserContextProvider';
import { useCookies } from 'react-cookie';

const StyleContext = createContext<StyleContextType>({} as StyleContextType);

const ERA_FALLBACKS: Record<string, Partial<StyleModel>> = {
  wikipedia: {
    interfaceEra: 'wikipedia',
    bodyColor: '#f8f9fa',
    articleColor: '#ffffff',
    articleRightColor: '#f8f9fa',
    articleRightInnerColor: '#eaecf0',
    footerListTextColor: '#202122',
    footerListLinkTextColor: '#0645ad',
    fontFamily: "'Linux Libertine', Georgia, serif",
    glassBgOpacity: 1.0,
    glassBlurRadius: 0,
    glassBorderReflection: 0,
    bgMeshGradient: 'none',
    borderRadius: '0px',
    borderStyle: '1px solid #a2a9b1',
    glassGlowIntensity: 0,
    bubbleCountDesktop: 0,
    bubbleCountMobile: 0,
  },
  glass: {
    interfaceEra: 'glass',
    bodyColor: '#507ced',
    articleColor: '#526cad',
    articleRightColor: '#3c5fb8',
    articleRightInnerColor: '#2b4ea6',
    footerListTextColor: '#d0d8f0',
    footerListLinkTextColor: '#8fb8ff',
    fontFamily: 'Arial, sans-serif',
    glassBgOpacity: 0.35,
    glassBlurRadius: 12,
    glassBorderReflection: 0.15,
    bgMeshGradient: 'radial-gradient(circle at 20% 80%, rgba(80,124,237,0.4) 0%, transparent 50%), radial-gradient(circle at 80% 20%, rgba(82,108,173,0.3) 0%, transparent 50%), linear-gradient(135deg, #1a2a6c, #2b4ea6, #507ced)',
    borderRadius: '12px',
    borderStyle: '1px solid rgba(255,255,255,0.12)',
    glassGlowIntensity: 0.5,
    bubbleCountDesktop: 20,
    bubbleCountMobile: 10,
  },
  modern: {
    interfaceEra: 'modern',
    bodyColor: '#0f1117',
    articleColor: '#1a1d27',
    articleRightColor: '#222639',
    articleRightInnerColor: '#2a2f45',
    footerListTextColor: '#8b8fa3',
    footerListLinkTextColor: '#8b7dff',
    fontFamily: 'Inter, system-ui, sans-serif',
    glassBgOpacity: 0.95,
    glassBlurRadius: 0,
    glassBorderReflection: 0,
    bgMeshGradient: 'linear-gradient(135deg, #0f1117 0%, #1a1d27 50%, #222639 100%)',
    borderRadius: '8px',
    borderStyle: '1px solid rgba(255,255,255,0.06)',
    glassGlowIntensity: 0.3,
    bubbleCountDesktop: 0,
    bubbleCountMobile: 0,
  },
  frutiger: {
    interfaceEra: 'frutiger',
    bodyColor: '#2b8a3e',
    articleColor: '#e8f5e9',
    articleRightColor: '#a5d6a7',
    articleRightInnerColor: '#66bb6a',
    footerListTextColor: '#1b5e20',
    footerListLinkTextColor: '#1565c0',
    fontFamily: 'Segoe UI, Tahoma, sans-serif',
    glassBgOpacity: 0.85,
    glassBlurRadius: 0,
    glassBorderReflection: 0.25,
    bgMeshGradient: 'linear-gradient(135deg, #2b8a3e 0%, #43a047 30%, #1b5e20 70%, #2b8a3e 100%)',
    borderRadius: '24px',
    borderStyle: '1px solid rgba(255,255,255,0.35)',
    glassGlowIntensity: 0.25,
    bubbleCountDesktop: 10,
    bubbleCountMobile: 5,
  },
};

export function applyEraFallbacks(styles: Partial<StyleModel>, preserveIdentity = false): StyleModel {
  const era = styles.interfaceEra || 'wikipedia';
  const fallback = ERA_FALLBACKS[era] || ERA_FALLBACKS.wikipedia;
  if (!preserveIdentity) {
    // Strip user identity fields when loading a preset
    const { wikiName: _wikiName, logo: _logo, ...eraOnly } = styles;
    return { ...fallback, ...eraOnly } as StyleModel;
  }
  return { ...fallback, ...styles } as StyleModel;
}

export const StyleProvider = ({ children }: { children: React.ReactNode }) => {
  const [styles, setStyles] = useState<StyleModel>(ERA_FALLBACKS.wikipedia as StyleModel);
  const [systemPresets, setSystemPresets] = useState<StyleModel[]>([]);
  const [userThemes, setUserThemes] = useState<StyleModel[]>([]);
  const [cookies] = useCookies(["jwt_token"]);
  const { decodedTokenContext } = useUserContext();

  // Fetch active theme on mount — preserve saved name/logo
  useEffect(() => {
    fetchCurrentStyles()
      .then(data => setStyles(applyEraFallbacks(data, true)))
      .catch(() => setStyles(ERA_FALLBACKS.wikipedia as StyleModel));
  }, []);

  // Fetch system presets on mount
  useEffect(() => {
    fetchSystemPresets()
      .then(data => setSystemPresets(data))
      .catch(() => {});
  }, []);

  // Fetch user themes when user changes
  const refreshUserThemes = useCallback(() => {
    const userId = decodedTokenContext?.sub;
    const token = cookies["jwt_token"];
    if (!userId || !token) {
      setUserThemes([]);
      return;
    }
    fetchUserThemes(userId, token)
      .then(data => setUserThemes(data))
      .catch(() => {});
  }, [decodedTokenContext, cookies]);

  useEffect(() => {
    refreshUserThemes();
  }, [refreshUserThemes]);

  // Inject CSS custom properties on document root whenever styles change
  useEffect(() => {
    const root = document.documentElement;
    const autoText = deriveContrastText(styles.bodyColor);
    const autoLink = deriveContrastLink(styles.bodyColor, autoText);
    const textColor = styles.footerListTextColor || autoText;
    const linkColor = styles.footerListLinkTextColor || autoLink;
    root.style.setProperty('--custom-body-color', styles.bodyColor || '#f8f9fa');
    root.style.setProperty('--custom-header-color', styles.articleColor || '#ffffff');
    root.style.setProperty('--custom-sidebar-color', styles.articleRightColor || '#ffffff');
    root.style.setProperty('--article-color', styles.articleColor || '#ffffff');
    root.style.setProperty('--glass-bg-opacity', String(styles.glassBgOpacity ?? 1));
    root.style.setProperty('--glass-blur-radius', (styles.glassBlurRadius || 0) + 'px');
    root.style.setProperty('--glass-border-reflection', String(styles.glassBorderReflection ?? 0));
    root.style.setProperty('--bg-mesh-gradient', styles.bgMeshGradient || 'none');
    root.style.setProperty('--custom-border-radius', styles.borderRadius || '0px');
    root.style.setProperty('--custom-border-style', styles.borderStyle || '1px solid #a2a9b1');
    root.style.setProperty('--panel-opacity', String(styles.glassBgOpacity ?? 0.12));
    root.style.setProperty('--glass-glow-intensity', String(styles.glassGlowIntensity ?? 0));
    root.style.setProperty('--bubble-count-desktop', String(styles.bubbleCountDesktop ?? 0));
    root.style.setProperty('--bubble-count-mobile', String(styles.bubbleCountMobile ?? 0));
    root.style.setProperty('--footer-text-color-auto', autoText);
    root.style.setProperty('--footer-link-color-auto', autoLink);
    root.style.setProperty('--footer-text-color', textColor);
    root.style.setProperty('--footer-link-color', linkColor);
  }, [styles]);

  const loadTheme = useCallback((theme: StyleModel) => {
    setStyles(applyEraFallbacks(theme));
  }, []);

  return (
    <StyleContext.Provider value={{
      styles, setStyles, updateStyles,
      systemPresets, userThemes, refreshUserThemes, loadTheme,
    }}>
      {children}
    </StyleContext.Provider>
  );
};

export const useStyleContext = () => {
  const context = useContext(StyleContext);
  if (!context) {
    throw new Error('useStyleContext must be used within a StyleProvider');
  }
  return context;
};

const hexToRgb = (hex: string): [number, number, number] | null => {
  if (!hex) return null;
  const cleaned = hex.replace('#', '').trim();
  if (cleaned.length !== 3 && cleaned.length !== 6) return null;
  const full = cleaned.length === 3
    ? cleaned.split('').map((c) => c + c).join('')
    : cleaned;
  const result = /^([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(full);
  if (!result) return null;
  return [parseInt(result[1], 16), parseInt(result[2], 16), parseInt(result[3], 16)];
};

const relativeLuminance = (rgb: [number, number, number]): number => {
  const [r, g, b] = rgb.map((v) => {
    const c = v / 255;
    return c <= 0.03928 ? c / 12.92 : Math.pow((c + 0.055) / 1.055, 2.4);
  });
  return 0.2126 * r + 0.7152 * g + 0.0722 * b;
};

const isLight = (rgb: [number, number, number]): boolean =>
  relativeLuminance(rgb) > 0.5;

const deriveContrastText = (bodyColor: string | undefined, fallback = '#202122'): string => {
  const rgb = bodyColor ? hexToRgb(bodyColor) : null;
  if (!rgb) return fallback;
  return isLight(rgb) ? '#1a1a1a' : '#f5f5f5';
};

const deriveContrastLink = (bodyColor: string | undefined, textColor: string): string => {
  const rgb = bodyColor ? hexToRgb(bodyColor) : null;
  if (!rgb) return textColor === '#f5f5f5' ? '#7cb9ff' : '#1d4ed8';
  return isLight(rgb) ? '#0d3fc4' : '#82b6ff';
};

export { deriveContrastText, deriveContrastLink, relativeLuminance, isLight };
