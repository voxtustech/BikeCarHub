export function AdPlaceholder({ label = "Advertisement", className = "", height = "h-24" }) {
    return (
        <div className={`${height} ${className} flex items-center justify-center border border-dashed border-slate-200 bg-slate-50 rounded-lg`}>
            <span className="text-xs text-slate-400 tracking-widest uppercase">{label}</span>
        </div>
    );
}