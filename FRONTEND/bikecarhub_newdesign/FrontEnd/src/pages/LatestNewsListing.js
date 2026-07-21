
import React, { useEffect, useState } from "react";

import { getLatestNewsArticles } from "../api/latestNewsApi";

import { AdPlaceholder } from "../components/AdPlaceholder";
import { BlogsSection } from "../components/BlogsSection";
import { LatestNewsSection } from "../components/LatestNewsSection";
import { CompareBikesSection } from "../components/CompareBikesSection";
import { EcosystemSection } from "../components/EcosystemSection";

import LatestNewsCard from "../components/latestNews/LatestNewsCard";

export default function LatestNewsListing() {

    const [articles, setArticles] = useState([]);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    useEffect(() => {

        loadArticles();

    }, []);

    async function loadArticles() {

        try {

            setLoading(true);

            const data = await getLatestNewsArticles();

            setArticles(data);

        }

        catch (err) {

            console.error(err);

            setError("Unable to load Latest News articles.");

        }

        finally {

            setLoading(false);

        }

    }

    return (

        <main className="bg-slate-50 min-h-screen">

            <div className="max-w-7xl mx-auto px-6 py-12">

                <div className="mb-12">

                    <h1 className="text-5xl font-bold text-slate-900">

                        Latest News

                    </h1>

                    <p className="mt-4 text-lg text-slate-600 max-w-3xl">

                        Find the best value-for-money variants,
                        expert buying advice, feature comparisons,
                        pricing insights and recommendations before
                        purchasing your next vehicle.

                    </p>

                </div>

                {loading && (

                    <div className="py-24 text-center text-slate-500">

                        Loading articles...

                    </div>

                )}

                {error && (

                    <div className="bg-red-50 border border-red-200 rounded-xl p-6 text-red-600">

                        {error}

                    </div>

                )}

                {!loading && !error && (

                    <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-8">

                        {articles.map(article => (

                            <LatestNewsCard

                                key={article.id}

                                article={article}

                            />

                        ))}

                    </div>

                )}

            </div>

            <div className="max-w-7xl mx-auto px-6 py-4">

                <AdPlaceholder

                    label="Advertisement"

                    height="h-20"

                />

            </div>

            <BlogsSection />

            <LatestNewsSection />

            <CompareBikesSection />

            <EcosystemSection />

        </main>

    );

}