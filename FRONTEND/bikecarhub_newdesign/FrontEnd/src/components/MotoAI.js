import { useState, useRef, useEffect } from "react";
import { Bot, X, Send, Minimize2, Sparkles } from "lucide-react";

const starterSuggestions = [
  "Best car under ₹10 lakh?",
  "Compare Creta vs Seltos",
  "Best EV for daily commute?",
  "Calculate EMI for ₹15L car",
];

const mockResponses = {
  default: "Great question! Based on your needs, I'd recommend exploring our curated vehicle collections. Would you like me to narrow it down by budget, fuel type, or segment?",
  budget: "For budget vehicles, the Maruti Swift (₹6.49L), Hyundai i20 (₹7.04L), and Tata Tiago (₹5.40L) are excellent choices. All offer great mileage and reliability. Want specs for any?",
  ev: "For EV commuters, the Tata Nexon EV (₹14.79L) is India's best-selling EV with 437 km range. The Ola S1 Pro (₹1.29L) is perfect for short urban commutes. Which suits your budget?",
  compare: "I'll set up a comparison for you! The Creta has a larger boot and more premium feel, while the Seltos offers better performance per rupee. Want the full spec breakdown?",
  emi: "For a ₹15L car with 20% down payment (₹3L) and 8.5% interest over 5 years, your EMI would be approximately ₹24,800/month. Want me to adjust the tenure or rate?",
};

const getResponse = (text) => {
  const lower = text.toLowerCase();
  if (lower.includes("emi") || lower.includes("loan")) return mockResponses.emi;
  if (lower.includes("ev") || lower.includes("electric")) return mockResponses.ev;
  if (lower.includes("compare") || lower.includes("vs")) return mockResponses.compare;
  if (lower.includes("budget") || lower.includes("under") || lower.includes("lakh")) return mockResponses.budget;
  return mockResponses.default;
};

