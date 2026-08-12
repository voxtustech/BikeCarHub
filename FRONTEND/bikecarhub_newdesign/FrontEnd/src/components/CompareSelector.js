import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import {
    fetchBrands,
    fetchModels,
    fetchVariants,
    fetchBikeForCompare
} from "../api/compareSelectorApi";

export default function CompareSelector({
    bike1Id,
    variant1Id,
    onCompare
}) {
    console.log("✅ CompareSelector mounted");

    const navigate = useNavigate();

    /* ---------------- Bike 1 ---------------- */

    const [brand1, setBrand1] = useState("");
    const [model1, setModel1] = useState(null);
    const [variant1, setVariant1] = useState(null);

    const [models1, setModels1] = useState([]);
    const [variants1, setVariants1] = useState([]);

    /* ---------------- Bike 2 ---------------- */

    const [brand2, setBrand2] = useState("");
    const [model2, setModel2] = useState(null);
    const [variant2, setVariant2] = useState(null);

    const [models2, setModels2] = useState([]);
    const [variants2, setVariants2] = useState([]);

    /* ---------------- Shared ---------------- */

    const [brands, setBrands] = useState([]);

    const [loading, setLoading] = useState(true);

    /* -------------------------------------------------- */

    useEffect(() => {

        async function loadBrands() {

            try {

                const data = await fetchBrands();

                console.log("Brands from API:", data);

                setBrands(data);

            } catch (err) {

                console.error(err);

            } finally {

                setLoading(false);

            }

        }

        loadBrands();

    }, []);
/*
    useEffect(() => {

        if (!bike1Id)
            return;

        async function loadBike() {

            const bike = await fetchBikeForCompare(bike1Id);

            setBrand1(bike.brandName);

            const models = await fetchModels(bike.brandName);

            setModels1(models);

            const selectedModel =
                models.find(
                    x => x.id === bike.modelId
                );

            setModel1(selectedModel);

            const variants =
                await fetchVariants(bike.modelId);

            setVariants1(variants);

            const selectedVariant =
                variants.find(
                    x => x.id === bike.variantId
                );

            setVariant1(selectedVariant);

        }

        loadBike();

    }, [bike1Id]);
*/
    useEffect(() => {

        if (!variant1Id) {
            return;
        }

        const loadBike = async () => {

            try {

                console.log(
                    "Loading Bike 1 from variant:",
                    variant1Id
                );

                const bike = await fetchBikeForCompare(variant1Id);

                console.log("Bike returned from API:", bike);

                setBrand1(bike.brandName);

                const models = await fetchModels(bike.brandName);

                setModels1(models);

                const selectedModel = models.find(
                    x => x.id === bike.modelId
                );

                setModel1(selectedModel);

                const variants = await fetchVariants(bike.modelId);

                setVariants1(variants);

                const selectedVariant = variants.find(
                    x => x.id === bike.variantId
                );

                setVariant1(selectedVariant);

            } catch (error) {

                console.error("Error loading bike for compare:", error);

            }

        };

        loadBike();

    }, [variant1Id]);


    /* -------------------------------------------------- */

    useEffect(() => {

        if (!brand1) {

            setModels1([]);
            setModel1(null);
            setVariants1([]);
            setVariant1(null);

            return;

        }

        async function loadModels() {

            const data = await fetchModels(brand1);

            setModels1(data);

            setModel1(null);
            setVariants1([]);
            setVariant1(null);

        }

        loadModels();

    }, [brand1]);

    /* -------------------------------------------------- */

    useEffect(() => {

        if (!model1) {

            setVariants1([]);
            setVariant1(null);

            return;

        }

        async function loadVariants() {

            const data = await fetchVariants(model1.id);

            setVariants1(data);

            setVariant1(null);

        }

        loadVariants();

    }, [model1]);

    /* -------------------------------------------------- */

    useEffect(() => {

        if (!brand2) {

            setModels2([]);
            setModel2(null);
            setVariants2([]);
            setVariant2(null);

            return;

        }

        async function loadModels() {

            const data = await fetchModels(brand2);

            setModels2(data);

            setModel2(null);
            setVariants2([]);
            setVariant2(null);

        }

        loadModels();

    }, [brand2]);

    /* -------------------------------------------------- */

    useEffect(() => {

        if (!model2) {

            setVariants2([]);
            setVariant2(null);

            return;

        }

        async function loadVariants() {

            const data = await fetchVariants(model2.id);

            setVariants2(data);

            setVariant2(null);

        }

        loadVariants();

    }, [model2]);

    /* -------------------------------------------------- */

    function compare() {

        if (
            !model1 ||
            !variant1 ||
            !model2 ||
            !variant2
        ) {
            alert("Please select both bikes and their variants.");
            return;
        }

        if (onCompare) {
            onCompare(
                bike1Id || model1.id,
                variant1.id,
                model2.id,
                variant2.id
            );
        }

    }

    if (loading) {

        return (
            <div className="py-20 text-center text-slate-500">
                Loading...
            </div>
        );

    }

    console.log("Brands state:", brands);

    return (
        <div className="bg-white rounded-3xl shadow-lg p-8">

            <h2 className="text-3xl font-bold mb-8">
                Compare Bikes
            </h2>

            <div className="grid grid-cols-1 lg:grid-cols-2 gap-10">
                {/* ---------------- Bike 1 ---------------- */}

                <div className="space-y-5">

                    <h3 className="text-xl font-semibold">
                        Bike 1
                    </h3>

                    <select
                        value={brand1}
                        disabled={!!bike1Id}
                        onChange={(e) => setBrand1(e.target.value)}
                        className="w-full border rounded-xl p-3"
                    >
                        <option value="">Select Brand</option>

                        {Array.isArray(brands) &&
                            brands.map((brand) => (
                                <option key={brand.id} value={brand.name}>
                                    {brand.name}
                                </option>
                            ))}
                    </select>

                    <select
                        value={model1?.value || ""}
                        disabled={!brand1 || !!bike1Id}
                        onChange={(e) => {

                            const selected =
                                models1.find(
                                    x => x.value === e.target.value
                                );

                            setModel1(selected);

                        }}
                        className="w-full border rounded-xl p-3"
                    >
                        <option value="">
                            Select Model
                        </option>

                        {models1.map((model) => (

                            <option
                                key={model.id}
                                value={model.value}
                            >
                                {model.label}
                            </option>

                        ))}

                    </select>

                    <select
                        value={variant1?.id || ""}
                        disabled={!model1 || !!bike1Id}
                        onChange={(e) => {

                            const selected =
                                variants1.find(
                                    x => x.id === Number(e.target.value)
                                );

                            setVariant1(selected);

                        }}
                        className="w-full border rounded-xl p-3"
                    >
                        <option value="">
                            Select Variant
                        </option>

                        {variants1.map((variant) => (

                            <option
                                key={variant.id}
                                value={variant.id}
                            >
                                {variant.name}
                            </option>

                        ))}

                    </select>

                </div>

                {/* ---------------- Bike 2 ---------------- */}

                <div className="space-y-5">

                    <h3 className="text-xl font-semibold">
                        Bike 2
                    </h3>

                    <select
                        value={brand2}
                        onChange={(e) => setBrand2(e.target.value)}
                        className="w-full border rounded-xl p-3"
                    >
                        <option value="">Select Brand</option>

                        {Array.isArray(brands) &&
                            brands.map((brand) => (
                                <option key={brand.id} value={brand.name}>
                                    {brand.name}
                                </option>
                            ))}
                    </select>

                    <select
                        value={model2?.value || ""}
                        disabled={!brand2}
                        onChange={(e) => {

                            const selected =
                                models2.find(
                                    x => x.value === e.target.value
                                );

                            setModel2(selected);

                        }}
                        className="w-full border rounded-xl p-3"
                    >
                        <option value="">
                            Select Model
                        </option>

                        {models2.map((model) => (

                            <option
                                key={model.id}
                                value={model.value}
                            >
                                {model.label}
                            </option>

                        ))}

                    </select>

                    <select
                        value={variant2?.id || ""}
                        disabled={!model2}
                        onChange={(e) => {

                            const selected =
                                variants2.find(
                                    x => x.id === Number(e.target.value)
                                );

                            setVariant2(selected);

                        }}
                        className="w-full border rounded-xl p-3"
                    >
                        <option value="">
                            Select Variant
                        </option>

                        {variants2.map((variant) => (

                            <option
                                key={variant.id}
                                value={variant.id}
                            >
                                {variant.name}
                            </option>

                        ))}

                    </select>

                </div>

            </div>

            <div className="mt-10 flex justify-center">

                <button
                    onClick={compare}
                    className="bg-blue-600 hover:bg-blue-700 text-white px-10 py-3 rounded-xl font-semibold transition"
                >
                    Compare Bikes
                </button>

            </div>

        </div>

    );

}