import React from "react";
import { useNavigate } from "react-router-dom";
import { BACKEND_URL } from "../config";
import { slugify } from "../utils/slugify";

export default function BrandBikeHorizontalCard({ bike }) {

    const navigate = useNavigate();

    if (!bike) return null;

    const image =
        bike.image
            ? `${BACKEND_URL}${bike.image}`
            : "/placeholder-bike.png";

    return (

        <div
            onClick={() =>
                navigate(
                    `/${slugify(bike.brand)}/${slugify(bike.name)}`
                )
            }
            className="bg-white rounded-2xl border border-slate-200 shadow-sm hover:shadow-md transition cursor-pointer overflow-hidden"
        >

            <div className="flex">

                {/* Bike Image */}

                <div className="w-52 h-44 flex items-center justify-center bg-white border-r">

                    <img
                        src={image}
                        alt={bike.name}
                        className="max-w-full max-h-full object-contain p-4"
                    />

                </div>

                {/* Bike Details */}

                <div className="flex-1 p-6 flex flex-col justify-center">

                    <p className="uppercase tracking-wider text-slate-400 text-sm font-semibold">

                        {bike.brand}

                    </p>

                    <h2 className="text-3xl font-bold text-slate-800 mt-2">

                        {bike.name}

                    </h2>

                    <p className="text-2xl font-bold text-blue-700 mt-4">

                        ₹ {bike.price}

                    </p>

                    <div className="mt-5 flex items-center gap-5 text-slate-500">

                        <span>

                            {bike.isEV ? "Electric" : "Petrol"}

                        </span>

                        <span>

                            ★ {bike.rating ?? "4.5"}

                        </span>

                    </div>

                    <div className="mt-8">

                        <button
                            className="bg-blue-600 hover:bg-blue-700 text-white px-6 py-3 rounded-xl font-semibold"
                            onClick={(e) => {

                                e.stopPropagation();

                                navigate(
                                    `/${slugify(bike.brand)}/${slugify(bike.name)}`
                                );

                            }}
                        >

                            View Details

                        </button>

                    </div>

                </div>

            </div>

        </div>

    );

}