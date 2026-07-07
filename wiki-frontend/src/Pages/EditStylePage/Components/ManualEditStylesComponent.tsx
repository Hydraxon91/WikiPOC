const EPOCHS = ["wikipedia", "glass", "modern", "frutiger"] as const;
const EPOCH_LABELS: Record<string, string> = {
  wikipedia: "Wikipedia Classic",
  glass: "Liquid Glass",
  modern: "Modern Sleek",
  frutiger: "Frutiger Aero",
};

const fontOptions = [
  "Arial", "Helvetica", "Times New Roman", "Courier New", "Georgia",
  "Verdana", "Comic Sans MS", "Arial Black", "Impact", "Lucida Console",
  "Segoe UI, Tahoma, sans-serif", "Inter, system-ui, sans-serif",
];

const rgbToHex = (color: string) => {
  if (!color) return "#000000";
  if (color.startsWith("#")) return color;
  const m = color.match(/\d+/g);
  if (!m || m.length < 3) return "#000000";
  const [r, g, b] = m.map(Number);
  return "#" + ((1 << 24) + (r << 16) + (g << 8) + b).toString(16).slice(1);
};

const ManualEditStylesComponent = ({
  handleChange,
  newStyles,
  handleLogoPictureChange,
  isWikipedia,
}) => {
  return (
    <div>
      {/* === CORE CONFIG === */}
      <h3 style={{ marginTop: 0 }}>Core Configuration</h3>

      <div className="form-group edit_logo">
        <p>Logo Picture:</p>
        <input type="file" accept="image/*" onChange={handleLogoPictureChange} />
      </div>

      <div className="form-group">
        <label>Wiki Name:</label>
        <input
          type="text"
          value={newStyles.wikiName || ""}
          onChange={(e) => handleChange("wikiName", e.target.value)}
        />
      </div>

      <div className="form-group font-change">
        <label>Font Family:</label>
        <select
          value={newStyles.fontFamily}
          onChange={(e) => handleChange("fontFamily", e.target.value)}
        >
          {fontOptions.map((f) => (
            <option key={f} value={f}>{f}</option>
          ))}
        </select>
      </div>

      {/* === ERA SWITCHER === */}
      <h3>Era Workspace</h3>

      <div style={{ display: "flex", gap: "0.5em", flexWrap: "wrap", marginBottom: "1em" }}>
        {EPOCHS.map((era) => (
          <button
            key={era}
            onClick={() => handleChange("interfaceEra", era)}
            style={{
              padding: "0.4em 1em",
              border: newStyles.interfaceEra === era ? "2px solid #fff" : "1px solid rgba(255,255,255,0.3)",
              borderRadius: 6,
              background: "rgba(255,255,255,0.08)",
              color: "#fff",
              cursor: "pointer",
              fontWeight: newStyles.interfaceEra === era ? "bold" : "normal",
            }}
          >
            {EPOCH_LABELS[era]}
          </button>
        ))}
      </div>

      {/* === COLOR PALETTE === */}
      <h3>Color Palette</h3>

      {[
        { key: "bodyColor", label: "Body Background" },
        { key: "articleColor", label: "Article / Panel" },
        { key: "articleRightColor", label: "Sidebar / Accent" },
        { key: "articleRightInnerColor", label: "Inner Accent" },
        { key: "footerListTextColor", label: "Text Color" },
        { key: "footerListLinkTextColor", label: "Link Color" },
      ].map(({ key, label }) => (
        <div className="form-group" key={key}>
          <label>{label}:</label>
          <input
            type="color"
            className="form-control-color align-middle"
            value={rgbToHex(newStyles[key])}
            onChange={(e) => handleChange(key, e.target.value)}
          />
        </div>
      ))}

      {/* === AESTHETIC MODIFIERS === */}
      <h3>Aesthetic Modifiers</h3>

      <div
        className="form-group"
        style={{ opacity: isWikipedia ? 0.4 : 1, transition: "opacity 0.2s" }}
        title={
          isWikipedia
            ? "Glass/blur settings are saved but visually bypassed in Wikipedia era."
            : ""
        }
      >
        <label>Glass Opacity ({Math.round((newStyles.glassBgOpacity ?? 1) * 100)}%):</label>
        <input
          type="range"
          min="0.05"
          max="1.0"
          step="0.05"
          value={newStyles.glassBgOpacity ?? 1}
          onChange={(e) => handleChange("glassBgOpacity", parseFloat(e.target.value))}
          disabled={isWikipedia}
        />
      </div>

      <div
        className="form-group"
        style={{ opacity: isWikipedia ? 0.4 : 1, transition: "opacity 0.2s" }}
        title={isWikipedia ? "Bypassed in Wikipedia era — values saved for later use." : ""}
      >
        <label>Blur Radius ({(newStyles.glassBlurRadius || 0)}px):</label>
        <input
          type="range"
          min="0"
          max="30"
          step="1"
          value={newStyles.glassBlurRadius || 0}
          onChange={(e) => handleChange("glassBlurRadius", parseInt(e.target.value))}
          disabled={isWikipedia}
        />
      </div>

      <div
        className="form-group"
        style={{ opacity: isWikipedia ? 0.4 : 1, transition: "opacity 0.2s" }}
        title={isWikipedia ? "Bypassed in Wikipedia era — values saved for later use." : ""}
      >
        <label>Border Reflection:</label>
        <input
          type="range"
          min="0"
          max="0.4"
          step="0.05"
          value={newStyles.glassBorderReflection || 0}
          onChange={(e) => handleChange("glassBorderReflection", parseFloat(e.target.value))}
          disabled={isWikipedia}
        />
      </div>

      <div className="form-group">
        <label>Background Mesh (CSS gradient):</label>
        <textarea
          rows={3}
          style={{ width: "100%", fontFamily: "monospace", fontSize: "0.85em" }}
          value={newStyles.bgMeshGradient || ""}
          onChange={(e) => handleChange("bgMeshGradient", e.target.value)}
        />
      </div>

      {/* === BORDER CONFIG === */}
      <h3>Border & Radius</h3>

      <div className="form-group">
        <label>Border Radius ({newStyles.borderRadius || "0px"}):</label>
        <input
          type="range"
          min="0"
          max="32"
          step="1"
          value={parseInt(newStyles.borderRadius || "0")}
          onChange={(e) => handleChange("borderRadius", e.target.value + "px")}
        />
      </div>

      <div className="form-group">
        <label>Border Style:</label>
        <input
          type="text"
          value={newStyles.borderStyle || ""}
          onChange={(e) => handleChange("borderStyle", e.target.value)}
        />
      </div>
    </div>
  );
};

export default ManualEditStylesComponent;
