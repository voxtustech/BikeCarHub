import { API_BASE } from "../config";

export async function getBikeDetails(brandName, bikeName) {

    const response = await fetch(
        `${API_BASE}/bikes/details/${brandName}/${bikeName}`
    );

    if (!response.ok)
        throw new Error("Failed to load bike.");

    return response.json();
}