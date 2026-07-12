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
}) => {
  return (
    <div>
      {/* === FONT CONFIG === */}
      <h3 style={{ marginTop: 0 }}>Font Family</h3>

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

      {/* === LEGIBILITY PREVIEW === */}
      <h3>Text Legibility Preview</h3>
      <p style={{ fontSize: "0.8em", opacity: 0.7, margin: "0 0 0.5em 0" }}>
        See how your text color reads against the current body and glass
        opacity. Adjust until it feels comfortable.
      </p>
      <div
        style={{
          background: newStyles.bodyColor || "#f8f9fa",
          borderRadius: newStyles.borderRadius || "0px",
          border: newStyles.borderStyle || "1px solid #a2a9b1",
          padding: "1.5em",
          marginBottom: "1.5em",
          position: "relative",
          overflow: "hidden",
        }}
      >
        <div
          style={{
            position: "absolute",
            inset: 0,
            background: newStyles.articleColor || "#ffffff",
            opacity: 1 - (newStyles.glassBgOpacity ?? 1),
            pointerEvents: "none",
          }}
        />
        <div
          style={{
            position: "relative",
            backdropFilter: `blur(${newStyles.glassBlurRadius || 0}px)`,
            WebkitBackdropFilter: `blur(${newStyles.glassBlurRadius || 0}px)`,
            padding: "1em",
            borderRadius: (newStyles.borderRadius ? parseInt(newStyles.borderRadius) / 2 : 0) + "px",
            background: "transparent",
          }}
        >
          <p
            style={{
              color: newStyles.footerListTextColor || "#202122",
              fontFamily: newStyles.fontFamily,
              margin: 0,
              lineHeight: 1.6,
              fontSize: "0.95em",
            }}
          >
            This is how your <a
              href="#"
              style={{ color: newStyles.footerListLinkTextColor || "#0645ad" }}
            >links</a> and body text will look. The text color{" "}
            <code style={{ background: "rgba(0,0,0,0.06)", padding: "0 0.2em", borderRadius: 3 }}>
              {newStyles.footerListTextColor || "auto"}
            </code>{" "}
            is set against the body{" "}
            <code style={{ background: "rgba(0,0,0,0.06)", padding: "0 0.2em", borderRadius: 3 }}>
              {newStyles.bodyColor || "#f8f9fa"}
            </code>{" "}
            with glass opacity{" "}
            <strong>{Math.round((newStyles.glassBgOpacity ?? 1) * 100)}%</strong>.
          </p>
          <p
            style={{
              color: newStyles.footerListTextColor || "#202122",
              fontFamily: newStyles.fontFamily,
              fontSize: "0.85em",
              margin: "0.5em 0 0 0",
              opacity: 0.85,
            }}
          >
            <strong>Bold text</strong>, <em>italic text</em>, and{" "}
            <span style={{ textDecoration: "underline" }}>underlined text</span>{" "}
            should all remain readable.
          </p>
        </div>
      </div>

      {/* === AESTHETIC MODIFIERS — Liquid Glass only === */}
      {newStyles.interfaceEra === "glass" && (
        <>
          <h3>Aesthetic Modifiers</h3>

          <div className="form-group">
            <label>Glass Opacity ({Math.round((newStyles.glassBgOpacity ?? 1) * 100)}%):</label>
            <input
              type="range"
              min="0.05"
              max="1.0"
              step="0.05"
              value={newStyles.glassBgOpacity ?? 1}
              onChange={(e) => handleChange("glassBgOpacity", parseFloat(e.target.value))}
            />
          </div>

          <div className="form-group">
            <label>Blur Radius ({(newStyles.glassBlurRadius || 0)}px):</label>
            <input
              type="range"
              min="0"
              max="30"
              step="1"
              value={newStyles.glassBlurRadius || 0}
              onChange={(e) => handleChange("glassBlurRadius", parseInt(e.target.value))}
            />
          </div>

          <div className="form-group">
            <label>Border Reflection:</label>
            <input
              type="range"
              min="0"
              max="0.4"
              step="0.05"
              value={newStyles.glassBorderReflection || 0}
              onChange={(e) => handleChange("glassBorderReflection", parseFloat(e.target.value))}
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
        </>
      )}

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
