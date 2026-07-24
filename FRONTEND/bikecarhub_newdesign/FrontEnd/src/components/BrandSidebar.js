/*
import React from "react";
import { useNavigate } from "react-router-dom";
import { BACKEND_URL } from "../config";

export default function BrandSidebar({

    brands = [],

    currentBrandId

}) {

    const navigate = useNavigate();

    return (

        <aside className="bg-white rounded-3xl border border-slate-200 shadow-sm p-6 sticky top-24">

            <h2 className="text-xl font-bold text-slate-800 mb-6">

                Popular Brands

            </h2>

            <div className="space-y-3">

                {brands.map((brand) => {

                    const active =
                        brand.id === currentBrandId;

                    return (

                        <button
                            key={brand.id}
                            onClick={() =>
                                navigate(`/brand/${brand.id}`)
                            }
                            className={`
                                w-full
                                flex
                                items-center
                                gap-4
                                rounded-2xl
                                border
                                p-3
                                transition-all
                                duration-200
                                ${active
                                    ? "border-blue-600 bg-blue-50"
                                    : "border-slate-200 hover:border-blue-400 hover:bg-slate-50"
                                }
                            `}
                        >

                            <div className="w-14 h-14 bg-white rounded-xl border flex items-center justify-center overflow-hidden">

                                <img
                                    src={`${BACKEND_URL}${brand.logo}`}
                                    alt={brand.name}
                                    className="w-10 h-10 object-contain"
                                />

                            </div>

                            <div className="flex-1 text-left">

                                <h3
                                    className={`font-semibold ${active
                                            ? "text-blue-700"
                                            : "text-slate-800"
                                        }`}
                                >
                                    {brand.name}
                                </h3>

                            </div>

                        </button>

                    );

                })}

            </div>

        </aside>

    );

}
*/

import React from "react";
import { useNavigate } from "react-router-dom";
import { BACKEND_URL } from "../config";
import { slugify } from "../utils/slugify";

export default function BrandSidebar({

    brands = [],

    currentBrandId

}) {

    const navigate = useNavigate();

    return (

        <div className="sticky top-24">

            <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-8">

                <h2 className="text-3xl font-bold text-slate-800 mb-8">

                    Popular Brands

                </h2>

                <div className="grid grid-cols-3 gap-4">

                    {brands.map((brand) => {

                        const active =
                            brand.id === currentBrandId;

                        return (

                            <button

                                key={brand.id}

                                onClick={() =>
                                    navigate(`/${slugify(brand.name)}`)
                                }

                                className={`rounded-2xl border p-4 flex flex-col items-center justify-center transition-all hover:shadow-md
                                ${active
                                        ? "border-blue-600 bg-blue-50"
                                        : "border-slate-200 hover:border-blue-300"
                                    }`}

                            >

                                <div className="w-16 h-16 flex items-center justify-center">

                                    <img
                                        src={`${BACKEND_URL}${brand.logo}`}
                                        alt={brand.name}
                                        className="max-w-full max-h-full object-contain"
                                    />

                                </div>

                                <p className="mt-2 text-[11px] font-medium text-center leading-4">

                                    {brand.name}

                                </p>

                            </button>

                        );

                    })}

                </div>

            </div>

        </div>

    );

}