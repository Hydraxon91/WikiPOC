import { useStyleContext } from "../../../Components/contexts/StyleContext";

const ERA_TAGS: Record<string, string> = {
  wikipedia: "Utilitarian Minimalist — 2001",
  glass: "Ambient Frosted — 2023",
  modern: "Dark Geometric — 2025",
  frutiger: "Hyper-Gloss Retro — 2006",
};

const PresetsComponent = ({ onLoad }: { onLoad?: (theme: any) => void }) => {
  const { systemPresets, loadTheme, styles } = useStyleContext();

  return (
    <div>
      <h3 style={{ marginBottom: "1em" }}>System Eras</h3>
      <div className="wikipage-preset-component">
        {systemPresets.map((preset) => {
          const era = preset.interfaceEra || "wikipedia";
          const isActive =
            styles.interfaceEra === era && styles.isSystemPreset;
          return (
            <div
              key={preset.id || era}
              className={`wikipage-preset-card-component${
                isActive ? " preset-active" : ""
              }`}
              style={{ backgroundColor: preset.bodyColor, fontFamily: preset.fontFamily }}
            >
              <div style={{ display: "flex", gap: "4px", marginBottom: "0.5em" }}>
                <div style={{ width: 20, height: 20, background: preset.bodyColor, border: "1px solid rgba(0,0,0,0.2)", borderRadius: 3 }} />
                <div style={{ width: 20, height: 20, background: preset.articleColor, border: "1px solid rgba(0,0,0,0.2)", borderRadius: 3 }} />
                <div style={{ width: 20, height: 20, background: preset.articleRightColor, border: "1px solid rgba(0,0,0,0.2)", borderRadius: 3 }} />
                <div style={{ width: 20, height: 20, background: preset.articleRightInnerColor, border: "1px solid rgba(0,0,0,0.2)", borderRadius: 3 }} />
                <div style={{ width: 20, height: 20, background: preset.footerListLinkTextColor, border: "1px solid rgba(0,0,0,0.2)", borderRadius: 3 }} />
              </div>
              <h4 style={{ margin: "0 0 0.25em" }}>{preset.themeName || era}</h4>
              <p style={{ fontSize: "0.75em", margin: "0 0 0.75em", opacity: 0.7 }}>
                {ERA_TAGS[era] || era}
              </p>
              <button
                className="btn"
                onClick={() => (onLoad || loadTheme)(preset)}
                style={{
                  background: preset.articleRightInnerColor,
                  color: "#fff",
                  border: "none",
                  borderRadius: 4,
                  padding: "0.4em 1em",
                  cursor: "pointer",
                  fontSize: "0.85em",
                }}
              >
                {isActive ? "Active" : "Load"}
              </button>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default PresetsComponent;
