import { Heart } from "lucide-react";

export default function BikeWishlistButton({ loggedIn }) {

    if (!loggedIn)
        return null;

    return (

        <button className="flex items-center gap-2 px-5 py-3 rounded-xl bg-red-50 hover:bg-red-100">

            <Heart size={18} />

            Wishlist

        </button>

    );

}