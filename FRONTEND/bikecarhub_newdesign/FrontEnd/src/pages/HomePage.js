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
import SEO from "../components/SEO/SEO";

export default function HomePage() {

    return (

        <main>
            <SEO
                title="New Bikes, Cars, Scooters & New Electric Vehicle | BikeCarHub"
                description="Discover your ideal bike or scooter at BikeCarHub. Check on-road prices, colors, reviews, comparisons, latest news, and upcoming bikes & cars in one place at BikeCarHub."
                keywords="bikecarhub, bike, new bikes, bike comparison, bikes prices, reviews, Images, news, compare bikes, Instant Bike On-Road Price, Upcoming bikes, Latest News, Ask a Question"
                canonical="/"
            />
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