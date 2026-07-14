import { useEffect } from 'react';
import { useSiteSettings } from '../Components/contexts/SiteSettingsContext';
import { useStyleContext } from '../Components/contexts/StyleContext';

const API_URL = import.meta.env.VITE_API_URL || '';

function setMetaTag(attr: string, name: string, content: string) {
  const selector = attr === 'property'
    ? `meta[property="${name}"]`
    : `meta[name="${name}"]`;
  let el = document.querySelector<HTMLMetaElement>(selector);
  if (!el) {
    el = document.createElement('meta');
    el.setAttribute(attr, name);
    document.head.appendChild(el);
  }
  el.setAttribute('content', content);
}

export function usePageMeta(title?: string, description?: string) {
  const { settings } = useSiteSettings();
  const { styles } = useStyleContext();

  useEffect(() => {
    const wikiName = settings.wikiName || styles.wikiName || 'WikiPOC';
    const pageTitle = title ? `${title} — ${wikiName}` : wikiName;
    const rawLogo = settings.logo || styles.logo;
    const isPlaceholder = !rawLogo || rawLogo === 'logo_pfp.png' || rawLogo === 'logo/logo_pfp.png';
    const logoUrl = isPlaceholder ? '/img/logo.png' : `${API_URL}/api/Image/${rawLogo}`;
    const desc = description || `Explore articles and discussions on ${wikiName}`;
    const url = window.location.href;

    document.title = pageTitle;

    const favicon = document.querySelector<HTMLLinkElement>("link[rel='icon']");
    if (favicon) favicon.href = logoUrl;

    setMetaTag('name', 'description', desc);

    setMetaTag('property', 'og:title', pageTitle);
    setMetaTag('property', 'og:description', desc);
    setMetaTag('property', 'og:image', logoUrl);
    setMetaTag('property', 'og:url', url);
    setMetaTag('property', 'og:type', 'website');

    setMetaTag('name', 'twitter:card', 'summary');
    setMetaTag('name', 'twitter:title', pageTitle);
    setMetaTag('name', 'twitter:description', desc);
    setMetaTag('name', 'twitter:image', logoUrl);
  }, [title, description, settings, styles]);
}
