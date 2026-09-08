//export const API_BASE = "https://localhost:7135/api";
//export const BACKEND_URL = "https://localhost:7135";
//export const BACKEND_BASE =API_BASE.replace("/api", "");
//export const API_BASE = "https://api.bikecarhub.com/api";

//export const BACKEND_URL = "https://api.bikecarhub.com";

//export const BACKEND_BASE = "https://api.bikecarhub.com";
export const API_BASE = process.env.REACT_APP_API_BASE;

export const BACKEND_URL = process.env.REACT_APP_BACKEND_URL;

export const BACKEND_BASE = process.env.REACT_APP_BACKEND_BASE;

export function getImageUrl(imagePath) {
    if (!imagePath) return "";

    if (
        imagePath.startsWith("http://") ||
        imagePath.startsWith("https://")
    ) {
        return imagePath;
    }

    if (!imagePath.startsWith("/")) {
        imagePath = "/" + imagePath;
    }

    return `${BACKEND_BASE}${imagePath}`;
}