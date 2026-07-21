import { useState } from "react";
import { Heart, GitCompare, Star, Zap, Fuel, Wind } from "lucide-react";
import { BACKEND_URL } from "../config";

const fuelIcon = (type) => {
  if (type === "Electric") return <Zap size={12} className="text-green-500" />;
  if (type === "Hybrid") return <Wind size={12} className="text-teal-500" />;
  return <Fuel size={12} className="text-slate-400" />;
};

const fuelColor = (type) => {
  if (type === "Electric") return "text-green-600 bg-green-50";
  if (type === "Hybrid") return "text-teal-600 bg-teal-50";
  if (type === "Diesel") return "text-amber-700 bg-amber-50";
  return "text-slate-600 bg-slate-100";
};

export function VehicleCard({ vehicle, size = "md" }) {
  const [saved, setSaved] = useState(false);
  const [compared, setCompared] = useState(false);

  return (
    <div className="group bg-white rounded-2xl overflow-hidden border border-slate-100 shadow-sm hover:shadow-md transition-all duration-300 hover:-translate-y-0.5 cursor-pointer">
      <div className="relative overflow-hidden bg-slate-50" style={{ height: size === "lg" ? "220px" : "180px" }}>
              <img
                  src={`${BACKEND_URL}${vehicle.image}`}
                  alt={vehicle.name}
                  className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500"
        />
        {/*
        <img
          src={vehicle.image}
          alt={vehicle.name}
          className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500"
              />
        */}
        {vehicle.tag && (
          <span className={`absolute top-3 left-3 text-xs px-2 py-1 rounded-full font-medium ${vehicle.tagColor || "bg-[#0A0A2B] text-white"}`}>
            {vehicle.tag}
          </span>
        )}
        <div className="absolute top-3 right-3 flex gap-1.5">
          <button
            onClick={(e) => { e.stopPropagation(); setSaved(!saved); }}
            className={`w-8 h-8 rounded-full flex items-center justify-center backdrop-blur-sm transition-all ${saved ? "bg-red-500 text-white" : "bg-white/90 text-slate-500 hover:text-red-500"}`}
          >
            <Heart size={14} fill={saved ? "currentColor" : "none"} />
          </button>
          <button
            onClick={(e) => { e.stopPropagation(); setCompared(!compared); }}
            className={`w-8 h-8 rounded-full flex items-center justify-center backdrop-blur-sm transition-all ${compared ? "bg-[#0A0A2B] text-white" : "bg-white/90 text-slate-500 hover:text-[#0A0A2B]"}`}
          >
            <GitCompare size={14} />
          </button>
        </div>
      </div>

      <div className="p-4">
        <div className="flex items-start justify-between gap-2 mb-1">
          <div>
            <p className="text-xs text-slate-400 uppercase tracking-wider mb-0.5">{vehicle.brand}</p>
            <h3 className="text-slate-800 leading-snug" style={{ fontFamily: "var(--font-display)", fontWeight: 600 }}>
              {vehicle.name}
            </h3>
          </div>
          <div className="flex items-center gap-1 shrink-0">
            <Star size={12} fill="#F59E0B" className="text-amber-400" />
            <span className="text-sm text-slate-700" style={{ fontWeight: 600 }}>{vehicle.rating}</span>
            <span className="text-xs text-slate-400">({vehicle.reviews})</span>
          </div>
        </div>

        <div className="flex items-center justify-between mt-3 pt-3 border-t border-slate-100">
          <p className="text-slate-900" style={{ fontFamily: "var(--font-display)", fontWeight: 700 }}>
            {vehicle.price}
          </p>
          <span className={`flex items-center gap-1 text-xs px-2 py-1 rounded-full ${fuelColor(vehicle.fuelType)}`} style={{ fontWeight: 500 }}>
            {fuelIcon(vehicle.fuelType)}
            {vehicle.fuelType}
          </span>
        </div>
      </div>
    </div>
  );
}
