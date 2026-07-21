import { useEffect, useState } from "react";
import { SectionTitle } from "./SectionTitle";
import { HScrollCarousel } from "./HScrollCarousel";
import { BACKEND_URL } from "../config";
import { getValueForMoney } from "../api/valueForMoneyApi";
import { getValueForMoneyArticles } from "../api/valueForMoneyApi";
import { useNavigate } from "react-router-dom";

export function ValueForMoneySection() {

    const [articles, setArticles] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const navigate = useNavigate();

    useEffect(() => {

        async function loadArticles() {

            try {

                const data = await getValueForMoneyArticles();

                setArticles(data);

            }
            catch (err) {

                console.error(err);
                setError("Unable to load articles.");

            }
            finally {

                setLoading(false);

            }

        }

        loadArticles();

    }, []);

    if (loading) {

        return (
            <section className="py-10 bg-white border-t border-slate-100">
            
                <div className="max-w-7xl mx-auto px-6">
                    <SectionTitle
                        onClick={() => navigate("/value-for-money")}
                    >
                        Value For Money
                    </SectionTitle>
                    <p className="text-slate-500">Loading...</p>
                </div>
               
            </section>
        );

    }

    if (error) {

        return (
            <section className="py-10 bg-white border-t border-slate-100">
               
                <div className="max-w-7xl mx-auto px-6">
                    <SectionTitle
                        onClick={() => navigate("/value-for-money")}
                    >
                        Value For Money
                    </SectionTitle>
                    <p className="text-red-500">{error}</p>
                </div>
                
            </section>
        );

    }

    const slugMap = {
        "value-for-money/best-value-for-money-variant-of-tata-punch": "tatapunch",
        "value-for-money/best-value-for-money-variant-of-tata-tiago": "tatatiago",
        "value-for-money/best-value-for-money-variant-of-tata-altroz-facelift": "tataaltrozfacelift",
        "value-for-money/alto-k10-value-for-money-varient": "altok10",
        "value-for-money/maruti-suzuki-wagonR-2025-the-value-for-money-variant": "marutisuzukiwagonr2025",
        "value-for-money/skoda-kylaq-value-for-money-variant": "skodakylaq",
        "value-for-money/maruti-suzuki-swift-2025-the-value-for-money-variant": "marutisuzukiswift2025",
        "value-for-money/best-value-for-money-variant-of-the-maruti-suzuki-s-presso": "marutisuzukispresso",
        "value-for-money/best-value-for-money-variant-of-maruti-suzuki-nexa-ignis": "marutisuzukinexaignis",
        "value-for-money/maruti-suzuki-ertiga-zXIO-the-value-for-money-variant": "marutisuzukiertigazxio",
        "value-for-money/maruti-suzuki-dzire-2025-the-value-for-money-variant": "marutisuzukidzire2025",
        "value-for-money/maruti-suzuki-celerio-the-value-for-money-variant": "marutisuzukicelerio",
        "value-for-money/maruti-suzuki-brezza-the-value-for-money-variant": "marutisuzukibrezza",
        "value-for-money/kia-syros-value-for-money-varient": "kiasyros"
    };

    return (

        <section className="py-10 bg-white border-t border-slate-100">

            <div className="max-w-7xl mx-auto px-6">

                <SectionTitle
                    onClick={() => navigate("/value-for-money")}
                >
                    Value For Money
                </SectionTitle>

                <HScrollCarousel itemWidth={340}>

                    {articles.map((article) => (

                        <div
                            key={article.id}
                            className="w-80 bg-white rounded-lg overflow-hidden shadow-sm hover:shadow-lg transition-all duration-300 cursor-pointer border border-slate-100 hover:-translate-y-1"
                            onClick={() => {
                                const route = slugMap[article.slug];

                                if (route) {
                                    navigate(`/value-for-money/${route}`);
                                } else {
                                    console.log("No mapping found:", article.slug);
                                }
                            }}
                        >

                            <div className="h-48 overflow-hidden bg-slate-100">

                                <img
                                    src={`${BACKEND_URL}${article.image}`}
                                    alt={article.heading}
                                    className="w-full h-full object-cover hover:scale-105 transition-transform duration-500"
                                />

                            </div>

                            <div className="p-4">

                                <p
                                    className="text-slate-800 leading-snug line-clamp-2"
                                    style={{
                                        fontFamily: "var(--font-display)",
                                        fontWeight: 600,
                                        fontSize: "15px"
                                    }}
                                >

                                    {article.heading}

                                </p>

                                <div className="flex items-center justify-between mt-4">

                                    <span className="text-xs text-slate-400">

                                        {new Date(article.date).toLocaleDateString("en-IN", {
                                            day: "numeric",
                                            month: "short",
                                            year: "numeric"
                                        })}

                                    </span>

                                    <span className="text-[#2563EB] text-sm font-semibold">

                                        Read More →

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