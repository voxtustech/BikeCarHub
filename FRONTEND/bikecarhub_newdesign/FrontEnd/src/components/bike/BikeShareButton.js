import { Share2 } from "lucide-react";

export default function BikeShareButton() {

    return (

        <button
            className="flex items-center gap-2 px-5 py-3 rounded-xl border"
            onClick={() => navigator.share?.({ url: window.location.href })}
        >

            <Share2 size={18} />

            Share

        </button>

    );

}