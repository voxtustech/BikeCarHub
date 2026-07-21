import {
    Gauge,
    Fuel,
    Weight,
    Bike,
    ShieldCheck,
    Zap,
    ArrowUp,
    Ruler
} from "lucide-react";

export default function BikeInfoCards({
    bike,
    spec,
    engine,
    features,
    dimensions
}) {

    if (!bike)
        return null;

    const cards = [

        {
            icon: Gauge,
            title: "Mileage",
            value:
                spec?.mileage
                    ? `${spec.mileage} kmpl`
                    : "Not Available"
        },

        {
            icon: Bike,
            title: "Engine",
            value:
                engine?.displacement
                    ? `${engine.displacement} cc`
                    : "Not Available"
        },

        {
            icon: Zap,
            title: "Power",
            value:
                engine?.peakPower ||
                "Not Available"
        },

        {
            icon: Fuel,
            title: "Fuel Tank",
            value:
                spec?.fuelCapacity
                    ? `${spec.fuelCapacity} L`
                    : "Not Available"
        },

        {
            icon: ShieldCheck,
            title: "ABS",
            value:
                features?.abs ||
                "Not Available"
        },

        {
            icon: Weight,
            title: "Kerb Weight",
            value:
                dimensions?.kerbWeight
                    ? `${dimensions.kerbWeight} kg`
                    : "Not Available"
        },

        {
            icon: ArrowUp,
            title: "Ground Clearance",
            value:
                dimensions?.groundClearance
                    ? `${dimensions.groundClearance} mm`
                    : "Not Available"
        },

        {
            icon: Ruler,
            title: "Body Type",
            value:
                spec?.bodyType ||
                "Not Available"
        }

    ];

    return (

        <section
            id="overview"
            className="bg-white rounded-3xl border shadow-sm p-6"
        >

            <div className="flex items-center justify-between mb-6">

                <div>

                    <h2 className="text-2xl font-bold">

                        Key Highlights

                    </h2>

                    <p className="text-slate-500 mt-1">

                        Important specifications of
                        {" "}
                        <span className="font-semibold">

                            {bike.name}

                        </span>

                    </p>

                </div>

            </div>

            <div className="grid sm:grid-cols-2 lg:grid-cols-4 gap-5">

                {cards.map((item, index) => {

                    const Icon = item.icon;

                    return (

                        <div
                            key={index}
                            className="rounded-2xl border border-slate-200 p-5 hover:border-blue-500 hover:shadow-md transition-all duration-300 bg-white"
                        >

                            <div className="w-12 h-12 rounded-xl bg-blue-100 flex items-center justify-center mb-4">

                                <Icon
                                    size={22}
                                    className="text-blue-700"
                                />

                            </div>

                            <p className="text-slate-500 text-sm">

                                {item.title}

                            </p>

                            <h3 className="font-semibold mt-2 text-slate-800 leading-6">

                                {item.value}

                            </h3>

                        </div>

                    );

                })}

            </div>

        </section>

    );

}