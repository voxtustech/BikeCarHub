import { useState } from "react";

export function MotoAIPage() {
  const [vehicleType, setVehicleType] = useState("");
  const [budget, setBudget] = useState("");
  const [purpose, setPurpose] = useState("");

  const getRecommendations = () => {
    if (
      vehicleType === "Bike" &&
      budget === "1-2" &&
      purpose === "Commute"
    ) {
      return [
        "TVS Apache RTR 160",
        "Bajaj Pulsar N160",
        "Hero Xtreme 160R",
      ];
    }

    if (
      vehicleType === "Bike" &&
      budget === "2-5" &&
      purpose === "Touring"
    ) {
      return [
        "Royal Enfield Meteor 350",
        "Honda CB350",
        "Yezdi Adventure",
      ];
    }

    return [];
  };

  const recommendations = getRecommendations();

  return (
    <div className="min-h-screen bg-slate-50">
      {/* Hero Section */}
      <section
        className="py-12 text-center"
        style={{
          background: "#0A0A2B",
        }}
      >
        <h1
          style={{
            color: "white",
            fontSize: "48px",
            fontWeight: 800,
          }}
        >
          MotoAI
        </h1>

        <p
          style={{
            color: "rgba(255,255,255,0.7)",
            marginTop: "10px",
          }}
        >
          AI Powered Vehicle Recommendations
        </p>
      </section>

      {/* Chat Card */}
      <div className="max-w-3xl mx-auto p-6">
        <div className="bg-white rounded-2xl shadow-lg p-8">

          <div className="mb-6">
            <h2 className="text-xl font-bold mb-4">
              Hi 👋 I'm MotoAI
            </h2>

            <p>What are you looking for?</p>

            <select
              className="w-full border rounded-xl p-3 mt-3"
              value={vehicleType}
              onChange={(e) => setVehicleType(e.target.value)}
            >
              <option value="">Select Vehicle Type</option>
              <option>Bike</option>
              <option>Car</option>
              <option>Scooter</option>
            </select>
          </div>

          {vehicleType && (
            <div className="mb-6">
              <p>What's your budget?</p>

              <select
                className="w-full border rounded-xl p-3 mt-3"
                value={budget}
                onChange={(e) => setBudget(e.target.value)}
              >
                <option value="">Select Budget</option>
                <option value="1-2">₹1–2 Lakh</option>
                <option value="2-5">₹2–5 Lakh</option>
                <option value="5+">₹5 Lakh+</option>
              </select>
            </div>
          )}

          {budget && (
            <div className="mb-6">
              <p>Purpose?</p>

              <select
                className="w-full border rounded-xl p-3 mt-3"
                value={purpose}
                onChange={(e) => setPurpose(e.target.value)}
              >
                <option value="">Select Purpose</option>
                <option value="Commute">Daily Commute</option>
                <option value="Touring">Touring</option>
                <option value="Sports">Sports</option>
              </select>
            </div>
          )}

          {recommendations.length > 0 && (
            <div
              className="mt-8 p-5 rounded-xl"
              style={{
                background: "#F8FAFC",
                border: "1px solid #E2E8F0",
              }}
            >
              <h3 className="font-bold text-lg mb-3">
                Recommended Vehicles
              </h3>

              {recommendations.map((bike) => (
                <div
                  key={bike}
                  className="py-2 border-b last:border-b-0"
                >
                  {bike}
                </div>
              ))}
            </div>
          )}
        </div>
      </div>
    </div>
  );
}