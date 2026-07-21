import { useState } from "react";
import { Calendar } from "lucide-react";

const allBlogs = [
  { id: 1, title: "BMW F 450 GS India Launch: Price, Specs, Features and Comparison", date: "7 May 2026", image: "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=600&h=380&fit=crop&auto=format" },
  { id: 2, title: "MG Majestor 2026: India's Most Dominant Off-Road SUV", date: "22 Apr 2026", image: "https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=600&h=380&fit=crop&auto=format" },
  { id: 3, title: "The New Renault Duster: A Bold Comeback with Hybrid Power", date: "22 Apr 2026", image: "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=600&h=380&fit=crop&auto=format" },
  { id: 4, title: "Nissan Gravite: The New Benchmark in Premium Compact SUVs", date: "9 Mar 2026", image: "https://images.unsplash.com/photo-1494976388531-d1058494cdd8?w=600&h=380&fit=crop&auto=format" },
  { id: 5, title: "The New BMW 2 Series Gran Coupe: Style Meets Performance", date: "26 Jan 2026", image: "https://images.unsplash.com/photo-1617704548623-340376564e68?w=600&h=380&fit=crop&auto=format" },
  { id: 6, title: "The New Skoda Kushaq: Refined, Powerful and Feature-Packed", date: "26 Jan 2026", image: "https://images.unsplash.com/photo-1593941707882-a5bba14938c7?w=600&h=380&fit=crop&auto=format" },
  { id: 7, title: "All-New Tata Punch Facelift: Everything You Need to Know", date: "19 Jan 2026", image: "https://images.unsplash.com/photo-1590362891991-f776e747a588?w=600&h=380&fit=crop&auto=format" },
  { id: 8, title: "BMW New X3: Price, Features, Range and Full Review", date: "15 Jan 2026", image: "https://images.unsplash.com/photo-1617469767053-d3b523a0b982?w=600&h=380&fit=crop&auto=format" },
  { id: 9, title: "New Tata Harrier Petro: The Iconic SUV Gets a Petrol Heart", date: "14 Jan 2026", image: "https://images.unsplash.com/photo-1563720223523-0bf25e2c9e6a?w=600&h=380&fit=crop&auto=format" },
  { id: 10, title: "Mahindra XUV TXO: Price, Specs and All You Need to Know", date: "10 Jan 2026", image: "https://images.unsplash.com/photo-1542362567-b07e54358753?w=600&h=380&fit=crop&auto=format" },
  { id: 11, title: "The All-New KIA Seltos: Bold Design, Smart Features", date: "18 Dec 2025", image: "https://images.unsplash.com/photo-1547549082-6bc09f2049ae?w=600&h=380&fit=crop&auto=format" },
  { id: 12, title: "Mahindra BE 6 Formula E Inspired: India's Boldest EV Yet", date: "30 Nov 2025", image: "https://images.unsplash.com/photo-1585313647787-ececc7a670ca?w=600&h=380&fit=crop&auto=format" },
  { id: 13, title: "Tata Sierra: The Return of a Legend in Electric Avatar", date: "28 Nov 2025", image: "https://images.unsplash.com/photo-1609630875171-b1321377ee65?w=600&h=380&fit=crop&auto=format" },
  { id: 14, title: "The Legend Reborn: Unwrapping the All-New Jeep Wrangler 2026", date: "26 Nov 2025", image: "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87?w=600&h=380&fit=crop&auto=format" },
  { id: 15, title: "Hyundai VENUE: The New Champion of Urban Mobility", date: "10 Nov 2025", image: "https://images.unsplash.com/photo-1525160354320-d8e92641c563?w=600&h=380&fit=crop&auto=format" },
  { id: 16, title: "The Ultimate Road Trip Companion: Top 5 Highway Cruisers", date: "27 Oct 2025", image: "https://images.unsplash.com/photo-1591637333184-19aa84b3e01f?w=600&h=380&fit=crop&auto=format" },
  { id: 17, title: "Royal Enfield Bear 650: India's New Adventure Tourer Arrives", date: "15 Sep 2025", image: "https://images.unsplash.com/photo-1609630875171-b1321377ee65?w=600&h=380&fit=crop&auto=format" },
  { id: 18, title: "Maruti Victoris: Mileage King or Premium Pretender?", date: "15 Sep 2025", image: "https://images.unsplash.com/photo-1542362567-b07e54358753?w=600&h=380&fit=crop&auto=format" },
  { id: 19, title: "Road and Highway Types in India: A Complete Guide", date: "12 Sep 2025", image: "https://images.unsplash.com/photo-1494976388531-d1058494cdd8?w=600&h=380&fit=crop&auto=format" },
  { id: 20, title: "Renault Kiger Facelift: Sharper Looks, Smarter Tech", date: "19 Aug 2025", image: "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=600&h=380&fit=crop&auto=format" },
  { id: 21, title: "Royal Enfield Interceptor 650 vs Continental GT 650", date: "8 Aug 2025", image: "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=600&h=380&fit=crop&auto=format" },
  { id: 22, title: "Hero vs Honda: Which Bike Brand is Better Under Rs 1 Lakh?", date: "4 Aug 2025", image: "https://images.unsplash.com/photo-1547549082-6bc09f2049ae?w=600&h=380&fit=crop&auto=format" },
  { id: 23, title: "Most Powerful Bikes Under Rs 3 Lakhs in India 2025", date: "29 Jul 2025", image: "https://images.unsplash.com/photo-1568772585407-9361f9bf3a87?w=600&h=380&fit=crop&auto=format" },
  { id: 24, title: "Renault Triber 2025 Facelift: The Family Car Gets a Glow-Up", date: "24 Jul 2025", image: "https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=600&h=380&fit=crop&auto=format" },
];

