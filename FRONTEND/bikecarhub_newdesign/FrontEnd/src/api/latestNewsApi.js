
import { API_BASE } from "../config";


export async function getLatestNewsArticles() {

    const response = await fetch(`${API_BASE}/latest-news`);

    if (!response.ok) {

        throw new Error("Failed to load Latest News articles.");

    }

    return await response.json();

}

// ======================================================
// Get one article
// ======================================================

export async function getLatestNewsDetails(slug) {

    const response = await fetch(

        `${API_BASE}/latest-news/${slug}`

    );

    if (!response.ok) {

        throw new Error("Failed to load article.");

    }

    return await response.json();

}

// ======================================================
// Related Articles
// ======================================================

export async function getRelatedLatestNewsArticles(slug) {

    const response = await fetch(

        `${API_BASE}/latest-news/related/${slug}`

    );

    if (!response.ok) {

        throw new Error("Failed to load related articles.");

    }

    return await response.json();

}