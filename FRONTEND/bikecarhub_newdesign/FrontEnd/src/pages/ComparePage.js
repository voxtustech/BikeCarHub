import { Bike } from "lucide-react";
import { useState } from "react";

export function ComparePage() {
  const [bike1, setBike1] = useState("");
  const [bike2, setBike2] = useState("");

  return (
    <>
      {/* Hero Banner */}
      <div
        className="w-full py-2 px-6 flex flex-col items-center justify-center"
        style={{ background: "#0A0A2B" }}
      >
        <h1
          className="text-white"
          style={{
            fontFamily: "var(--font-display)",
            fontWeight: 700,
            fontSize: "clamp(1.5rem, 3vw, 2.25rem)",
          }}
        >
          Compare Bikes
        </h1>

        <p
          className="text-white/70 mt-0 text-center"
          style={{
            fontFamily: "var(--font-body)",
            fontSize: "14px",
          }}
        >
          Compare specifications, pricing and features side by side
        </p>
      </div>

      {/* Content */}
      <section className="max-w-7xl mx-auto px-6 py-10">
        <h2
          className="mb-3"
          style={{
            color: "#0A0A2B",
            fontWeight: 700,
            fontSize: "32px",
          }}
        >
          Find Your Perfect Ride
        </h2>

        <p className="text-slate-600 mb-10">
          Compare key specifications, mileage, engine type and braking
          systems to make an informed decision.
        </p>

        <div className="grid md:grid-cols-2 gap-8">
          {[1, 2].map((card) => (
            <div
              key={card}
              className="bg-white rounded-[36px] p-8 shadow-sm border border-slate-100"
            >
              <div className="flex justify-center mb-6">
                <div className="w-52 h-28 rounded-full border-4 border-slate-200 flex items-center justify-center">
                  <Bike size={72} color="#4B5563" />
                </div>
              </div>

              <h3
                className="text-center mb-5"
                style={{
                  fontWeight: 700,
                  fontSize: "28px",
                  color: "#0A0A2B",
                }}
              >
                Add to Compare
              </h3>

              <div className="space-y-4">
                <select
                  className="w-full border border-slate-300 rounded px-4 py-3"
                >
                  <option>Select Brand</option>
                </select>

                <select
                  className="w-full border border-slate-300 rounded px-4 py-3"
                >
                  <option>Select Model</option>
                </select>

                <select
                  className="w-full border border-slate-300 rounded px-4 py-3"
                >
                  <option>Select Variant</option>
                </select>
              </div>
            </div>
          ))}
        </div>

        <button
          className="w-full mt-10 py-3 rounded-md text-white"
          style={{ background: "#0A0A2B" }}
        >
          + Add Bike
        </button>

        <div className="flex justify-center mt-6">
          <button
            className="px-16 py-3 rounded-md text-white"
            style={{ background: "#0A0A2B" }}
          >
            Compare
          </button>
        </div>
      </section>
    </>
  );
}