export function MotoAI() {
  const [open, setOpen] = useState(false);
  const [minimized, setMinimized] = useState(false);
  const [input, setInput] = useState("");
  const [messages, setMessages] = useState([
    {
      role: "assistant",
      text: "Hi! I'm MotoAI 👋 Your intelligent automotive assistant. Ask me anything about cars, bikes, EVs, pricing, or comparisons.",
    },
  ]);
  const [typing, setTyping] = useState(false);
  const bottomRef = useRef(null);

  useEffect(() => {
    bottomRef.current?.scrollIntoView({ behavior: "smooth" });
  }, [messages, typing]);

  const sendMessage = (text) => {
    if (!text.trim()) return;
    const userMsg = { role: "user", text };
    setMessages((prev) => [...prev, userMsg]);
    setInput("");
    setTyping(true);
    setTimeout(() => {
      setTyping(false);
      setMessages((prev) => [...prev, { role: "assistant", text: getResponse(text) }]);
    }, 1200);
  };

  return (
    <>
      {/* Floating button */}
      {!open && (
        <button
          onClick={() => setOpen(true)}
          className="fixed bottom-6 right-6 z-50 w-14 h-14 bg-[#0A0A2B] text-white rounded-2xl shadow-2xl flex items-center justify-center hover:bg-[#06061A] hover:scale-105 transition-all"
          style={{ boxShadow: "0 8px 32px rgba(10,10,43,0.4)" }}
        >
          <Bot size={24} />
          <span className="absolute -top-1 -right-1 w-4 h-4 bg-green-400 rounded-full border-2 border-white" />
        </button>
      )}

      {/* Chat modal */}
      {open && (
        <div
          className={`fixed bottom-6 right-6 z-50 bg-white rounded-2xl shadow-2xl border border-slate-100 flex flex-col transition-all duration-300 ${minimized ? "h-14 w-72" : "w-[380px] h-[520px]"}`}
          style={{ boxShadow: "0 24px 80px rgba(0,0,0,0.16)" }}
        >
          {/* Header */}
          <div className="flex items-center justify-between px-4 py-3 border-b border-slate-100 shrink-0">
            <div className="flex items-center gap-2.5">
              <div className="w-8 h-8 bg-[#0A0A2B] rounded-xl flex items-center justify-center">
                <Bot size={16} className="text-white" />
              </div>
              <div>
                <div className="flex items-center gap-1.5">
                  <span style={{ fontFamily: "var(--font-display)", fontWeight: 700, fontSize: "14px", color: "#1F2937" }}>MotoAI</span>
                  <Sparkles size={11} className="text-amber-400" />
                </div>
                <span className="text-xs text-green-500" style={{ fontWeight: 500 }}>● Online</span>
              </div>
            </div>
            <div className="flex items-center gap-1">
              <button onClick={() => setMinimized(!minimized)} className="w-8 h-8 rounded-lg flex items-center justify-center text-slate-400 hover:text-slate-600 hover:bg-slate-100 transition-all">
                <Minimize2 size={14} />
              </button>
              <button onClick={() => setOpen(false)} className="w-8 h-8 rounded-lg flex items-center justify-center text-slate-400 hover:text-slate-600 hover:bg-slate-100 transition-all">
                <X size={14} />
              </button>
            </div>
          </div>

          {!minimized && (
            <>
              {/* Messages */}
              <div className="flex-1 overflow-y-auto p-4 space-y-3">
                {messages.map((msg, idx) => (
                  <div key={idx} className={`flex ${msg.role === "user" ? "justify-end" : "justify-start"}`}>
                    {msg.role === "assistant" && (
                      <div className="w-6 h-6 bg-[#E8E8F0] rounded-lg flex items-center justify-center mr-2 mt-0.5 shrink-0">
                        <Bot size={12} className="text-[#0A0A2B]" />
                      </div>
                    )}
                    <div
                      className={`max-w-[78%] px-3 py-2.5 rounded-2xl text-sm leading-relaxed ${
                        msg.role === "user"
                          ? "bg-[#0A0A2B] text-white rounded-br-sm"
                          : "bg-slate-100 text-slate-700 rounded-bl-sm"
                      }`}
                    >
                      {msg.text}
                    </div>
                  </div>
                ))}
                {typing && (
                  <div className="flex items-center gap-2">
                    <div className="w-6 h-6 bg-[#E8E8F0] rounded-lg flex items-center justify-center shrink-0">
                      <Bot size={12} className="text-[#0A0A2B]" />
                    </div>
                    <div className="bg-slate-100 px-3 py-2.5 rounded-2xl rounded-bl-sm">
                      <div className="flex gap-1">
                        {[0, 1, 2].map((i) => (
                          <div
                            key={i}
                            className="w-1.5 h-1.5 bg-slate-400 rounded-full animate-bounce"
                            style={{ animationDelay: `${i * 0.15}s` }}
                          />
                        ))}
                      </div>
                    </div>
                  </div>
                )}
                <div ref={bottomRef} />
              </div>

              {/* Suggestions */}
              {messages.length <= 1 && (
                <div className="px-4 pb-2">
                  <p className="text-xs text-slate-400 mb-2">Try asking:</p>
                  <div className="flex flex-wrap gap-1.5">
                    {starterSuggestions.map((s) => (
                      <button
                        key={s}
                        onClick={() => sendMessage(s)}
                        className="text-xs px-2.5 py-1.5 rounded-full bg-[#E8E8F0] text-[#0A0A2B] hover:bg-[#E8E8F0] transition-colors"
                        style={{ fontWeight: 500 }}
                      >
                        {s}
                      </button>
                    ))}
                  </div>
                </div>
              )}

              {/* Input */}
              <div className="p-3 border-t border-slate-100 shrink-0">
                <div className="flex gap-2">
                  <input
                    type="text"
                    value={input}
                    onChange={(e) => setInput(e.target.value)}
                    onKeyDown={(e) => e.key === "Enter" && sendMessage(input)}
                    placeholder="Ask me anything about vehicles..."
                    className="flex-1 px-3 py-2 text-sm border border-slate-200 rounded-xl outline-none focus:border-[#0A0A2B] text-slate-700 placeholder-slate-400 transition-colors"
                  />
                  <button
                    onClick={() => sendMessage(input)}
                    disabled={!input.trim()}
                    className="w-9 h-9 bg-[#0A0A2B] text-white rounded-xl flex items-center justify-center hover:bg-[#06061A] disabled:opacity-40 transition-all"
                  >
                    <Send size={14} />
                  </button>
                </div>
              </div>
            </>
          )}
        </div>
      )}
    </>
  );
}
