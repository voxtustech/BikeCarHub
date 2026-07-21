import React from "react";

import UpcomingBikeHero from "./UpcomingBikeHero";
import UpcomingBikeSection from "./UpcomingBikeSection";
import UpcomingBikeTable from "./UpcomingBikeTable";
import UpcomingBikeFAQ from "./UpcomingBikeFAQ";
import UpcomingBikeRelatedArticles from "./UpcomingBikeRelatedArticles";

export default function UpcomingBikeArticleLayout({ article }) {

    if (!article) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-20">

                <div className="text-center text-slate-500">

                    Bike article not found.

                </div>

            </div>

        );

    }

    return (

        <div className="max-w-7xl mx-auto px-6 py-10">

            <div className="max-w-5xl mx-auto">

                <UpcomingBikeHero article={article} />

                {article.sections?.map((section, index) => (

                    <UpcomingBikeSection

                        key={index}

                        section={section}

                    />

                ))}

                {article.tables?.map((table, index) => (

                    <UpcomingBikeTable

                        key={index}

                        table={table}

                    />

                ))}

                {article.faqs?.length > 0 && (

                    <UpcomingBikeFAQ

                        faqs={article.faqs}

                    />

                )}

                <UpcomingBikeRelatedArticles

                    currentSlug={article.slug}

                />

            </div>

        </div>

    );

}