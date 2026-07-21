export default function CompareTable({ title, rows }) {
    return (
        <section className="bg-white rounded-3xl shadow-sm border border-slate-200 p-8 mb-8">
            <h2 className="text-2xl font-bold mb-6">
                {title}
            </h2>

            <table className="w-full table-fixed">
                <colgroup>
                    <col style={{ width: "40%" }} />
                    <col style={{ width: "30%" }} />
                    <col style={{ width: "30%" }} />
                </colgroup>

                <tbody>
                    {rows.map(([label, left, right]) => (
                        <tr
                            key={label}
                            className="border-b border-slate-200 last:border-0"
                        >
                            <td className="py-4 font-medium text-slate-800">
                                {label}
                            </td>

                            <td className="py-4 text-center text-slate-700">
                                {left ?? "-"}
                            </td>

                            <td className="py-4 text-center text-slate-700">
                                {right ?? "-"}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </section>
    );
}