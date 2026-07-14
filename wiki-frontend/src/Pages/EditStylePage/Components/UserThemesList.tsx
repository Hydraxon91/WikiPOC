import { useState } from "react";
import { useStyleContext } from "../../../Components/contexts/StyleContext";
import { deleteUserTheme } from "../../../Api/wikiApi";
import { useNotification } from "../../../Components/NotificationProvider";
import type { StyleModel } from "../../../types/models";

const UserThemesList = ({ jwtToken, onLoad }: { jwtToken: string; onLoad?: (theme: StyleModel) => void }) => {
  const { userThemes, refreshUserThemes, loadTheme } = useStyleContext();
  const { showNotification } = useNotification();
  const [deleting, setDeleting] = useState<number | null>(null);

  const handleDelete = async (id: number) => {
    if (!confirm("Delete this custom theme?")) return;
    setDeleting(id);
    try {
      await deleteUserTheme(id, jwtToken);
      refreshUserThemes();
      showNotification("Theme deleted");
    } catch {
      showNotification("Failed to delete theme");
    } finally {
      setDeleting(null);
    }
  };

  if (userThemes.length === 0) {
    return (
      <div style={{ opacity: 0.6, fontStyle: "italic", padding: "1em 0" }}>
        No custom themes yet. Adjust the controls and click "Save as Custom Theme".
      </div>
    );
  }

  return (
    <div>
      <h3>My Custom Themes</h3>
      {userThemes.map((theme) => (
        <div
          key={theme.id}
          style={{
            display: "flex",
            alignItems: "center",
            gap: "0.75em",
            padding: "0.6em 0.8em",
            marginBottom: "0.5em",
            borderRadius: 6,
            background: "rgba(255,255,255,0.06)",
          }}
        >
          <div
            style={{
              width: 12,
              height: 12,
              borderRadius: "50%",
              background: theme.bodyColor || "#ccc",
              border: "1px solid rgba(255,255,255,0.2)",
            }}
          />
          <span style={{ flex: 1, fontWeight: 500 }}>
            {theme.themeName || theme.interfaceEra || "Untitled"}
          </span>
          <span
            style={{
              fontSize: "0.75em",
              padding: "0.15em 0.5em",
              borderRadius: 4,
              background: "rgba(255,255,255,0.08)",
            }}
          >
            {theme.interfaceEra}
          </span>
          <button
            onClick={() => (onLoad || loadTheme)(theme)}
            style={{
              background: "rgba(255,255,255,0.12)",
              border: "1px solid rgba(255,255,255,0.15)",
              borderRadius: 4,
              color: "#fff",
              padding: "0.3em 0.8em",
              cursor: "pointer",
              fontSize: "0.8em",
            }}
          >
            Load
          </button>
          <button
            onClick={() => handleDelete(theme.id!)}
            disabled={deleting === theme.id}
            style={{
              background: "rgba(255,60,60,0.2)",
              border: "1px solid rgba(255,60,60,0.3)",
              borderRadius: 4,
              color: "#ff6b6b",
              padding: "0.3em 0.8em",
              cursor: "pointer",
              fontSize: "0.8em",
            }}
          >
            {deleting === theme.id ? "..." : "Delete"}
          </button>
        </div>
      ))}
    </div>
  );
};

export default UserThemesList;
