import UpcomingBikeArticleLayout from "../components/upcomingBikes/UpcomingBikeArticleLayout";

import { BlogsSection } from "../components/BlogsSection";
import { LatestNewsSection } from "../components/LatestNewsSection";
import { CompareBikesSection } from "../components/CompareBikesSection";
import { EcosystemSection } from "../components/EcosystemSection";
import { AdPlaceholder } from "../components/AdPlaceholder";
import { useParams } from "react-router-dom";

import TriumphTigerSport800 from "../data/upcomingBikes/TriumphTigerSport800";

const articles = {

    triumphtigersport800: TriumphTigerSport800

};

export default function UpcomingBikeDetails() {

    const { slug } = useParams();

    const article = articles[slug];

    if (!article) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-20">

                <div className="bg-red-50 border border-red-200 rounded-2xl p-8 text-center">

                    <h2 className="text-3xl font-bold">

                        Article Not Found

                    </h2>

                    <p className="mt-3 text-slate-600">

                        The Upcoming Bike article you are looking for does not exist.

                    </p>

                </div>

            </div>

        );

    }

    return (

        <main className="bg-slate-50 min-h-screen">

            <UpcomingBikeArticleLayout article={article} />

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