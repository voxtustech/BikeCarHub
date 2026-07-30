import { Users } from "lucide-react";

export default function AboutSection() {
    return (
        <section className="py-24 bg-white">
            <div className="max-w-7xl mx-auto px-6">

                <div className="grid lg:grid-cols-2 gap-16 items-center">

                    <div>

                        <div className="inline-flex items-center gap-3 bg-blue-50 px-5 py-3 rounded-full mb-6">
                            <Users className="text-[#1E5E8C]" />
                            <span className="font-semibold text-[#1E5E8C]">
                                Who We Are
                            </span>
                        </div>

                        <h2 className="text-4xl font-bold text-slate-900 mb-6">
                            Built for Every Vehicle Enthusiast
                        </h2>

                        <p className="text-slate-600 text-lg leading-9 mb-6">
                            BikeCarHub is your trusted destination for everything
                            related to bikes and cars in India. Whether you're
                            buying your first scooter, comparing family SUVs,
                            researching premium motorcycles or staying updated
                            with the latest launches, we simplify every step of
                            your journey.
                        </p>

                        <p className="text-slate-600 text-lg leading-9">
                            We believe automotive research should be transparent,
                            accurate and easy to understand. Every article,
                            comparison and specification is curated to help users
                            make smarter decisions with confidence.
                        </p>

                    </div>

                    <div>

                        <div className="bg-slate-50 rounded-3xl shadow-xl p-10">

                            <div className="grid grid-cols-2 gap-6">

                                <div className="bg-white rounded-2xl p-8 shadow text-center">
                                    <h3 className="text-5xl font-bold text-[#1E5E8C]">
                                        100%
                                    </h3>

                                    <p className="mt-3 text-slate-600">
                                        Free Platform
                                    </p>
                                </div>

                                <div className="bg-white rounded-2xl p-8 shadow text-center">
                                    <h3 className="text-5xl font-bold text-[#1E5E8C]">
                                        24×7
                                    </h3>

                                    <p className="mt-3 text-slate-600">
                                        Accessible
                                    </p>
                                </div>

                                <div className="bg-white rounded-2xl p-8 shadow text-center">
                                    <h3 className="text-5xl font-bold text-[#1E5E8C]">
                                        Daily
                                    </h3>

                                    <p className="mt-3 text-slate-600">
                                        Updated Content
                                    </p>
                                </div>

                                <div className="bg-white rounded-2xl p-8 shadow text-center">
                                    <h3 className="text-5xl font-bold text-[#1E5E8C]">
                                        Trusted
                                    </h3>

                                    <p className="mt-3 text-slate-600">
                                        Information
                                    </p>
                                </div>

                            </div>

                        </div>

                    </div>

                </div>

            </div>
        </section>
    );
}