import React from "react";

import { HeroSection } from "../../components/HeroSection";
import { BlogsSection } from "../../components/BlogsSection";
import { ValueForMoneySection } from "../../components/ValueForMoneySection";
import { UpcomingBikesSection } from "../../components/UpcomingBikesSection";
import { LatestNewsSection } from "../../components/LatestNewsSection";
import { PopularBrandsSection } from "../..//components/PopularBrandsSection";
import { CompareBikesSection } from "../../components/CompareBikesSection";
import { EcosystemSection } from "../../components/EcosystemSection";
import { AdPlaceholder } from "../../components/AdPlaceholder";

export default function ArticleRealtedSections() {

    return (

        <main>

            <BlogsSection />

            <ValueForMoneySection />

            <UpcomingBikesSection />

            <LatestNewsSection />

            <PopularBrandsSection />

            <CompareBikesSection />

            <EcosystemSection />

        </main>

    );

}