import { useState } from "react";
import { ArrowRight } from "lucide-react";
import { CoverflowCarousel } from "./CoverflowCarousel";
import { AdPlaceholder } from "./AdPlaceholder";

export function VehicleSection({
  title,
  subtitle,
  filters,
  vehicles,
  showAd = false,
  accentColor = "#0A0A2B",
}) {
  const [activeFilter, setActiveFilter] = useState(filters[0]);

  return (
    <section className="py-14 border-t border-slate-100">
      <div className="max-w-7xl mx-auto px-4">
        <div className="flex items-end justify-between mb-6">
          <div>
            <p className="text-xs uppercase tracking-widest mb-1" style={{ color: accentColor, fontWeight: 600 }}>
              {subtitle}
            </p>
            <h2 className="text-slate-800" style={{ fontFamily: "var(--font-display)", fontWeight: 800, fontSize: "clamp(1.5rem, 3vw, 2rem)" }}>
              {title}
            </h2>
          </div>
          <button className="hidden md:flex items-center gap-1.5 text-sm hover:gap-2.5 transition-all" style={{ color: accentColor, fontWeight: 600 }}>
            View All <ArrowRight size={14} />
          </button>
        </div>

        {/* Filters */}
        <div className="flex gap-2 mb-8 flex-wrap">
          {filters.map((f) => (
            <button
              key={f}
              onClick={() => setActiveFilter(f)}
              className={`px-4 py-2 rounded-full text-sm transition-all ${
                activeFilter === f
                  ? "text-white shadow-sm"
                  : "bg-white border border-slate-200 text-slate-600 hover:border-slate-300"
              }`}
              style={activeFilter === f ? { background: accentColor, fontWeight: 600 } : { fontWeight: 500 }}
            >
              {f}
            </button>
          ))}
        </div>

        {showAd && (
          <AdPlaceholder label="Advertisement" height="h-16" className="mb-6" />
        )}

        <CoverflowCarousel vehicles={vehicles} />

        <div className="flex md:hidden justify-center mt-6">
          <button className="flex items-center gap-1.5 text-sm px-6 py-3 rounded-full border border-slate-200 hover:border-slate-300" style={{ color: accentColor, fontWeight: 600 }}>
            View All <ArrowRight size={14} />
          </button>
        </div>
      </div>
    </section>
  );
}
