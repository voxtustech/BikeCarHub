
import { useEffect, useState } from "react";

const sections = [
    { id: "specifications", label: "Specifications" },
    { id: "engine", label: "Engine & Transmission" },
    { id: "features", label: "Features" },
    { id: "safety", label: "Safety" },
    { id: "mileage", label: "Mileage & Performance" },
    { id: "dimensions", label: "Dimensions & Capacity" },
    { id: "electricals", label: "Electricals" },
    { id: "tyres", label: "Tyres & Brakes" },
    { id: "motor", label: "Motor & Battery" },
    { id: "charging", label: "Charging" },
    { id: "underpinnings", label: "Underpinnings" }
];

export default function BikeStickyMenu() {

    const [active, setActive] = useState("specifications");

    useEffect(() => {

        const observer = new IntersectionObserver(

            entries => {

                entries.forEach(entry => {

                    if (entry.isIntersecting)
                        setActive(entry.target.id);

                });

            },

            { threshold: 0.3 }

        );

        sections.forEach(section => {

            const el = document.getElementById(section.id);

            if (el)
                observer.observe(el);

        });

        return () => observer.disconnect();

    }, []);

    return (

        <aside className="sticky top-24">

            <div className="bg-white rounded-xl shadow border">

                {sections.map(section => (

                    <button

                        key={section.id}

                        onClick={() => {

                            document
                                .getElementById(section.id)
                                ?.scrollIntoView({
                                    behavior: "smooth"
                                });

                        }}

                        className={`

                        w-full
                        text-left
                        px-5
                        py-4
                        border-b

                        transition

                        ${active === section.id
                                ? "bg-[#0A0A2B] text-white"
                                : "hover:bg-slate-50"}

                        `}

                    >

                        {section.label}

                    </button>

                ))}

            </div>

        </aside>

    );

}