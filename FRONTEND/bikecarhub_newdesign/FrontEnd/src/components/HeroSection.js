//import { getModels } from "../api/modelApi";
import * as modelApi from "../api/modelApi";
import { ChevronDown, Search, TrendingUp } from "lucide-react";
import { AdPlaceholder } from "./AdPlaceholder";
import { useEffect, useState } from "react";
import { getBrands } from "../api/brandApi";
import { getVehicleDetails } from "../api/searchApi";
import { useNavigate } from "react-router-dom";
import { slugify } from "../utils/slugify";

const heroSlides = [
  {
    title: "Drive Your\nDream Vehicle",
    subtitle: "Discover 50,000+ cars, bikes, and EVs with expert reviews and AI-powered recommendations.",
    image: "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=1400&h=800&fit=crop&auto=format",
    badge: "New Launch",
    featured: "Tata Curvv EV",
    price: "₹17.49 Lakh onwards",
  },
  {
    title: "India's Fastest\nGrowing EVs",
    subtitle: "Explore the complete electric vehicle ecosystem — cars, bikes, and scooters for a greener drive.",
    image: "https://images.unsplash.com/photo-1593941707882-a5bba14938c7?w=1400&h=800&fit=crop&auto=format",
    badge: "Electric Era",
    featured: "MG ZS EV 2024",
    price: "₹18.98 Lakh onwards",
  },
  {
    title: "Born to\nConquer Roads",
    subtitle: "From everyday commuters to adventure tourers — find the perfect bike that matches your spirit.",
    image: "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=1400&h=800&fit=crop&auto=format",
    badge: "Top Rated",
    featured: "Royal Enfield Himalayan",
    price: "₹2.69 Lakh onwards",
  },
];


const budgetOptions = [
  { label: "Under ₹1 Lakh", value: "under-1l" },
  { label: "Under ₹2 Lakh", value: "under-2l" },
  { label: "Under ₹3 Lakh", value: "under-3l" },
  { label: "More Than ₹3 Lakh", value: "above-3l" },
];

function SelectField({
  label,
  value,
  onChange,
  options,
  disabled = false,
  placeholder,
}) {
  return (
    <div className="relative flex flex-col gap-1.5">
      <label className="text-xs uppercase tracking-wider text-slate-500" style={{ fontWeight: 600 }}>
        {label}
      </label>
      <div className="relative">
        <select
          value={value}
          onChange={(e) => onChange(e.target.value)}
          disabled={disabled}
          className={`w-full appearance-none px-4 py-3 pr-10 bg-white border rounded-xl text-sm outline-none transition-all cursor-pointer
            ${disabled ? "border-slate-100 text-slate-400 cursor-not-allowed bg-slate-50" : "border-slate-200 text-slate-700 hover:border-[#0A0A2B] focus:border-[#0A0A2B] focus:ring-2 focus:ring-[#E8E8F0]"}
          `}
          style={{ fontFamily: "var(--font-body)", fontWeight: value ? 500 : 400 }}
        >
          <option value="" disabled>
            {placeholder}
          </option>
          {options.map((opt) => (
            <option key={opt.value} value={opt.value}>
              {opt.label}
            </option>
          ))}
        </select>
        <ChevronDown
          size={15}
          className={`absolute right-3 top-1/2 -translate-y-1/2 pointer-events-none transition-colors ${disabled ? "text-slate-300" : "text-slate-400"}`}
        />
      </div>
    </div>
  );
}

