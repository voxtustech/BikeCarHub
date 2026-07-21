import { API_BASE } from "../config";

export async function getBikeDetails(id) {

    const response = await fetch(`${API_BASE}/bikes/details/${id}`);

    if (!response.ok)
        throw new Error("Failed to load bike.");

    return response.json();

}