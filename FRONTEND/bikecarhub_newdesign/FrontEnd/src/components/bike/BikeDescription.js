export default function BikeDescription({ bike }) {

    return (

        <section className="bg-white rounded-xl border shadow p-8">

            <h2 className="text-3xl font-bold mb-6">

                Overview

            </h2>

            <p className="leading-8 text-slate-700">

                {bike.description || "No description available."}

            </p>

        </section>

    );

}