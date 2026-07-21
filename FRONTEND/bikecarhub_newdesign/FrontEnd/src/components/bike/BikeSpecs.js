
export default function BikeSpecs({ spec }) {

    if (!spec)
        return null;

    const rows = [

        ["Mileage", `${spec.mileage} kmpl`],

        ["Fuel Capacity", `${spec.fuelCapacity} L`],

        ["Front Brake", spec.frontBrake],

        ["Rear Brake", spec.rearBrake],

        ["Body Type", spec.bodyType]

    ];

    return (

        <section
            id="specifications"
            className="bg-white rounded-xl shadow border p-8"
        >

            <h2 className="text-3xl font-bold mb-6">

                Specifications

            </h2>

            <table className="w-full">

                <tbody>

                    {rows.map(([k, v]) => (

                        <tr

                            key={k}

                            className="border-b"

                        >

                            <td className="py-4 font-semibold">

                                {k}

                            </td>

                            <td className="py-4 text-slate-600">

                                {v || "Not Available"}

                            </td>

                        </tr>

                    ))}

                </tbody>

            </table>

        </section>

    );

}