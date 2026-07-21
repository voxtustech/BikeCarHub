import React, { useEffect, useState } from "react";
import { ArrowRight } from "lucide-react";
import { Link } from "react-router-dom";

import { getRelatedLatestNewsArticles } from "../../api/latestNewsApi";
import LatestNewsCard from "./LatestNewsCard";

export default function RelatedArticles({

    currentSlug

}) {

    const [articles, setArticles] = useState([]);

    const [loading, setLoading] = useState(true);

    useEffect(() => {

        loadArticles();

    }, [currentSlug]);

    async function loadArticles() {

        try {

            setLoading(true);

            const data = await getRelatedValueForMoneyArticles(

                currentSlug

            );

            setArticles(data);

        }

        catch (err) {

            console.error(err);

        }

        finally {

            setLoading(false);

        }

    }

    if (loading) {

        return (

            <section className="mt-16">

                <div className="text-center text-slate-500">

                    Loading related articles...

                </div>

            </section>

        );

    }

    if (!articles.length) return null;

    return (

        <section className="mt-20">

            <div className="flex items-center justify-between mb-8">

                <div>

                    <h2 className="text-3xl font-bold text-slate-900">

                        More Latest News Picks

                    </h2>

                    <p className="text-slate-500 mt-2">

                        Continue exploring

                    </p>

                </div>

                <Link

                    to="/value-for-money"

                    className="flex items-center gap-2 font-semibold text-blue-600 hover:gap-3 transition-all"

                >

                    View All

                    <ArrowRight size={18} />

                </Link>

            </div>

            <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-8">

                {articles.map(article => (

                    <ValueForMoneyCard

                        key={article.id}

                        article={article}

                    />

                ))}

            </div>

        </section>

    );

}