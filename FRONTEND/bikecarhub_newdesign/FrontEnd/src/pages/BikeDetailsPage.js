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
import ArticleRelatedSections from "../components/common/ArticleRelatedSections";
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
    /*
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
    */
    const currentSpec = useMemo(() =>
        bikeData?.specs?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentEngine = useMemo(() =>
        bikeData?.engine?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentFeatures = useMemo(() =>
        bikeData?.features?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentSafety = useMemo(() =>
        bikeData?.safety?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentPerformance = useMemo(() =>
        bikeData?.performance?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentDimensions = useMemo(() =>
        bikeData?.dimensions?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentElectricals = useMemo(() =>
        bikeData?.electricals?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentTyres = useMemo(() =>
        bikeData?.tyres?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentMotorBattery = useMemo(() =>
        bikeData?.motorBattery?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentCharging = useMemo(() =>
        bikeData?.charging?.find(
            x => Number(x.variantId) === Number(selectedVariant)
        ),
        [bikeData, selectedVariant]
    );

    const currentUnderpinnings = useMemo(() =>
        bikeData?.underpinnings?.find(
            x => Number(x.variantId) === Number(selectedVariant)
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
        <div className="bg-slate-50 w-full overflow-x-hidden">

            {/* Breadcrumb */}
            <div className="border-b bg-white overflow-hidden">

                <div className="w-full max-w-7xl mx-auto px-4 sm:px-6 py-3 sm:py-4 text-xs sm:text-sm text-slate-500 break-words">

                    <span>Home</span>

                    <span className="mx-1 sm:mx-2">/</span>

                    <span>{bikeData.bike.brand}</span>

                    <span className="mx-1 sm:mx-2">/</span>

                    <span>{bikeData.bike.name}</span>

                </div>

            </div>


            {/* Main Container */}
            <div className="w-full max-w-7xl mx-auto px-4 sm:px-6 py-6 sm:py-8 overflow-hidden">

                {/* Image + Hero */}
                <div className="grid grid-cols-1 lg:grid-cols-2 gap-6 lg:gap-10 w-full">

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


                {/* Info Cards */}
                <div className="mt-6 sm:mt-8 w-full min-w-0 overflow-hidden">

                    <BikeInfoCards
                        bike={bikeData.bike}
                        spec={currentSpec}
                        engine={currentEngine}
                        features={currentFeatures}
                        dimensions={currentDimensions}
                    />

                </div>


                {/* Variant Selector */}
                <div className="mt-6 sm:mt-8 w-full min-w-0 overflow-hidden">

                    <BikeVariantSelector
                        variants={bikeData.variants}
                        selectedVariant={selectedVariant}
                        setSelectedVariant={setSelectedVariant}
                    />

                </div>


                {/* Specs + Sticky Menu */}
                <div className="grid grid-cols-1 lg:grid-cols-12 gap-6 lg:gap-8 mt-8 lg:mt-10 w-full">

                    {/* Desktop Sidebar */}
                    <aside className="hidden lg:block lg:col-span-3 min-w-0">

                        <BikeStickyMenu />

                    </aside>


                    {/* Specifications */}
                    <main className="col-span-1 lg:col-span-9 min-w-0 w-full space-y-8 lg:space-y-10">

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


                {/* Related Sections */}
                <div className="w-full min-w-0 space-y-8 lg:space-y-10 mt-10 lg:mt-16 overflow-hidden">

                    <SimilarBikesSection
                        bikes={bikeData.similarBikes}
                    />

                    <BikeCompareSection
                        bike={bikeData.bike}
                    />

                    <BikeNewsSection
                        news={bikeData.news}
                    />

                    <ArticleRelatedSections />

                </div>

            </div>

        </div>
    );

}