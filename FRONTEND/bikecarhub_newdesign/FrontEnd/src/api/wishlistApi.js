import { API_BASE } from "../config";

async function handleResponse(response) {
    let data = {};

    try {
        data = await response.json();
    } catch { }

    if (!response.ok) {
        const error = new Error(data.message || "Something went wrong.");
        error.status = response.status;
        throw error;
    }

    return data;
}

export async function getWishlist() {

    const response = await fetch(
        `${API_BASE}/wishlist`,
        {
            credentials: "include",
        }
    );

    return handleResponse(response);
}

export async function checkWishlist(bikeId) {

    const response = await fetch(
        `${API_BASE}/wishlist/check/${bikeId}`,
        {
            credentials: "include",
        }
    );

    return handleResponse(response);
}

export async function addToWishlist(bikeId) {

    const response = await fetch(
        `${API_BASE}/wishlist/${bikeId}`,
        {
            method: "POST",
            credentials: "include",
        }
    );

    return handleResponse(response);
}

export async function removeFromWishlist(bikeId) {

    const response = await fetch(
        `${API_BASE}/wishlist/${bikeId}`,
        {
            method: "DELETE",
            credentials: "include",
        }
    );

    return handleResponse(response);
}