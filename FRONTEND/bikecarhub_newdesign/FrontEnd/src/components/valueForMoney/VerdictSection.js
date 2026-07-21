import React from "react";
import { Award } from "lucide-react";

export default function VerdictSection({

    verdict

}) {

    if (!verdict) return null;

    return (

        <section className="bg-gradient-to-br from-blue-600 to-indigo-700 rounded-3xl shadow-lg p-10 mb-10 text-white">

            <div className="flex items-center gap-4 mb-8">

                <div className="w-14 h-14 rounded-full bg-white/20 flex items-center justify-center">

                    <Award size={28} />

                </div>

                <div>

                    <h2 className="text-3xl font-bold">

                        Final Verdict

                    </h2>

                    <p className="text-blue-100 mt-1">

                        Our recommendation based on value, features and ownership.

                    </p>

                </div>

            </div>

            {verdict.summary && (

                <p className="text-lg leading-8 text-blue-50 mb-8">

                    {verdict.summary}

                </p>

            )}

            {verdict.points?.length > 0 && (

                <div className="grid md:grid-cols-2 gap-5">

                    {verdict.points.map((point, index) => (

                        <div

                            key={index}

                            className="bg-white/10 rounded-2xl p-5 backdrop-blur-sm"

                        >

                            <div className="flex items-start gap-3">

                                <div className="mt-2 w-2 h-2 rounded-full bg-white"></div>

                                <span className="leading-7">

                                    {point}

                                </span>

                            </div>

                        </div>

                    ))}

                </div>

            )}

            {verdict.recommendedVariant && (

                <div className="mt-8 bg-white text-slate-900 rounded-2xl p-6">

                    <p className="text-sm uppercase tracking-wide text-slate-500 mb-2">

                        Recommended Variant

                    </p>

                    <h3 className="text-2xl font-bold">

                        {verdict.recommendedVariant}

                    </h3>

                </div>

            )}

        </section>

    );

}