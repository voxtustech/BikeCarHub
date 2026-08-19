import { API_BASE } from "../config";


async function handleResponse(response) {

    let data = {};

    try {
        data = await response.json();
    }
    catch {
    }


    if (!response.ok) {

        const error = new Error(
            data.message || "Something went wrong."
        );

        error.status = response.status;

        throw error;
    }


    return data;
}


// Submit / update review
export async function submitReview(
    twoWheelerId,
    rating,
    reviewText
) {

    const response = await fetch(
        `${API_BASE}/reviews`,
        {
            method: "POST",

            credentials: "include",

            headers: {
                "Content-Type": "application/json"
            },

            body: JSON.stringify({
                twoWheelerId,
                rating,
                reviewText
            })
        }
    );


    return handleResponse(response);
}


// Get reviews for a bike
export async function getBikeReviews(
    twoWheelerId
) {

    const response = await fetch(
        `${API_BASE}/reviews/bike/${twoWheelerId}`,
        {
            credentials: "include"
        }
    );


    return handleResponse(response);
}
export async function getMyReviews() {

    const response = await fetch(
        `${API_BASE}/reviews/my`,
        {
            credentials: "include"
        }
    );

    return handleResponse(response);
}
export async function updateReview(
    reviewId,
    rating,
    reviewText
) {

    const response = await fetch(
        `${API_BASE}/reviews/${reviewId}`,
        {
            method: "PUT",

            credentials: "include",

            headers: {
                "Content-Type": "application/json"
            },

            body: JSON.stringify({
                rating,
                reviewText
            })
        }
    );

    return handleResponse(response);
}

export async function deleteReview(reviewId) {

    const response = await fetch(
        `${API_BASE}/reviews/${reviewId}`,
        {
            method: "DELETE",

            credentials: "include"
        }
    );

    return handleResponse(response);
}