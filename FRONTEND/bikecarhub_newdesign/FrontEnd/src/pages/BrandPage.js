import React, { useEffect, useState } from "react";
import { useParams, useSearchParams } from "react-router-dom";

import {
    getBrand,
    getBrandBikes,
    getPopularBrands
} from "../api/brandApi";

import BrandHero from "../components/BrandHero";
import BrandBikeGrid from "../components/BrandBikeGrid";
import BrandSidebar from "../components/BrandSidebar";

import { BlogsSection } from "../components/BlogsSection";
import { ValueForMoneySection } from "../components/ValueForMoneySection";
import { UpcomingBikesSection } from "../components/UpcomingBikesSection";
import { LatestNewsSection } from "../components/LatestNewsSection";
import { CompareBikesSection } from "../components/CompareBikesSection";
import { EcosystemSection } from "../components/EcosystemSection";
import { AdPlaceholder } from "../components/AdPlaceholder";
import SEO from "../components/SEO/SEO";

export default function BrandPage() {

    const { brandName } = useParams();

    const [brand, setBrand] = useState(null);

    const [bikes, setBikes] = useState([]);

    const [brands, setBrands] = useState([]);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    const [searchParams] = useSearchParams();

    const budget = searchParams.get("budget");

    const getPriceNumber = (price) => {
        if (price === null || price === undefined || price === "") {
            return 0;
        }

        // If API returns a number
        if (typeof price === "number") {
            return price;
        }

        const value = price
            .toString()
            .replace(/₹/g, "")
            .replace(/Rs\.?/gi, "")
            .replace(/,/g, "")
            .trim()
            .toLowerCase();

        if (value.includes("crore")) {
            return parseFloat(value.replace("crore", "").trim()) * 10000000;
        }

        if (value.includes("lakh")) {
            return parseFloat(value.replace("lakh", "").trim()) * 100000;
        }

        return parseFloat(value.replace(/[^\d.]/g, "")) || 0;
    };

    const filteredBikes = bikes.filter((bike) => {

        if (!budget) {
            return true;
        }

        const price = getPriceNumber(
            bike.basePrice ?? bike.BasePrice ?? bike.price ?? bike.Price
        );

        switch (budget) {

            case "under-1l":
                return price < 100000;

            case "under-2l":
                return price < 200000;

            case "under-3l":
                return price < 300000;

            case "above-3l":
                return price >= 300000;

            default:
                return true;
        }
    });

    useEffect(() => {

        loadPage();

    }, [brandName]);

    async function loadPage() {

        try {

            setLoading(true);

            const [

                brandData,

                bikeData,

                sidebarBrands

            ] = await Promise.all([

                getBrand(brandName),

                getBrandBikes(brandName),

                getPopularBrands()

            ]);

            setBrand(brandData);

            setBikes(bikeData);

            setBrands(sidebarBrands);

        }

        catch (err) {

            console.error(err);

            setError("Unable to load brand.");

        }

        finally {

            setLoading(false);

        }

    }

    if (loading) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-20">

                <div className="text-center text-slate-500 text-xl">

                    Loading Brand...

                </div>

            </div>

        );

    }

    if (error) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-20">

                <div className="bg-red-50 border border-red-200 rounded-2xl p-8 text-red-600">

                    {error}

                </div>

            </div>

        );

    }

    return (

        <main>
            <SEO
                title={brand?.seoTitle || brand?.titleTag || `${brand?.name} Bikes in India`}
                description={
                    brand?.seoDescription || brand?.metaDescription ||
                    `Explore ${brand?.name} bikes in India with prices, specifications, features and reviews.`
                }
                keywords={brand?.seoKeywords || brand?.metaKeywords}
                canonical={`/${brandName}`}
            />

            <div className="max-w-7xl mx-auto px-6 py-10">

                

                <BrandHero
                    brand={brand}
                    bikeCount={filteredBikes.length}
                />

                <div className="grid lg:grid-cols-[60%_40%] gap-8 items-start">

                    <div>
                        <BrandBikeGrid
                            bikes={filteredBikes}
                            loading={loading}
                        />

                        

                    </div>

                    <div>

                        <BrandSidebar
                            brands={brands}
                            currentBrandId={brand?.id}
                        />

                    </div>

                </div>

            </div>

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

            <CompareBikesSection />

            <EcosystemSection />

        </main>

    );

}