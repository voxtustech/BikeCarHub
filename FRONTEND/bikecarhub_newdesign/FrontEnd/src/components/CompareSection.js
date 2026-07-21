import { useState } from "react";
import { Plus, X, ArrowRight, GitCompare } from "lucide-react";

const compareVehicles = [
  {
    id: 1,
    name: "Hyundai Creta 2024",
    image: "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=400&h=250&fit=crop&auto=format",
    price: "₹10.99 Lakh",
    power: "115 bhp",
    mileage: "17.4 kmpl",
    fuelType: "Petrol",
    rating: 4.5,
    segments: ["Family SUV", "Mid-size"],
  },
  {
    id: 2,
    name: "Kia Seltos 2024",
    image: "https://images.unsplash.com/photo-1563720223523-0bf25e2c9e6a?w=400&h=250&fit=crop&auto=format",
    price: "₹10.90 Lakh",
    power: "138 bhp",
    mileage: "16.5 kmpl",
    fuelType: "Petrol",
    rating: 4.5,
    segments: ["Family SUV", "Mid-size"],
  },
  {
    id: 3,
    name: "Maruti Grand Vitara",
    image: "https://images.unsplash.com/photo-1590362891991-f776e747a588?w=400&h=250&fit=crop&auto=format",
    price: "₹10.70 Lakh",
    power: "102 bhp",
    mileage: "21.1 kmpl",
    fuelType: "Hybrid",
    rating: 4.3,
    segments: ["Mid-size SUV", "Hybrid"],
  },
];

const specs = ["Price", "Power", "Mileage", "Fuel Type", "Rating"];

export function CompareSection() {
  const [selected, setSelected] = useState([compareVehicles[0], compareVehicles[1]]);

  const getSpec = (vehicle, spec) => {
    switch (spec) {
      case "Price": return vehicle.price;
      case "Power": return vehicle.power;
      case "Mileage": return vehicle.mileage;
      case "Fuel Type": return vehicle.fuelType;
      case "Rating": return `${vehicle.rating}/5`;
      default: return "—";
    }
  };

  const isBest = (spec, idx) => {
    if (spec === "Price") {
      const prices = selected.map(v => parseFloat(v.price.replace(/[^0-9.]/g, "")));
      return prices[idx] === Math.min(...prices);
    }
    if (spec === "Power") {
      const vals = selected.map(v => parseFloat(v.power));
      return vals[idx] === Math.max(...vals);
    }
    if (spec === "Mileage") {
      const vals = selected.map(v => parseFloat(v.mileage));
      return vals[idx] === Math.max(...vals);
    }
    if (spec === "Rating") {
      const vals = selected.map(v => v.rating);
      return vals[idx] === Math.max(...vals);
    }
    return false;
  };

  return (
    <section className="py-14 border-t border-slate-100">
      <div className="max-w-7xl mx-auto px-4">
        <div className="flex items-end justify-between mb-8">
          <div>
            <p className="text-xs uppercase tracking-widest text-[#0A0A2B] mb-1" style={{ fontWeight: 600 }}>
              Smart Tools
            </p>
            <h2 className="text-slate-800" style={{ fontFamily: "var(--font-display)", fontWeight: 800, fontSize: "clamp(1.5rem, 3vw, 2rem)" }}>
              Compare Vehicles
            </h2>
          </div>
          <button className="hidden md:flex items-center gap-1.5 text-sm text-[#0A0A2B] hover:gap-2.5 transition-all" style={{ fontWeight: 600 }}>
            Full Comparison <ArrowRight size={14} />
          </button>
        </div>

        <div className="bg-white border border-slate-100 rounded-2xl overflow-hidden shadow-sm">
          {/* Vehicle columns */}
          <div className="grid" style={{ gridTemplateColumns: `200px repeat(${selected.length}, 1fr) 160px` }}>
            {/* Header row */}
            <div className="p-4 bg-slate-50 border-b border-slate-100 flex items-center">
              <span className="text-xs uppercase tracking-wider text-slate-500" style={{ fontWeight: 600 }}>Specifications</span>
            </div>
            {selected.map((v, idx) => (
              <div key={v.id} className="border-l border-slate-100 border-b bg-white">
                <div className="relative">
                  <img src={v.image} alt={v.name} className="w-full h-36 object-cover" />
                  <button
                    onClick={() => setSelected(selected.filter((_, i) => i !== idx))}
                    className="absolute top-2 right-2 w-7 h-7 bg-white/90 rounded-full flex items-center justify-center text-slate-500 hover:text-red-500 transition-colors"
                  >
                    <X size={13} />
                  </button>
                </div>
                <div className="p-3">
                  <p className="text-slate-800 leading-snug" style={{ fontFamily: "var(--font-display)", fontWeight: 600, fontSize: "14px" }}>{v.name}</p>
                  <p className="text-[#0A0A2B] text-sm mt-0.5" style={{ fontWeight: 700 }}>{v.price}</p>
                </div>
              </div>
            ))}
            {selected.length < 3 && (
              <div className="border-l border-slate-100 border-b bg-slate-50 flex flex-col items-center justify-center gap-2 p-4 cursor-pointer hover:bg-[#E8E8F0] transition-colors group">
                <div className="w-10 h-10 rounded-full border-2 border-dashed border-slate-300 group-hover:border-[#0A0A2B] flex items-center justify-center transition-colors">
                  <Plus size={16} className="text-slate-400 group-hover:text-[#0A0A2B] transition-colors" />
                </div>
                <p className="text-xs text-slate-500 group-hover:text-[#0A0A2B] transition-colors text-center" style={{ fontWeight: 500 }}>Add Vehicle</p>
              </div>
            )}
          </div>

          {/* Spec rows */}
          {specs.map((spec) => (
            <div key={spec} className="grid border-b border-slate-50 last:border-0 hover:bg-slate-50/50 transition-colors" style={{ gridTemplateColumns: `200px repeat(${selected.length}, 1fr) 160px` }}>
              <div className="p-4 flex items-center">
                <span className="text-sm text-slate-500" style={{ fontWeight: 500 }}>{spec}</span>
              </div>
              {selected.map((v, idx) => (
                <div key={v.id} className="p-4 border-l border-slate-100 flex items-center">
                  <span
                    className={`text-sm ${isBest(spec, idx) ? "text-green-700 bg-green-50 px-2 py-0.5 rounded-full" : "text-slate-700"}`}
                    style={{ fontWeight: isBest(spec, idx) ? 600 : 500 }}
                  >
                    {getSpec(v, spec)}
                    {isBest(spec, idx) && <span className="ml-1 text-xs">✓</span>}
                  </span>
                </div>
              ))}
              {selected.length < 3 && <div className="border-l border-slate-100" />}
            </div>
          ))}
        </div>

        <div className="flex justify-center mt-6">
          <button className="flex items-center gap-2 px-6 py-3 bg-[#0A0A2B] text-white rounded-xl hover:bg-[#06061A] transition-colors" style={{ fontWeight: 600 }}>
            <GitCompare size={16} />
            Full Side-by-Side Comparison
          </button>
        </div>
      </div>
    </section>
  );
}
