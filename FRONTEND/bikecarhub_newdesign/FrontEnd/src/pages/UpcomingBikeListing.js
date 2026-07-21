/*
import React, { useEffect, useState } from "react";

import { getUpcomingBikeArticles } from "../api/upcomingBikeApi";

import { AdPlaceholder } from "../components/AdPlaceholder";
import { BlogsSection } from "../components/BlogsSection";
import { LatestNewsSection } from "../components/LatestNewsSection";
import { CompareBikesSection } from "../components/CompareBikesSection";
import { EcosystemSection } from "../components/EcosystemSection";

import UpcomingBikeCard from "../components/upcomingBikes/UpcomingBikeCard";

export default function UpcomingBikeListing() {

    const [articles, setArticles] = useState([]);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    useEffect(() => {

        loadArticles();

    }, []);

    async function loadArticles() {

        try {

            setLoading(true);

            const data = await getUpcomingBikeArticles();

            setArticles(data);

        }

        catch (err) {

            console.error(err);

            setError("Unable to load Upcoming Bikes articles.");

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

                        Upcoming Bikes

                    </h1>

                    <p className="mt-4 text-lg text-slate-600 max-w-3xl">

                        Discover upcoming motorcycles launching in India, expected prices, launch dates, specifications and expert previews before they arrive.

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

                            <UpcomingBikeCard

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

*/

import React, { useEffect, useState } from "react";

import { getUpcomingBikeArticles } from "../api/upcomingBikeApi";

import { AdPlaceholder } from "../components/AdPlaceholder";
import { BlogsSection } from "../components/BlogsSection";
import { LatestNewsSection } from "../components/LatestNewsSection";
import { CompareBikesSection } from "../components/CompareBikesSection";
import { EcosystemSection } from "../components/EcosystemSection";

import UpcomingBikeCard from "../components/upcomingBikes/UpcomingBikeCard";

export default function UpcomingBikeListing() {

    const [articles, setArticles] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        loadArticles();
    }, []);

    async function loadArticles() {
        try {
            setLoading(true);

            const data = await getUpcomingBikeArticles();

            setArticles(data);
        }
        catch (err) {
            console.error(err);
            setError("Unable to load Upcoming Bike articles.");
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
                        Upcoming Bikes
                    </h1>

                    <p className="mt-4 text-lg text-slate-600 max-w-3xl">
                        Explore upcoming bike launches, expected prices,
                        specifications, features and expert previews before
                        they arrive in the market.
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
                            <UpcomingBikeCard
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