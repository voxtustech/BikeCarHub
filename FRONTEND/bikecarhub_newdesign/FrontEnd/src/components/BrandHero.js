import React from "react";
import { BACKEND_URL } from "../config";

export default function BrandHero({ brand, bikeCount }) {

    if (!brand) return null;

    return (

        <section className="bg-gradient-to-r from-slate-900 via-slate-800 to-slate-900 rounded-3xl overflow-hidden mb-10">

            <div className="px-10 py-12 flex flex-col lg:flex-row items-center justify-between gap-10">

                <div className="flex-1">

                    <div className="flex items-center gap-6">

                        <div className="w-24 h-24 bg-white rounded-2xl shadow flex items-center justify-center p-3">

                            <img
                                src={`${BACKEND_URL}${brand.logo}`}
                                alt={brand.name}
                                className="w-full h-full object-contain"
                            />

                        </div>

                        <div>

                            <h1 className="text-4xl font-bold text-white">

                                {brand.name} Bikes

                            </h1>

                            <p className="text-slate-300 mt-2 text-lg">

                                {bikeCount} Models Available

                            </p>

                        </div>

                    </div>

                    <p className="text-slate-300 mt-8 leading-8 text-base max-w-4xl">

                        {brand.description ||
                            `${brand.name} offers a wide range of motorcycles and scooters across multiple segments. Browse all available models, compare specifications, prices, images and features to find the perfect bike for your needs.`}

                    </p>

                </div>

                <div className="hidden lg:flex">

                    <div className="w-72 h-72 rounded-full bg-white/5 border border-white/10 flex items-center justify-center">

                        <img
                            src={`${BACKEND_URL}${brand.logo}`}
                            alt={brand.name}
                            className="w-44 h-44 object-contain opacity-90"
                        />

                    </div>

                </div>

            </div>

        </section>

    );

}