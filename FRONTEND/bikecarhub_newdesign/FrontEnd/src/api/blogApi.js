import { API_BASE } from "../config";


// =========================================================
// GET ALL BLOGS
// =========================================================

export async function getBlogs() {

    const response = await fetch(
        `${API_BASE}/blogs`
    );


    if (!response.ok) {

        throw new Error(
            "Failed to load blogs."
        );

    }


    return await response.json();
}

export async function getLatestBlogs() {
    const response = await fetch(`${API_BASE}/blogs/latest`);

    if (!response.ok) {
        throw new Error("Failed to fetch latest blogs");
    }

    return await response.json();
}


// =========================================================
// GET BLOG BY SLUG
// =========================================================

export async function getBlogBySlug(slug) {

    if (!slug) {

        throw new Error(
            "Blog slug is required."
        );

    }


    console.log(
        "Fetching blog:",
        slug
    );


    const response = await fetch(
        `${API_BASE}/blogs/${encodeURIComponent(slug)}`
    );


    if (!response.ok) {

        throw new Error(
            `Failed to load blog article. Status: ${response.status}`
        );

    }


    return await response.json();
}