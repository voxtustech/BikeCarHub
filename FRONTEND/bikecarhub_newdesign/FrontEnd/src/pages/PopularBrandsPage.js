import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getBrands } from "../api/brandApi";
import { BACKEND_URL } from "../config";
import { slugify } from "../utils/slugify";

export function PopularBrandsPage() {

    const [brands, setBrands] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    const navigate = useNavigate();

    useEffect(() => {

        async function loadBrands() {

            try {

                const data = await getBrands();

                setBrands(data);

            }

            catch {

                setError("Unable to load brands.");

            }

            finally {

                setLoading(false);

            }

        }

        loadBrands();

    }, []);

    if (loading) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-16">

                <h1 className="text-4xl font-bold">

                    Popular Brands

                </h1>

                <p className="mt-8 text-slate-500">

                    Loading brands...

                </p>

            </div>

        );

    }

    if (error) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-16">

                <h1 className="text-4xl font-bold">

                    Popular Brands

                </h1>

                <p className="mt-8 text-red-500">

                    {error}

                </p>

            </div>

        );

    }

    return (

        <section className="py-14 bg-white">

            <div className="max-w-7xl mx-auto px-6">

                <div className="mb-12">

                    <h1 className="text-5xl font-bold text-slate-900">

                        Popular Brands

                    </h1>

                    <p className="text-slate-500 mt-4 text-lg">

                        Browse all bike brands available on BikeCarHub.
                        Click any brand to explore its complete lineup,
                        specifications, pricing, images, reviews and latest updates.

                    </p>

                </div>

                <div className="grid grid-cols-2 sm:grid-cols-4 lg:grid-cols-6 gap-5">

                    {brands.map((brand) => (

                        <div
                            key={brand.id}
                            onClick={() =>
                                navigate(`/${slugify(brand.name)}`)
                            }
                            className="
                                group
                                bg-white
                                rounded-xl
                                border
                                border-slate-200
                                p-5
                                flex
                                flex-col
                                items-center
                                justify-center
                                cursor-pointer
                                transition-all
                                duration-300
                                hover:shadow-lg
                                hover:-translate-y-1
                                hover:border-blue-200
                            "
                        >

                            <div className="h-14 flex items-center justify-center mb-4">

                                <img
                                    src={`${BACKEND_URL}${brand.logo}`}
                                    alt={brand.name}
                                    className="max-h-12 max-w-[120px] object-contain"
                                />

                            </div>

                            <h3 className="text-center text-sm font-semibold text-slate-800">

                                {brand.name}

                            </h3>

                            <div className="flex gap-2 mt-3">

                                {brand.petrol && (

                                    <span className="px-2 py-1 rounded-full text-[10px] bg-blue-100 text-blue-700">

                                        Petrol

                                    </span>

                                )}

                                {brand.ev && (

                                    <span className="px-2 py-1 rounded-full text-[10px] bg-green-100 text-green-700">

                                        EV

                                    </span>

                                )}

                            </div>

                        </div>

                    ))}

                </div>

            </div>

        </section>

    );

}