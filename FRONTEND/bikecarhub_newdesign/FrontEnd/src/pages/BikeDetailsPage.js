import { useParams } from "react-router-dom";
import { useEffect, useMemo, useState } from "react";

import { getBikeDetails } from "../api/bikeApi";

import BikeHero from "../components/bike/BikeHero";
import BikeStickyMenu from "../components/bike/BikeStickyMenu";
import BikeVariantSelector from "../components/bike/BikeVariantSelector";
import BikeInfoCards from "../components/bike/BikeInfoCards";
//import BikeDescription from "../components/bike/BikeDescription";
import BikeSpecs from "../components/bike/BikeSpecs";

import BikeEngineTransmission from "../components/bike/BikeEngineTransmission";
import BikeFeatures from "../components/bike/BikeFeatures";
import BikeSafety from "../components/bike/BikeSafety";
import BikeMileagePerformance from "../components/bike/BikeMileagePerformance";
import BikeDimensions from "../components/bike/BikeDimensions";
import BikeElectricals from "../components/bike/BikeElectricals";
import BikeTyresBrakes from "../components/bike/BikeTyresBrakes";
import BikeMotorBattery from "../components/bike/BikeMotorBattery";
import BikeCharging from "../components/bike/BikeCharging";
import BikeUnderpinnings from "../components/bike/BikeUnderpinnings";

import BikeImageGallery from "../components/bike/BikeImageGallery";

import SimilarBikesSection from "../components/bike/SimilarBikesSection";
import BikeCompareSection from "../components/bike/BikeCompareSection";
import BikeNewsSection from "../components/bike/BikeNewsSection";
import BikeBlogsSection from "../components/bike/BikeBlogsSection";

export default function BikeDetailsPage() {

    const { brandName, bikeName } = useParams();

    const [bikeData, setBikeData] = useState(null);

    const [loading, setLoading] = useState(true);

    const [selectedVariant, setSelectedVariant] = useState(null);

    useEffect(() => {

        async function loadBike() {

            try {

                const data = await getBikeDetails(brandName, bikeName);

                setBikeData(data);

                if (data.variants.length > 0)
                    setSelectedVariant(data.variants[0].id);

            }

            catch (err) {

                console.error(err);

            }

            finally {

                setLoading(false);

            }

        }

        loadBike();

    }, [brandName, bikeName]);

    const currentSpec = useMemo(() =>
        bikeData?.specs?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentEngine = useMemo(() =>
        bikeData?.engine?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentFeatures = useMemo(() =>
        bikeData?.features?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentSafety = useMemo(() =>
        bikeData?.safety?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentPerformance = useMemo(() =>
        bikeData?.performance?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentDimensions = useMemo(() =>
        bikeData?.dimensions?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentElectricals = useMemo(() =>
        bikeData?.electricals?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentTyres = useMemo(() =>
        bikeData?.tyres?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentMotorBattery = useMemo(() =>
        bikeData?.motorBattery?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentCharging = useMemo(() =>
        bikeData?.charging?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    const currentUnderpinnings = useMemo(() =>
        bikeData?.underpinnings?.find(
            x => x.variantId === selectedVariant
        ),
        [bikeData, selectedVariant]
    );

    if (loading)
        return (
            <div className="max-w-7xl mx-auto py-20 text-center">
                Loading...
            </div>
        );

    if (!bikeData)
        return (
            <div className="max-w-7xl mx-auto py-20 text-center">
                Bike not found.
            </div>
        );
    console.log("========== BIKE DETAILS DEBUG ==========");

    console.log("Bike:", bikeData.bike);

    console.log("Variants:", bikeData.variants);
    console.log("Selected:", selectedVariant);

    console.log("Engine:", bikeData.engine);

    console.log("Features:", bikeData.features);

    console.log("Dimensions:", bikeData.dimensions);

    console.log("Images:", bikeData.images);

    console.log(
        "Selected variant:",
        selectedVariant,
        typeof selectedVariant
    );

    console.log(
        "Spec variant IDs:",
        bikeData.specs?.map(x => ({
            variantId: x.variantId,
            type: typeof x.variantId
        }))
    );
    console.log("========================================");
    return (

        <div className="bg-slate-50">

            <div className="border-b bg-white">

                <div className="max-w-7xl mx-auto px-6 py-4 text-sm text-slate-500">

                    Home

                    <span className="mx-2">/</span>

                    {bikeData.bike.brand}

                    <span className="mx-2">/</span>

                    {bikeData.bike.name}

                </div>

            </div>

            <div className="max-w-7xl mx-auto px-6 py-8">

                <div className="grid lg:grid-cols-2 gap-10">

                    <BikeImageGallery
                        images={
                            bikeData.images?.length > 0
                                ? bikeData.images
                                : bikeData.bike?.image
                                    ? [
                                        {
                                            imageURL: bikeData.bike.image
                                        }
                                    ]
                                    : []
                        }
                    />

                    <BikeHero
                        bike={bikeData.bike}
                    />

                </div>

                <div className="mt-8">

                    <BikeInfoCards
                        bike={bikeData.bike}
                        spec={currentSpec}
                        engine={currentEngine}
                        features={currentFeatures}
                        dimensions={currentDimensions}
                    />

                </div>

                <div className="mt-8">

                    <BikeVariantSelector
                        variants={bikeData.variants}
                        selectedVariant={selectedVariant}
                        setSelectedVariant={setSelectedVariant}
                    />

                </div>

                <div className="grid grid-cols-12 gap-8 mt-10">

                    <aside className="col-span-3">

                        <BikeStickyMenu />

                    </aside>

                    <main className="col-span-9 space-y-10">

                        {/*
                        <BikeDescription
                            bike={bikeData.bike}
                        />
                        */}

                        <BikeSpecs
                            spec={currentSpec}
                        />

                        <BikeEngineTransmission
                            engine={currentEngine}
                        />

                        <BikeFeatures
                            features={currentFeatures}
                        />

                        <BikeSafety
                            safety={currentSafety}
                        />

                        <BikeMileagePerformance
                            performance={currentPerformance}
                        />

                        <BikeDimensions
                            dimensions={currentDimensions}
                        />

                        <BikeElectricals
                            electricals={currentElectricals}
                        />

                        <BikeTyresBrakes
                            tyres={currentTyres}
                        />

                        {bikeData.bike.isEV && (

                            <BikeMotorBattery
                                motorBattery={currentMotorBattery}
                            />

                        )}

                        {bikeData.bike.isEV && (

                            <BikeCharging
                                charging={currentCharging}
                            />

                        )}

                        <BikeUnderpinnings
                            underpinnings={currentUnderpinnings}
                        />

                    </main>

                </div>

                <div className="space-y-10 mt-16">

                    <SimilarBikesSection
                        bikes={bikeData.similarBikes}
                    />

                    <BikeCompareSection
                        bike={bikeData.bike}
                    />

                    <BikeNewsSection
                        news={bikeData.news}
                    />

                    <BikeBlogsSection
                        blogs={bikeData.blogs}
                    />

                </div>

            </div>

        </div>

    );

}