import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

import { SectionTitle } from "./SectionTitle";
import { HScrollCarousel } from "./HScrollCarousel";
import { getBlogs } from "../api/blogApi";
import { BACKEND_URL } from "../config";

export function BlogsSection() {

    const navigate = useNavigate();

    const [blogs, setBlogs] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {

        async function loadBlogs() {

            try {

                const data = await getBlogs();

                setBlogs(data);

            }
            catch (err) {

                console.error(err);

                setError("Unable to load blogs.");

            }
            finally {

                setLoading(false);

            }

        }

        loadBlogs();

    }, []);

    if (loading) {

        return (

            <section className="py-10 bg-white border-t border-slate-100">

                <div className="max-w-7xl mx-auto px-6">

                    <SectionTitle>Blogs</SectionTitle>

                    <p className="text-slate-500">

                        Loading blogs...

                    </p>

                </div>

            </section>

        );

    }

    if (error) {

        return (

            <section className="py-10 bg-white border-t border-slate-100">

                <div className="max-w-7xl mx-auto px-6">

                    <SectionTitle>Blogs</SectionTitle>

                    <p className="text-red-500">

                        {error}

                    </p>

                </div>

            </section>

        );

    }

    return (

        <section className="py-12 bg-white border-t border-slate-100">

            <div className="max-w-7xl mx-auto px-6">

                <SectionTitle>

                    Blogs

                </SectionTitle>

                <HScrollCarousel itemWidth={340}>

                    {blogs.map((blog) => {

                        const slug = blog.url.split("/").pop();

                        return (

                            <div

                                key={blog.blogId}

                                onClick={() => navigate(`/blogs/${slug}`)}

                                className="group
                                w-80
                                bg-white
                                rounded-2xl
                                overflow-hidden
                                shadow-sm
                                hover:shadow-xl
                                transition-all
                                duration-300
                                cursor-pointer
                                border
                                border-slate-100
                                hover:-translate-y-2"

                            >

                                {/* IMAGE */}

                                <div className="relative h-48 overflow-hidden bg-slate-100">

                                    <img

                                        src={`${BACKEND_URL}${blog.imageURL}`}

                                        alt={blog.blogHeading}

                                        className="w-full
                                        h-full
                                        object-cover
                                        group-hover:scale-110
                                        transition-transform
                                        duration-700"

                                    />

                                    <div
                                        className="absolute inset-0"
                                        style={{
                                            background:
                                                "linear-gradient(to top, rgba(15,23,42,.45), transparent)"
                                        }}
                                    />

                                    <span
                                        className="absolute
                                        top-4
                                        left-4
                                        bg-[#2563EB]
                                        text-white
                                        px-3
                                        py-1
                                        rounded-full
                                        text-xs
                                        font-semibold"
                                    >
                                        BLOG
                                    </span>

                                </div>

                                {/* CONTENT */}

                                <div className="p-5">

                                    <h3
                                        className="text-slate-900
                                        font-semibold
                                        text-[16px]
                                        leading-7
                                        line-clamp-2
                                        mb-3"
                                        style={{
                                            fontFamily: "var(--font-display)"
                                        }}
                                    >

                                        {blog.blogHeading}

                                    </h3>

                                    <p
                                        className="text-slate-500
                                        text-sm
                                        leading-7
                                        line-clamp-3"
                                    >

                                        {blog.blogSummary}

                                    </p>

                                    <div
                                        className="mt-5
                                        flex
                                        items-center
                                        justify-between"
                                    >

                                        <span
                                            className="text-xs
                                            text-slate-400"
                                        >

                                            {new Date(blog.date).toLocaleDateString(
                                                "en-IN",
                                                {
                                                    day: "numeric",
                                                    month: "short",
                                                    year: "numeric",
                                                }
                                            )}

                                        </span>

                                        <span
                                            className="text-[#2563EB]
                                            font-semibold
                                            group-hover:translate-x-2
                                            transition-transform"
                                        >

                                            Read More →

                                        </span>

                                    </div>

                                </div>

                            </div>

                        );

                    })}

                </HScrollCarousel>

            </div>

        </section>

    );

}