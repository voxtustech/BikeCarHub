import { CheckCircle2 } from "lucide-react";

export default function BikeVariantSelector({
    variants = [],
    selectedVariant,
    setSelectedVariant
}) {

    if (!variants.length)
        return null;

    return (

        <section
            id="variants"
            className="bg-white rounded-3xl shadow-sm border p-6"
        >

            <div className="flex items-center justify-between mb-6">

                <div>

                    <h2 className="text-2xl font-bold">

                        Select Variant

                    </h2>

                    <p className="text-slate-500 mt-1">

                        Choose a variant to view its specifications.

                    </p>

                </div>

            </div>

            <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-5">

                {variants.map((variant) => {

                    const active =
                        variant.id === selectedVariant;

                    return (

                        <button
                            key={variant.id}
                            onClick={() =>
                                setSelectedVariant(
                                    variant.id
                                )
                            }
                            className={`rounded-2xl border p-5 transition-all text-left
                            ${active
                                    ? "border-blue-600 bg-blue-50 shadow-md"
                                    : "border-slate-200 hover:border-blue-300 hover:shadow"
                                }`}
                        >

                            <div className="flex justify-between">

                                <div>

                                    <h3 className="font-semibold text-lg">

                                        {variant.name}

                                    </h3>

                                    {variant.price && (

                                        <p className="text-blue-700 font-bold mt-2">

                                            {variant.price}

                                        </p>

                                    )}

                                </div>

                                {active && (

                                    <CheckCircle2
                                        className="text-blue-700"
                                        size={26}
                                    />

                                )}

                            </div>

                            <div className="mt-5">

                                {active ? (

                                    <span className="text-blue-700 text-sm font-semibold">

                                        ✓ Selected

                                    </span>

                                ) : (

                                    <span className="text-slate-500 text-sm">

                                        Click to Select

                                    </span>

                                )}

                            </div>

                        </button>

                    );

                })}

            </div>

        </section>

    );

}