import React from "react";
import { Calendar, Clock, ChevronRight } from "lucide-react";
import { BACKEND_URL } from "../../config";
import {
    Share2,
    Bookmark
} from "lucide-react";

export default function ArticleHero({ article }) {

    return (

        <section className="mb-12">

            {/* Breadcrumb */}

            <div className="flex items-center gap-2 text-sm text-slate-500 mb-6">

                <span className="hover:text-blue-600 cursor-pointer">

                    Home

                </span>

                <ChevronRight size={16} />

                <span className="hover:text-blue-600 cursor-pointer">

                    Latest News

                </span>

                <ChevronRight size={16} />

                <span className="text-slate-700 font-medium">

                    {article.title}

                </span>

            </div>

            {/* Badge */}

            <div className="inline-flex items-center px-4 py-2 rounded-full bg-blue-50 text-blue-700 font-semibold text-sm mb-6">

                LATEST NEWS

            </div>

            {/* Title */}

            <h1 className="text-5xl font-bold text-slate-900 leading-tight max-w-5xl">

                {article.title}

            </h1>

            {/* Subtitle */}

            {article.description && (

                <p className="mt-6 text-xl leading-9 text-slate-600 max-w-4xl">

                    {article.description}

                </p>

            )}

            {/* Meta */}

            <div className="flex flex-wrap items-center justify-between gap-6 mt-8">

                <div className="flex flex-wrap items-center gap-6 text-slate-500">

                    <div className="flex items-center gap-2">
                        <Calendar size={20} />
                        <span>{article.date}</span>
                    </div>

                    <div className="flex items-center gap-2">
                        <Clock size={20} />
                        <span>{article.readTime}</span>
                    </div>

                </div>

                <div className="flex items-center gap-3">

                    <button
                        className="flex items-center gap-2 rounded-lg border border-slate-300 px-5 py-2.5 hover:bg-slate-100 transition"
                    >
                        <Share2 size={18} />
                        Share
                    </button>

                    <button
                        className="flex items-center gap-2 rounded-lg bg-blue-600 text-white px-5 py-2.5 hover:bg-blue-700 transition"
                    >
                        <Bookmark size={18} />
                        Save
                    </button>

                </div>

            </div>

            {/* Hero Image */}

            {article.image && (

                <div className="mt-10 rounded-3xl overflow-hidden shadow-xl border border-slate-200">

                    <img

                        src={article.image}

                        alt={article.title}

                        className="w-full h-[550px] object-cover"

                    />

                </div>

            )}

        </section>

    );

}