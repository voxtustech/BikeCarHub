import { Calendar } from "lucide-react";

const API = "https://localhost:7135";

export default function BikeNewsSection({ news = [] }) {

    if (!news.length) return null;

    return (

        <section className="bg-white rounded-3xl border shadow-sm p-8">

            <h2 className="text-2xl font-bold mb-8">

                Latest News

            </h2>

            <div className="grid lg:grid-cols-3 gap-6">

                {news.map(item => (

                    <article
                        key={item.id}
                        className="border rounded-2xl overflow-hidden hover:shadow-lg transition"
                    >

                        <img
                            src={`${API}${item.image}`}
                            className="w-full h-52 object-cover"
                            alt=""
                        />

                        <div className="p-5">

                            <div className="flex items-center gap-2 text-slate-500 text-sm">

                                <Calendar size={14} />

                                {item.date}

                            </div>

                            <h3 className="font-semibold mt-4 leading-7">

                                {item.title}

                            </h3>

                        </div>

                    </article>

                ))}

            </div>

        </section>

    );

}