import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import UpcomingBikeArticleLayout
    from "../components/upcomingBikes/UpcomingBikeArticleLayout";

import { BlogsSection } from "../components/BlogsSection";
import { LatestNewsSection } from "../components/LatestNewsSection";
import { CompareBikesSection } from "../components/CompareBikesSection";
import { EcosystemSection } from "../components/EcosystemSection";
import { AdPlaceholder } from "../components/AdPlaceholder";

import {
    getUpcomingBikeDetails
} from "../api/upcomingBikeApi";

export default function UpcomingBikeDetails() {

    const { slug } = useParams();

    const [article, setArticle] = useState(null);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    useEffect(() => {

        console.log("UPCOMING BIKE DETAILS PAGE");

        console.log("Slug from URL:", slug);

        async function loadArticle() {

            try {

                setLoading(true);

                setError("");

                const data =
                    await getUpcomingBikeDetails(slug);

                console.log(
                    "Upcoming bike API response:",
                    data
                );

                setArticle(data);

            }
            catch (err) {

                console.error(
                    "Upcoming bike loading error:",
                    err
                );

                setError(
                    "Unable to load upcoming bike article."
                );

            }
            finally {

                setLoading(false);

            }

        }

        if (slug) {
            loadArticle();
        }

    }, [slug]);


    if (loading) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-20">

                <div className="text-center text-slate-500 text-xl">

                    Loading article...

                </div>

            </div>

        );

    }


    if (error || !article) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-20">

                <div className="bg-red-50 border border-red-200 rounded-2xl p-8 text-center">

                    <h2 className="text-3xl font-bold">

                        Article Not Found

                    </h2>

                    <p className="mt-3 text-slate-600">

                        {error}

                    </p>

                </div>

            </div>

        );

    }


    return (

        <main className="bg-slate-50 min-h-screen">

            <UpcomingBikeArticleLayout
                article={article}
            />

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