const PAGE_SIZE = 12;

function BlogCard({ blog }) {
  const [hovered, setHovered] = useState(false);

  return (
    <div
      onMouseEnter={() => setHovered(true)}
      onMouseLeave={() => setHovered(false)}
      className="rounded-xl overflow-hidden cursor-pointer flex flex-col"
      style={{
        border: hovered ? "1.5px solid #0A0A2B" : "1.5px solid #E5E7EB",
        background: hovered ? "#F5F6FF" : "#ffffff",
        boxShadow: hovered ? "0 8px 32px rgba(10,10,43,0.13)" : "0 2px 8px rgba(0,0,0,0.05)",
        transition: "all 0.22s ease",
        transform: hovered ? "translateY(-4px)" : "translateY(0)",
      }}
    >
      <div className="overflow-hidden" style={{ height: "168px", flexShrink: 0 }}>
        <img
          src={blog.image}
          alt={blog.title}
          className="w-full h-full object-cover"
          style={{
            transform: hovered ? "scale(1.05)" : "scale(1)",
            transition: "transform 0.4s ease",
          }}
        />
      </div>

      <div className="p-4 flex flex-col flex-1 gap-2">
        <p
          style={{
            fontFamily: "var(--font-display)",
            fontWeight: 600,
            fontSize: "13px",
            color: hovered ? "#0A0A2B" : "#1F2937",
            lineHeight: 1.45,
            display: "-webkit-box",
            WebkitLineClamp: 2,
            WebkitBoxOrient: "vertical",
            overflow: "hidden",
            transition: "color 0.2s",
          }}
        >
          {blog.title}
        </p>

        <div className="flex items-center gap-1.5" style={{ color: "#6B7280", fontSize: "12px" }}>
          <Calendar size={11} />
          <span style={{ fontFamily: "var(--font-body)" }}>{blog.date}</span>
        </div>

        <div className="mt-auto pt-2">
          <button
            className="px-4 py-1.5 rounded text-white text-xs transition-all"
            style={{
              background: hovered ? "#06061A" : "#0A0A2B",
              fontFamily: "var(--font-display)",
              fontWeight: 600,
              letterSpacing: "0.02em",
            }}
          >
            View Details
          </button>
        </div>
      </div>
    </div>
  );
}

export function BlogsPage() {
  const [page, setPage] = useState(1);
  const totalPages = Math.ceil(allBlogs.length / PAGE_SIZE);
  const visible = allBlogs.slice((page - 1) * PAGE_SIZE, page * PAGE_SIZE);

  return (
    <div className="min-h-screen bg-white" style={{ fontFamily: "var(--font-body)" }}>
      <div
        className="w-full py-2 px-6 flex flex-col items-center justify-center"
        style={{ background: "#0A0A2B" }}
      >
        <h1
          style={{
            fontFamily: "var(--font-display)",
            fontWeight: 800,
            fontSize: "clamp(1.6rem, 3vw, 2.2rem)",
            color: "#ffffff",
            letterSpacing: "-0.02em",
          }}
        >
          Blogs
        </h1>
        <p style={{ color: "rgba(255,255,255,0.55)", fontSize: "14px", marginTop: "0px" }}>
          Latest news, reviews and guides from BikeCarHub
        </p>
      </div>

      <div className="max-w-7xl mx-auto px-6 py-10">
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-5">
          {visible.map((blog) => (
            <BlogCard key={blog.id} blog={blog} />
          ))}
        </div>

        {totalPages > 1 && (
          <div className="flex items-center justify-center gap-2 mt-10">
            <button
              onClick={() => { setPage((p) => Math.max(1, p - 1)); window.scrollTo({ top: 0, behavior: "smooth" }); }}
              disabled={page === 1}
              className="px-4 py-2 rounded-lg text-sm transition-all disabled:opacity-40"
              style={{
                border: "1.5px solid #0A0A2B",
                background: "white",
                color: "#0A0A2B",
                fontFamily: "var(--font-display)",
                fontWeight: 600,
                cursor: page === 1 ? "not-allowed" : "pointer",
              }}
            >
              Prev
            </button>

            {Array.from({ length: totalPages }, (_, i) => i + 1).map((p) => (
              <button
                key={p}
                onClick={() => { setPage(p); window.scrollTo({ top: 0, behavior: "smooth" }); }}
                className="w-9 h-9 rounded-lg text-sm transition-all"
                style={{
                  background: p === page ? "#0A0A2B" : "white",
                  color: p === page ? "white" : "#0A0A2B",
                  border: "1.5px solid #0A0A2B",
                  fontFamily: "var(--font-display)",
                  fontWeight: 600,
                }}
              >
                {p}
              </button>
            ))}

            <button
              onClick={() => { setPage((p) => Math.min(totalPages, p + 1)); window.scrollTo({ top: 0, behavior: "smooth" }); }}
              disabled={page === totalPages}
              className="px-4 py-2 rounded-lg text-sm transition-all disabled:opacity-40"
              style={{
                border: "1.5px solid #0A0A2B",
                background: "white",
                color: "#0A0A2B",
                fontFamily: "var(--font-display)",
                fontWeight: 600,
                cursor: page === totalPages ? "not-allowed" : "pointer",
              }}
            >
              Next
            </button>
          </div>
        )}
      </div>
    </div>
  );
}
