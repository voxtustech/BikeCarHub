import { ArrowRight } from "lucide-react";
import { useNavigate } from "react-router-dom";
import { slugify } from "../../utils/slugify";

const API = "https://localhost:7135";

export default function SimilarBikesSection({ bikes = [] }) {

    const navigate = useNavigate();

    if (!bikes.length) return null;

    return (

        <section className="bg-white rounded-3xl border shadow-sm p-8">

            <div className="flex justify-between items-center mb-8">

                <h2 className="text-2xl font-bold">

                    Similar Bikes

                </h2>

            </div>

            <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-6">

                {bikes.map(bike => (

                    <div
                        key={bike.id}
                        className="border rounded-2xl overflow-hidden hover:shadow-lg transition cursor-pointer"
                        onClick={() =>
                            navigate(
                                `/${slugify(bike.brand)}/${slugify(bike.name)}`
                            )
                        }
                    >

                        <img
                            src={`${API}${bike.image}`}
                            className="w-full h-52 object-contain bg-slate-50"
                            alt=""
                        />

                        <div className="p-5">

                            <h3 className="font-semibold">

                                {bike.name}

                            </h3>

                            <p className="text-blue-700 font-bold mt-2">

                                {bike.price}

                            </p>

                            <button className="mt-5 text-blue-700 flex items-center gap-2">

                                View Details

                                <ArrowRight size={16} />

                            </button>

                        </div>

                    </div>

                ))}

            </div>

        </section>

    );

}