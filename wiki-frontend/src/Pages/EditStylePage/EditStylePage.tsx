import ManualEditStylesComponent from "./Components/ManualEditStylesComponent";
import PresetsComponent from "./Components/PresetsComponent";
import UserThemesList from "./Components/UserThemesList";
import "../../Styles/stylepage.css";
import { useState, useEffect, useRef } from "react";
import { useNavigate } from "react-router-dom";
import { useStyleContext } from "../../Components/contexts/StyleContext";
import { useUserContext } from "../../Components/contexts/UserContextProvider";
import { useNotification } from "../../Components/NotificationProvider";
import { saveUserTheme, activateTheme, fetchCurrentStyles } from "../../Api/wikiApi";
import { applyEraFallbacks } from "../../Components/contexts/StyleContext";
import { StyleModel } from "../../types/models";

const EditStylePage = ({ jwtToken }) => {
  const _navigate = useNavigate();
  const { styles, setStyles, refreshUserThemes } = useStyleContext();
  const { decodedTokenContext } = useUserContext();
  const { showNotification } = useNotification();

  const [newStyles, setNewStyles] = useState(styles);
  const [activeTab, setActiveTab] = useState<"presets" | "manual">("presets");
  const [saveName, setSaveName] = useState("");
  const [showSavePrompt, setShowSavePrompt] = useState(false);
  const [activating, setActivating] = useState(false);
  const hasSavedRef = useRef(false);
  const themeNameRef = useRef<HTMLInputElement>(null);
  const initialSync = useRef(true);
  const initialStylesRef = useRef(styles);

  const role = decodedTokenContext?.["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  const userId = decodedTokenContext?.sub;
  const isAdmin = role === "Admin" || role === "Owner";
  const _isWikipedia = newStyles.interfaceEra === "wikipedia";

  // Load theme into both editor state and live preview
  const handleLoadTheme = (theme: StyleModel) => {
    const merged = applyEraFallbacks(theme);
    setNewStyles(merged);
    setStyles(merged);
  };

  // Sync editor state to live preview
  useEffect(() => {
    setStyles(newStyles);
  }, [newStyles, setStyles]);

  // Sync initial styles from context into editor (after API fetch completes)
  useEffect(() => {
    if (initialSync.current && styles.interfaceEra) {
      setNewStyles(styles);
      initialSync.current = false;
    }
  }, [styles]);

  // Restore pre-edit state on unmount if user didn't save
  useEffect(() => {
    return () => {
      if (!hasSavedRef.current) setStyles(initialStylesRef.current);
    };
  }, [setStyles]);

  const handleChange = (field: string, value: string | number | boolean) => {
    setNewStyles((prev) => ({ ...prev, [field]: value }));
  };

  // Save as custom theme
  const handleSaveCustomTheme = async () => {
    if (!userId) {
      showNotification("You must be logged in to save a theme.");
      return;
    }
    if (!saveName.trim()) {
      showNotification("Please enter a theme name.");
      themeNameRef.current?.focus();
      return;
    }
    try {
      const { id: _id, isActive: _isActive, ...themeData } = newStyles;
      const created = await saveUserTheme(
        { ...themeData, userId, themeName: saveName.trim(), isSystemPreset: false },
        jwtToken
      );
      showNotification("Theme saved!");
      setSaveName("");
      setShowSavePrompt(false);
      refreshUserThemes();
      handleLoadTheme(created);
    } catch (err: unknown) {
      showNotification("Failed to save theme: " + ((err instanceof Error ? err.message : null) || "Unknown error"));
    }
  };

  // Activate globally (admin only)
  const handleActivateGlobal = async () => {
    if (!newStyles.id) {
      showNotification("Select a theme to activate.");
      return;
    }
    setActivating(true);
    try {
      await activateTheme(newStyles.id, jwtToken);
      const fresh = await fetchCurrentStyles();
      setStyles(fresh);
      hasSavedRef.current = true;
      initialStylesRef.current = fresh;
      showNotification("Theme activated globally!");
    } catch (err: unknown) {
      showNotification("Failed to activate: " + ((err instanceof Error ? err.message : null) || "Unknown error"));
    } finally {
      setActivating(false);
    }
  };

  return (
    <div className="article" style={{ backgroundColor: styles.articleColor, padding: "1.5em" }}>
      <div className="stylepage">
        <h2>Theme Editor Dashboard</h2>

        {/* Tab bar */}
        <div style={{ display: "flex", gap: "0.5em", marginBottom: "1.5em" }}>
          <button
            onClick={() => setActiveTab("presets")}
            style={{
              padding: "0.5em 1.2em",
              border: "none",
              borderRadius: 6,
              background: activeTab === "presets" ? "rgba(255,255,255,0.15)" : "rgba(255,255,255,0.05)",
              color: "#fff",
              cursor: "pointer",
              fontWeight: activeTab === "presets" ? "bold" : "normal",
            }}
          >
            System Presets
          </button>
          <button
            onClick={() => setActiveTab("manual")}
            style={{
              padding: "0.5em 1.2em",
              border: "none",
              borderRadius: 6,
              background: activeTab === "manual" ? "rgba(255,255,255,0.15)" : "rgba(255,255,255,0.05)",
              color: "#fff",
              cursor: "pointer",
              fontWeight: activeTab === "manual" ? "bold" : "normal",
            }}
          >
            Manual Edit
          </button>
        </div>

        <div style={{ marginBottom: '1em', padding: '0.5em', background: 'rgba(255,255,255,0.06)', borderRadius: 6 }}>
          Wiki name &amp; logo are managed on the <a href="/site-settings" style={{ color: styles.footerListLinkTextColor }}>Site Settings</a> page.
        </div>

        {/* Tab content */}
        {activeTab === "presets" && (
          <>
            <PresetsComponent onLoad={handleLoadTheme} />
            <UserThemesList jwtToken={jwtToken} onLoad={handleLoadTheme} />

            {/* Save & Activate — presets tab */}
            <div
              style={{
                marginTop: "2em",
                paddingTop: "1.5em",
                borderTop: "1px solid rgba(255,255,255,0.1)",
                display: "flex",
                gap: "0.75em",
                flexWrap: "wrap",
                alignItems: "center",
              }}
            >
              {!showSavePrompt ? (
                <button
                  onClick={() => setShowSavePrompt(true)}
                  style={{
                    padding: "0.5em 1.2em",
                    border: "1px solid rgba(255,255,255,0.2)",
                    borderRadius: 6,
                    background: "rgba(255,255,255,0.08)",
                    color: "#fff",
                    cursor: "pointer",
                  }}
                >
                  Save as Custom Theme
                </button>
              ) : (
                <div style={{ display: "flex", gap: "0.5em", alignItems: "center" }}>
                  <input
                    ref={themeNameRef}
                    type="text"
                    placeholder="Theme name..."
                    value={saveName}
                    onChange={(e) => setSaveName(e.target.value)}
                    onKeyDown={(e) => e.key === "Enter" && handleSaveCustomTheme()}
                    style={{
                      padding: "0.4em 0.6em",
                      borderRadius: 4,
                      border: "1px solid rgba(255,255,255,0.2)",
                      background: "rgba(255,255,255,0.08)",
                      color: "#fff",
                      fontSize: "0.9em",
                    }}
                    autoFocus
                  />
                  <button
                    onClick={handleSaveCustomTheme}
                    style={{
                      padding: "0.5em 1.2em",
                      border: "1px solid rgba(100,200,100,0.4)",
                      borderRadius: 6,
                      background: "rgba(100,200,100,0.15)",
                      color: "#8f8",
                      cursor: "pointer",
                    }}
                  >
                    Save
                  </button>
                  <button
                    onClick={() => { setShowSavePrompt(false); setSaveName(""); }}
                    style={{
                      padding: "0.5em 1.2em",
                      border: "1px solid rgba(255,255,255,0.1)",
                      borderRadius: 6,
                      background: "transparent",
                      color: "#aaa",
                      cursor: "pointer",
                    }}
                  >
                    Cancel
                  </button>
                </div>
              )}

              {isAdmin && (
                <div style={{ display: 'flex', alignItems: 'center', gap: '0.75em', marginLeft: 'auto' }}>
                  <span style={{ fontSize: '0.75em', opacity: 0.6, maxWidth: '200px', textAlign: 'right' }}>
                    Save a custom theme above, then activate it globally.
                  </span>
                  <button
                    onClick={handleActivateGlobal}
                    disabled={activating || !newStyles.id}
                    style={{
                      padding: "0.5em 1.2em",
                      border: "1px solid rgba(255,200,100,0.4)",
                      borderRadius: 6,
                      background: activating ? "rgba(255,200,100,0.08)" : "rgba(255,200,100,0.15)",
                      color: activating ? "#888" : "#ffd700",
                      cursor: activating ? "not-allowed" : "pointer",
                      whiteSpace: 'nowrap',
                    }}
                  >
                    {activating ? "Activating..." : "Activate Globally"}
                  </button>
                </div>
              )}
            </div>
          </>
        )}

        {activeTab === "manual" && (
          <>
            <ManualEditStylesComponent
              handleChange={handleChange}
              newStyles={newStyles}
            />
            <div style={{ marginTop: '1.5em', opacity: 0.7, fontStyle: 'italic' }}>
              Switch to <a href="#" onClick={(e) => { e.preventDefault(); setActiveTab('presets'); }} style={{ color: styles.footerListLinkTextColor }}>System Presets</a> to save and activate your theme.
            </div>
          </>
        )}
      </div>
    </div>
  );
};

export default EditStylePage;
