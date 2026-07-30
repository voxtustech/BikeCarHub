import { API_BASE } from "../config";

export async function subscribeNewsletter(email) {

    const response = await fetch(
        `${API_BASE}/newsletter`,
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                email,
            }),
        }
    );

    const result = await response.json();

    if (!response.ok) {
        throw new Error(result.message);
    }

    return result;
}