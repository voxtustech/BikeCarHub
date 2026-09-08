import React from "react";
import { useParams } from "react-router-dom";

import UpcomingBikeArticleLayout
    from "../components/upcomingBikes/UpcomingBikeArticleLayout";

import { BlogsSection } from "../components/BlogsSection";
import { LatestNewsSection } from "../components/LatestNewsSection";
import { CompareBikesSection } from "../components/CompareBikesSection";
import { EcosystemSection } from "../components/EcosystemSection";
import { AdPlaceholder } from "../components/AdPlaceholder";

// Import your complete React article
import TVSXLEV from "../data/upcomingBikes/TVSXLEV ";
import IndianFTR1200 from "../data/upcomingBikes/IndianFTR1200";
import TriumphTigerSport800 from "../data/upcomingBikes/TriumphTigerSport800";
import YamahaYZFR7 from "../data/upcomingBikes/YamahaYZFR7";
import RoyalEnfieldHimalayan750 from "../data/upcomingBikes/RoyalEnfieldHimalayan750";

// ======================================================
// FULL UPCOMING BIKE ARTICLES
// ======================================================

const articles = {

    "tvs-xl-ev": TVSXLEV,

    "triumph-tiger-sport-800": TriumphTigerSport800,
    "yamaha-yzf-r7": YamahaYZFR7,
    "royal-enfield-himalayan-750": RoyalEnfieldHimalayan750,
    "indian-ftr-1200": IndianFTR1200

};


export default function UpcomingBikeDetails() {

    const { slug } = useParams();

    console.log("=================================");
    console.log("UPCOMING BIKE DETAILS PAGE");
    console.log("Slug from URL:", slug);
    console.log("Available articles:", Object.keys(articles));
    console.log("=================================");


    // Get the complete article from React data
    const article = articles[slug];


    console.log("Selected article:", article);


    // ======================================================
    // ARTICLE NOT FOUND
    // ======================================================

    if (!article) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-20">

                <div className="bg-red-50 border border-red-200 rounded-2xl p-8 text-center">

                    <h2 className="text-3xl font-bold">

                        Article Not Found

                    </h2>

                    <p className="mt-3 text-slate-600">

                        The Upcoming Bike article you are looking for
                        does not exist.

                    </p>

                    <p className="mt-3 text-sm text-slate-500">

                        Requested slug: {slug}

                    </p>

                </div>

            </div>

        );

    }


    // ======================================================
    // PAGE
    // ======================================================

    return (

        <main className="bg-slate-50 min-h-screen">

            {/* COMPLETE ARTICLE */}

            <UpcomingBikeArticleLayout
                article={article}
            />


            {/* ADVERTISEMENT */}

            <div className="max-w-7xl mx-auto px-6 py-4">

                <AdPlaceholder
                    label="Advertisement"
                    height="h-20"
                />

            </div>


            {/* OTHER SECTIONS */}

            <BlogsSection />

            <LatestNewsSection />

            <CompareBikesSection />

            <EcosystemSection />

        </main>

    );

}