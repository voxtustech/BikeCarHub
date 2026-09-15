import { API_BASE } from "../config";

export async function sendContactMessage(data) {
    const response = await fetch(`${API_BASE}/contact`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        credentials: "include",
        body: JSON.stringify(data)
    });

    const result = await response.json();

    if (!response.ok) {
        throw new Error(
            result.message || "Unable to submit your message."
        );
    }

    return result;
}


export async function submitQuestion(data) {
    const response = await fetch(`${API_BASE}/contact/question`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        credentials: "include",
        body: JSON.stringify(data)
    });

    const result = await response.json();

    if (!response.ok) {
        throw new Error(
            result.message || "Unable to submit your question."
        );
    }

    return result;
}