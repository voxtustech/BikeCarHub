import { API_BASE } from "../config";

export async function sendContactMessage(data) {

    const response = await fetch(`${API_BASE}/contact`, {
        method: "POST",
        credentials: "include",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            name: data.name,
            phoneNo: data.phoneNo,
            email: data.email,
            message: data.message,
        }),
    });

    const text = await response.text();

    console.log("Status:", response.status);
    console.log("Response:", text);

    const result = text ? JSON.parse(text) : {};

    if (!response.ok) {
        throw new Error(result.message || "Request failed.");
    }

    return result;
}