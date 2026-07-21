import React from "react";

import ArticleHero from "./ArticleHero";
import ArticleSection from "./ArticleSection";
import TableSection from "./TableSection";
import FAQSection from "./FAQSection";
import UpcomingBikeRelatedArticles from "./UpmcomingBikeRelatedArticles";

export default function ArticleLayout({ article }) {
    if (!article) {
        return (
            <div className="max-w-7xl mx-auto px-6 py-20">
                <div className="text-center text-slate-500">
                    Article not found.
                </div>
            </div>
        );
    }

    return (
        <div className="max-w-7xl mx-auto px-6 py-10">
            <div className="max-w-5xl mx-auto">

                <div>

                    {/* ================= FIRST ARTICLE ================= */}

                    <ArticleHero article={article} />

                    {article.sections?.map((section, index) => (
                        <ArticleSection
                            key={`section-${index}`}
                            section={section}
                        />
                    ))}

                    {article.tables?.map((table, index) => (
                        <TableSection
                            key={`table-${index}`}
                            table={table}
                        />
                    ))}


                    {article.faqs?.length > 0 && (
                        <FAQSection faqs={article.faqs} />
                    )}

                    {/* ================= SECOND ARTICLE ================= */}

                    {article.secondArticle && (
                        <>
                            <div className="mt-20">

                                <h2 className="text-3xl font-bold mb-8">
                                    {article.secondArticle.title}
                                </h2>

                                {article.secondArticle.heroImage && (
                                    <img
                                        src={article.secondArticle.heroImage}
                                        alt={article.secondArticle.title}
                                        className="w-full rounded-xl mb-8"
                                    />
                                )}

                                <p className="text-lg text-gray-700 leading-8 mb-10">
                                    {article.secondArticle.introduction}
                                </p>

                                {/* Top Pick */}

                                <h3 className="text-2xl font-semibold mb-4">
                                    {article.secondArticle.topPick.title}
                                </h3>

                                <p className="mb-4">
                                    {article.secondArticle.topPick.description}
                                </p>
                                
                                <ul className="list-disc pl-6 space-y-2 mb-6">
                                    {(article.secondArticle.topPick.points ?? []).map((item, index) => (
                                        <li key={index}>{item}</li>
                                    ))}
                                </ul>

                                <p className="mb-10">
                                    {article.secondArticle.topPick.conclusion}
                                </p>

                                {/* Other Picks */}

                                <h3 className="text-2xl font-semibold mb-6">
                                    Other Great VFM Picks
                                </h3>
                    
                                <div className="grid md:grid-cols-2 gap-6 mb-8">

                                    <img
                                        src={article.secondArticle.otherVfmImage1}
                                        alt=""
                                        className="rounded-xl w-full"
                                    />

                                    <img
                                        src={article.secondArticle.otherVfmImage2}
                                        alt=""
                                        className="rounded-xl w-full"
                                    />

                                </div>

                                <ul className="list-disc pl-6 space-y-3 mb-10">
                                    {article.secondArticle.otherGreatPicks.map((pick, index) => (
                                        <li key={index}>
                                            <strong>{pick.title}</strong> – {pick.description}
                                        </li>
                                    ))}
                                </ul>

                                {/* Price Table */}

                                <TableSection
                                    table={{
                                        heading: article.secondArticle.priceTable.title,
                                        headers: article.secondArticle.priceTable.headers,
                                        rows: article.secondArticle.priceTable.rows.map(row => ({
                                            columns: row
                                        }))
                                    }}
                                />

                                {/* Verdict */}

                                <VerdictSection
                                    verdict={article.secondArticle.verdict}
                                />

                                {/* FAQs */}

                                <FAQSection
                                    faqs={article.secondArticle.faqs}
                                />

                            </div>
                        </>
                    )}

                    <RelatedArticles currentSlug={article.slug} />

                </div>

            </div>
        </div>
    );
}