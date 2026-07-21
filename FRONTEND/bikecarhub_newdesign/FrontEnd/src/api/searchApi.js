import { API_BASE } from "../config";

export async function searchVehicles(term) {

    if (!term.trim()) return [];

    const response = await fetch(
        `${API_BASE}/search?term=${encodeURIComponent(term)}`
    );

    if (!response.ok)
        throw new Error("Search failed");

    return response.json();
}

export async function getVehicleDetails(name) {

    const response = await fetch(
        `${API_BASE}/search/details?name=${encodeURIComponent(name)}`
    );

    if (!response.ok)
        throw new Error("Vehicle not found");

    return response.json();
}
