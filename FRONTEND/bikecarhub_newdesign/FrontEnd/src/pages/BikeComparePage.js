import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";


import CompareOverview from "../components/CompareOverview";
import CompareEngine from "../components/CompareEngine";
import CompareFeatures from "../components/CompareFeatures";
import CompareDimensions from "../components/CompareDimensions";
import ComparePerformance from "../components/ComparePerformance";
import CompareSafety from "../components/CompareSafety";
import CompareElectricals from "../components/CompareElectricals";
import CompareTyres from "../components/CompareTyres";
import CompareUnderpinnings from "../components/CompareUnderpinnings";
import CompareSelector from "../components/CompareSelector";

import { getBikeComparison } from "../api/bikeCompareApi";

import { useSearchParams } from "react-router-dom";

export default function BikeComparePage() {
    console.log("✅ BikeComparePage mounted");

    const navigate = useNavigate();

    const [searchParams] = useSearchParams();

    const bike1Id = searchParams.get("bike1");
    const variant1Id = searchParams.get("variant1");

    const bike2Id = searchParams.get("bike2");
    const variant2Id = searchParams.get("variant2");

    const [comparison, setComparison] = useState(null);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");

    useEffect(() => {

        if (!bike1Id || !bike2Id) {

            setLoading(false);

            return;

        }

        loadComparison();

    }, [bike1Id, variant1Id, bike2Id, variant2Id]);

    async function loadComparison() {

        try {

            setLoading(true);

            const data = await getBikeComparison(
                bike1Id,
                variant1Id,
                bike2Id,
                variant2Id
            );

            setComparison(data);

        }

        catch (err) {
            console.error("Comparison API Error:", err);

            if (err.response) {
                console.log("Status:", err.response.status);
                console.log("Body:", err.response.data);
            }

            setError("Unable to load comparison.");
        }

        finally {

            setLoading(false);

        }

    }

    function handleCompare(
        firstBikeId,
        firstVariantId,
        secondBikeId,
        secondVariantId
    ) {

        navigate(
            `/compare?bike1=${firstBikeId}&variant1=${firstVariantId}&bike2=${secondBikeId}&variant2=${secondVariantId}`
        );

    }

    console.log("Comparison object:", comparison);

    if (loading) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-12">

                <p className="text-slate-500 text-lg">

                    Loading comparison...

                </p>

            </div>

        );

    }

    return (

        <div className="bg-slate-50 min-h-screen">

            <div className="max-w-7xl mx-auto px-6 py-10">
                
                {error && (

                    <div className="mt-8 rounded-xl bg-red-50 border border-red-200 p-4 text-red-600">

                        {error}

                    </div>

                )}

                {!comparison && !error && (
                    <CompareSelector onCompare={handleCompare} />
                )}

                {comparison && (
                    <>
                      

                        <CompareOverview comparison={comparison} />
                        <CompareEngine comparison={comparison} />
                        <ComparePerformance comparison={comparison} />
                        <CompareDimensions comparison={comparison} />
                        <CompareFeatures comparison={comparison} />
                        <CompareSafety comparison={comparison} />
                        <CompareElectricals comparison={comparison} />
                        <CompareTyres comparison={comparison} />
                        <CompareUnderpinnings comparison={comparison} />
                    </>
                )}

            </div>

        </div>

    );

}