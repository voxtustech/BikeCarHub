import { useNavigate } from "react-router-dom";
import { SectionTitle } from "./SectionTitle";
import { HScrollCarousel } from "./HScrollCarousel";

const BACKEND_URL = "https://localhost:5030"; // Change if needed

export function RelatedBlogs({ blogs }) {

    const navigate = useNavigate();

    if (!blogs || blogs.length === 0) return null;

    return (

        <section className="py-20 bg-slate-50 border-t border-slate-200">

            <div className="max-w-7xl mx-auto px-6">

                <SectionTitle>
                    Related Articles
                </SectionTitle>

                <p className="text-slate-500 mb-10">
                    Continue exploring the latest automotive news, reviews and buying guides.
                </p>

                <HScrollCarousel itemWidth={360}>

                    {blogs.map((blog) => {

                        const slug = blog.url.split("/").pop();

                        return (

                            <div

                                key={blog.blogId}

                                onClick={() => navigate(`/blogs/${slug}`)}

                                className="group
                                w-[340px]
                                bg-white
                                rounded-3xl
                                overflow-hidden
                                shadow-sm
                                hover:shadow-xl
                                transition-all
                                duration-300
                                cursor-pointer"

                            >

                                {/* IMAGE */}

                                <div className="relative overflow-hidden h-56">

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
                                                "linear-gradient(to top, rgba(15,23,42,.55), transparent)"
                                        }}

                                    />

                                    <span

                                        className="absolute
                                        top-5
                                        left-5
                                        bg-[#2563EB]
                                        text-white
                                        px-4
                                        py-2
                                        rounded-full
                                        text-xs
                                        font-semibold"

                                    >

                                        BLOG

                                    </span>

                                </div>

                                {/* CONTENT */}

                                <div className="p-6">

                                    <p

                                        className="text-slate-900
                                        font-bold
                                        text-lg
                                        leading-7
                                        line-clamp-2
                                        mb-4"

                                    >

                                        {blog.blogHeading}

                                    </p>

                                    <p

                                        className="text-slate-500
                                        text-sm
                                        leading-7
                                        line-clamp-3"

                                    >

                                        {blog.blogSummary}

                                    </p>

                                    <div

                                        className="mt-6
                                        flex
                                        justify-between
                                        items-center"

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
                                                    year: "numeric"
                                                }
                                            )}

                                        </span>

                                        <span

                                            className="font-semibold
                                            text-[#2563EB]
                                            group-hover:translate-x-2
                                            transition"

                                        >

                                            Read →

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