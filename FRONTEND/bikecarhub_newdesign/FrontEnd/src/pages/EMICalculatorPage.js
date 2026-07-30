import { useState } from "react";
import { useLocation } from "react-router-dom";

function formatINR(n) {
  return n.toLocaleString("en-IN");
}

export function EMICalculatorPage() {
    const location = useLocation();

    const initialPrice =
        Number(location.state?.bikePrice) || 100000;

    const bikeName =
        location.state?.bikeName || "";

    const [principal, setPrincipal] = useState(initialPrice);

    const [principalInput, setPrincipalInput] =
        useState(String(initialPrice));
  const [rate, setRate] = useState(10);
  const [period, setPeriod] = useState(3);

  // EMI = P * r * (1+r)^n / ((1+r)^n - 1)
  const monthlyRate = rate / 12 / 100;
  const months = period * 12;
  const emi =
    monthlyRate === 0
      ? principal / months
      : (principal * monthlyRate * Math.pow(1 + monthlyRate, months)) /
        (Math.pow(1 + monthlyRate, months) - 1);
  const totalPayable = emi * months;
  const totalInterest = totalPayable - principal;

  const sliderTrackStyle = (val, min, max) => ({
    background: `linear-gradient(to right, #0A0A2B ${((val - min) / (max - min)) * 100}%, #D1D5DB ${((val - min) / (max - min)) * 100}%)`,
  });

  const handlePrincipalBlur = () => {
    const v = Math.min(10000000, Math.max(50000, Number(principalInput.replace(/,/g, "")) || 50000));
    setPrincipal(v);
    setPrincipalInput(String(v));
  };

  return (
    <div className="min-h-screen bg-white" style={{ fontFamily: "var(--font-body)" }}>
      {/* Page header */}
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
          EMI Calculator
              </h1>
              {bikeName && (
                  <p
                      className="text-center text-slate-500 mt-2"
                      style={{ fontWeight: 600 }}
                  >
                      {bikeName}
                  </p>
              )}
        <p style={{ color: "rgba(255,255,255,0.55)", fontSize: "14px", marginTop: "0px" }}>
          Calculate your monthly vehicle loan EMI instantly
        </p>
      </div>

      {/* Content */}
      <div className="max-w-5xl mx-auto px-4 py-12">
        <div className="grid grid-cols-1 lg:grid-cols-2 gap-8 items-start">

          {/* Left — Inputs */}
          <div
            className="rounded-2xl p-8 border border-slate-100"
            style={{ background: "#ffffff", boxShadow: "0 4px 32px rgba(10,10,43,0.08)" }}
          >
            <h2
              className="text-center mb-8"
              style={{
                fontFamily: "var(--font-display)",
                fontWeight: 800,
                fontSize: "22px",
                color: "#0A0A2B",
              }}
            >
              Loan Calculator
            </h2>

            {/* Principal Amount */}
            <div className="mb-7">
              <label
                className="block mb-2 text-sm"
                style={{ fontFamily: "var(--font-display)", fontWeight: 600, color: "#1F2937" }}
              >
                Principal Amount (₹50,000 to ₹1,00,00,000):
              </label>
              <div
                className="flex items-center rounded-lg border border-slate-300 overflow-hidden"
                style={{ background: "#fff" }}
              >
                <span className="px-3 text-slate-500 text-sm select-none">₹</span>
                <input
                  type="text"
                  value={principalInput}
                  onChange={(e) => setPrincipalInput(e.target.value.replace(/[^0-9]/g, ""))}
                  onBlur={handlePrincipalBlur}
                  className="flex-1 py-2.5 pr-3 text-sm outline-none"
                  style={{ fontFamily: "var(--font-body)", color: "#1F2937" }}
                />
              </div>
              <input
                type="range"
                min={50000}
                max={10000000}
                step={10000}
                value={principal}
                onChange={(e) => {
                  const v = Number(e.target.value);
                  setPrincipal(v);
                  setPrincipalInput(String(v));
                }}
                className="w-full mt-3 h-1.5 rounded-full appearance-none cursor-pointer"
                style={sliderTrackStyle(principal, 50000, 10000000)}
              />
              <div className="flex justify-between text-xs text-slate-400 mt-1">
                <span>₹50K</span><span>₹1Cr</span>
              </div>
              <p className="text-xs mt-1" style={{ color: "#0A0A2B", fontWeight: 500 }}>
                Selected Amount: ₹{formatINR(principal)}
              </p>
            </div>

            {/* Rate of Interest */}
            <div className="mb-7">
              <label
                className="block mb-2 text-sm"
                style={{ fontFamily: "var(--font-display)", fontWeight: 600, color: "#1F2937" }}
              >
                Rate of Interest (1% to 18%):
              </label>
              <div
                className="flex items-center rounded-lg border border-slate-300 overflow-hidden"
                style={{ background: "#fff" }}
              >
                <input
                  type="number"
                  min={1}
                  max={18}
                  step={0.5}
                  value={rate}
                  onChange={(e) => setRate(Math.min(18, Math.max(1, Number(e.target.value))))}
                  className="flex-1 py-2.5 pl-3 text-sm outline-none"
                  style={{ fontFamily: "var(--font-body)", color: "#1F2937" }}
                />
                <span className="px-3 text-slate-500 text-sm select-none">%</span>
              </div>
              <input
                type="range"
                min={1}
                max={18}
                step={0.5}
                value={rate}
                onChange={(e) => setRate(Number(e.target.value))}
                className="w-full mt-3 h-1.5 rounded-full appearance-none cursor-pointer"
                style={sliderTrackStyle(rate, 1, 18)}
              />
              <div className="flex justify-between text-xs text-slate-400 mt-1">
                <span>1%</span><span>18%</span>
              </div>
              <p className="text-xs mt-1" style={{ color: "#0A0A2B", fontWeight: 500 }}>
                Selected Rate of Interest: {rate}%
              </p>
            </div>

            {/* Loan Period */}
            <div>
              <label
                className="block mb-2 text-sm"
                style={{ fontFamily: "var(--font-display)", fontWeight: 600, color: "#1F2937" }}
              >
                Loan Period (1 to 7 years):
              </label>
              <div
                className="flex items-center rounded-lg border border-slate-300 overflow-hidden"
                style={{ background: "#fff" }}
              >
                <input
                  type="number"
                  min={1}
                  max={7}
                  step={1}
                  value={period}
                  onChange={(e) => setPeriod(Math.min(7, Math.max(1, Number(e.target.value))))}
                  className="flex-1 py-2.5 pl-3 text-sm outline-none"
                  style={{ fontFamily: "var(--font-body)", color: "#1F2937" }}
                />
                <span className="px-3 text-slate-500 text-sm select-none">years</span>
              </div>
              <input
                type="range"
                min={1}
                max={7}
                step={1}
                value={period}
                onChange={(e) => setPeriod(Number(e.target.value))}
                className="w-full mt-3 h-1.5 rounded-full appearance-none cursor-pointer"
                style={sliderTrackStyle(period, 1, 7)}
              />
              <div className="flex justify-between text-xs text-slate-400 mt-1">
                {[1,2,3,4,5,6,7].map(n => <span key={n}>{n}</span>)}
              </div>
              <p className="text-xs mt-1" style={{ color: "#0A0A2B", fontWeight: 500 }}>
                Selected Period: {period} year(s)
              </p>
            </div>
          </div>

          {/* Right — Results */}
          <div
            className="rounded-2xl p-8 flex flex-col justify-center"
            style={{ background: "#EEF4FB", border: "1px solid #C7DCF0", minHeight: "360px" }}
          >
            <h2
              className="text-center mb-1"
              style={{
                fontFamily: "var(--font-display)",
                fontWeight: 700,
                fontSize: "20px",
                color: "#0A0A2B",
              }}
            >
              Calculation Results
            </h2>
            <p
              className="text-center mb-2"
              style={{
                fontFamily: "var(--font-display)",
                fontWeight: 600,
                fontSize: "16px",
                color: "#0A0A2B",
              }}
            >
              Monthly EMI:
            </p>

            {/* Big EMI number */}
            <div className="text-center mb-8">
              <span
                style={{
                  fontFamily: "var(--font-display)",
                  fontWeight: 800,
                  fontSize: "clamp(2.4rem, 6vw, 3.2rem)",
                  color: "#C28A00",
                  letterSpacing: "-0.02em",
                }}
              >
                ₹{formatINR(Math.round(emi))}
              </span>
            </div>

            {/* Breakdown */}
            <div className="space-y-4">
              {[
                { label: "Principal Amount", value: `₹${formatINR(principal)}` },
                { label: "Total Interest Payable", value: `₹${formatINR(Math.round(totalInterest))}` },
                { label: "Total Amount Payable", value: `₹${formatINR(Math.round(totalPayable))}` },
              ].map(({ label, value }) => (
                <div key={label} className="flex items-center justify-between border-b border-blue-100 pb-3">
                  <span
                    style={{
                      fontFamily: "var(--font-display)",
                      fontWeight: 600,
                      fontSize: "14px",
                      color: "#1F2937",
                    }}
                  >
                    {label}:
                  </span>
                  <span
                    style={{
                      fontFamily: "var(--font-display)",
                      fontWeight: 700,
                      fontSize: "14px",
                      color: "#0A0A2B",
                    }}
                  >
                    {value}
                  </span>
                </div>
              ))}
            </div>
          </div>

        </div>
      </div>

      {/* Slider thumb global style */}
      <style>{`
        input[type='range']::-webkit-slider-thumb {
          -webkit-appearance: none;
          width: 18px;
          height: 18px;
          border-radius: 50%;
          background: #0A0A2B;
          border: 2px solid #fff;
          box-shadow: 0 0 0 2px #0A0A2B;
          cursor: pointer;
        }
        input[type='range']::-moz-range-thumb {
          width: 18px;
          height: 18px;
          border-radius: 50%;
          background: #0A0A2B;
          border: 2px solid #fff;
          box-shadow: 0 0 0 2px #0A0A2B;
          cursor: pointer;
        }
      `}</style>
    </div>
  );
}
