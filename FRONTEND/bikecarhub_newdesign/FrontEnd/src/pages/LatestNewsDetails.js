import React, {
    useEffect,
    useState
} from "react";

import {
    useParams
} from "react-router-dom";

import {
    Calendar
} from "lucide-react";

import {
    BACKEND_URL
} from "../config";

import {
    getLatestNewsBySlug
} from "../api/newsApi";

import latestNewsArticles
    from "../data/latestNews/Index";

import UpcomingBikeImageGallery
    from "../components/upcomingBikes/UpcomingBikeImageGallery";

import UpcomingBikeBulletList
    from "../components/upcomingBikes/UpcomingBikeBulletList";

import UpcomingBikeTable
    from "../components/upcomingBikes/UpcomingBikeTable";

import UpcomingBikeFAQ
    from "../components/upcomingBikes/UpcomingBikeFAQ";


export default function LatestNewsDetails() {

    const {
        slug
    } = useParams();


    const [
        article,
        setArticle
    ] = useState(null);


    const [
        loading,
        setLoading
    ] = useState(true);


    const [
        error,
        setError
    ] = useState("");


    useEffect(() => {

        async function loadArticle() {

            console.log(
                "================================="
            );

            console.log(
                "LATEST NEWS DETAILS PAGE"
            );

            console.log(
                "Slug from URL:",
                slug
            );

            console.log(
                "================================="
            );


            if (!slug) {

                console.error(
                    "No slug received from URL."
                );

                setError(
                    "Latest news slug is missing."
                );

                setLoading(false);

                return;

            }


            try {

                /*
                 * =================================================
                 * 1. Find full article from local data
                 * =================================================
                 */

                const localArticle =
                    latestNewsArticles[slug];


                console.log(
                    "LOCAL ARTICLE:",
                    localArticle
                );


                if (!localArticle) {

                    console.error(
                        "No local article found for slug:",
                        slug
                    );

                    console.log(
                        "Available local articles:",
                        Object.keys(
                            latestNewsArticles
                        )
                    );

                    setError(
                        "Full latest news article content was not found."
                    );

                    return;

                }


                /*
                 * =================================================
                 * 2. Get metadata from backend
                 * =================================================
                 */

                let apiArticle = null;


                try {

                    apiArticle =
                        await getLatestNewsBySlug(
                            slug
                        );


                    console.log(
                        "API ARTICLE:",
                        apiArticle
                    );

                }
                catch (apiError) {

                    console.warn(
                        "API article metadata unavailable:",
                        apiError
                    );

                }


                /*
                 * =================================================
                 * 3. Combine local full article + DB metadata
                 * =================================================
                 */

                const finalArticle = {

                    ...localArticle,


                    title:
                        apiArticle?.heading ||
                        localArticle.title,


                    description:
                        apiArticle?.summary ||
                        localArticle.description,


                    date:
                        apiArticle?.date ||
                        localArticle.date,


                    heroImage:
                        localArticle.heroImage ||
                        (
                            apiArticle?.imageFolder
                                ? `${BACKEND_URL}${apiArticle.imageFolder}`
                                : null
                        )

                };


                console.log(
                    "================================="
                );

                console.log(
                    "FINAL ARTICLE:",
                    finalArticle
                );

                console.log(
                    "SECTIONS:",
                    finalArticle.sections
                );

                console.log(
                    "TABLES:",
                    finalArticle.tables
                );

                console.log(
                    "FAQS:",
                    finalArticle.faqs
                );

                console.log(
                    "================================="
                );


                setArticle(
                    finalArticle
                );

            }
            catch (err) {

                console.error(
                    "LATEST NEWS DETAILS ERROR:",
                    err
                );

                setError(
                    "Unable to load latest news article."
                );

            }
            finally {

                setLoading(false);

            }

        }


        loadArticle();

    }, [slug]);


    /*
     * =========================================================
     * LOADING
     * =========================================================
     */

    if (loading) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-20">

                <p className="
                    text-center
                    text-slate-500
                    text-xl
                ">

                    Loading article...

                </p>

            </div>

        );

    }


    /*
     * =========================================================
     * ERROR
     * =========================================================
     */

    if (error || !article) {

        return (

            <div className="
                max-w-7xl
                mx-auto
                px-6
                py-20
            ">

                <div className="
                    bg-red-50
                    border
                    border-red-200
                    rounded-2xl
                    p-8
                    text-center
                ">

                    <h2 className="
                        text-3xl
                        font-bold
                    ">

                        Article Not Found

                    </h2>


                    <p className="
                        mt-3
                        text-slate-600
                    ">

                        {error}

                    </p>

                </div>

            </div>

        );

    }


    return (

        <main className="
            bg-slate-50
            min-h-screen
        ">

            <article className="
                max-w-5xl
                mx-auto
                px-6
                py-12
            ">


                {/* ================================================= */}
                {/* TITLE */}
                {/* ================================================= */}

                <h1 className="
                    text-4xl
                    md:text-5xl
                    font-bold
                    text-slate-900
                    leading-tight
                ">

                    {article.title}

                </h1>


                {/* ================================================= */}
                {/* DATE */}
                {/* ================================================= */}

                {article.date && (

                    <div className="
                        flex
                        items-center
                        gap-3
                        text-slate-500
                        mt-5
                        mb-8
                    ">

                        <Calendar size={18} />

                        <span>

                            {article.date}

                        </span>

                    </div>

                )}


                {/* ================================================= */}
                {/* HERO IMAGE */}
                {/* ================================================= */}

                {article.heroImage && (

                    <div className="mb-10">

                        <img
                            src={article.heroImage}
                            alt={article.title}
                            className="
                                w-full
                                max-h-[600px]
                                object-cover
                                rounded-3xl
                                shadow-sm
                            "
                        />

                    </div>

                )}


                {/* ================================================= */}
                {/* DESCRIPTION */}
                {/* ================================================= */}

                {article.description && (

                    <div className="
                        text-xl
                        leading-8
                        text-slate-700
                        mb-10
                    ">

                        {article.description}

                    </div>

                )}


                {/* ================================================= */}
                {/* SECTIONS */}
                {/* ================================================= */}

                {article.sections?.map(
                    (section, index) => (

                        <section
                            key={index}
                            className="
                                bg-white
                                rounded-3xl
                                border
                                border-slate-200
                                shadow-sm
                                p-8
                                mb-10
                            "
                        >


                            {/* SECTION TITLE */}

                            {section.title && (

                                <h2 className="
                                    text-3xl
                                    font-bold
                                    text-slate-900
                                    mb-6
                                ">

                                    {section.title}

                                </h2>

                            )}


                            {/* SECTION IMAGES */}

                            {section.images?.length > 0 && (

                                <div className="mb-8">

                                    <UpcomingBikeImageGallery
                                        images={
                                            section.images
                                        }
                                    />

                                </div>

                            )}


                            {/* PARAGRAPHS */}

                            {section.paragraphs?.map(
                                (
                                    paragraph,
                                    paragraphIndex
                                ) => (

                                    <p
                                        key={
                                            paragraphIndex
                                        }
                                        className="
                                            text-lg
                                            leading-8
                                            text-slate-700
                                            mb-5
                                        "
                                    >

                                        {paragraph}

                                    </p>

                                )
                            )}


                            {/* BULLETS */}

                            {section.points?.length > 0 && (

                                <div className="mt-6">

                                    <UpcomingBikeBulletList
                                        points={
                                            section.points
                                        }
                                    />

                                </div>

                            )}

                        </section>

                    )
                )}


                {/* ================================================= */}
                {/* TABLES */}
                {/* ================================================= */}

                {article.tables?.map(
                    (table, index) => (

                        <UpcomingBikeTable
                            key={index}
                            table={table}
                        />

                    )
                )}


                {/* ================================================= */}
                {/* FAQ */}
                {/* ================================================= */}

                {article.faqs?.length > 0 && (

                    <UpcomingBikeFAQ
                        faqs={
                            article.faqs
                        }
                    />

                )}

            </article>

        </main>

    );

}