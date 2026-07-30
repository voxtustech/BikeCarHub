
import { API_BASE } from "../config";
import { getBrands } from "./brandApi";
import { getModels } from "./modelApi";

/**
 * Returns all brands.
 */
export async function fetchBrands() {
    return await getBrands();
}

/**
 * Returns all models for a selected brand.
 */
export async function fetchModels(brand) {
    if (!brand) return [];

    return await getModels(brand);
}

/**
 * Returns all variants for a selected bike.
 */
export async function fetchVariants(bikeId) {

    if (!bikeId)
        return [];

    const response = await fetch(
        `${API_BASE}/search/variants/${bikeId}`
    );

    if (!response.ok)
        throw new Error("Failed to load variants.");

    return await response.json();
}

export async function fetchBikeForCompare(bikeId) {

    const response = await fetch(
        `${API_BASE}/compare/bike/${bikeId}`,
        {
            credentials: "include",
        }
    );

    if (!response.ok) {
        throw new Error("Failed to load bike details.");
    }

    return await response.json();

}
/**
 * Loads everything required for the selector.
 */
export async function loadSelectorData(brand, bikeId) {

    const [brands, models, variants] = await Promise.all([
        fetchBrands(),
        brand ? fetchModels(brand) : Promise.resolve([]),
        bikeId ? fetchVariants(bikeId) : Promise.resolve([])
    ]);

    return {
        brands,
        models,
        variants
    };
}