import { createContext, useContext, useState, useEffect, useCallback } from 'react';
import { fetchSiteSettings, updateSiteSettings } from '../../Api/wikiApi';

interface SiteSettings {
  wikiName?: string;
  logo?: string;
}

interface SiteSettingsContextType {
  settings: SiteSettings;
  refresh: () => void;
  save: (wikiName: string, logoFile: File | null, token: string) => Promise<void>;
}

const SiteSettingsContext = createContext<SiteSettingsContextType>({} as SiteSettingsContextType);

export const SiteSettingsProvider = ({ children }) => {
  const [settings, setSettings] = useState<SiteSettings>({ wikiName: 'WikiPOC', logo: 'logo_pfp.png' });

  const refresh = useCallback(async () => {
    try {
      const data = await fetchSiteSettings();
      if (data) setSettings(data);
    } catch { /* keep existing */ }
  }, []);

  useEffect(() => { refresh(); }, [refresh]);

  const save = useCallback(async (wikiName: string, logoFile: File | null, token: string) => {
    await updateSiteSettings(wikiName, logoFile, token);
    await refresh();
  }, [refresh]);

  return (
    <SiteSettingsContext.Provider value={{ settings, refresh, save }}>
      {children}
    </SiteSettingsContext.Provider>
  );
};

export const useSiteSettings = () => {
  const ctx = useContext(SiteSettingsContext);
  if (!ctx) throw new Error('useSiteSettings must be used within SiteSettingsProvider');
  return ctx;
};
