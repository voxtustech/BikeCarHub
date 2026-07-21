import React from "react";
import { useNavigate } from "react-router-dom";
import { Calendar, ArrowRight } from "lucide-react";
import { BACKEND_URL } from "../../config";

export default function ValueForMoneyCard({ article }) {

    const navigate = useNavigate();

    console.log(article.title, article.slug);

    const slugMap = {

        "value-for-money/best-value-for-money-variant-of-tata-punch": "tatapunch",

        "value-for-money/best-value-for-money-variant-of-tata-tiago": "tatatiago",

        "value-for-money/best-value-for-money-variant-of-tata-altroz-facelift": "tataaltrozfacelift",

        "value-for-money/alto-k10-value-for-money-varient": "altok10",

        "value-for-money/maruti-suzuki-wagonR-2025-the-value-for-money-variant": "marutisuzukiwagonr2025",

        "value-for-money/skoda-kylaq-value-for-money-variant": "skodakylaq",

        "value-for-money/maruti-suzuki-swift-2025-the-value-for-money-variant": "marutisuzukiswift2025",

        "value-for-money/best-value-for-money-variant-of-the-maruti-suzuki-s-presso": "marutisuzukispresso",

        "value-for-money/best-value-for-money-variant-of-maruti-suzuki-nexa-ignis": "marutisuzukinexaignis",

        "value-for-money/maruti-suzuki-ertiga-zXIO-the-value-for-money-variant": "marutisuzukiertigazxio",

        "value-for-money/maruti-suzuki-dzire-2025-the-value-for-money-variant": "marutisuzukidzire2025",

        "value-for-money/maruti-suzuki-celerio-the-value-for-money-variant": "marutisuzukicelerio",

        "value-for-money/maruti-suzuki-brezza-the-value-for-money-variant": "marutisuzukibrezza",

        "value-for-money/kia-syros-value-for-money-varient": "kiasyros"

    };

    function openArticle() {

        const route = slugMap[article.slug];

        if (route) {
            navigate(`/value-for-money/${route}`);
        } else {
            console.error("No route mapping found for:", article.slug);
        }

    }

    return (

        <div

            onClick={openArticle}

            className="group cursor-pointer bg-white rounded-3xl overflow-hidden border border-slate-200 shadow-sm hover:shadow-xl transition-all duration-300 hover:-translate-y-1"

        >

            <div className="relative h-60 overflow-hidden bg-slate-100">

                <img

                    src={`${BACKEND_URL}${article.image}`}

                    alt={article.title}

                    className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500"

                />

                <div className="absolute top-4 left-4">

                    <span className="bg-[#0A0A2B] text-white px-4 py-2 rounded-full text-xs font-semibold">

                        VALUE FOR MONEY

                    </span>

                </div>

            </div>

            <div className="p-6">

                <h2 className="text-2xl font-bold text-slate-900 leading-tight group-hover:text-blue-600 transition-colors">

                    {article.title}

                </h2>

                {article.description && (

                    <p className="mt-4 text-slate-600 leading-7 line-clamp-3">

                        {article.description}

                    </p>

                )}

                <div className="flex items-center justify-between mt-8">

                    <div className="flex items-center gap-2 text-slate-500">

                        <Calendar size={16} />

                        <span className="text-sm">

                            {article.date}

                        </span>

                    </div>

                    <div className="flex items-center gap-2 font-semibold text-blue-600 group-hover:gap-4 transition-all">

                        Read More

                        <ArrowRight size={18} />

                    </div>

                </div>

            </div>

        </div>

    );

}