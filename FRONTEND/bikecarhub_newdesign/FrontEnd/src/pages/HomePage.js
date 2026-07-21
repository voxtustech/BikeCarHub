import React from "react";

import { HeroSection } from "../components/HeroSection";
import { BlogsSection } from "../components/BlogsSection";
import { ValueForMoneySection } from "../components/ValueForMoneySection";
import { UpcomingBikesSection } from "../components/UpcomingBikesSection";
import { LatestNewsSection } from "../components/LatestNewsSection";
import { PopularBrandsSection } from "../components/PopularBrandsSection";
import { CompareBikesSection } from "../components/CompareBikesSection";
import { EcosystemSection } from "../components/EcosystemSection";
import { AdPlaceholder } from "../components/AdPlaceholder";

export default function HomePage() {

    return (

        <main>

            <HeroSection />

            <div className="max-w-7xl mx-auto px-6 py-4">
                <AdPlaceholder
                    label="Advertisement"
                    height="h-20"
                />
            </div>

            <BlogsSection />

            <div className="max-w-7xl mx-auto px-6 py-4">
                <AdPlaceholder
                    label="Advertisement"
                    height="h-20"
                />
            </div>

            <ValueForMoneySection />

            <UpcomingBikesSection />

            <LatestNewsSection />

            <PopularBrandsSection />

            <CompareBikesSection />

            <EcosystemSection />

        </main>

    );

}