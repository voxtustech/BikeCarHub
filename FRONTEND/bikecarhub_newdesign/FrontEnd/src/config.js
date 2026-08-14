export const API_BASE = "https://localhost:7135/api";
export const BACKEND_URL = "https://localhost:7135";

export const BACKEND_BASE =
    API_BASE.replace("/api", "");

export function getImageUrl(imagePath) {

    if (!imagePath) {
        return "";
    }

    if (
        imagePath.startsWith("http://") ||
        imagePath.startsWith("https://")
    ) {
        return imagePath;
    }

    return `${BACKEND_BASE}${imagePath}`;
}