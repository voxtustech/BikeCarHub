import { useState, useRef, useEffect } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { MapPin, User, Bell, Menu, X, Search } from "lucide-react";
//import { ImageWithFallback } from "./figma/ImageWithFallback"
import { AskQuestionModal } from "./AskQuestionModal";
import bchLogo from "../imports/bchlogo.jpeg";
import { searchVehicles, getVehicleDetails } from "../api/searchApi";

const navItems = ["Home", "Compare", "Blogs", "EMI Calculator", "Ask a Question"];

export function Header() {
    const [mobileOpen, setMobileOpen] = useState(false);
    const [askOpen, setAskOpen] = useState(false);
    const [showHeader, setShowHeader] = useState(true);
    const [searchTerm, setSearchTerm] = useState("");
    const [showSuggestions, setShowSuggestions] = useState(false);
    const [suggestions, setSuggestions] = useState([]);
    const [loadingSuggestions, setLoadingSuggestions] = useState(false);
    const navigate = useNavigate();
    const location = useLocation();
    const routeMap = {
        "/": "Home",
        "/compare": "Compare",
        "/blogs": "Blogs",
        "/emi-calculator": "EMI Calculator",
        "/login": "Login",
    };

    const handleNavigation = (item) => {
        switch (item) {
            case "Home":
                navigate("/");
                break;

            case "Compare":
                navigate("/compare");
                break;

            case "Blogs":
                navigate("/blogs");
                break;

            case "EMI Calculator":
                navigate("/emi-calculator");
                break;

            case "Login":
                navigate("/login");
                break;

            case "Ask a Question":
                setAskOpen(true);
                break;

            default:
                navigate("/");
        }
    };

    const activeItem = routeMap[location.pathname] || "Home";
    const menuRef = useRef(null);
    const searchRef = useRef(null);


    useEffect(() => {
        const handleClick = (e) => {
            if (menuRef.current && !menuRef.current.contains(e.target)) {
                setMobileOpen(false);
            }
        };
        document.addEventListener("mousedown", handleClick);
        return () => document.removeEventListener("mousedown", handleClick);
    }, []);

    useEffect(() => {
        document.body.style.overflow = mobileOpen ? "hidden" : "";
        return () => { document.body.style.overflow = ""; };
    }, [mobileOpen]);

    useEffect(() => {
        const handleClickOutside = (e) => {
            if (
                searchRef.current &&
                !searchRef.current.contains(e.target)
            ) {
                setShowSuggestions(false);
            }
        };

        document.addEventListener("mousedown", handleClickOutside);

        return () => {
            document.removeEventListener("mousedown", handleClickOutside);
        };
    }, []);

    /*
      useEffect(() => {
      let lastScrollY = window.scrollY;
    
      const handleScroll = () => {
        const currentScrollY = window.scrollY;
    
        if (currentScrollY < 50) {
          setShowHeader(true);
        } else if (currentScrollY > lastScrollY) {
          // scrolling down
          setShowHeader(false);
        } else {
          // scrolling up
          setShowHeader(true);
        }
    
        lastScrollY = currentScrollY;
      };
    
      window.addEventListener("scroll", handleScroll);
    
      return () => {
        window.removeEventListener("scroll", handleScroll);
      };
    }, []);
    */

    useEffect(() => {
        let lastScrollY = window.scrollY;

        const handleScroll = () => {
            const currentScrollY = window.scrollY;

            if (currentScrollY < 50) {
                setShowHeader(true);
            } else if (currentScrollY > lastScrollY) {
                // Scrolling DOWN → hide header
                setShowHeader(false);
            } else {
                // Scrolling UP → show header
                setShowHeader(true);
            }

            lastScrollY = currentScrollY;
        };

        window.addEventListener("scroll", handleScroll);

        return () => {
            window.removeEventListener("scroll", handleScroll);
        };
    }, []);

    useEffect(() => {

        if (searchTerm.trim().length < 2) {

            setSuggestions([]);
            return;

        }

        const timer = setTimeout(async () => {

            try {

                setLoadingSuggestions(true);

                const data = await searchVehicles(searchTerm);

                setSuggestions(data);

                setShowSuggestions(true);

            } catch (err) {

                console.error(err);

            } finally {

                setLoadingSuggestions(false);

            }

        }, 300);

        return () => clearTimeout(timer);

    }, [searchTerm]);

    return (
        /*<header
        className="sticky top-0 z-50 transition-transform duration-300"
        style={{
          transform: showHeader ? "translateY(0)" : "translateY(-100%)",
          boxShadow: "0 2px 16px rgba(0,0,0,0.18)",
        }}
        >*/
        /*
          <header
          className="sticky top-0 z-50"
          style={{
            boxShadow: "0 2px 16px rgba(0,0,0,0.18)",
            borderBottom: "1px solid rgba(255,255,255,0.08)",
          }}
        >
        */
        <header
            className="sticky top-0 z-50 transition-transform duration-300"
            style={{
                transform: showHeader ? "translateY(0)" : "translateY(-100%)",
                boxShadow: "0 2px 16px rgba(0,0,0,0.18)",
                borderBottom: "1px solid rgba(255,255,255,0.08)",
            }}
        >

            {/* Row 1: Logo | Location | Bell | Login — blue glassmorphism bar */}
            <div
                className="px-4 flex items-center gap-4"
                style={{
                    background: "#0A0A2B",
                    minHeight: "44px",
                    paddingTop: "8px",
                    paddingBottom: "8px",
                }}
            >
                <div className="max-w-7xl w-full mx-auto flex items-center gap-4">
                    {/* Logo — generous container, no clipping */}
                    <div className="flex items-center shrink-0 py-1">
                        {/*
                        <ImageWithFallback
                            src={bchLogo}
                            alt="BikeCarHub logo"
                            className="w-auto object-contain"
                            style={{ height: "clamp(34px, 5vw, 48px)", maxWidth: "200px", display: "block" }}
                        />
                        */}
                        <img
                            src={bchLogo}
                            alt="BikeCarHub logo"
                            style={{
                                height: "48px",
                                width: "auto",
                                objectFit: "contain"
                            }}
                        />
                    </div>

                    {/* Search Bar */}
                    {/*<div className="hidden lg:block relative w-80 ml-6">*/}
                    <div
                        ref={searchRef}
                        className="hidden md:block relative w-48 lg:w-64 xl:w-72 ml-4"
                    >
                        {/*
  <Search
    size={16}
    className="absolute left-3 top-1/2 -translate-y-1/2 text-white"
  />
  */}
                        <Search
                            size={18}
                            className="absolute left-4 top-1/2 -translate-y-1/2 text-[#0A0A2B]"
                        />

                        <input
                            type="text"
                            placeholder="Search Bikes & Cars..."
                            value={searchTerm}
                            onChange={(e) => {

                                setSearchTerm(e.target.value);

                            }}
                            onFocus={() => setShowSuggestions(true)}
                            className="w-full pl-10 pr-4 py-1 outline-none text-sm"
                            /*
                            style={{
                              background: "rgba(255,255,255,0.08)",
                              border: "1px solid rgba(255,255,255,0.15)",
                              color: "white",
                            }}
                            */
                            style={{
                                background: "#FFFFFF",
                                border: "2px solid #E5E7EB",
                                color: "#0A0A2B",
                                borderRadius: "9999px",
                                fontSize: "16px",
                                fontWeight: 500,
                            }}
                        />

                        {showSuggestions &&
                            (loadingSuggestions || suggestions.length > 0) && (

                                <div
                                    className="absolute top-full mt-2 left-0 right-0 rounded-lg overflow-hidden z-[999]"
                                    style={{
                                        background: "#FFFFFF",
                                        boxShadow: "0 10px 30px rgba(0,0,0,0.2)",
                                    }}
                                >

                                    {loadingSuggestions && (
                                        <div className="px-4 py-3 text-sm text-slate-500">
                                            Searching...
                                        </div>
                                    )}

                                    {!loadingSuggestions &&
                                        suggestions.map((item) => (

                                            <div
                                                key={item.label}
                                                className="px-4 py-3 text-sm cursor-pointer hover:bg-slate-100"
                                                onClick={async () => {

                                                    setSearchTerm(item.label);

                                                    setShowSuggestions(false);

                                                    try {

                                                        if (item.type === "Brand") {

                                                            navigate(`/brand/${item.id}`);

                                                            return;

                                                        }

                                                        const details = await getVehicleDetails(item.label);

                                                        navigate(`/bike/${details.modelId}`);

                                                    }

                                                    catch (err) {

                                                        console.error(err);

                                                    }

                                                }}
                                            >

                                                <div className="font-medium">
                                                    {item.label}
                                                </div>

                                                <div className="text-xs text-slate-500 mt-1">
                                                    {item.type}
                                                </div>

                                            </div>

                                        ))}

                                </div>

                            )}
                    </div>

                    {/* Center Navigation */}
                    <nav className="hidden lg:flex flex-1 justify-center items-center gap-5">
                        {navItems.map((item) => (
                            /*
                                <button
                                  key={item}
                                  onClick={() => {
                                    etMobileOpen(false);
                                    handleNavigation(item);
                                  }}
                                  className="transition-colors cursor-pointer hover:text-white"
                                  style={{
                                    color: activeItem === item ? "#FFFFFF" : "rgba(255,255,255,0.75)",
                                    fontWeight: activeItem === item ? 700 : 500,
                                    fontSize: "15px",
                                  }}
                                >
                                  {item}
                                </button>
                            */
                            <button
                                key={item}
                                onClick={() => handleNavigation(item)}
                                className="
    cursor-pointer
    transition-all
    duration-200
    hover:text-white
    hover:-translate-y-0.5
  "
                                style={{
                                    color: activeItem === item ? "#FFFFFF" : "rgba(255,255,255,0.75)",
                                    fontWeight: activeItem === item ? 700 : 500,
                                    fontSize: "15px",
                                }}
                            >
                                {item}
                            </button>

                        ))}
                    </nav>

                    {/* Spacer */}
                    {/*
        <div className="flex-1" />
*/}

                    {/* Location */}
                    <button className="w-9 h-9 rounded-lg border border-white/30 flex items-center justify-center text-white/80 hover:border-white hover:text-white hover:bg-white/10 transition-all shrink-0">
                        <MapPin size={16} />
                    </button>

                    {/* Notification */}
                    <button className="w-9 h-9 rounded-lg border border-white/30 flex items-center justify-center text-white/80 hover:border-white hover:text-white hover:bg-white/10 transition-all shrink-0">
                        <Bell size={16} />
                    </button>

                    {/* Login */}
                    <button
                        onClick={() => navigate("/login")}
                        className="flex items-center gap-2 px-4 py-2 rounded-lg text-sm shrink-0 transition-all"
                        style={{
                            background: "rgba(255,255,255,0.18)",
                            border: "1px solid rgba(255,255,255,0.4)",
                            color: "white",
                            fontWeight: 600,
                            backdropFilter: "blur(4px)",
                        }}
                        onMouseEnter={(e) => { e.currentTarget.style.background = "rgba(255,255,255,0.28)"; }}
                        onMouseLeave={(e) => { e.currentTarget.style.background = "rgba(255,255,255,0.18)"; }}
                    >
                        <User size={15} />
                        <span className="hidden sm:inline">Sign In</span>
                    </button>

                    {/* Hamburger — mobile only, beside Sign In */}
                    <button
                        className="md:hidden w-9 h-9 rounded-lg border border-white/30 flex items-center justify-center text-white/80 hover:border-white hover:text-white hover:bg-white/10 transition-all shrink-0"
                        onClick={() => setMobileOpen((v) => !v)}
                        aria-label="Toggle menu"
                    >
                        {mobileOpen ? <X size={18} /> : <Menu size={18} />}
                    </button>
                </div>
            </div>

            {/* Mobile slide-in menu */}
            {mobileOpen && (
                <div className="md:hidden fixed inset-0 z-[100] flex overflow-hidden">
                    {/* Left half — blurred transparent overlay, click to close */}
                    <div
                        className="flex-1"
                        style={{ background: "rgba(10, 10, 43, 0.45)", backdropFilter: "blur(8px)", WebkitBackdropFilter: "blur(8px)" }}
                        onClick={() => setMobileOpen(false)}
                    />

                    {/* Right half — solid dark panel */}
                    <div
                        //className="w-[50vw] max-w-[280px] h-full flex flex-col"
                        className="w-[55vw] h-full flex flex-col relative z-[101]"
                        style={{
                            background: "rgba(10, 10, 43, 0.97)",
                            borderTopLeftRadius: "32px",
                            borderBottomLeftRadius: "32px",
                        }}
                    >
                        {/* Close button */}
                        <div className="flex justify-end px-4 pt-5 pb-4">
                            <button
                                onClick={() => setMobileOpen(false)}
                                className="w-9 h-9 rounded-full border border-white/20 flex items-center justify-center text-white/70 hover:text-white hover:bg-white/10 transition-all"
                                aria-label="Close menu"
                            >
                                <X size={18} />
                            </button>
                        </div>

                        {/* Nav items — top half of panel, evenly spaced */}
                        <nav className="flex flex-col px-5" style={{ height: "50%" }}>
                            {navItems.map((item, i) => (
                                <button
                                    key={item}
                                    onClick={() => { if (item === "Ask a Question") { setMobileOpen(false); setAskOpen(true); } else { handleNavigation(item); setMobileOpen(false); } }}
                                    className="w-full text-left transition-all duration-200"
                                    style={{
                                        flex: 1,
                                        color: activeItem === item ? "#ffffff" : "rgba(255,255,255,0.65)",
                                        fontFamily: "var(--font-display)",
                                        fontWeight: activeItem === item ? 700 : 500,
                                        fontSize: "14px",
                                        borderBottom: i < navItems.length - 1 ? "1px solid rgba(255,255,255,0.08)" : "none",
                                        letterSpacing: "0.01em",
                                        display: "flex",
                                        alignItems: "center",
                                        gap: "8px",
                                    }}
                                >
                                    {activeItem === item && (
                                        <span style={{ width: "3px", height: "16px", background: "#2563EB", borderRadius: "2px", flexShrink: 0 }} />
                                    )}
                                    {item}
                                </button>
                            ))}
                        </nav>
                    </div>
                </div>
            )}
           
            {askOpen && <AskQuestionModal onClose={() => setAskOpen(false)} />}
          

            {/* Navigation bar — desktop only */}
            {/*<div className="hidden md:block border-t border-slate-100 bg-white">*/}
            {/*
      <div
        className="transition-transform duration-300"
        style={{
        transform: showHeader ? "translateY(0)" : "translateY(-100%)",
        }}
      >
*/}
            {/* Navigation bar — desktop only */}
            {/*
      <div className="hidden md:block border-t border-slate-100 bg-white overflow-x-hidden"></div>


        <div className="max-w-7xl mx-auto px-4">
          <nav className="flex items-center justify-center gap-1">
            {navItems.map((item) => (
              <button
                key={item}
                onClick={() => { if (item === "Ask a Question") { setAskOpen(true); } else { setActiveItem(item); } }}
                className={`px-5 py-3 text-sm whitespace-nowrap transition-all duration-200 border-b-2 cursor-pointer ${
                  activeItem === item
                    ? "text-[#0A0A2B] border-[#0A0A2B]"
                    : "text-slate-600 border-transparent hover:text-[#0A0A2B] hover:border-slate-300"
                }`}
                style={{ fontWeight: 600 }}
              >
                {item}
              </button>
            ))}
          </nav>
        </div>
      </div>
*/}
        </header>
    );
}