import { useStyleContext } from "../../../Components/contexts/StyleContext";
import type { StyleModel } from "../../../types/models";

const ERA_TAGS: Record<string, string> = {
  wikipedia: "Utilitarian Minimalist — 2001",
  glass: "Ambient Frosted — 2023",
  modern: "Dark Geometric — 2025",
  frutiger: "Hyper-Gloss Retro — 2006",
};

const ERA_DESC: Record<string, string> = {
  wikipedia: "Clean, light, timeless. No effects, pure content focus — just like the original Wikipedia.",
  glass: "Floating glass bubbles, animated aurora, and frosted translucent panels with neon blobs.",
  modern: "Dark mode with subtle static mesh, frosted surfaces, and soft purple accents.",
  frutiger: "Nostalgic blue sky, green hills, drifting clouds, and glossy rounded panels.",
};

const ERA_LABELS: Record<string, string> = {
  wikipedia: "Wikipedia Classic",
  glass: "Liquid Glass",
  modern: "Modern Sleek",
  frutiger: "Frutiger Aero",
};

const ERA_BTN_STYLE: Record<string, React.CSSProperties> = {
  glass: {
    background: "linear-gradient(135deg, #507ced 0%, #3c5fb8 100%)",
    border: "1px solid rgba(255,255,255,0.15)",
    borderRadius: 12,
    boxShadow: "0 2px 8px rgba(0,0,0,0.3)",
  },
  modern: {
    background: "linear-gradient(135deg, #6c63ff 0%, #5046e5 100%)",
    border: "1px solid rgba(255,255,255,0.06)",
    borderRadius: 6,
    boxShadow: "0 2px 8px rgba(99,102,241,0.25)",
  },
  frutiger: {
    background: "linear-gradient(to bottom, #7cd97c 0%, #4caf50 40%, #2e7d32 100%)",
    border: "1px solid #a5d6a7",
    borderRadius: 30,
    boxShadow: "0 4px 10px rgba(0,0,0,0.15), inset 0 2px 3px #fff",
  },
  wikipedia: {
    background: "#eaecf0",
    border: "1px solid #a2a9b1",
    borderRadius: 0,
    color: "#202122",
    boxShadow: "none",
  },
};

const PresetsComponent = ({ onLoad }: { onLoad?: (theme: StyleModel) => void }) => {
  const { systemPresets, loadTheme, styles } = useStyleContext();

  return (
    <div>
      <h3 style={{ marginBottom: "1em" }}>System Eras</h3>
      <div className="wikipage-preset-component">
        {systemPresets.map((preset) => {
          const era = preset.interfaceEra || "wikipedia";
          const isActive =
            styles.interfaceEra === era && styles.isSystemPreset;
          const btnStyle = ERA_BTN_STYLE[era] || {};
          return (
            <div
              key={preset.id || era}
              className={`wikipage-preset-card-component preset-card-${era}${
                isActive ? " preset-active" : ""
              }`}
              style={{ fontFamily: preset.fontFamily }}
            >
              {isActive && <span className="preset-active-badge">Active</span>}

              <div
                className={`preset-panel preset-panel-${era}`}
                style={{
                  backgroundColor: preset.articleColor,
                  border: preset.borderStyle || "1px solid #a2a9b1",
                  borderRadius: preset.borderRadius || "0px",
                  '--preset-text': preset.footerListTextColor || '#202122',
                  '--preset-link': preset.footerListLinkTextColor || '#0645ad',
                } as React.CSSProperties}
              >
                <h4>
                  {preset.themeName || ERA_LABELS[era]}
                </h4>
                <p className="preset-panel-tag">
                  {ERA_TAGS[era]}
                </p>
                <p className="preset-panel-desc">
                  {ERA_DESC[era]}
                </p>
                <a
                  href="#"
                  onClick={(e) => e.preventDefault()}
                >
                  Sample link &rarr;
                </a>
              </div>

              <button
                className="btn"
                onClick={() => (onLoad || loadTheme)(preset)}
                style={{
                  color: "#fff",
                  border: "none",
                  padding: "0.4em 1em",
                  cursor: "pointer",
                  fontSize: "0.85em",
                  fontWeight: 600,
                  ...btnStyle,
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