export function HeroSection() {
    const navigate = useNavigate();
    const [activeSlide, setActiveSlide] = useState(0);
    const [brand, setBrand] = useState("");
    const [model, setModel] = useState("");
    const [budget, setBudget] = useState("");

    const [brands, setBrands] = useState([]);
    const [models, setModels] = useState([]);

    useEffect(() => {

        async function loadBrands() {

            try {

                const data = await getBrands();

                setBrands(data);

            } catch (err) {

                console.error(err);

            }

        }

        loadBrands();

    }, []);

  const slide = heroSlides[activeSlide];

    const handleBrandChange = async (value) => {

        setBrand(value);
        setModel("");
        setModels([]);

        try {


            //const data = await getModels(value);
            console.log(modelApi);

            const data = await modelApi.getModels(value);

            setModels(data);

        } catch (err) {

            console.error(err);

        }

    };

    const canSearch = brand !== "";

    const handleSearch = async () => {

        try {

            // Brand selected but no model selected
            if (brand && !model) {

                const selectedBrand = brands.find(
                    b => b.name === brand
                );

                if (selectedBrand) {

                    navigate(`/${selectedBrand.name.toLowerCase().replace(/\s+/g, "-")}`);

                    return;

                }

            }

            // Brand + Model selected
            if (brand && model) {

                const details = await getVehicleDetails(model);

                navigate(
                    `/${details.brandName}/${details.bikeName}`
                );

            }

        }

        catch (err) {

            console.error(err);

        }

    };

  return (
    <section className="relative">
      <div className="max-w-7xl mx-auto px-4 py-6">
        <div className="grid grid-cols-1 lg:grid-cols-[1fr_420px] gap-6 items-stretch">

          {/* Hero main banner */}
          <div className="relative rounded-2xl overflow-hidden" style={{ minHeight: "480px" }}>
            <img
              src={slide.image}
              alt={slide.featured}
              className="absolute inset-0 w-full h-full object-cover transition-all duration-700"
            />
            <div className="absolute inset-0 bg-gradient-to-r from-[#1F2937]/80 via-[#1F2937]/40 to-transparent" />
            <div className="absolute inset-0 bg-gradient-to-t from-[#1F2937]/60 via-transparent to-transparent" />

            {/* Text content */}
            <div className="relative z-10 p-8 flex flex-col justify-between" style={{ minHeight: "480px" }}>
              <div>
                <span className="inline-block px-3 py-1 rounded-full text-xs bg-[#0A0A2B] text-white mb-4" style={{ fontWeight: 600 }}>
                  {slide.badge}
                </span>
                <h1
                  className="text-white mb-3 leading-tight"
                  style={{
                    fontFamily: "var(--font-display)",
                    fontWeight: 800,
                    fontSize: "clamp(2rem, 4vw, 3rem)",
                    whiteSpace: "pre-line",
                  }}
                >
                  {slide.title}
                </h1>
                <p className="text-slate-300 max-w-sm leading-relaxed" style={{ fontSize: "15px" }}>
                  {slide.subtitle}
                </p>
              </div>

              {/* Featured vehicle chip */}
              <div className="flex items-center gap-3">
                <div className="bg-white/10 backdrop-blur-sm border border-white/20 rounded-xl px-4 py-3">
                  <div className="flex items-center gap-2">
                    <TrendingUp size={14} className="text-[#A0A0CC]" />
                    <span className="text-white text-xs" style={{ fontWeight: 600 }}>{slide.featured}</span>
                    <span className="text-slate-300 text-xs">—</span>
                    <span className="text-[#A0A0CC] text-xs" style={{ fontWeight: 600 }}>{slide.price}</span>
                  </div>
                </div>
              </div>
            </div>

            {/* Slide indicators */}
            <div className="absolute top-6 right-6 flex gap-1.5 z-10">
              {heroSlides.map((_, idx) => (
                <button
                  key={idx}
                  onClick={() => setActiveSlide(idx)}
                  className={`rounded-full transition-all ${idx === activeSlide ? "w-5 h-2 bg-white" : "w-2 h-2 bg-white/50 hover:bg-white/75"}`}
                />
              ))}
            </div>
          </div>

          {/* Right column: Search card + ad + trending */}
          <div className="flex flex-col h-full">

            {/* ── SEARCH BIKES CARD ── */}
            <div
              className="bg-white rounded-2xl border border-slate-100 shadow-md overflow-hidden flex flex-col"
              style={{ minHeight: "480px" }}
            >
              {/* Card header */}
              <div className="bg-[#0A0A2B] px-5 py-3.5 flex items-center gap-2">
                <Search size={16} className="text-white/80" />
                <span
                  className="text-white tracking-wider"
                  style={{ fontFamily: "var(--font-display)", fontWeight: 700, fontSize: "14px", letterSpacing: "0.08em" }}
                >
                  SEARCH BIKES
                </span>
              </div>

              {/* Form body */}
              <div className="p-5 flex flex-col gap-4 flex-1 justify-center">
                {/* Brand */}
                {console.log(models)}
                <SelectField
                  label="Select Brand"
                  value={brand}
                  onChange={handleBrandChange}
                  options={brands.map((b) => ({
                    label: b.name,
                    value: b.name
                  }))}
                  placeholder="Select Brand"
                />

                {/* Model */}
                <SelectField
                  label="Select Model"
                  value={model}
                  onChange={setModel}
                  options={models}
                  disabled={!brand}
                  placeholder={brand ? "Select Model" : "Select a brand first"}
                />

                {/* Budget */}
                <SelectField
                  label="Select Budget"
                  value={budget}
                  onChange={setBudget}
                  options={budgetOptions}
                  placeholder="Select Budget"
                />

                {/* Search button */}
                <button
                  onClick={handleSearch}
                  disabled={!canSearch}
                  className={`w-full flex items-center justify-center gap-2 py-3.5 rounded-xl text-sm transition-all mt-1
                    ${canSearch
                      ? "bg-[#0A0A2B] hover:bg-[#06061A] text-white shadow-sm hover:shadow-md hover:-translate-y-0.5 active:translate-y-0"
                      : "bg-slate-100 text-slate-400 cursor-not-allowed"
                    }`}
                  style={{ fontFamily: "var(--font-display)", fontWeight: 700, letterSpacing: "0.06em" }}
                >
                  <Search size={15} />
                  SEARCH
                </button>

                {!canSearch && (
                  <p className="text-xs text-slate-400 text-center -mt-2">
                       Select a brand or model to search
                  </p>
                )}
              </div>
            </div>

          </div>
        </div>
      </div>
    </section>
  );
}
