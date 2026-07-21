import { useState, useRef } from "react";
import { ChevronLeft, ChevronRight } from "lucide-react";
import { VehicleCard } from "./VehicleCard";

export function CoverflowCarousel({ vehicles }) {
  const [activeIndex, setActiveIndex] = useState(2);
  const trackRef = useRef(null);

  const getCardStyle = (index) => {
    const offset = index - activeIndex;
    const absOffset = Math.abs(offset);

    if (absOffset > 3) return { display: "none" };

    const scale = offset === 0 ? 1 : absOffset === 1 ? 0.85 : 0.72;
    const translateX = offset * 75;
    const rotateY = offset * -12;
    const zIndex = 10 - absOffset;
    const opacity = absOffset > 2 ? 0 : 1 - absOffset * 0.15;
    const blur = absOffset > 1 ? `blur(${absOffset * 1}px)` : "none";

    return {
      transform: `perspective(1200px) translateX(${translateX}%) scale(${scale}) rotateY(${rotateY}deg)`,
      zIndex,
      opacity,
      filter: blur,
      transition: "all 0.45s cubic-bezier(0.25, 0.46, 0.45, 0.94)",
      transformStyle: "preserve-3d",
    };
  };

  const prev = () => setActiveIndex(Math.max(0, activeIndex - 1));
  const next = () => setActiveIndex(Math.min(vehicles.length - 1, activeIndex + 1));

  return (
    <div className="relative">
      <div
        ref={trackRef}
        className="relative flex items-center justify-center overflow-hidden"
        style={{ height: "320px", perspective: "1200px" }}
      >
        {vehicles.map((vehicle, index) => (
          <div
            key={vehicle.id}
            className="absolute w-72 cursor-pointer"
            style={getCardStyle(index)}
            onClick={() => setActiveIndex(index)}
          >
            <VehicleCard vehicle={vehicle} size={index === activeIndex ? "lg" : "md"} />
          </div>
        ))}
      </div>

      <div className="flex items-center justify-center gap-4 mt-6">
        <button
          onClick={prev}
          disabled={activeIndex === 0}
          className="w-10 h-10 rounded-full border border-slate-200 flex items-center justify-center text-slate-600 hover:border-[#0A0A2B] hover:text-[#0A0A2B] disabled:opacity-30 disabled:cursor-not-allowed transition-all"
        >
          <ChevronLeft size={18} />
        </button>

        <div className="flex gap-2">
          {vehicles.map((_, idx) => (
            <button
              key={idx}
              onClick={() => setActiveIndex(idx)}
              className={`rounded-full transition-all ${idx === activeIndex ? "w-6 h-2 bg-[#0A0A2B]" : "w-2 h-2 bg-slate-200 hover:bg-slate-300"}`}
            />
          ))}
        </div>

        <button
          onClick={next}
          disabled={activeIndex === vehicles.length - 1}
          className="w-10 h-10 rounded-full border border-slate-200 flex items-center justify-center text-slate-600 hover:border-[#0A0A2B] hover:text-[#0A0A2B] disabled:opacity-30 disabled:cursor-not-allowed transition-all"
        >
          <ChevronRight size={18} />
        </button>
      </div>
    </div>
  );
}
