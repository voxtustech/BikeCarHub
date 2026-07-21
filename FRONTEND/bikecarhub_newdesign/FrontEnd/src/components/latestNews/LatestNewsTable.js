/*
import React from "react";

export default function TableSection({

    table

}) {

    if (!table) return null;

    return (

        <section className="bg-white rounded-3xl border border-slate-200 shadow-sm p-8 mb-10">

            {table.title && (

                <h2 className="text-3xl font-bold text-slate-900 mb-8">

                    {table.title}

                </h2>

            )}

            <div className="overflow-x-auto rounded-2xl border border-slate-200">

                <table className="w-full">

                    <thead className="bg-slate-900 text-white">

                        <tr>

                            {table.columns.map((column, index) => (

                                <th

                                    key={index}

                                    className="px-6 py-4 text-left text-sm font-semibold"

                                >

                                    {column}

                                </th>

                            ))}

                        </tr>

                    </thead>

                    <tbody>

                        {table.rows.map((row, rowIndex) => (

                            <tr

                                key={rowIndex}

                                className={`border-t border-slate-200 transition-colors hover:bg-slate-50
                                ${rowIndex % 2 === 0 ? "bg-white" : "bg-slate-50/40"}`}

                            >

                                {row.map((cell, cellIndex) => (

                                    <td

                                        key={cellIndex}

                                        className="px-6 py-4 text-slate-700"

                                    >

                                        {cell}

                                    </td>

                                ))}

                            </tr>

                        ))}

                    </tbody>

                </table>

            </div>

            {table.note && (

                <p className="mt-5 text-sm text-slate-500">

                    {table.note}

                </p>

            )}

        </section>

    );

}
*/
import React from "react";

export default function TableSection({ table }) {

    if (!table) return null;

    return (
        <section className="bg-white rounded-3xl border border-slate-200 shadow-sm p-8 mb-10">

            {table.heading && (
                <h2 className="text-3xl font-bold text-slate-900 mb-8">
                    {table.heading}
                </h2>
            )}

            <div className="overflow-x-auto rounded-2xl border border-slate-200">

                <table className="w-full">

                    <thead className="bg-slate-900 text-white">

                        <tr>

                            {(table.headers ?? []).map((header, index) => (
                                <th
                                    key={index}
                                    className="px-6 py-4 text-left text-sm font-semibold"
                                >
                                    {header}
                                </th>
                            ))}

                        </tr>

                    </thead>

                    <tbody>

                        {(table.rows ?? []).map((row, rowIndex) => (

                            <tr
                                key={rowIndex}
                                className={`border-t border-slate-200 transition-colors hover:bg-slate-50
                                ${rowIndex % 2 === 0 ? "bg-white" : "bg-slate-50/40"}`}
                            >

                                {(row.columns ?? []).map((cell, cellIndex) => (

                                    <td
                                        key={cellIndex}
                                        className="px-6 py-4 text-slate-700"
                                    >
                                        {cell}
                                    </td>

                                ))}

                            </tr>

                        ))}

                    </tbody>

                </table>

            </div>

        </section>
    );
}