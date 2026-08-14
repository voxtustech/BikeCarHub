import { useEffect, useState } from "react";
import { getWishlist, removeFromWishlist } from "../api/wishlistApi";
import { Trash2 } from "lucide-react";
import "./wishlistpages.css";
import { getImageUrl } from "../config";

export default function WishlistPage() {

    const [wishlist, setWishlist] = useState([]);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    const [deletingId, setDeletingId] = useState(null);
   

    // Load wishlist
    useEffect(() => {

        async function loadWishlist() {

            try {

                setLoading(true);

                const data = await getWishlist();

                console.log("Wishlist data:", data);

                setWishlist(data);

            }
            catch (err) {

                console.error(
                    "Failed to load wishlist:",
                    err
                );

                if (err.status === 401) {

                    setError(
                        "Please login to view your wishlist."
                    );

                }
                else {

                    setError(
                        "Unable to load wishlist."
                    );

                }

            }
            finally {

                setLoading(false);

            }

        }

        loadWishlist();

    }, []);


    // Delete wishlist item
    const handleDelete = async (bikeId) => {

        try {

            setDeletingId(bikeId);

            await removeFromWishlist(bikeId);

            // Remove the card from UI immediately
            setWishlist((currentWishlist) =>
                currentWishlist.filter(
                    (item) =>
                        item.twoWheelerID !== bikeId
                )
            );

        }
        catch (err) {

            console.error(
                "Failed to remove from wishlist:",
                err
            );

            alert("Unable to remove this item from wishlist.");

        }
        finally {

            setDeletingId(null);

        }

    };


    // Loading
    if (loading) {

        return (
            <div className="wishlist-page">

                <h1 className="wishlist-title">
                    My Wishlist
                </h1>

                <p className="wishlist-loading">
                    Loading wishlist...
                </p>

            </div>
        );

    }


    // Error
    if (error) {

        return (
            <div className="wishlist-page">

                <h1 className="wishlist-title">
                    My Wishlist
                </h1>

                <p className="wishlist-error">
                    {error}
                </p>

            </div>
        );

    }


    return (

        <div className="wishlist-page">

            <h1 className="wishlist-title">
                My Wishlist
            </h1>


            {wishlist.length === 0 ? (

                <div className="wishlist-empty">

                    <div className="wishlist-empty-icon">
                        ❤️
                    </div>

                    <h2>
                        Your wishlist is empty
                    </h2>

                    <p>
                        Add your favourite bikes or cars
                        to see them here.
                    </p>

                </div>

            ) : (

                <div className="wishlist-grid">

                    {wishlist.map((item) => {

                        const bike =
                            item.twoWheelers;

                        const bikeId =
                            item.twoWheelerID;
                       

                        return (

                            <div
                                className="wishlist-card"
                                key={bikeId}
                            >

                                {/* Delete button */}
                                <button
                                    className="wishlist-delete-button"
                                    onClick={() =>
                                        handleDelete(bikeId)
                                    }
                                    disabled={
                                        deletingId === bikeId
                                    }
                                    title="Remove from wishlist"
                                >

                                    <Trash2
                                        size={21}
                                        strokeWidth={2.5}
                                    />

                                </button>


                                {/* Bike Image */}
                                <div className="wishlist-image-container">

                                    <img
                                        src={getImageUrl(bike?.twImage)}
                                        alt={bike?.twoWheelerName || "Bike"}
                                        className="wishlist-image"
                                    />

                                </div>


                                {/* Bike Name */}
                                <h2 className="wishlist-bike-name">

                                    {bike?.twoWheelerName ||
                                        "Unknown Bike"}

                                </h2>


                                {/* Price */}
                                <p className="wishlist-bike-price">
                                    {bike?.price || "Price unavailable"}
                                </p>

                            </div>

                        );

                    })}

                </div>

            )}

        </div>

    );

}