import { useEffect, useState } from "react";
import { X } from "lucide-react";

export function AskQuestionModal({ onClose }) {
    const [form, setForm] = useState({ name: "", phone: "", email: "", message: "" });
    const [submitted, setSubmitted] = useState(false);

    // Lock body scroll while open
    useEffect(() => {
        document.body.style.overflow = "hidden";
        return () => { document.body.style.overflow = ""; };
    }, []);

    const handleChange = (e) => {
        setForm((prev) => ({ ...prev, [e.target.name]: e.target.value }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setSubmitted(true);
        setTimeout(() => { onClose(); }, 1800);
    };

    const inputStyle = {
        width: "100%",
        padding: "10px 12px",
        borderRadius: "8px",
        border: "1px solid #D1D5DB",
        background: "#FFFFFF",
        fontFamily: "var(--font-body)",
        fontSize: "14px",
        color: "#1F2937",
        outline: "none",
        transition: "border-color 0.2s",
    };

    const labelStyle = {
        fontFamily: "var(--font-display)",
        fontWeight: 700,
        fontSize: "15px",
        color: "#1F2937",
        marginBottom: "8px",
        display: "block",
    };

    return (
        /* Backdrop */
        <div
            className="fixed inset-0 z-[200] flex items-center justify-center px-4"
            style={{ background: "rgba(10, 10, 43, 0.60)", backdropFilter: "blur(6px)", WebkitBackdropFilter: "blur(6px)" }}
            onClick={(e) => { if (e.target === e.currentTarget) onClose(); }}
        >
            {/* Modal */}
            <div
                className="relative w-full max-w-lg rounded-2xl shadow-2xl overflow-hidden"
                style={{ background: "#FFFFFF", maxHeight: "80vh", overflowY: "auto" }}
            >
                {/* Close button */}
                <button
                    onClick={onClose}
                    className="absolute top-4 right-4 w-8 h-8 flex items-center justify-center rounded-full hover:bg-slate-100 transition-colors text-slate-500 hover:text-slate-800"
                    aria-label="Close"
                >
                    <X size={18} />
                </button>

                {/* Header */}
                <div className="px-8 pt-8 pb-2">
                    <h2
                        style={{
                            fontFamily: "var(--font-display)",
                            fontWeight: 800,
                            fontSize: "22px",
                            color: "#0A0A2B",
                            letterSpacing: "-0.01em",
                        }}
                    >
                        Ask a Question
                    </h2>
                    <p style={{ fontFamily: "var(--font-body)", fontSize: "13px", color: "#6B7280", marginTop: "4px" }}>
                        Fill in your details and we'll get back to you shortly.
                    </p>
                </div>

                {submitted ? (
                    <div className="px-8 py-12 flex flex-col items-center gap-3 text-center">
                        <div
                            className="w-14 h-14 rounded-full flex items-center justify-center mb-2"
                            style={{ background: "#0A0A2B" }}
                        >
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none">
                                <path d="M5 13l4 4L19 7" stroke="white" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round" />
                            </svg>
                        </div>
                        <p style={{ fontFamily: "var(--font-display)", fontWeight: 700, fontSize: "18px", color: "#0A0A2B" }}>
                            Submitted!
                        </p>
                        <p style={{ fontFamily: "var(--font-body)", fontSize: "14px", color: "#6B7280" }}>
                            Thank you. We'll reach out to you soon.
                        </p>
                    </div>
                ) : (
                    <form onSubmit={handleSubmit} className="px-8 py-6 flex flex-col gap-3">
                        <div>
                            <label style={labelStyle}>Name</label>
                            <input
                                name="name"
                                type="text"
                                required
                                placeholder="Your full name"
                                value={form.name}
                                onChange={handleChange}
                                style={inputStyle}
                                onFocus={(e) => { e.currentTarget.style.borderColor = "#0A0A2B"; }}
                                onBlur={(e) => { e.currentTarget.style.borderColor = "#D1D5DB"; }}
                            />
                        </div>

                        <div>
                            <label style={labelStyle}>Phone No.</label>
                            <input
                                name="phone"
                                type="tel"
                                required
                                placeholder="+91 00000 00000"
                                value={form.phone}
                                onChange={handleChange}
                                style={inputStyle}
                                onFocus={(e) => { e.currentTarget.style.borderColor = "#0A0A2B"; }}
                                onBlur={(e) => { e.currentTarget.style.borderColor = "#D1D5DB"; }}
                            />
                        </div>

                        <div>
                            <label style={labelStyle}>Email</label>
                            <input
                                name="email"
                                type="email"
                                required
                                placeholder="you@example.com"
                                value={form.email}
                                onChange={handleChange}
                                style={inputStyle}
                                onFocus={(e) => { e.currentTarget.style.borderColor = "#0A0A2B"; }}
                                onBlur={(e) => { e.currentTarget.style.borderColor = "#D1D5DB"; }}
                            />
                        </div>

                        <div>
                            <label style={labelStyle}>Message</label>
                            <textarea
                                name="message"
                                required
                                rows={4}
                                placeholder="Type your question here..."
                                value={form.message}
                                onChange={handleChange}
                                style={{ ...inputStyle, resize: "vertical", minHeight: "90px" }}
                                onFocus={(e) => { e.currentTarget.style.borderColor = "#0A0A2B"; }}
                                onBlur={(e) => { e.currentTarget.style.borderColor = "#D1D5DB"; }}
                            />
                        </div>

                        <button
                            type="submit"
                            className="w-full py-3.5 rounded-xl text-white transition-opacity hover:opacity-90 active:opacity-80"
                            style={{
                                background: "#0A0A2B",
                                fontFamily: "var(--font-display)",
                                fontWeight: 700,
                                fontSize: "15px",
                                letterSpacing: "0.02em",
                            }}
                        >
                            Submit
                        </button>
                    </form>
                )}
            </div>
        </div>
    );
}