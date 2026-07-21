import React from "react";
import { useNavigate } from "react-router-dom";
import { Calendar, ArrowRight } from "lucide-react";
import { BACKEND_URL } from "../../config";

export default function UpcomingBikesCard({ article }) {

    const navigate = useNavigate();

    console.log(article.title, article.slug);

    function openArticle() {
        navigate(`/upcoming-bike/${article.slug}`);
    }

    return (

        <div

            onClick={openArticle}

            className="group cursor-pointer bg-white rounded-3xl overflow-hidden border border-slate-200 shadow-sm hover:shadow-xl transition-all duration-300 hover:-translate-y-1"

        >

            <div className="relative h-60 overflow-hidden bg-slate-100">

                <img

                    src={article.heroImage}

                    alt={article.title}

                    className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500"

                />

                <div className="absolute top-4 left-4">

                    <span className="bg-[#0A0A2B] text-white px-4 py-2 rounded-full text-xs font-semibold">

                        UPCOMING BIKES

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