import { Target } from "lucide-react";

export default function MissionSection() {
    return (
        <section className="py-24 bg-slate-50">

            <div className="max-w-5xl mx-auto px-6">

                <div
                    className="
                        bg-white
                        rounded-3xl
                        shadow-xl
                        p-14
                        text-center
                        hover:shadow-2xl
                        transition-all
                        duration-300
                    "
                >

                    <div className="flex justify-center mb-8">

                        <div className="w-24 h-24 rounded-full bg-blue-100 flex items-center justify-center">

                            <Target
                                size={44}
                                className="text-[#1E5E8C]"
                            />

                        </div>

                    </div>

                    <h2 className="text-4xl font-bold text-slate-900 mb-8">
                        Our Mission
                    </h2>

                    <p className="text-xl text-slate-600 leading-10">

                        Our mission is to simplify vehicle research by bringing
                        together accurate specifications, transparent pricing,
                        expert reviews, comparisons, buying advice and the latest
                        automotive news on a single trusted platform.

                    </p>

                </div>

            </div>

        </section>
    );
}