import { API_BASE } from "../config";

//export async function getLatestNews() {
//    const response = await fetch(`${API_BASE}/latest-news`);

//    if (!response.ok) {
//        throw new Error("Failed to fetch latest news");
//    }

//    return response.json();
//}
// ============================================
// Get latest news
// ============================================

export async function getLatestNews() {

    const response = await fetch(
        `${API_BASE}/latest-news`
    );

    if (!response.ok) {

        throw new Error(
            "Failed to load latest news."
        );

    }

    return await response.json();
}


// ============================================
// Get one news article
// ============================================

export async function getLatestNewsById(id) {

    const response = await fetch(
        `${API_BASE}/latest-news/${id}`
    );

    if (!response.ok) {

        throw new Error(
            "Failed to load news article."
        );

    }

    return await response.json();
}

export async function getLatestNewsBySlug(slug) {

    if (!slug) {

        throw new Error(
            "Latest news slug is missing."
        );

    }

    const encodedSlug =
        encodeURIComponent(slug);

    console.log(
        "Getting latest news by slug:",
        encodedSlug
    );

    const response = await fetch(
        `${API_BASE}/latest-news/${encodedSlug}`
    );

    if (!response.ok) {

        throw new Error(
            "Failed to load news article."
        );

    }

    return await response.json();

}