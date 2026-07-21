import { API_BASE } from "../config";

// ======================================================
// Get all Upcoming Bikes
// ======================================================

export async function getUpcomingBikeArticles() {

    const response = await fetch(`${API_BASE}/upcoming-bikes`);

    if (!response.ok) {

        throw new Error("Failed to load Upcoming Bike articles.");

    }

    return await response.json();

}

// ======================================================
// Get one article
// ======================================================

export async function getUpcomingBikeDetails(slug) {

    const response = await fetch(

        `${API_BASE}/upcoming-bikes/${slug}`

    );

    if (!response.ok) {

        throw new Error("Failed to load article.");

    }

    return await response.json();

}

// ======================================================
// Related Articles
// ======================================================

export async function getRelatedUpcomingBikeArticles(slug) {

    const response = await fetch(

        `${API_BASE}/upcoming-bikes/related/${slug}`

    );

    if (!response.ok) {

        throw new Error("Failed to load related articles.");

    }

    return await response.json();

}