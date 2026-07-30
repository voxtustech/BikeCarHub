import { CarFront, Bike } from "lucide-react";

export default function Hero() {
    return (
        <section
            className="
                relative
                overflow-hidden
                bg-gradient-to-r
                from-slate-900
                via-[#164e7d]
                to-[#2563EB]
                text-white
            "
        >
            <div className="max-w-7xl mx-auto px-6 py-24">

                <div className="grid lg:grid-cols-2 gap-16 items-center">

                    <div>

                        <p className="uppercase tracking-[4px] text-blue-200 mb-4">
                            About BikeCarHub
                        </p>

                        <h1 className="text-5xl lg:text-6xl font-bold leading-tight mb-6">

                            Your Trusted

                            <span className="block text-blue-300">

                                Automotive Platform

                            </span>

                        </h1>

                        <p className="text-xl text-slate-200 leading-9">

                            Helping users compare, research and discover
                            India's latest bikes and cars with accurate
                            specifications, expert reviews and trusted pricing.

                        </p>

                    </div>

                    <div className="flex justify-center">

                        <div
                            className="
                                bg-white/10
                                backdrop-blur-xl
                                rounded-3xl
                                p-12
                                shadow-2xl
                            "
                        >

                            <div className="flex gap-8">

                                <CarFront
                                    size={120}
                                    className="text-blue-200"
                                />

                                <Bike
                                    size={120}
                                    className="text-white"
                                />

                            </div>

                        </div>

                    </div>

                </div>

            </div>
        </section>
    );
}