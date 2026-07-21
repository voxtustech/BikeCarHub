import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

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

export default function BrandPage() {

    const { brandId } = useParams();

    const [brand, setBrand] = useState(null);

    const [bikes, setBikes] = useState([]);

    const [brands, setBrands] = useState([]);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    useEffect(() => {

        loadPage();

    }, [brandId]);

    async function loadPage() {

        try {

            setLoading(true);

            const [

                brandData,

                bikeData,

                sidebarBrands

            ] = await Promise.all([

                getBrand(brandId),

                getBrandBikes(brandId),

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

            <div className="max-w-7xl mx-auto px-6 py-10">

                <BrandHero

                    brand={brand}

                    bikeCount={bikes.length}

                />

                <div className="grid lg:grid-cols-[60%_40%] gap-8 items-start">

                    <div>

                        <BrandBikeGrid
                            bikes={bikes}
                            loading={loading}
                        />

                    </div>

                    <div>

                        <BrandSidebar
                            brands={brands}
                            currentBrandId={Number(brandId)}
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