import { API_BASE } from "../config";

console.log("✅ modelApi loaded");

export const getModels = async (brand) => {

    const response = await fetch(
        `${API_BASE}/models/${encodeURIComponent(brand)}`
    );

    if (!response.ok) {
        throw new Error("Failed to load models");
    }

    return await response.json();
};