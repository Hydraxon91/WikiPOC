import { useState, useEffect } from 'react';
import { useSiteSettings } from '../../Components/contexts/SiteSettingsContext';
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { useNotification } from '../../Components/NotificationProvider';

const SiteSettingsPage = ({ jwtToken }) => {
  const { settings, save } = useSiteSettings();
  const { styles } = useStyleContext();
  const { showNotification } = useNotification();
  const [wikiName, setWikiName] = useState('');
  const [logoFile, setLogoFile] = useState<File | null>(null);
  const [saving, setSaving] = useState(false);

  useEffect(() => {
    if (settings?.wikiName) setWikiName(settings.wikiName);
  }, [settings?.wikiName]);

  const handleSave = async () => {
    if (!jwtToken) { showNotification('Not logged in.'); return; }
    setSaving(true);
    try {
      await save(wikiName, logoFile, jwtToken);
      showNotification('Site settings saved!');
      setLogoFile(null);
    } catch (err: any) {
      showNotification('Failed: ' + (err?.message || 'Unknown error'));
    } finally {
      setSaving(false);
    }
  };

  return (
    <div className="article" style={{ backgroundColor: styles.articleColor, padding: '1.5em' }}>
      <h2>Site Settings</h2>

      <div className="form-group">
        <label>Wiki Name:</label>
        <input type="text" value={wikiName} onChange={e => setWikiName(e.target.value)}
          style={{ padding: '0.5em', fontSize: '1em', width: '100%', boxSizing: 'border-box' }} />
      </div>

      <div className="form-group edit_logo">
        <p>Logo Picture:</p>
        <label htmlFor="ss-logo-upload" className="era-button">
          <input id="ss-logo-upload" type="file" accept="image/*" onChange={e => setLogoFile(e.target.files?.[0] || null)} hidden />
          {logoFile ? logoFile.name : 'Choose Logo'}
        </label>
      </div>

      <button onClick={handleSave} disabled={saving}
        style={{ padding: '0.5em 1.5em', marginTop: '1em', cursor: 'pointer' }}>
        {saving ? 'Saving...' : 'Save Settings'}
      </button>
    </div>
  );
};

export default SiteSettingsPage;
