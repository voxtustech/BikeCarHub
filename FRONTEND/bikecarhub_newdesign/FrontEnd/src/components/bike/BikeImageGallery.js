import { useEffect, useState } from "react";
import {
    ChevronLeft,
    ChevronRight,
    Maximize2,
    X
} from "lucide-react";

const API = "http://localhost:5030";
const DEFAULT_IMAGE = `${API}/images/TwoWheeler/default.webp`;

export default function BikeImageGallery({ images = [] }) {

    const [selected, setSelected] = useState(0);
    const [fullscreen, setFullscreen] = useState(false);

    useEffect(() => {
        setSelected(0);
    }, [images]);

    // Create gallery with placeholder if no images exist
    const galleryImages =
        images && images.length > 0
            ? images
            : [
                {
                    imageURL: DEFAULT_IMAGE,
                    color: "Default Image"
                }
            ];

    const current = galleryImages[selected];

    const getImageSrc = (image) => {
        if (!image?.imageURL) return DEFAULT_IMAGE;

        // Absolute URL (Google, CDN, etc.)
        if (image.imageURL.startsWith("http")) {
            return image.imageURL;
        }

        // Relative path from backend
        return `${API}${image.imageURL}`;
    };

    const next = () =>
        setSelected((selected + 1) % galleryImages.length);

    const previous = () =>
        setSelected(
            (selected - 1 + galleryImages.length) %
            galleryImages.length
        );

    return (
        <>
            <div className="bg-white rounded-3xl shadow-sm border overflow-hidden">

                {/* Main Image */}
                <div className="relative bg-slate-50 h-[520px]">

                    <img
                        src={getImageSrc(current)}
                        alt={current?.color || "Bike"}
                        loading="eager"
                        decoding="async"
                        onError={(e) => {
                            e.target.onerror = null;
                            e.target.src = DEFAULT_IMAGE;
                        }}
                        className="w-full h-full object-contain p-6 transition-all duration-300"
                    />

                    {/* Previous */}
                    {galleryImages.length > 1 && (
                        <button
                            onClick={previous}
                            className="absolute left-4 top-1/2 -translate-y-1/2 bg-white rounded-full shadow-md p-3 hover:bg-slate-100"
                        >
                            <ChevronLeft size={20} />
                        </button>
                    )}

                    {/* Next */}
                    {galleryImages.length > 1 && (
                        <button
                            onClick={next}
                            className="absolute right-4 top-1/2 -translate-y-1/2 bg-white rounded-full shadow-md p-3 hover:bg-slate-100"
                        >
                            <ChevronRight size={20} />
                        </button>
                    )}

                    {/* Fullscreen */}
                    <button
                        onClick={() => setFullscreen(true)}
                        className="absolute top-5 right-5 bg-white rounded-xl shadow px-3 py-2 hover:bg-slate-100"
                    >
                        <Maximize2 size={18} />
                    </button>

                    {/* Counter */}
                    <div className="absolute bottom-5 right-5 bg-black/60 text-white px-4 py-2 rounded-full text-sm">
                        {selected + 1} / {galleryImages.length}
                    </div>

                </div>

                {/* Thumbnails */}
                <div className="flex gap-3 overflow-x-auto p-5">

                    {galleryImages.map((img, index) => (

                        <button
                            key={index}
                            onClick={() => setSelected(index)}
                            className={`rounded-xl overflow-hidden border-2 transition ${selected === index
                                    ? "border-blue-600"
                                    : "border-transparent"
                                }`}
                        >

                            <img
                                src={getImageSrc(img)}
                                alt={img.color || "Thumbnail"}
                                loading="lazy"
                                decoding="async"
                                onError={(e) => {
                                    e.target.onerror = null;
                                    e.target.src = DEFAULT_IMAGE;
                                }}
                                className="w-24 h-20 object-cover"
                            />

                        </button>

                    ))}

                </div>

            </div>

            {/* Fullscreen */}

            {fullscreen && (

                <div className="fixed inset-0 z-50 bg-black/90 flex items-center justify-center">

                    <button
                        onClick={() => setFullscreen(false)}
                        className="absolute top-6 right-6 bg-white rounded-full p-3"
                    >
                        <X />
                    </button>

                    {galleryImages.length > 1 && (
                        <button
                            onClick={previous}
                            className="absolute left-8 text-white"
                        >
                            <ChevronLeft size={42} />
                        </button>
                    )}

                    <img
                        src={getImageSrc(current)}
                        alt={current?.color || "Bike"}
                        onError={(e) => {
                            e.target.onerror = null;
                            e.target.src = DEFAULT_IMAGE;
                        }}
                        className="max-h-[90vh] max-w-[90vw] object-contain"
                    />

                    {galleryImages.length > 1 && (
                        <button
                            onClick={next}
                            className="absolute right-8 text-white"
                        >
                            <ChevronRight size={42} />
                        </button>
                    )}

                </div>

            )}

        </>
    );
}