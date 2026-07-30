import {
    Car,
    Bike,
    Newspaper,
    Scale,
} from "lucide-react";

const features = [
    {
        icon: Car,
        title: "Detailed Specifications",
        description:
            "Complete specifications, mileage, engine details and features.",
    },
    {
        icon: Bike,
        title: "Upcoming Launches",
        description:
            "Stay informed about upcoming bikes and cars across India.",
    },
    {
        icon: Scale,
        title: "Vehicle Comparison",
        description:
            "Compare specifications, pricing and features side by side.",
    },
    {
        icon: Newspaper,
        title: "Latest News",
        description:
            "Automotive news, launches, reviews and buying guides.",
    },
];

export default function FeaturesSection() {
    return (
        <section className="py-24 bg-white">

            <div className="max-w-7xl mx-auto px-6">

                <div className="text-center mb-16">

                    <h2 className="text-4xl font-bold text-slate-900 mb-4">
                        What We Offer
                    </h2>

                    <p className="text-slate-600 text-lg">
                        Everything you need before purchasing your next vehicle.
                    </p>

                </div>

                <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-8">

                    {features.map((feature) => {

                        const Icon = feature.icon;

                        return (

                            <div
                                key={feature.title}
                                className="
                                    group
                                    bg-slate-50
                                    rounded-3xl
                                    p-8
                                    shadow-lg
                                    hover:-translate-y-2
                                    hover:shadow-2xl
                                    transition-all
                                    duration-300
                                "
                            >

                                <div className="w-16 h-16 rounded-2xl bg-blue-100 flex items-center justify-center mb-6">

                                    <Icon
                                        className="text-[#1E5E8C]"
                                        size={32}
                                    />

                                </div>

                                <h3 className="text-xl font-bold mb-4 group-hover:text-[#1E5E8C]">
                                    {feature.title}
                                </h3>

                                <p className="text-slate-600 leading-8">
                                    {feature.description}
                                </p>

                            </div>

                        );

                    })}

                </div>

            </div>

        </section>
    );
}