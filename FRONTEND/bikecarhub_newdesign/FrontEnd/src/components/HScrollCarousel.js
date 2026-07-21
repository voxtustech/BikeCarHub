import { useRef, useState, useEffect, Children } from "react";
import { ChevronLeft, ChevronRight } from "lucide-react";

export function HScrollCarousel({ children, itemWidth = 320 }) {
  const scrollRef = useRef(null);
  const [activeIndex, setActiveIndex] = useState(0);

  useEffect(() => {
    const container = scrollRef.current;
    if (!container) return;

    const onScroll = () => {
      const containerCenter = container.scrollLeft + container.offsetWidth / 2;
      let closest = 0;
      let minDist = Infinity;
      Array.from(container.children).forEach((child, i) => {
        const el = child;
        const cardCenter = el.offsetLeft + el.offsetWidth / 2;
        const dist = Math.abs(containerCenter - cardCenter);
        if (dist < minDist) { minDist = dist; closest = i; }
      });
      setActiveIndex(closest);
    };

    container.addEventListener("scroll", onScroll, { passive: true });
    onScroll();
    return () => container.removeEventListener("scroll", onScroll);
  }, [children]);

  const scroll = (dir) => {
    if (!scrollRef.current) return;
    scrollRef.current.scrollBy({ left: dir === "left" ? -itemWidth : itemWidth, behavior: "smooth" });
  };

  const items = Children.toArray(children);

  return (
    <div className="relative">
      <button
        onClick={() => scroll("left")}
        className="absolute left-0 top-1/2 -translate-y-1/2 -translate-x-3 z-10 w-8 h-8 rounded-full bg-white border border-slate-200 shadow-md flex items-center justify-center text-slate-600 hover:text-[#0A0A2B] hover:border-[#0A0A2B] transition-all"
      >
        <ChevronLeft size={16} />
      </button>

      <div
        ref={scrollRef}
        className="flex gap-5 overflow-x-auto scrollbar-hide scroll-smooth px-6 pb-6 pt-4"
        style={{ scrollSnapType: "x mandatory" }}
      >
        {items.map((child, i) => {
          const isActive = i === activeIndex;
          return (
            <div
              key={i}
              style={{
                transition: "transform 0.4s cubic-bezier(0.4,0,0.2,1), opacity 0.4s ease, box-shadow 0.4s ease",
                transform: isActive
                  ? "scale(1.10) perspective(800px) rotateY(0deg)"
                  : i < activeIndex
                    ? "scale(0.88) perspective(800px) rotateY(6deg)"
                    : "scale(0.88) perspective(800px) rotateY(-6deg)",
                opacity: isActive ? 1 : 0.45,
                transformOrigin: "center center",
                flexShrink: 0,
                scrollSnapAlign: "start",
                filter: isActive ? "none" : "brightness(0.72) saturate(0.6)",
                boxShadow: isActive ? "0 12px 40px rgba(10,10,43,0.18)" : "none",
              }}
            >
              {child}
            </div>
          );
        })}
      </div>

      <button
        onClick={() => scroll("right")}
        className="absolute right-0 top-1/2 -translate-y-1/2 translate-x-3 z-10 w-8 h-8 rounded-full bg-white border border-slate-200 shadow-md flex items-center justify-center text-slate-600 hover:text-[#0A0A2B] hover:border-[#0A0A2B] transition-all"
      >
        <ChevronRight size={16} />
      </button>
    </div>
  );
}
