import { API_BASE } from "../config";

export async function getCompareCards() {

    const response = await fetch(`${API_BASE}/compare`);

    if (!response.ok) {
        throw new Error("Failed to load compare cards");
    }

    return await response.json();
}