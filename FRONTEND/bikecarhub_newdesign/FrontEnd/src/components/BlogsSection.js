import { useEffect, useState } from "react";
import { Calendar } from "lucide-react";
import { useNavigate } from "react-router-dom";

import { SectionTitle } from "./SectionTitle";
import { HScrollCarousel } from "./HScrollCarousel";
import { getBlogs } from "../api/blogApi";
import { BACKEND_URL } from "../config";

export function BlogsSection() {

    const [blogs, setBlogs] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    const navigate = useNavigate();


    useEffect(() => {

        async function loadBlogs() {

            try {

                const data = await getBlogs();

                console.log("HOME BLOGS API RESPONSE:", data);

                setBlogs(Array.isArray(data) ? data : []);

            }
            catch (err) {

                console.error(
                    "HOME BLOGS ERROR:",
                    err
                );

                setError("Unable to load blogs.");

            }
            finally {

                setLoading(false);

            }

        }

        loadBlogs();

    }, []);


    /*
     * -----------------------------------------
     * Loading
     * -----------------------------------------
     */

    if (loading) {

        return (

            <section className="py-10 bg-white border-t border-slate-100">

                <div className="max-w-7xl mx-auto px-6">

                    <SectionTitle
                        onClick={() => navigate("/blogs")}
                    >
                        Blogs
                    </SectionTitle>

                    <p className="text-slate-500">
                        Loading blogs...
                    </p>

                </div>

            </section>

        );

    }


    /*
     * -----------------------------------------
     * Error
     * -----------------------------------------
     */

    if (error) {

        return (

            <section className="py-10 bg-white border-t border-slate-100">

                <div className="max-w-7xl mx-auto px-6">

                    <SectionTitle
                        onClick={() => navigate("/blogs")}
                    >
                        Blogs
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


                {/* ========================================= */}
                {/* SECTION TITLE */}
                {/* ========================================= */}

                <SectionTitle
                    onClick={() => navigate("/blogs")}
                >
                    Blogs
                </SectionTitle>


                <HScrollCarousel itemWidth={320}>

                    {blogs.map((blog) => {


                        /*
                         * =========================================
                         * IMPORTANT:
                         * Backend slug is:
                         *
                         * blogs/mahindra-scorpio-n-facelift
                         *
                         * We only need:
                         *
                         * mahindra-scorpio-n-facelift
                         * =========================================
                         */

                        const rawSlug = blog.slug || blog.url || "";

                        const slug = rawSlug
                            .replace(/^blogs\//, "")
                            .replace(/^\/+|\/+$/g, "");


                        /*
                         * =========================================
                         * IMAGE
                         * =========================================
                         */

                        const imageUrl = blog.image
                            ? (
                                blog.image.startsWith("http")
                                    ? blog.image
                                    : `${BACKEND_URL}${blog.image.startsWith("/") ? "" : "/"}${blog.image}`
                            )
                            : "";


                        return (

                            <div
                                key={blog.id}
                                onClick={() => {

                                    console.log(
                                        "BLOG CARD CLICKED:",
                                        blog
                                    );

                                    console.log(
                                        "BLOG SLUG:",
                                        slug
                                    );

                                    if (!slug) {

                                        console.error(
                                            "Blog slug is missing:",
                                            blog
                                        );

                                        return;

                                    }

                                    navigate(`/blogs/${slug}`);

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


                                {/* ========================================= */}
                                {/* IMAGE */}
                                {/* ========================================= */}

                                <div className="
                                    h-44
                                    overflow-hidden
                                    bg-slate-100
                                ">

                                    {imageUrl ? (

                                        <img
                                            src={imageUrl}
                                            alt={blog.title || "BikeCarHub Blog"}
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
                                                    "BLOG IMAGE FAILED:",
                                                    imageUrl
                                                );

                                                e.currentTarget.style.display =
                                                    "none";

                                            }}
                                        />

                                    ) : (

                                        <div className="
                                            w-full
                                            h-full
                                            flex
                                            items-center
                                            justify-center
                                            bg-slate-100
                                            text-slate-400
                                            text-sm
                                        ">

                                            No Image

                                        </div>

                                    )}

                                </div>


                                {/* ========================================= */}
                                {/* CONTENT */}
                                {/* ========================================= */}

                                <div className="p-4">


                                    {/* TITLE */}

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

                                        {blog.title}

                                    </p>


                                    {/* DATE */}

                                    <div className="
                                        flex
                                        items-center
                                        gap-1.5
                                        text-slate-400
                                        text-xs
                                        mb-3
                                    ">

                                        <Calendar size={11} />

                                        <span>

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

                                        <p className="
                                            text-sm
                                            text-slate-500
                                            line-clamp-2
                                            mb-4
                                        ">

                                            {blog.summary}

                                        </p>

                                    )}


                                    {/* BUTTON */}

                                    <button
                                        type="button"
                                        onClick={(e) => {

                                            /*
                                             * Prevent the button click
                                             * from causing any duplicate
                                             * event.
                                             */

                                            e.stopPropagation();

                                            console.log(
                                                "BLOG READ MORE CLICKED:",
                                                slug
                                            );

                                            if (slug) {

                                                navigate(
                                                    `/blogs/${slug}`
                                                );

                                            }

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