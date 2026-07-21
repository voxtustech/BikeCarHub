import { useEffect, useState } from "react";
import { SectionTitle } from "./SectionTitle";
import { HScrollCarousel } from "./HScrollCarousel";
import { getCompareCards } from "../api/compareApi";
import { BACKEND_URL } from "../config";
import { useNavigate } from "react-router-dom";

export function CompareBikesSection() {

    const [comparisons, setComparisons] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const navigate = useNavigate();

    useEffect(() => {

        async function loadComparisons() {

            try {

                const data = await getCompareCards();
                console.log(data[0]);
                console.table(data);

                setComparisons(data);

            }
            catch (err) {

                console.error(err);
                setError("Unable to load comparisons.");

            }
            finally {

                setLoading(false);

            }

        }

        loadComparisons();

    }, []);

    if (loading) {

        return (
            <section className="py-10 bg-white border-t border-slate-100">
                <div className="max-w-7xl mx-auto px-6">
                    <SectionTitle>Compare Bikes</SectionTitle>
                    <p className="text-slate-500">Loading comparisons...</p>
                </div>
            </section>
        );

    }

    if (error) {

        return (
            <section className="py-10 bg-white border-t border-slate-100">
                <div className="max-w-7xl mx-auto px-6">
                    <SectionTitle>Compare Bikes</SectionTitle>
                    <p className="text-red-500">{error}</p>
                </div>
            </section>
        );

    }

    return (

        <section className="py-10 bg-white border-t border-slate-100">

            <div className="max-w-7xl mx-auto px-6">

                <SectionTitle>Compare Bikes</SectionTitle>

                <HScrollCarousel itemWidth={380}>

                    {comparisons.map((item) => (

                        <div
                            key={item.id}
                            onClick={() =>
                                navigate(
                                    `/compare?bike1=${item.bike1Id}&variant1=${item.bike1VariantId}&bike2=${item.bike2Id}&variant2=${item.bike2VariantId}`
                                )
                            }
                            className="w-96 rounded-lg overflow-hidden shadow-sm hover:shadow-lg transition-all duration-300 cursor-pointer border border-slate-100 hover:-translate-y-1"
                        >

                            <div className="relative h-44 overflow-hidden">

                                <img
                                    src={`${BACKEND_URL}${item.image}`}
                                    alt={item.title}
                                    className="w-full h-full object-cover hover:scale-105 transition-transform duration-500"
                                />

                                <div className="absolute inset-0 flex items-center justify-center">

                                    <span
                                        className="bg-white text-slate-800 rounded-full w-10 h-10 flex items-center justify-center shadow-lg"
                                        style={{
                                            fontFamily: "var(--font-display)",
                                            fontWeight: 800,
                                            fontSize: "13px"
                                        }}
                                    >
                                        VS
                                    </span>

                                </div>

                            </div>

                            <div className="bg-white p-4">

                                <p
                                    className="text-slate-800 text-center line-clamp-2"
                                    style={{
                                        fontFamily: "var(--font-display)",
                                        fontWeight: 600,
                                        fontSize: "15px"
                                    }}
                                >
                                    {item.title}
                                </p>

                                <div className="flex justify-center mt-4">

                                    <span className="text-[#2563EB] text-sm font-semibold">

                                        Compare Now →

                                    </span>

                                </div>

                            </div>

                        </div>

                    ))}

                </HScrollCarousel>

            </div>

        </section>

    );

}