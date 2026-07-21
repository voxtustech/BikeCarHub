export default function SpecTable({
    title,
    rows = [],
    id
}) {

    const validRows = rows.filter(
        r =>
            r.value !== null &&
            r.value !== undefined &&
            r.value !== "" &&
            r.value !== "NULL"
    );

    if (validRows.length === 0)
        return null;

    return (

        <section
            id={id}
            className="bg-white rounded-3xl border shadow-sm overflow-hidden"
        >

            <div className="px-8 py-6 border-b bg-slate-50">

                <h2 className="text-2xl font-bold">

                    {title}

                </h2>

            </div>

            <div>

                {validRows.map((row, index) => (

                    <div
                        key={index}
                        className={`grid md:grid-cols-2 gap-4 px-8 py-5 ${index !== validRows.length - 1
                                ? "border-b"
                                : ""
                            }`}
                    >

                        <div className="text-slate-500 font-medium">

                            {row.label}

                        </div>

                        <div className="text-slate-800 break-words">

                            {row.value}

                        </div>

                    </div>

                ))}

            </div>

        </section>

    );

}