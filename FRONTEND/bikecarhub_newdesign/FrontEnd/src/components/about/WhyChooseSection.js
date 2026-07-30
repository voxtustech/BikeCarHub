import {
    ShieldCheck,
    BadgeCheck,
    Clock3,
    HeartHandshake,
} from "lucide-react";

const reasons = [
    {
        icon: ShieldCheck,
        title: "Reliable Information",
        description:
            "Accurate specifications, transparent pricing and verified automotive content.",
    },
    {
        icon: BadgeCheck,
        title: "Expert Reviews",
        description:
            "Well-researched articles, comparisons and buying guides for every segment.",
    },
    {
        icon: Clock3,
        title: "Always Up-to-Date",
        description:
            "Latest launches, news, price updates and market trends in one place.",
    },
    {
        icon: HeartHandshake,
        title: "Built for Users",
        description:
            "Designed to make vehicle research faster, easier and more enjoyable.",
    },
];

const stats = [
    {
        number: "4+",
        label: "Core Services",
    },
    {
        number: "24×7",
        label: "Available",
    },
    {
        number: "100%",
        label: "Free to Use",
    },
    {
        number: "Trusted",
        label: "Platform",
    },
];

export default function WhyChooseSection() {

    return (

        <section className="py-24 bg-slate-100">

            <div className="max-w-7xl mx-auto px-6">

                <div className="text-center mb-16">

                    <h2 className="text-4xl font-bold text-slate-900 mb-5">

                        Why Choose BikeCarHub?

                    </h2>

                    <p className="text-slate-600 text-lg max-w-3xl mx-auto">

                        We focus on making automotive research simple,
                        transparent and genuinely useful for every vehicle buyer.

                    </p>

                </div>

                <div className="grid lg:grid-cols-2 gap-10">

                    {reasons.map((reason) => {

                        const Icon = reason.icon;

                        return (

                            <div
                                key={reason.title}
                                className="
                                    bg-white
                                    rounded-3xl
                                    p-8
                                    shadow-lg
                                    hover:-translate-y-2
                                    hover:shadow-2xl
                                    transition-all
                                    duration-300
                                    flex
                                    gap-6
                                "
                            >

                                <div
                                    className="
                                        w-16
                                        h-16
                                        rounded-2xl
                                        bg-blue-100
                                        flex
                                        items-center
                                        justify-center
                                        shrink-0
                                    "
                                >

                                    <Icon
                                        size={30}
                                        className="text-[#1E5E8C]"
                                    />

                                </div>

                                <div>

                                    <h3 className="text-2xl font-semibold mb-3">

                                        {reason.title}

                                    </h3>

                                    <p className="text-slate-600 leading-8">

                                        {reason.description}

                                    </p>

                                </div>

                            </div>

                        );

                    })}

                </div>

                <div className="grid grid-cols-2 lg:grid-cols-4 gap-8 mt-20">

                    {stats.map((stat) => (

                        <div
                            key={stat.label}
                            className="
                                bg-gradient-to-br
                                from-[#1E5E8C]
                                to-[#2563EB]
                                rounded-3xl
                                text-center
                                p-10
                                text-white
                                shadow-xl
                            "
                        >

                            <h3 className="text-5xl font-bold">

                                {stat.number}

                            </h3>

                            <p className="mt-4 text-lg text-blue-100">

                                {stat.label}

                            </p>

                        </div>

                    ))}

                </div>

            </div>

        </section>

    );

}