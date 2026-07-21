/*
import React from "react";
import BrandBikeCard from "./BrandBikeCard";
import { Link } from "react-router-dom";

export default function BrandBikeGrid({

    bikes = [],

    loading = false

}) {

    if (loading) {

        return (

            <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-12">

                <div className="text-center text-slate-500 text-lg">

                    Loading bikes...

                </div>

            </div>

        );

    }

    if (!bikes.length) {

        return (

            <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-12">

                <div className="text-center">

                    <h3 className="text-2xl font-semibold text-slate-700">

                        No Bikes Found

                    </h3>

                    <p className="text-slate-500 mt-3">

                        There are currently no bikes available for this brand.

                    </p>

                </div>

            </div>

        );

    }

    return (

        <div>

            <div className="flex items-center justify-between mb-6">

                <h2 className="text-2xl font-bold text-slate-800">

                    Available Models

                </h2>

                <span className="text-slate-500">

                    {bikes.length} Bikes

                </span>

            </div>

            <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-2 gap-6">

                {bikes.map((bike) => (

                    <BrandBikeCard
                        key={bike.id}
                        bike={bike}
                    />

                ))}

            </div>

            <div className="flex justify-center mt-10">

                <Link
                    to="/brands"
                    className="px-8 py-3 rounded-xl bg-[#1B2A52] text-white hover:bg-[#24396e] transition"
                >
                    View All Brands
                </Link>

            </div>


        </div>

    );

}
*/

import React from "react";
import BrandBikeHorizontalCard from "./BrandBikeHorizontalCard";

export default function BrandBikeGrid({

    bikes = [],

    loading = false

}) {

    if (loading) {

        return (

            <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-12">

                <div className="text-center text-slate-500 text-lg">

                    Loading bikes...

                </div>

            </div>

        );

    }

    if (!bikes.length) {

        return (

            <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-12">

                <div className="text-center">

                    <h3 className="text-2xl font-semibold text-slate-700">

                        No Bikes Found

                    </h3>

                    <p className="text-slate-500 mt-3">

                        There are currently no bikes available for this brand.

                    </p>

                </div>

            </div>

        );

    }

    return (

        <div>

            <div className="flex items-center justify-between mb-8">

                <h2 className="text-3xl font-bold text-slate-800">

                    Available Models

                </h2>

                <span className="text-slate-500 text-lg">

                    {bikes.length} Bikes

                </span>

            </div>

            <div className="space-y-8">

                {bikes.map((bike) => (

                    <BrandBikeHorizontalCard
                        key={bike.id}
                        bike={bike}
                    />

                ))}

            </div>

        </div>

    );

}