import { API_BASE } from "../config";

async function request(url, options = {}) {

    const response = await fetch(

        `${API_BASE}${url}`,

        {
            credentials: "include",
            headers: {
                "Content-Type": "application/json",
                ...(options.headers || {})
            },
            ...options
        }

    );

    const data = await response.json().catch(() => ({}));

    if (!response.ok) {

        let message = "Something went wrong.";

        if (data.message) {
            message = data.message;
        }
        else if (Array.isArray(data.errors)) {
            message = data.errors.join(", ");
        }
        else if (typeof data.errors === "string") {
            message = data.errors;
        }
        else if (data.errors && typeof data.errors === "object") {
            message = Object.values(data.errors).flat().join(", ");
        }

        throw new Error(message);
    }

    return data;

}

export function login(data) {

    return request("/auth/login", {

        method: "POST",

        body: JSON.stringify(data)

    });

}

export function register(data) {

    return request("/auth/register", {

        method: "POST",

        body: JSON.stringify(data)

    });

}

export function forgotPassword(data) {

    return request("/auth/forgot-password", {

        method: "POST",

        body: JSON.stringify(data)

    });

}

export function resetPassword(data) {

    return request("/auth/reset-password", {

        method: "POST",

        body: JSON.stringify(data)

    });

}

export function currentUser() {

    return request("/auth/me");

}

export function logout() {

    return request("/auth/logout", {

        method: "POST"

    });

}