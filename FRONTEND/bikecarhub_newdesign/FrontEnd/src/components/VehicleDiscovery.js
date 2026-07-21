import { useState } from "react";
import { VehicleCard } from "./VehicleCard";
import { carsData, bikesData, evsData } from "./data";

const filters = ["Popular", "Upcoming", "New Launches", "Best in Segment", "Top Rated"];

const allVehicles = [...carsData.slice(0, 4), ...bikesData.slice(0, 2), ...evsData.slice(0, 2)];

export function VehicleDiscovery() {
  const [activeFilter, setActiveFilter] = useState("Popular");

  return (
    <section className="py-14 bg-[#F8FAFC] border-t border-slate-100">
      <div className="max-w-7xl mx-auto px-4">
        <div className="text-center mb-8">
          <p className="text-xs uppercase tracking-widest text-[#0A0A2B] mb-2" style={{ fontWeight: 600 }}>
            Vehicle Discovery
          </p>
          <h2 className="text-slate-800" style={{ fontFamily: "var(--font-display)", fontWeight: 800, fontSize: "clamp(1.75rem, 3vw, 2.5rem)" }}>
            Find Your Perfect Vehicle
          </h2>
          <p className="text-slate-500 mt-2 max-w-lg mx-auto">
            Explore curated collections across cars, bikes, and EVs tailored for every lifestyle and budget.
          </p>
        </div>

        <div className="flex gap-2 justify-center mb-8 flex-wrap">
          {filters.map((f) => (
            <button
              key={f}
              onClick={() => setActiveFilter(f)}
              className={`px-5 py-2 rounded-full text-sm transition-all ${
                activeFilter === f
                  ? "bg-[#0A0A2B] text-white shadow-sm"
                  : "bg-white border border-slate-200 text-slate-600 hover:border-[#0A0A2B] hover:text-[#0A0A2B]"
              }`}
              style={{ fontWeight: 500 }}
            >
              {f}
            </button>
          ))}
        </div>

        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-5">
          {allVehicles.map((v) => (
            <VehicleCard key={v.id} vehicle={v} />
          ))}
        </div>
      </div>
    </section>
  );
}
