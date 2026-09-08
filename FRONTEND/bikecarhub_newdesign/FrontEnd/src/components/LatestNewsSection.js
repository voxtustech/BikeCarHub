import { useEffect, useState } from "react";
import { Calendar } from "lucide-react";
import { useNavigate } from "react-router-dom";

import { SectionTitle } from "./SectionTitle";
import { HScrollCarousel } from "./HScrollCarousel";
import { getLatestNews } from "../api/newsApi";
import { BACKEND_URL } from "../config";

export function LatestNewsSection() {

    const [news, setNews] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    const navigate = useNavigate();


    useEffect(() => {

        async function loadNews() {

            try {

                const data = await getLatestNews();

                console.log("LATEST NEWS API DATA:");
                console.log(data);

                setNews(data);

            }
            catch (err) {

                console.error(
                    "LATEST NEWS LOAD ERROR:",
                    err
                );

                setError(
                    "Unable to load latest news."
                );

            }
            finally {

                setLoading(false);

            }

        }

        loadNews();

    }, []);


    /*
     * Convert database ImageURL into slug
     *
     * Example:
     *
     * latestnews/tvs-jupiter-cng-scooter-launched-with-140-mile-range
     *
     * becomes:
     *
     * tvs-jupiter-cng-scooter-launched-with-140-mile-range
     */
    function getNewsSlug(item) {

        if (item.slug) {

            return item.slug;

        }

        if (item.image) {

            return item.image
                .split("/")
                .filter(Boolean)
                .pop();

        }

        return null;

    }


    if (loading) {

        return (

            <section className="py-10 bg-white border-t border-slate-100">

                <div className="max-w-7xl mx-auto px-6">

                    <SectionTitle>

                        Latest News

                    </SectionTitle>

                    <p className="text-slate-500">

                        Loading latest news...

                    </p>

                </div>

            </section>

        );

    }


    if (error) {

        return (

            <section className="py-10 bg-white border-t border-slate-100">

                <div className="max-w-7xl mx-auto px-6">

                    <SectionTitle>

                        <span
                            onClick={() =>
                                navigate("/latest-news")
                            }
                            className="cursor-pointer hover:text-blue-600"
                        >

                            Latest News →

                        </span>

                    </SectionTitle>

                    <p className="text-red-500">

                        {error}

                    </p>

                </div>

            </section>

        );

    }


    return (

        <section className="py-10 bg-white border-t border-slate-100">

            <div className="max-w-7xl mx-auto px-6">

                <SectionTitle>

                    <span
                        onClick={() =>
                            navigate("/latest-news")
                        }
                        className="cursor-pointer hover:text-blue-600 transition-colors duration-200"
                    >

                        Latest News

                    </span>

                </SectionTitle>


                <HScrollCarousel itemWidth={320}>

                    {news.map((item) => {

                        const slug = getNewsSlug(item);

                        return (

                            <div
                                key={item.id}

                                onClick={() => {

                                    console.log(
                                        "================================="
                                    );

                                    console.log(
                                        "LATEST NEWS CARD CLICKED:"
                                    );

                                    console.log(item);

                                    console.log(
                                        "IMAGE:",
                                        item.image
                                    );

                                    console.log(
                                        "SLUG FROM API:",
                                        item.slug
                                    );

                                    console.log(
                                        "FINAL SLUG:",
                                        slug
                                    );

                                    console.log(
                                        "================================="
                                    );


                                    if (!slug) {

                                        console.error(
                                            "LATEST NEWS SLUG IS MISSING:",
                                            item
                                        );

                                        return;

                                    }


                                    navigate(
                                        `/latest-news/${encodeURIComponent(slug)}`
                                    );

                                }}

                                className="
                                    group
                                    w-80
                                    bg-white
                                    rounded-xl
                                    overflow-hidden
                                    shadow-sm
                                    hover:shadow-xl
                                    transition-all
                                    duration-300
                                    cursor-pointer
                                    border
                                    border-slate-100
                                    hover:-translate-y-1
                                "
                            >


                                {/* IMAGE */}

                                <div className="h-44 overflow-hidden bg-slate-100">

                                    <img
                                        src={
                                            item.imageFolder
                                                ? `${BACKEND_URL}${item.imageFolder}`
                                                : `${BACKEND_URL}${item.image}`
                                        }

                                        alt={item.heading}

                                        className="
                                            w-full
                                            h-full
                                            object-cover
                                            group-hover:scale-105
                                            transition-transform
                                            duration-500
                                        "

                                        onError={(e) => {

                                            console.error(
                                                "NEWS IMAGE FAILED:",
                                                e.currentTarget.src
                                            );

                                        }}
                                    />

                                </div>


                                {/* CONTENT */}

                                <div className="p-4">

                                    <p
                                        className="
                                            text-slate-800
                                            leading-snug
                                            mb-2
                                            line-clamp-2
                                        "
                                        style={{
                                            fontFamily:
                                                "var(--font-display)",
                                            fontWeight: 600,
                                            fontSize: "14px"
                                        }}
                                    >

                                        {item.heading}

                                    </p>


                                    {/* DATE */}

                                    <div
                                        className="
                                            flex
                                            items-center
                                            gap-1.5
                                            text-slate-400
                                            text-xs
                                            mb-3
                                        "
                                    >

                                        <span>

                                            {item.brand !== "NULL"
                                                ? item.brand
                                                : "BikeCarHub"}

                                        </span>

                                        <span>|</span>

                                        <Calendar size={11} />

                                        <span>

                                            {item.date
                                                ? new Date(
                                                    item.date
                                                ).toLocaleDateString(
                                                    "en-IN",
                                                    {
                                                        day: "numeric",
                                                        month: "short",
                                                        year: "numeric"
                                                    }
                                                )
                                                : ""
                                            }

                                        </span>

                                    </div>


                                    {/* SUMMARY */}

                                    <p
                                        className="
                                            text-sm
                                            text-slate-500
                                            line-clamp-2
                                            mb-4
                                        "
                                    >

                                        {item.summary}

                                    </p>


                                    {/* READ MORE */}

                                    <button
                                        type="button"
                                        onClick={(e) => {

                                            /*
                                             * Prevent the button from
                                             * triggering anything twice.
                                             */

                                            e.stopPropagation();

                                            if (!slug) {

                                                console.error(
                                                    "LATEST NEWS SLUG IS MISSING:",
                                                    item
                                                );

                                                return;

                                            }

                                            navigate(
                                                `/latest-news/${encodeURIComponent(slug)}`
                                            );

                                        }}

                                        className="
                                            text-xs
                                            hover:underline
                                            transition-colors
                                        "

                                        style={{
                                            color: "#0A0A2B",
                                            fontWeight: 600
                                        }}
                                    >

                                        Read More →

                                    </button>

                                </div>

                            </div>

                        );

                    })}

                </HScrollCarousel>

            </div>

        </section>

    );

}