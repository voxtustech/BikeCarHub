import { useState } from "react";
import { Mail, CheckCircle } from "lucide-react";

export function NewsletterSection() {
  const [email, setEmail] = useState("");
  const [subscribed, setSubscribed] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (email) {
      setSubscribed(true);
    }
  };

  return (
    <section className="py-16 border-t border-slate-100 bg-[#1F2937]">
      <div className="max-w-7xl mx-auto px-4">
        <div className="max-w-2xl mx-auto text-center">
          <div className="w-12 h-12 bg-[#0A0A2B] rounded-2xl flex items-center justify-center mx-auto mb-6">
            <Mail size={22} className="text-white" />
          </div>
          <h2 className="text-white mb-3" style={{ fontFamily: "var(--font-display)", fontWeight: 800, fontSize: "clamp(1.75rem, 3vw, 2.5rem)" }}>
            Join the BikeCarHub Ecosystem
          </h2>
          <p className="text-slate-400 mb-8 leading-relaxed">
            Get weekly vehicle reviews, price alerts, launch updates, and expert buying advice — delivered straight to your inbox.
          </p>

          {subscribed ? (
            <div className="flex items-center justify-center gap-3 py-4">
              <CheckCircle size={22} className="text-green-400" />
              <p className="text-green-400" style={{ fontFamily: "var(--font-display)", fontWeight: 600 }}>
                You're in! Welcome to the BikeCarHub community.
              </p>
            </div>
          ) : (
            <form onSubmit={handleSubmit} className="flex gap-3 max-w-md mx-auto">
              <input
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Enter your email address"
                className="flex-1 px-4 py-3 bg-white/10 border border-white/20 rounded-xl text-white placeholder-slate-500 outline-none focus:border-[#0A0A2B] focus:ring-2 focus:ring-blue-500/20 transition-all text-sm"
                required
              />
              <button
                type="submit"
                className="px-6 py-3 bg-[#0A0A2B] text-white rounded-xl hover:bg-[#06061A] transition-colors shrink-0 text-sm"
                style={{ fontWeight: 600 }}
              >
                Subscribe
              </button>
            </form>
          )}

          <p className="text-slate-600 text-xs mt-4">
            Join 125,000+ automotive enthusiasts. No spam, ever.
          </p>
        </div>
      </div>
    </section>
  );
}
