import { useState } from "react";
import { ArrowRight, Clock, User } from "lucide-react";
import { AdPlaceholder } from "./AdPlaceholder";

const tabs = ["Reviews", "Editorials", "News", "Buying Guides"];

const articles = {
  Reviews: [
    {
      id: 1,
      title: "Hyundai Creta 2024 Long-Term Review: Still the King of Compact SUVs?",
      excerpt: "After 12,000 km with the new Creta, we find out if it lives up to its legendary reputation in the fiercely competitive segment.",
      image: "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?w=800&h=500&fit=crop&auto=format",
      author: "Arjun Mehta",
      readTime: "8 min read",
      tag: "Long-term",
      featured: true,
    },
    {
      id: 2,
      title: "Tata Nexon EV vs MG ZS EV: Which EV Makes More Sense?",
      excerpt: "A comprehensive comparison of India's two most popular electric SUVs.",
      image: "https://images.unsplash.com/photo-1593941707882-a5bba14938c7?w=400&h=280&fit=crop&auto=format",
      author: "Priya Sharma",
      readTime: "6 min read",
      tag: "Comparison",
    },
    {
      id: 3,
      title: "Royal Enfield Himalayan 450 First Drive: A True Adventure Bike",
      excerpt: "The new Himalayan resets expectations for mid-capacity adventure bikes.",
      image: "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=400&h=280&fit=crop&auto=format",
      author: "Vikram Singh",
      readTime: "5 min read",
      tag: "First Drive",
    },
    {
      id: 4,
      title: "Honda City Hybrid: Premium Efficiency in the Sedan Segment",
      excerpt: "Honda's strong hybrid system makes the City a compelling choice.",
      image: "https://images.unsplash.com/photo-1494976388531-d1058494cdd8?w=400&h=280&fit=crop&auto=format",
      author: "Neha Kapoor",
      readTime: "7 min read",
      tag: "Road Test",
    },
  ],
  Editorials: [
    {
      id: 5,
      title: "The EV Revolution: Why 2024 is India's Defining Year for Electric Mobility",
      excerpt: "Infrastructure growth, new models, and falling prices are converging to make EVs a real option for the Indian consumer.",
      image: "https://images.unsplash.com/photo-1617704548623-340376564e68?w=800&h=500&fit=crop&auto=format",
      author: "Rohan Gupta",
      readTime: "10 min read",
      tag: "Opinion",
      featured: true,
    },
    {
      id: 6,
      title: "Why India's SUV Obsession Shows No Signs of Slowing",
      excerpt: "Data from 2024 sales figures reveals the continued dominance of utility vehicles.",
      image: "https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=400&h=280&fit=crop&auto=format",
      author: "Arjun Mehta",
      readTime: "6 min read",
      tag: "Analysis",
    },
    {
      id: 7,
      title: "The Case for Buying a Used Luxury Car in 2024",
      excerpt: "Premium depreciation creates extraordinary value opportunities for savvy buyers.",
      image: "https://images.unsplash.com/photo-1563720223523-0bf25e2c9e6a?w=400&h=280&fit=crop&auto=format",
      author: "Priya Sharma",
      readTime: "8 min read",
      tag: "Buying Advice",
    },
    {
      id: 8,
      title: "Performance Bikes Under ₹3 Lakh: The Sweet Spot",
      excerpt: "The best performing motorcycles that don't break the bank.",
      image: "https://images.unsplash.com/photo-1609630875171-b1321377ee65?w=400&h=280&fit=crop&auto=format",
      author: "Vikram Singh",
      readTime: "5 min read",
      tag: "Roundup",
    },
  ],
  News: [
    {
      id: 9,
      title: "Tata Curvv EV Officially Launched at ₹17.49 Lakh — Here's Everything You Need to Know",
      excerpt: "Tata's coupe-style electric SUV enters the market with strong specs and competitive pricing.",
      image: "https://images.unsplash.com/photo-1574175359067-5db88bef05d8?w=800&h=500&fit=crop&auto=format",
      author: "BikeCarHub Desk",
      readTime: "4 min read",
      tag: "Breaking",
      featured: true,
    },
    {
      id: 10,
      title: "Maruti Swift 2024 Sets New Booking Record — 50,000 Bookings in 30 Days",
      image: "https://images.unsplash.com/photo-1590362891991-f776e747a588?w=400&h=280&fit=crop&auto=format",
      excerpt: "The new Swift's popularity underscores India's enduring love for the hatchback.",
      author: "BikeCarHub Desk",
      readTime: "3 min read",
      tag: "Sales",
    },
  ],
  "Buying Guides": [
    {
      id: 11,
      title: "How to Buy Your First Car in India: A Complete 2024 Guide",
      excerpt: "Everything from budgeting and financing to insurance and resale value — all in one comprehensive guide.",
      image: "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=800&h=500&fit=crop&auto=format",
      author: "BikeCarHub Editors",
      readTime: "15 min read",
      tag: "Guide",
      featured: true,
    },
    {
      id: 12,
      title: "Best Cars Under ₹10 Lakh in India (2024 Edition)",
      image: "https://images.unsplash.com/photo-1542362567-b07e54358753?w=400&h=280&fit=crop&auto=format",
      excerpt: "Our experts pick the very best value-for-money cars in the budget segment.",
      author: "BikeCarHub Editors",
      readTime: "8 min read",
      tag: "Roundup",
    },
  ],
};

