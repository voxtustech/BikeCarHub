import {
    Bot,
    Calculator,
    GitCompare,
    Bell,
    Heart,
    Rocket,
} from "lucide-react";
import { useNavigate } from "react-router-dom";

const cards = [
    {
        icon: Bot,
        title: "MotoAI",
        description:
            "Get AI-powered vehicle recommendations based on your lifestyle, budget, and needs.",
        color: "#0A0A2B",
        bg: "#E8E8F0",
        cta: "Chat with MotoAI",
        page: "/moto-ai",
    },
    {
        icon: Calculator,
        title: "EMI Calculator",
        description:
            "Calculate monthly installments with real bank interest rates and loan periods.",
        color: "#059669",
        bg: "#ECFDF5",
        cta: "Calculate EMI",
        page: "/emi-calculator",
    },
    {
        icon: GitCompare,
        title: "Vehicle Comparison",
        description:
            "Compare up to 3 vehicles side-by-side with 50+ specification parameters.",
        color: "#7C3AED",
        bg: "#F5F3FF",
        cta: "Start Comparing",
        page: "/compare",
    },
    {
        icon: Bell,
        title: "Price Alerts",
        description:
            "Get instant notifications when your shortlisted vehicle drops in price.",
        color: "#D97706",
        bg: "#FFFBEB",
        cta: "Set Alert",
        page: "/price-alerts",
    },
    {
        icon: Heart,
        title: "Wishlist",
        description:
            "Save vehicles you love and organize them into custom collections.",
        color: "#DC2626",
        bg: "#FEF2F2",
        cta: "My Wishlist",
        page: "/wishlist",
    },
    {
        icon: Rocket,
        title: "Launch Tracker",
        description:
            "Track upcoming vehicles and get notified on launch day with pricing and specs.",
        color: "#0891B2",
        bg: "#ECFEFF",
        cta: "Track Launches",
        page: "/launch-tracker",
    },
];

export function EcosystemSection() {
    const navigate = useNavigate();

    return (
        <section className="py-14 border-t border-slate-100">
            <div className="max-w-7xl mx-auto px-4">
                <div className="text-center mb-10">
                    <p
                        className="text-xs uppercase tracking-widest text-[#0A0A2B] mb-2"
                        style={{ fontWeight: 600 }}
                    >
                        Tools & Features
                    </p>

                    <h2
                        className="text-slate-800"
                        style={{
                            fontFamily: "var(--font-display)",
                            fontWeight: 800,
                            fontSize: "clamp(1.75rem, 3vw, 2.5rem)",
                        }}
                    >
                        BikeCarHub Ecosystem
                    </h2>

                    <p className="text-slate-500 mt-2 max-w-lg mx-auto">
                        Everything you need to research, discover, and buy your next
                        vehicle — all in one place.
                    </p>
                </div>

                <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
                    {cards.map((card) => {
                        const Icon = card.icon;

                        return (
                            <div
                                key={card.title}
                                onClick={() => navigate(card.page)}
                                className="group bg-white border border-slate-100 rounded-2xl p-6 shadow-sm hover:shadow-md hover:-translate-y-0.5 transition-all cursor-pointer"
                            >
                                <div
                                    className="w-12 h-12 rounded-xl flex items-center justify-center mb-4"
                                    style={{ background: card.bg }}
                                >
                                    <Icon size={22} style={{ color: card.color }} />
                                </div>

                                <h3
                                    className="text-slate-800 mb-2"
                                    style={{
                                        fontFamily: "var(--font-display)",
                                        fontWeight: 700,
                                    }}
                                >
                                    {card.title}
                                </h3>

                                <p className="text-slate-500 text-sm leading-relaxed mb-4">
                                    {card.description}
                                </p>

                                <button
                                    onClick={(e) => {
                                        e.stopPropagation();
                                        navigate(card.page);
                                    }}
                                    className="text-sm transition-colors flex items-center gap-1 cursor-pointer hover:opacity-80"
                                    style={{
                                        color: card.color,
                                        fontWeight: 600,
                                    }}
                                >
                                    {card.cta} →
                                </button>
                            </div>
                        );
                    })}
                </div>
            </div>
        </section>
    );
}