import { API_BASE } from "../config";

// ======================================================
// Get all Value For Money articles
// ======================================================

export async function getValueForMoneyArticles() {

    const response = await fetch(`${API_BASE}/valueformoney`);

    if (!response.ok) {

        throw new Error("Failed to load Value For Money articles.");

    }

    return await response.json();

}

// ======================================================
// Get one article
// ======================================================

export async function getValueForMoneyDetails(slug) {

    const response = await fetch(

        `${API_BASE}/valueformoney/${slug}`

    );

    if (!response.ok) {

        throw new Error("Failed to load article.");

    }

    return await response.json();

}

// ======================================================
// Related Articles
// ======================================================

export async function getRelatedValueForMoneyArticles(slug) {

    const response = await fetch(

        `${API_BASE}/valueformoney/related/${slug}`

    );

    if (!response.ok) {

        throw new Error("Failed to load related articles.");

    }

    return await response.json();

}