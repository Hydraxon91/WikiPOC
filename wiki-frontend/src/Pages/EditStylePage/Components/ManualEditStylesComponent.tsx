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

const hexToRgb = (hex: string): [number, number, number] | null => {
  if (!hex) return null;
  const cleaned = hex.replace('#', '').trim();
  if (cleaned.length !== 3 && cleaned.length !== 6) return null;
  const full = cleaned.length === 3
    ? cleaned.split('').map((c) => c + c).join('')
    : cleaned;
  const m = /^([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(full);
  if (!m) return null;
  return [parseInt(m[1], 16), parseInt(m[2], 16), parseInt(m[3], 16)];
};

const lum = (rgb: [number, number, number]) => {
  const [r, g, b] = rgb.map((v) => {
    const c = v / 255;
    return c <= 0.03928 ? c / 12.92 : Math.pow((c + 0.055) / 1.055, 2.4);
  });
  return 0.2126 * r + 0.7152 * g + 0.0722 * b;
};

const isLight = (rgb: [number, number, number]) => lum(rgb) > 0.5;

const contrastRatio = (a: string, b: string): number => {
  const rgbA = hexToRgb(a);
  const rgbB = hexToRgb(b);
  if (!rgbA || !rgbB) return 1;
  const l1 = lum(rgbA);
  const l2 = lum(rgbB);
  const lighter = Math.max(l1, l2);
  const darker = Math.min(l1, l2);
  return (lighter + 0.05) / (darker + 0.05);
};

const contrastBadge = (ratio: number): { label: string; color: string } => {
  if (ratio >= 7) return { label: "AAA", color: "#22c55e" };
  if (ratio >= 4.5) return { label: "AA", color: "#84cc16" };
  if (ratio >= 3) return { label: "AA Large", color: "#eab308" };
  return { label: "Fail", color: "#ef4444" };
};

const suggestText = (body: string): string => {
  const rgb = body ? hexToRgb(body) : null;
  return rgb ? (isLight(rgb) ? "#1a1a1a" : "#f5f5f5") : "#202122";
};

const suggestLink = (body: string, textColor: string): string => {
  const rgb = body ? hexToRgb(body) : null;
  if (!rgb) return textColor === "#f5f5f5" ? "#7cb9ff" : "#1d4ed8";
  return isLight(rgb) ? "#0d3fc4" : "#82b6ff";
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
        See how your text reads against the current body and sidebar. The smart
        contrast suggestion adapts to your background automatically.
      </p>
      {(() => {
        const textCol = newStyles.footerListTextColor || "#202122";
        const linkCol = newStyles.footerListLinkTextColor || "#0645ad";
        const bodyCol = newStyles.bodyColor || "#f8f9fa";
        const sidebarCol = newStyles.articleRightColor || "#f8f9fa";
        const suggText = suggestText(bodyCol);
        const suggLink = suggestLink(bodyCol, suggText);
        const curRatio = contrastRatio(textCol, bodyCol);
        const suggRatio = contrastRatio(suggText, bodyCol);
        const linkRatio = contrastRatio(linkCol, bodyCol);
        const suggLinkRatio = contrastRatio(suggLink, bodyCol);
        const cur = contrastBadge(curRatio);
        const sugg = contrastBadge(suggRatio);
        const linkB = contrastBadge(linkRatio);
        const suggLinkB = contrastBadge(suggLinkRatio);
        const Badge = ({ b, ratio }: { b: { label: string; color: string }; ratio: number }) => (
          <span
            style={{
              display: "inline-block",
              padding: "1px 6px",
              borderRadius: 4,
              fontSize: "0.7em",
              fontWeight: 700,
              color: "#fff",
              background: b.color,
              marginLeft: 6,
              verticalAlign: "middle",
            }}
          >
            {b.label} {ratio.toFixed(1)}:1
          </span>
        );
        return (
          <div style={{ marginBottom: "1em" }}>
            <div
              style={{
                background: bodyCol,
                borderRadius: newStyles.borderRadius || "0px",
                border: newStyles.borderStyle || "1px solid #a2a9b1",
                padding: "1.2em",
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
              <div style={{ position: "relative" }}>
                <h2 style={{ color: textCol, fontSize: "1.1em", margin: "0 0 0.3em 0", fontFamily: newStyles.fontFamily }}>
                  Sample Heading
                </h2>
                <h3 style={{ color: textCol, fontSize: "0.9em", margin: "0 0 0.5em 0", fontFamily: newStyles.fontFamily, opacity: 0.85 }}>
                  Smaller Subheading
                </h3>
                <p
                  style={{
                    color: textCol,
                    fontFamily: newStyles.fontFamily,
                    margin: "0 0 1em 0",
                    lineHeight: 1.6,
                    fontSize: "0.9em",
                  }}
                >
                  Sample paragraph at the current text color.{" "}
                  <a href="#" style={{ color: linkCol }}>Here is a link</a>{" "}
                  using the current link color. Try{" "}
                  <strong>bold</strong>, <em>italic</em>, and{" "}
                  <span style={{ textDecoration: "underline" }}>underlined</span>{" "}
                  text — all should remain readable.
                </p>

                <div
                  style={{
                    display: "grid",
                    gridTemplateColumns: "1fr 1fr",
                    gap: "1em",
                    fontSize: "0.78em",
                    marginTop: "0.5em",
                    paddingTop: "0.5em",
                    borderTop: "1px solid rgba(255,255,255,0.15)",
                  }}
                >
                  <div>
                    <strong>Text</strong>{" "}
                    <code style={{ background: "rgba(255,255,255,0.12)", padding: "0 0.4em", borderRadius: 4 }}>
                      {textCol}
                    </code>
                    <Badge b={cur} ratio={curRatio} />
                    {suggText !== textCol && (
                      <button
                        type="button"
                        onClick={() => handleChange("footerListTextColor", suggText)}
                        style={{
                          display: "block",
                          marginTop: 4,
                          background: sugg.color,
                          color: "#fff",
                          border: "none",
                          padding: "2px 6px",
                          borderRadius: 4,
                          cursor: "pointer",
                          fontSize: "0.85em",
                          fontWeight: 600,
                        }}
                        title={`Use suggested ${suggText} (${suggRatio.toFixed(1)}:1 ${sugg.label})`}
                      >
                        Use {suggText}
                      </button>
                    )}
                  </div>
                  <div>
                    <strong>Link</strong>{" "}
                    <code style={{ background: "rgba(255,255,255,0.12)", padding: "0 0.4em", borderRadius: 4 }}>
                      {linkCol}
                    </code>
                    <Badge b={linkB} ratio={linkRatio} />
                    {suggLink !== linkCol && (
                      <button
                        type="button"
                        onClick={() => handleChange("footerListLinkTextColor", suggLink)}
                        style={{
                          display: "block",
                          marginTop: 4,
                          background: suggLinkB.color,
                          color: "#fff",
                          border: "none",
                          padding: "2px 6px",
                          borderRadius: 4,
                          cursor: "pointer",
                          fontSize: "0.85em",
                          fontWeight: 600,
                        }}
                        title={`Use suggested ${suggLink} (${suggLinkRatio.toFixed(1)}:1 ${suggLinkB.label})`}
                      >
                        Use {suggLink}
                      </button>
                    )}
                  </div>
                  {(suggText !== textCol || suggLink !== linkCol) && (
                    <div style={{ gridColumn: "1 / -1" }}>
                      <button
                        type="button"
                        onClick={() => {
                          handleChange("footerListTextColor", suggText);
                          handleChange("footerListLinkTextColor", suggLink);
                        }}
                        style={{
                          background: "rgba(255,255,255,0.15)",
                          color: textCol,
                          border: "1px solid rgba(255,255,255,0.2)",
                          padding: "3px 10px",
                          borderRadius: 4,
                          cursor: "pointer",
                          fontSize: "0.8em",
                          width: "100%",
                        }}
                      >
                        Reset both to recommended defaults
                      </button>
                    </div>
                  )}
                </div>
              </div>
            </div>

            <div
              style={{
                marginTop: "0.5em",
                padding: "0.7em 1em",
                background: sidebarCol,
                borderRadius: newStyles.borderRadius || "0px",
                border: newStyles.borderStyle || "1px solid #a2a9b1",
                fontSize: "0.78em",
                display: "flex",
                gap: "1em",
                alignItems: "center",
              }}
            >
              <span style={{ color: textCol, fontFamily: newStyles.fontFamily, fontWeight: 600 }}>
                Sidebar Preview
              </span>
              <a href="#" style={{ color: linkCol, fontFamily: newStyles.fontFamily }}>
                Sample Link
              </a>
            </div>
          </div>
        );
      })()}

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

      {/* === GLOW & BUBBLE CONFIG === */}
      <h3>Glow & Bubbles</h3>

      <div className="form-group">
        <label>Glass Glow Intensity ({Math.round((newStyles.glassGlowIntensity ?? 0) * 100)}%):</label>
        <input
          type="range"
          min="0"
          max="1.0"
          step="0.05"
          value={newStyles.glassGlowIntensity ?? 0}
          onChange={(e) => handleChange("glassGlowIntensity", parseFloat(e.target.value))}
        />
      </div>

      {(newStyles.interfaceEra === 'glass' || newStyles.interfaceEra === 'frutiger') && (
        <>
          <div className="form-group">
            <label>Bubble Count (Desktop — {newStyles.bubbleCountDesktop ?? 0}):</label>
            <input
              type="range"
              min="0"
              max="40"
              step="2"
              value={newStyles.bubbleCountDesktop ?? 0}
              onChange={(e) => {
                const raw = parseInt(e.target.value, 10);
                handleChange("bubbleCountDesktop", Math.round(raw / 2) * 2);
              }}
            />
          </div>

          <div className="form-group">
            <label>Bubble Count (Mobile — {newStyles.bubbleCountMobile ?? 0}):</label>
            <input
              type="range"
              min="0"
              max="20"
              step="2"
              value={newStyles.bubbleCountMobile ?? 0}
              onChange={(e) => {
                const raw = parseInt(e.target.value, 10);
                handleChange("bubbleCountMobile", Math.round(raw / 2) * 2);
              }}
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
