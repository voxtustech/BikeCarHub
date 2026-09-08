import { useEffect, useState } from "react";
import { Calendar } from "lucide-react";
import { useNavigate } from "react-router-dom";

import { getBlogs } from "../api/blogApi";
import { BACKEND_URL } from "../config";

const PAGE_SIZE = 12;


/* =========================================================
   BLOG CARD
========================================================= */

function BlogCard({ blog }) {

    const [hovered, setHovered] = useState(false);

    const navigate = useNavigate();


    const handleClick = () => {

        console.log(
            "BLOG CARD CLICKED:",
            blog
        );

        console.log(
            "BLOG SLUG:",
            blog.slug
        );


        if (!blog.slug) {

            console.error(
                "Blog slug is missing:",
                blog
            );

            return;
        }


        navigate(
            `/blogs/${encodeURIComponent(blog.slug)}`
        );

    };


    return (

        <div
            onMouseEnter={() => setHovered(true)}
            onMouseLeave={() => setHovered(false)}
            onClick={handleClick}

            className="rounded-xl overflow-hidden cursor-pointer flex flex-col"

            style={{
                border: hovered
                    ? "1.5px solid #0A0A2B"
                    : "1.5px solid #E5E7EB",

                background: hovered
                    ? "#F5F6FF"
                    : "#ffffff",

                boxShadow: hovered
                    ? "0 8px 32px rgba(10,10,43,0.13)"
                    : "0 2px 8px rgba(0,0,0,0.05)",

                transition: "all 0.22s ease",

                transform: hovered
                    ? "translateY(-4px)"
                    : "translateY(0)",
            }}
        >

            {/* ================================================= */}
            {/* IMAGE */}
            {/* ================================================= */}

            <div
                className="overflow-hidden"
                style={{
                    height: "168px",
                    flexShrink: 0
                }}
            >

                {blog.image && (

                    <img
                        src={
                            blog.image.startsWith("http")
                                ? blog.image
                                : `${BACKEND_URL}${blog.image}`
                        }

                        alt={blog.title}

                        className="w-full h-full object-cover"

                        onError={(e) => {

                            console.error(
                                "BLOG IMAGE FAILED:",
                                blog.image
                            );

                            e.currentTarget.style.display = "none";

                        }}

                        style={{
                            transform: hovered
                                ? "scale(1.05)"
                                : "scale(1)",

                            transition:
                                "transform 0.4s ease",
                        }}
                    />

                )}

            </div>


            {/* ================================================= */}
            {/* CONTENT */}
            {/* ================================================= */}

            <div className="p-4 flex flex-col flex-1 gap-2">

                <p
                    style={{
                        fontFamily:
                            "var(--font-display)",

                        fontWeight: 600,

                        fontSize: "13px",

                        color: hovered
                            ? "#0A0A2B"
                            : "#1F2937",

                        lineHeight: 1.45,

                        display: "-webkit-box",

                        WebkitLineClamp: 2,

                        WebkitBoxOrient: "vertical",

                        overflow: "hidden",

                        transition:
                            "color 0.2s",
                    }}
                >

                    {blog.title}

                </p>


                {/* DATE */}

                <div
                    className="flex items-center gap-1.5"

                    style={{
                        color: "#6B7280",
                        fontSize: "12px"
                    }}
                >

                    <Calendar size={11} />

                    <span
                        style={{
                            fontFamily:
                                "var(--font-body)"
                        }}
                    >

                        {blog.date
                            ? new Date(
                                blog.date
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

                {blog.summary && (

                    <p
                        className="text-xs text-slate-500 line-clamp-2"
                    >

                        {blog.summary}

                    </p>

                )}


                {/* BUTTON */}

                <div className="mt-auto pt-2">

                    <button
                        type="button"

                        onClick={(e) => {

                            e.stopPropagation();

                            handleClick();

                        }}

                        className="px-4 py-1.5 rounded text-white text-xs transition-all"

                        style={{
                            background: hovered
                                ? "#06061A"
                                : "#0A0A2B",

                            fontFamily:
                                "var(--font-display)",

                            fontWeight: 600,

                            letterSpacing:
                                "0.02em",
                        }}
                    >

                        View Details

                    </button>

                </div>

            </div>

        </div>

    );

}


/* =========================================================
   BLOGS PAGE
========================================================= */

export function BlogsPage() {

    const [blogs, setBlogs] = useState([]);

    const [page, setPage] = useState(1);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");


    /* =====================================================
       LOAD BLOGS
    ===================================================== */

    useEffect(() => {

        async function loadBlogs() {

            try {

                console.log(
                    "Loading blogs from database..."
                );


                const data = await getBlogs();


                console.log(
                    "BLOG API RESPONSE:",
                    data
                );


                setBlogs(data);

            }
            catch (err) {

                console.error(
                    "BLOG API ERROR:",
                    err
                );


                setError(
                    "Unable to load blogs."
                );

            }
            finally {

                setLoading(false);

            }

        }


        loadBlogs();

    }, []);


    /* =====================================================
       LOADING
    ===================================================== */

    if (loading) {

        return (

            <div className="min-h-screen bg-white">

                <div
                    className="w-full py-2 px-6 flex flex-col items-center justify-center"
                    style={{
                        background: "#0A0A2B"
                    }}
                >

                    <h1
                        className="text-white font-bold text-3xl"
                    >
                        Blogs
                    </h1>

                    <p className="text-white/50 text-sm">

                        Loading blogs...

                    </p>

                </div>


                <div className="max-w-7xl mx-auto px-6 py-10">

                    <p className="text-slate-500 text-center">

                        Loading blogs from database...

                    </p>

                </div>

            </div>

        );

    }


    /* =====================================================
       ERROR
    ===================================================== */

    if (error) {

        return (

            <div className="min-h-screen bg-white">

                <div
                    className="w-full py-2 px-6 flex flex-col items-center justify-center"
                    style={{
                        background: "#0A0A2B"
                    }}
                >

                    <h1
                        className="text-white font-bold text-3xl"
                    >
                        Blogs
                    </h1>

                </div>


                <div className="max-w-7xl mx-auto px-6 py-20">

                    <div className="
                        bg-red-50
                        border
                        border-red-200
                        rounded-2xl
                        p-8
                        text-center
                    ">

                        <h2 className="
                            text-2xl
                            font-bold
                            text-red-700
                        ">

                            Unable to Load Blogs

                        </h2>

                        <p className="
                            mt-3
                            text-slate-600
                        ">

                            {error}

                        </p>

                    </div>

                </div>

            </div>

        );

    }


    /* =====================================================
       PAGINATION
    ===================================================== */

    const totalPages =
        Math.ceil(
            blogs.length / PAGE_SIZE
        );


    const visibleBlogs =
        blogs.slice(
            (page - 1) * PAGE_SIZE,
            page * PAGE_SIZE
        );


    /* =====================================================
       PAGE
    ===================================================== */

    return (

        <div
            className="min-h-screen bg-white"

            style={{
                fontFamily:
                    "var(--font-body)"
            }}
        >

            {/* ================================================= */}
            {/* HEADER */}
            {/* ================================================= */}

            <div
                className="
                    w-full
                    py-2
                    px-6
                    flex
                    flex-col
                    items-center
                    justify-center
                "

                style={{
                    background: "#0A0A2B"
                }}
            >

                <h1
                    style={{
                        fontFamily:
                            "var(--font-display)",

                        fontWeight: 800,

                        fontSize:
                            "clamp(1.6rem, 3vw, 2.2rem)",

                        color: "#ffffff",

                        letterSpacing:
                            "-0.02em",
                    }}
                >

                    Blogs

                </h1>


                <p
                    style={{
                        color:
                            "rgba(255,255,255,0.55)",

                        fontSize: "14px",

                        marginTop: "0px"
                    }}
                >

                    Latest news, reviews and guides from BikeCarHub

                </p>

            </div>


            {/* ================================================= */}
            {/* BLOG GRID */}
            {/* ================================================= */}

            <div className="
                max-w-7xl
                mx-auto
                px-6
                py-10
            ">

                {blogs.length === 0 ? (

                    <div className="
                        text-center
                        py-20
                        text-slate-500
                    ">

                        No blogs found.

                    </div>

                ) : (

                    <div className="
                        grid
                        grid-cols-1
                        sm:grid-cols-2
                        lg:grid-cols-4
                        gap-5
                    ">

                        {visibleBlogs.map(
                            (blog) => (

                                <BlogCard
                                    key={blog.id}
                                    blog={blog}
                                />

                            )
                        )}

                    </div>

                )}


                {/* ================================================= */}
                {/* PAGINATION */}
                {/* ================================================= */}

                {totalPages > 1 && (

                    <div className="
                        flex
                        items-center
                        justify-center
                        gap-2
                        mt-10
                    ">

                        {/* PREVIOUS */}

                        <button
                            onClick={() => {

                                setPage(
                                    (p) =>
                                        Math.max(
                                            1,
                                            p - 1
                                        )
                                );

                                window.scrollTo({
                                    top: 0,
                                    behavior: "smooth"
                                });

                            }}

                            disabled={page === 1}

                            className="
                                px-4
                                py-2
                                rounded-lg
                                text-sm
                                transition-all
                                disabled:opacity-40
                            "

                            style={{
                                border:
                                    "1.5px solid #0A0A2B",

                                background:
                                    "white",

                                color:
                                    "#0A0A2B",

                                fontFamily:
                                    "var(--font-display)",

                                fontWeight: 600,

                                cursor:
                                    page === 1
                                        ? "not-allowed"
                                        : "pointer",
                            }}
                        >

                            Prev

                        </button>


                        {/* PAGE NUMBERS */}

                        {Array.from(
                            {
                                length:
                                    totalPages
                            },

                            (_, i) =>
                                i + 1

                        ).map((p) => (

                            <button
                                key={p}

                                onClick={() => {

                                    setPage(p);

                                    window.scrollTo({
                                        top: 0,
                                        behavior: "smooth"
                                    });

                                }}

                                className="
                                    w-9
                                    h-9
                                    rounded-lg
                                    text-sm
                                    transition-all
                                "

                                style={{
                                    background:
                                        p === page
                                            ? "#0A0A2B"
                                            : "white",

                                    color:
                                        p === page
                                            ? "white"
                                            : "#0A0A2B",

                                    border:
                                        "1.5px solid #0A0A2B",

                                    fontFamily:
                                        "var(--font-display)",

                                    fontWeight: 600,
                                }}
                            >

                                {p}

                            </button>

                        ))}


                        {/* NEXT */}

                        <button
                            onClick={() => {

                                setPage(
                                    (p) =>
                                        Math.min(
                                            totalPages,
                                            p + 1
                                        )
                                );

                                window.scrollTo({
                                    top: 0,
                                    behavior: "smooth"
                                });

                            }}

                            disabled={
                                page === totalPages
                            }

                            className="
                                px-4
                                py-2
                                rounded-lg
                                text-sm
                                transition-all
                                disabled:opacity-40
                            "

                            style={{
                                border:
                                    "1.5px solid #0A0A2B",

                                background:
                                    "white",

                                color:
                                    "#0A0A2B",

                                fontFamily:
                                    "var(--font-display)",

                                fontWeight: 600,

                                cursor:
                                    page === totalPages
                                        ? "not-allowed"
                                        : "pointer",
                            }}
                        >

                            Next

                        </button>

                    </div>

                )}

            </div>

        </div>

    );

}