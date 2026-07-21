import { API_BASE } from "../config";

export async function getBlogs() {
    const response = await fetch(`${API_BASE}/blogs`);

    if (!response.ok) {
        throw new Error("Failed to fetch blogs");
    }

    return response.json();
}

export async function getBlogBySlug(slug) {

    const response = await fetch(`${API_BASE}/blogs/slug/${slug}`);

    if (!response.ok)
        throw new Error("Blog not found");

    return response.json();

}