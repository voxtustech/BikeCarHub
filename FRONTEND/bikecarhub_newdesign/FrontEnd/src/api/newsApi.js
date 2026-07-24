import { API_BASE } from "../config";

export async function getLatestNews() {
    const response = await fetch(`${API_BASE}/latest-news`);

    if (!response.ok) {
        throw new Error("Failed to fetch latest news");
    }

    return response.json();
}