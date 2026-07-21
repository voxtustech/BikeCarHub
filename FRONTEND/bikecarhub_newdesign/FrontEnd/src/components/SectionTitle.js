/*
export function SectionTitle({ children, className = "" }) {
  return (
    <h2
      className={`text-center text-[#1F2937] mb-8 ${className}`}
      style={{
        fontFamily: "var(--font-display)",
        fontWeight: 700,
        fontSize: "clamp(1.4rem, 2.5vw, 1.75rem)",
        letterSpacing: "-0.01em",
      }}
    >
      {children}
    </h2>
  );
}
*/
export function SectionTitle({
    children,
    className = "",
    onClick
}) {
    return (
        <h2
            onClick={onClick}
            className={`text-center text-[#1F2937] mb-8 ${className} ${onClick
                    ? "cursor-pointer hover:text-[#2563EB] transition-colors duration-200"
                    : ""
                }`}
            style={{
                fontFamily: "var(--font-display)",
                fontWeight: 700,
                fontSize: "clamp(1.4rem, 2.5vw, 1.75rem)",
                letterSpacing: "-0.01em",
            }}
        >
            {children}
        </h2>
    );
}