import { GitCompare } from "lucide-react";
import { useNavigate } from "react-router-dom";

export default function BikeCompareSection({ bike }) {

    const navigate = useNavigate();

    if (!bike) return null;

    return (

        <section className="rounded-3xl bg-gradient-to-r from-blue-700 to-indigo-700 text-white p-10">

            <div className="flex justify-between items-center">

                <div>

                    <h2 className="text-3xl font-bold">

                        Compare {bike.name}

                    </h2>

                    <p className="mt-3 text-blue-100">

                        Compare specifications, features and prices with competing motorcycles.

                    </p>

                </div>

                <button

                    onClick={() => navigate("/compare")}

                    className="bg-white text-blue-700 px-6 py-4 rounded-xl font-semibold flex items-center gap-3"

                >

                    <GitCompare size={20} />

                    Compare Bikes

                </button>

            </div>

        </section>

    );

}