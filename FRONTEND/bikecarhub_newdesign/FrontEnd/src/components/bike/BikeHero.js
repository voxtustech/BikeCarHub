import {
    Heart,
    Share2,
    GitCompare,
    Download,
    Calendar,
    Star,
    IndianRupee
} from "lucide-react";

export default function BikeHero({ bike }) {

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

            <div className="flex items-center gap-3 mt-4">

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

                    4.4

                </span>

                <span className="text-slate-500">

                    (136 Reviews)

                </span>

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

                <button className="flex items-center justify-center gap-2 rounded-xl border border-slate-300 py-3 hover:bg-slate-50 transition">

                    <Heart size={18} />

                    Wishlist

                </button>

                <button className="flex items-center justify-center gap-2 rounded-xl border border-slate-300 py-3 hover:bg-slate-50 transition">

                    <GitCompare size={18} />

                    Compare

                </button>

                <button className="flex items-center justify-center gap-2 rounded-xl border border-slate-300 py-3 hover:bg-slate-50 transition">

                    <Share2 size={18} />

                    Share

                </button>

                <button className="flex items-center justify-center gap-2 rounded-xl border border-slate-300 py-3 hover:bg-slate-50 transition">

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

                    <button className="bg-blue-700 text-white px-5 py-3 rounded-xl hover:bg-blue-800 transition">

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

        </div>

    );

}