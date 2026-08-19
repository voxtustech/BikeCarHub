import {
    Heart,
    Share2,
    GitCompare,
    Download,
    Calendar,
    Star,
    IndianRupee,
    X
} from "lucide-react";

import { useEffect, useState } from "react";
import { useNavigate, useLocation } from "react-router-dom";

import {
    addToWishlist,
    removeFromWishlist,
    checkWishlist
} from "../../api/wishlistApi";
import {
    submitReview,
    getBikeReviews
} from "../../api/reviewApi";
export default function BikeHero({ bike }) {

    const navigate = useNavigate();
    const location = useLocation();

    const [isWishlisted, setIsWishlisted] = useState(false);
    const [loadingWishlist, setLoadingWishlist] = useState(false);
    const [showLoginModal, setShowLoginModal] = useState(false);
    const [showReviewModal, setShowReviewModal] = useState(false);
    const [reviewRating, setReviewRating] = useState(0);
    const [reviewText, setReviewText] = useState("");
    const [submittingReview, setSubmittingReview] = useState(false);
    const [averageRating, setAverageRating] = useState(0);
    const [reviewCount, setReviewCount] = useState(0);

    const handleCompare = () => {

        navigate(
            `/compare?bike1=${bike.id}&variant1=${bike.defaultVariantId}`
        );

    };

    const handleShare = async () => {
        if (navigator.share) {
            await navigator.share({
                title: bike.name,
                text: `Check out ${bike.name} on BikeCarHub`,
                url: window.location.href,
            });
        } else {
            await navigator.clipboard.writeText(window.location.href);
            alert("Link copied to clipboard.");
        }
    };

    const handleCalculateEMI = () => {

        navigate("/emi-calculator", {
            state: {
                bikeName: bike.name,
                bikePrice: bike.basePrice ?? bike.price
            }
        });

    };

    useEffect(() => {

        if (!bike?.id)
            return;

        async function loadWishlist() {

            try {

                const result = await checkWishlist(bike.id);

                setIsWishlisted(result.isWishlisted);

            }

            catch {

                // user not logged in

            }

        }

        loadWishlist();

    }, [bike]);
    useEffect(() => {

        if (!bike?.id) {
            return;
        }


        async function loadReviews() {

            try {

                const data =
                    await getBikeReviews(bike.id);


                setAverageRating(
                    data.averageRating || 0
                );


                setReviewCount(
                    data.reviewCount || 0
                );

            }
            catch (err) {

                console.error(
                    "Failed to load reviews:",
                    err
                );

            }

        }


        loadReviews();

    }, [bike?.id]);

    async function toggleWishlist() {

        if (loadingWishlist)
            return;

        setLoadingWishlist(true);

        try {

            if (isWishlisted) {

                await removeFromWishlist(bike.id);

                setIsWishlisted(false);

            }

            else {

                await addToWishlist(bike.id);

                setIsWishlisted(true);

            }

        }

        catch (err) {

            if (err.status === 401) {
                setShowLoginModal(true);
            }

            else {

                console.error(err);

            }

        }

        finally {

            setLoadingWishlist(false);

        }

    }
    async function handleSubmitReview() {

        if (reviewRating === 0) {

            alert("Please select a rating.");

            return;
        }


        if (
            !reviewText.trim() ||
            reviewText.trim().length < 10
        ) {

            alert(
                "Review must be at least 10 characters."
            );

            return;
        }


        try {

            setSubmittingReview(true);


            const result =
                await submitReview(
                    bike.id,
                    reviewRating,
                    reviewText
                );


            alert(result.message);


            // Close modal
            setShowReviewModal(false);


            // Reset form
            setReviewRating(0);

            setReviewText("");


            // Reload rating
            const updatedReviews =
                await getBikeReviews(bike.id);


            setAverageRating(
                updatedReviews.averageRating || 0
            );


            setReviewCount(
                updatedReviews.reviewCount || 0
            );

        }
        catch (err) {

            console.error(
                "Review submission failed:",
                err
            );


            if (err.status === 401) {

                setShowReviewModal(false);

                setShowLoginModal(true);

                return;
            }


            alert(
                err.message ||
                "Unable to submit review."
            );

        }
        finally {

            setSubmittingReview(false);

        }
    }

    if (!bike) return null;

    return (

        <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-8 flex flex-col h-full">

            {/* Bike Type */}

            <div className="flex items-center gap-2 mb-3">

                <span className="px-3 py-1 rounded-full bg-blue-100 text-blue-700 text-xs font-semibold">

                    {bike.type}

                </span>

                {bike.isEV && (

                    <span className="px-3 py-1 rounded-full bg-green-100 text-green-700 text-xs font-semibold">

                        Electric

                    </span>

                )}

            </div>

            {/* Name */}

            <h1 className="text-4xl font-bold text-slate-900 leading-tight">

                {bike.name}

            </h1>

            {/* Rating */}
            <div className="flex items-center gap-3 mt-4 flex-wrap">

                {/* Rating */}
                <div className="flex items-center gap-1">

                    {[1, 2, 3, 4, 5].map(i => (

                        <Star
                            key={i}
                            size={18}
                            className="fill-yellow-400 text-yellow-400"
                        />

                    ))}

                </div>

                <span className="font-semibold">
                    {averageRating.toFixed(1)}
                </span>

                <span className="text-slate-500">
                    ({reviewCount} Reviews)
                </span>

                {/* Write Review */}
                <button
                    onClick={() => setShowReviewModal(true)}
                    className="ml-2 text-blue-700 font-semibold hover:text-blue-800 hover:underline"
                >
                    Write a Review
                </button>

            </div>
            
            {/* Price */}

            <div className="mt-6">

                <p className="text-slate-500 text-sm">

                    Ex-Showroom Price

                </p>

                <h2 className="text-3xl font-bold text-blue-700 mt-1">

                    {bike.price}

                </h2>

            </div>

            {/* Launch */}

            <div className="mt-6 flex items-center gap-3">

                <Calendar size={18} />

                <span className="text-slate-700">

                    Launched on {bike.launchDate}

                </span>

            </div>

            {/* Description */}

            {bike.description && bike.description !== "" && (

                <p className="mt-6 text-slate-600 leading-7">

                    {bike.description}

                </p>

            )}

            {/* Buttons */}

            <div className="grid grid-cols-2 gap-3 mt-8">

                <button
                    onClick={toggleWishlist}
                    disabled={loadingWishlist}
                    className="flex items-center justify-center gap-2 rounded-xl border border-slate-300 py-3 hover:bg-slate-50 transition"
                >

                    <Heart
                        size={18}
                        className={
                            isWishlisted
                                ? "fill-red-500 text-red-500"
                                : ""
                        }
                    />

                    {loadingWishlist ? "Please wait..." : "Wishlist"}

                </button>

                <button className="flex items-center justify-center gap-2 rounded-xl border border-slate-300 py-3 hover:bg-slate-50 transition"
                        onClick={handleCompare}
                >

                    <GitCompare size={18} />

                    Compare

                </button>
                <button
                    className="flex items-center justify-center gap-2 rounded-xl border border-slate-300 py-3 hover:bg-slate-50 transition"
                    onClick={handleShare}
                >
                    <Share2 size={18} />
                    Share
                </button>

                <button
                    className="flex items-center justify-center gap-2 rounded-xl border border-slate-300 py-3 hover:bg-slate-50 transition"
                >
                    <Download size={18} />
                    Brochure
                </button>

            </div>

            {/* EMI */}

            <div className="mt-8 rounded-2xl bg-slate-50 border border-slate-200 p-5">

                <div className="flex justify-between items-center">

                    <div>

                        <p className="text-slate-500 text-sm">

                            EMI Starts From

                        </p>

                        <h3 className="text-2xl font-bold mt-1">

                            ₹3,250/month

                        </h3>

                    </div>

                    <button
                        onClick={handleCalculateEMI}
                        className="bg-blue-700 text-white px-5 py-3 rounded-xl hover:bg-blue-800 transition"
                    >
                        Calculate EMI
                    </button>

                </div>

            </div>

            {/* Highlights */}

            <div className="grid grid-cols-2 gap-4 mt-8">

                <div className="rounded-xl bg-slate-50 border p-4">

                    <p className="text-sm text-slate-500">

                        Starting Price

                    </p>

                    <div className="flex items-center gap-1 mt-2">

                        <IndianRupee size={18} />

                        <span className="font-semibold">

                            {bike.basePrice?.toLocaleString()}

                        </span>

                    </div>

                </div>

                <div className="rounded-xl bg-slate-50 border p-4">

                    <p className="text-sm text-slate-500">

                        Top Variant

                    </p>

                    <div className="flex items-center gap-1 mt-2">

                        <IndianRupee size={18} />

                        <span className="font-semibold">

                            {bike.topPrice?.toLocaleString()}

                        </span>

                    </div>

                </div>

            </div>

            {
                showReviewModal && (

                    <div className="fixed inset-0 z-50 bg-black/50 flex items-center justify-center px-4">

                        <div className="bg-white rounded-2xl shadow-xl w-full max-w-lg p-6">

                            {/* Header */}

                            <div className="flex justify-between items-center">

                                <h2 className="text-xl font-bold text-slate-900">
                                    Write a Review
                                </h2>

                                <button
                                    onClick={() => {
                                        setShowReviewModal(false);
                                        setReviewRating(0);
                                        setReviewText("");
                                    }}
                                    className="text-slate-500 hover:text-slate-800"
                                >
                                    <X size={22} />
                                </button>

                            </div>


                            {/* Bike name */}

                            <p className="text-slate-500 mt-2">
                                Review for {bike.name}
                            </p>


                            {/* Rating */}

                            <div className="mt-6">

                                <p className="font-semibold text-slate-800 mb-3">
                                    Your Rating
                                </p>

                                <div className="flex gap-2">

                                    {[1, 2, 3, 4, 5].map((star) => (

                                        <button
                                            key={star}
                                            type="button"
                                            onClick={() =>
                                                setReviewRating(star)
                                            }
                                            className="transition-transform hover:scale-110"
                                        >

                                            <Star
                                                size={32}
                                                className={
                                                    star <= reviewRating
                                                        ? "fill-yellow-400 text-yellow-400"
                                                        : "text-slate-300"
                                                }
                                            />

                                        </button>

                                    ))}

                                </div>

                                {reviewRating > 0 && (

                                    <p className="text-sm text-slate-500 mt-2">

                                        {reviewRating === 1 && "Poor"}

                                        {reviewRating === 2 && "Below Average"}

                                        {reviewRating === 3 && "Average"}

                                        {reviewRating === 4 && "Good"}

                                        {reviewRating === 5 && "Excellent"}

                                    </p>

                                )}

                            </div>


                            {/* Review textbox */}

                            <div className="mt-6">

                                <label
                                    className="block font-semibold text-slate-800 mb-2"
                                >
                                    Write your review
                                </label>

                                <textarea
                                    value={reviewText}
                                    onChange={(e) =>
                                        setReviewText(e.target.value)
                                    }
                                    placeholder="Tell us about your experience with this bike..."
                                    rows={5}
                                    maxLength={1000}
                                    className="w-full border border-slate-300 rounded-xl p-3 outline-none resize-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
                                />

                                <div className="text-right text-sm text-slate-400 mt-1">

                                    {reviewText.length}/1000

                                </div>

                            </div>


                            {/* Buttons */}

                            <div className="flex justify-end gap-3 mt-6">

                                <button
                                    type="button"
                                    onClick={() => {
                                        setShowReviewModal(false);
                                        setReviewRating(0);
                                        setReviewText("");
                                    }}
                                    className="px-5 py-2.5 rounded-lg border border-slate-300 hover:bg-slate-50"
                                >
                                    Cancel
                                </button>


                                <button
                                    type="button"
                                    onClick={handleSubmitReview}
                                    disabled={submittingReview}
                                    className="px-5 py-2.5 rounded-lg bg-blue-700 text-white hover:bg-blue-800 disabled:opacity-50"
                                >

                                    {submittingReview
                                        ? "Submitting..."
                                        : "Submit Review"}

                                </button>

                            </div>

                        </div>

                    </div>

                )
            }

            {
                showLoginModal && (

                    <div className="fixed inset-0 z-50 bg-black/50 flex items-center justify-center">

                        <div className="bg-white rounded-2xl shadow-xl w-full max-w-md p-6">

                            <div className="flex justify-between items-center">

                                <h2 className="text-xl font-bold">

                                    Login Required

                                </h2>

                                <button
                                    onClick={() => setShowLoginModal(false)}
                                >
                                    <X size={20} />
                                </button>

                            </div>

                            <p className="text-slate-600 mt-4">

                                You need to login before you can add bikes to your wishlist.

                            </p>

                            <div className="flex justify-end gap-3 mt-8">

                                <button
                                    onClick={() => setShowLoginModal(false)}
                                    className="px-5 py-2 rounded-lg border"
                                >
                                    Cancel
                                </button>

                                <button
                                    onClick={() => {

                                        navigate(
                                            `/login?returnUrl=${encodeURIComponent(location.pathname)}`
                                        );

                                    }}
                                    className="px-5 py-2 rounded-lg bg-blue-700 text-white"
                                >
                                    Login to Wishlist
                                </button>

                            </div>

                        </div>

                    </div>

                )
            }

        </div>

    );

}