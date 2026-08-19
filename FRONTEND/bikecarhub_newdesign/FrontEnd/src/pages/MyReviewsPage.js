import { useEffect, useState } from "react";

import {
    getMyReviews,
    updateReview,
    deleteReview
} from "../api/reviewApi";

import {
    getImageUrl
} from "../config";

import "./MyReviewsPages.css";
export default function MyReviewsPage() {

    const [reviews, setReviews] = useState([]);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    const [editingReview, setEditingReview] = useState(null);

    const [editRating, setEditRating] = useState(0);

    const [editText, setEditText] = useState("");

    const [savingEdit, setSavingEdit] = useState(false);

    const [deletingReview, setDeletingReview] = useState(null);
    function handleEditClick(review) {

        setEditingReview(review);

        setEditRating(review.rating);

        setEditText(review.reviewText);
    } async function handleUpdateReview() {

        if (editRating === 0) {

            alert("Please select a rating.");

            return;
        }

        if (
            !editText.trim() ||
            editText.trim().length < 10
        ) {

            alert(
                "Review must be at least 10 characters."
            );

            return;
        }

        try {

            setSavingEdit(true);

            await updateReview(
                editingReview.reviewId,
                editRating,
                editText
            );

            setEditingReview(null);

            setEditRating(0);

            setEditText("");

            const data = await getMyReviews();

            setReviews(data || []);

            alert("Review updated successfully.");

        }
        catch (err) {

            console.error(
                "Update review failed:",
                err
            );

            alert(
                err.message ||
                "Unable to update review."
            );

        }
        finally {

            setSavingEdit(false);

        }
    }
    async function handleDeleteReview(reviewId) {

        const confirmed = window.confirm(
            "Are you sure you want to delete this review?"
        );

        if (!confirmed) {
            return;
        }

        try {

            setDeletingReview(reviewId);

            await deleteReview(reviewId);

            // Remove immediately from UI
            setReviews(prev =>
                prev.filter(
                    review =>
                        review.reviewId !== reviewId
                )
            );

            alert("Review deleted successfully.");

        }
        catch (err) {

            console.error(
                "Delete review failed:",
                err
            );

            alert(
                err.message ||
                "Unable to delete review."
            );

        }
        finally {

            setDeletingReview(null);

        }
    }
    useEffect(() => {

        async function loadReviews() {

            try {

                setLoading(true);

                const data = await getMyReviews();

                setReviews(data || []);

            }
            catch (err) {

                console.error(
                    "Failed to load reviews:",
                    err
                );

                if (err.status === 401) {

                    setError(
                        "Please login to view your reviews."
                    );

                }
                else {

                    setError(
                        "Unable to load your reviews."
                    );

                }

            }
            finally {

                setLoading(false);

            }

        }


        loadReviews();

    }, []);


    if (loading) {

        return (

            <div className="my-reviews-page">

                <div className="reviews-loading">

                    Loading your reviews...

                </div>

            </div>

        );

    }


    if (error) {

        return (

            <div className="my-reviews-page">

                <div className="reviews-error">

                    {error}

                </div>

            </div>

        );

    }


    return (

        <div className="my-reviews-page">

            <div className="my-reviews-container">


                {/* Header */}

                <div className="my-reviews-header">

                    <div>

                        <h1>
                            My Reviews
                        </h1>

                        <p>
                            Reviews you have shared about bikes.
                        </p>

                    </div>


                    <div className="review-count">

                        {reviews.length}

                        <span>
                            {reviews.length === 1
                                ? " Review"
                                : " Reviews"}
                        </span>

                    </div>

                </div>


                {/* No Reviews */}

                {reviews.length === 0 ? (

                    <div className="no-reviews">

                        <div className="no-reviews-icon">
                            ★
                        </div>

                        <h2>
                            No reviews yet
                        </h2>

                        <p>
                            You haven't reviewed any bikes yet.
                        </p>

                    </div>

                ) : (


                    /* Reviews */

                    <div className="reviews-list">

                        {reviews.map((review) => (

                            <div
                                className="review-card"
                                key={review.reviewId}
                            >


                                {/* Bike image */}

                                <div className="review-bike-image">

                                    {review.image ? (

                                        <img
                                            src={getImageUrl(
                                                review.image
                                            )}
                                            alt={
                                                review.bikeName
                                            }
                                        />

                                    ) : (

                                        <div className="no-image">
                                            No Image
                                        </div>

                                    )}

                                </div>


                                {/* Review content */}

                                <div className="review-content">

                                    <div className="review-top">

                                        <div>

                                            <p className="review-brand">

                                                {review.brand}

                                            </p>

                                            <h2 className="review-bike-name">

                                                {review.bikeName}

                                            </h2>

                                        </div>


                                        <div className="review-date">

                                            {new Date(
                                                review.createdAt
                                            ).toLocaleDateString(
                                                "en-IN",
                                                {
                                                    day: "2-digit",
                                                    month: "short",
                                                    year: "numeric"
                                                }
                                            )}

                                        </div>

                                    </div>


                                    {/* Stars */}

                                    <div className="review-stars">

                                        {[1, 2, 3, 4, 5].map(
                                            (star) => (

                                                <span
                                                    key={star}
                                                    className={
                                                        star <= review.rating
                                                            ? "star active"
                                                            : "star"
                                                    }
                                                >
                                                    ★
                                                </span>

                                            )
                                        )}

                                        <span className="rating-number">

                                            {review.rating}/5

                                        </span>

                                    </div>


                                    {/* Review text */}

                                    <p className="review-text">

                                        {review.reviewText}

                                    </p>
                                    <div className="review-actions">

                                        <button
                                            className="edit-review-btn"
                                            onClick={() =>
                                                handleEditClick(review)
                                            }
                                        >
                                            Edit Review
                                        </button>


                                        <button
                                            className="delete-review-btn"
                                            onClick={() =>
                                                handleDeleteReview(
                                                    review.reviewId
                                                )
                                            }
                                            disabled={
                                                deletingReview === review.reviewId
                                            }
                                        >
                                            {deletingReview === review.reviewId
                                                ? "Deleting..."
                                                : "Delete Review"}
                                        </button>

                                    </div>

                                </div>

                            </div>

                        ))}

                    </div>

                )}

            </div>
            {editingReview && (

                <div className="review-modal-overlay">

                    <div className="review-edit-modal">

                        <div className="review-modal-header">

                            <div>

                                <h2>
                                    Edit Review
                                </h2>

                                <p>
                                    {editingReview.bikeName}
                                </p>

                            </div>


                            <button
                                className="review-modal-close"
                                onClick={() =>
                                    setEditingReview(null)
                                }
                            >
                                ×
                            </button>

                        </div>


                        <div className="edit-rating-section">

                            <label>
                                Your Rating
                            </label>


                            <div className="edit-stars">

                                {[1, 2, 3, 4, 5].map(
                                    star => (

                                        <button
                                            key={star}
                                            type="button"
                                            onClick={() =>
                                                setEditRating(star)
                                            }
                                        >

                                            <span
                                                className={
                                                    star <= editRating
                                                        ? "edit-star active"
                                                        : "edit-star"
                                                }
                                            >
                                                ★
                                            </span>

                                        </button>

                                    )
                                )}

                            </div>

                        </div>


                        <div className="edit-review-field">

                            <label>
                                Your Review
                            </label>

                            <textarea
                                value={editText}
                                onChange={(e) =>
                                    setEditText(
                                        e.target.value
                                    )
                                }
                                rows={6}
                                maxLength={1000}
                                placeholder="Write your review..."
                            />

                            <div className="character-count">

                                {editText.length}/1000

                            </div>

                        </div>


                        <div className="edit-modal-actions">

                            <button
                                className="cancel-edit-btn"
                                onClick={() =>
                                    setEditingReview(null)
                                }
                                disabled={savingEdit}
                            >
                                Cancel
                            </button>


                            <button
                                className="save-edit-btn"
                                onClick={handleUpdateReview}
                                disabled={savingEdit}
                            >
                                {savingEdit
                                    ? "Saving..."
                                    : "Save Changes"}
                            </button>

                        </div>

                    </div>

                </div>

            )}


        </div>

    );

}