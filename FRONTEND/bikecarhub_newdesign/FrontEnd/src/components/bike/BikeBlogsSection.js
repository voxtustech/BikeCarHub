import { ArrowRight } from "lucide-react";

const API = "http://localhost:5030";

export default function BikeBlogsSection({ blogs = [] }) {

    if (!blogs.length) return null;

    return (

        <section className="bg-white rounded-3xl border shadow-sm p-8">

            <div className="flex justify-between items-center mb-8">

                <h2 className="text-2xl font-bold">

                    Related Articles

                </h2>

            </div>

            <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-6">

                {blogs.map(blog => (

                    <article
                        key={blog.id}
                        className="border rounded-2xl overflow-hidden hover:shadow-lg transition"
                    >

                        <img
                            src={`${API}${blog.image}`}
                            className="w-full h-56 object-cover"
                            alt=""
                        />

                        <div className="p-6">

                            <h3 className="font-semibold leading-7">

                                {blog.title}

                            </h3>

                            <p className="mt-3 text-slate-600 text-sm line-clamp-3">

                                {blog.summary}

                            </p>

                            <button className="mt-5 flex items-center gap-2 text-blue-700">

                                Read More

                                <ArrowRight size={15} />

                            </button>

                        </div>

                    </article>

                ))}

            </div>

        </section>

    );

}