export function EditorialSection() {
  const [activeTab, setActiveTab] = useState("Reviews");
  const currentArticles = articles[activeTab];
  const featured = currentArticles.find((a) => a.featured) || currentArticles[0];
  const secondary = currentArticles.filter((a) => !a.featured || a.id !== featured.id).slice(0, 3);

  return (
    <section className="py-14 bg-[#F8FAFC] border-t border-slate-100">
      <div className="max-w-7xl mx-auto px-4">
        <div className="flex items-end justify-between mb-6">
          <div>
            <p className="text-xs uppercase tracking-widest text-[#0A0A2B] mb-1" style={{ fontWeight: 600 }}>
              Editorial
            </p>
            <h2 className="text-slate-800" style={{ fontFamily: "var(--font-display)", fontWeight: 800, fontSize: "clamp(1.5rem, 3vw, 2rem)" }}>
              Reviews & Stories
            </h2>
          </div>
          <button className="hidden md:flex items-center gap-1.5 text-sm text-[#0A0A2B] hover:gap-2.5 transition-all" style={{ fontWeight: 600 }}>
            All Articles <ArrowRight size={14} />
          </button>
        </div>

        {/* Tabs */}
        <div className="flex gap-1 mb-8 border-b border-slate-200">
          {tabs.map((tab) => (
            <button
              key={tab}
              onClick={() => setActiveTab(tab)}
              className={`px-5 py-2.5 text-sm transition-all border-b-2 -mb-px ${
                activeTab === tab
                  ? "border-[#0A0A2B] text-[#0A0A2B]"
                  : "border-transparent text-slate-500 hover:text-slate-700"
              }`}
              style={{ fontWeight: 500 }}
            >
              {tab}
            </button>
          ))}
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-[1fr_380px] gap-6">
          {/* Featured article */}
          <article className="group bg-white rounded-2xl overflow-hidden border border-slate-100 shadow-sm hover:shadow-md transition-all cursor-pointer">
            <div className="relative overflow-hidden" style={{ height: "320px" }}>
              <img src={featured.image} alt={featured.title} className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500" />
              <div className="absolute inset-0 bg-gradient-to-t from-[#1F2937]/80 via-transparent to-transparent" />
              <span className="absolute top-4 left-4 px-3 py-1 bg-[#0A0A2B] text-white text-xs rounded-full" style={{ fontWeight: 600 }}>
                {featured.tag}
              </span>
              <div className="absolute bottom-0 left-0 right-0 p-6">
                <h3 className="text-white leading-snug mb-2" style={{ fontFamily: "var(--font-display)", fontWeight: 700, fontSize: "1.25rem" }}>
                  {featured.title}
                </h3>
                <p className="text-slate-300 text-sm leading-relaxed line-clamp-2">{featured.excerpt}</p>
                <div className="flex items-center gap-3 mt-3">
                  <span className="text-xs text-slate-400 flex items-center gap-1"><User size={11} />{featured.author}</span>
                  <span className="text-xs text-slate-400 flex items-center gap-1"><Clock size={11} />{featured.readTime}</span>
                </div>
              </div>
            </div>
          </article>

          {/* Secondary articles */}
          <div className="flex flex-col gap-4">
            {secondary.map((article) => (
              <article key={article.id} className="group flex gap-4 bg-white rounded-xl overflow-hidden border border-slate-100 shadow-sm hover:shadow-md transition-all cursor-pointer p-3">
                <div className="w-24 h-24 shrink-0 rounded-lg overflow-hidden bg-slate-100">
                  <img src={article.image} alt={article.title} className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500" />
                </div>
                <div className="flex flex-col justify-between min-w-0">
                  <div>
                    <span className="text-xs text-[#0A0A2B] mb-1 block" style={{ fontWeight: 600 }}>{article.tag}</span>
                    <h4 className="text-slate-800 leading-snug line-clamp-2" style={{ fontFamily: "var(--font-display)", fontWeight: 600, fontSize: "14px" }}>
                      {article.title}
                    </h4>
                  </div>
                  <div className="flex items-center gap-3 mt-1">
                    <span className="text-xs text-slate-400 flex items-center gap-1"><Clock size={10} />{article.readTime}</span>
                  </div>
                </div>
              </article>
            ))}

            <AdPlaceholder label="Advertisement" height="h-24" />
          </div>
        </div>
      </div>
    </section>
  );
}
