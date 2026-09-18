import { API_BASE } from "../config";

export async function getHeroSlides() {
    const response = await fetch(`${API_BASE}/hero`);

    if (!response.ok) {
        throw new Error("Failed to load hero slides");
    }

    return await response.json();
}