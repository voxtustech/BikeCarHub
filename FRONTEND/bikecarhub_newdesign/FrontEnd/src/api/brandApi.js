import { API_BASE } from "../config";

/* --------------------------------------------
   Existing API
-------------------------------------------- */

export async function getBrands() {

    const response = await fetch(`${API_BASE}/brands`);

    if (!response.ok) {
        throw new Error("Failed to fetch brands");
    }

    return response.json();
}

/* --------------------------------------------
   Brand Details
-------------------------------------------- */

export async function getBrand(brandId) {

    const response = await fetch(
        `${API_BASE}/brands/${brandId}`
    );

    if (!response.ok) {
        throw new Error("Failed to fetch brand.");
    }

    return response.json();
}

/* --------------------------------------------
   Bikes By Brand
-------------------------------------------- */

export async function getBrandBikes(brandId) {

    const response = await fetch(
        `${API_BASE}/brands/${brandId}/bikes`
    );

    if (!response.ok) {
        throw new Error("Failed to fetch brand bikes.");
    }

    return response.json();
}

/* --------------------------------------------
   Sidebar Brands
-------------------------------------------- */

export async function getPopularBrands() {

    const response = await fetch(
        `${API_BASE}/brands/popular`
    );

    if (!response.ok) {
        throw new Error("Failed to fetch popular brands.");
    }

    return response.json();
}