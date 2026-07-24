export function slugify(text) {
    return text
        .toLowerCase()
        .trim()
        .replace(/&/g, "and")
        .replace(/\s+/g, "-")
        .replace(/[^\w-]+/g, "")
        .replace(/--+/g, "-");
}