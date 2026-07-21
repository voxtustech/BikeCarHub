import { BACKEND_URL } from "../config";

export default function CompareOverview({ comparison }) {

    if (!comparison) return null;

    const { bike1, bike2 } = comparison;

    const image = (bike) => {

        if (!bike?.image)
            return `${BACKEND_URL}/images/default-bike.png`;

        if (bike.image.startsWith("http"))
            return bike.image;

        return `${BACKEND_URL}${bike.image}`;
    };

    const Card = ({ bike }) => (

        <div className="flex flex-col items-center">

            <img
                src={image(bike)}
                alt={bike.name}
                className="h-56 object-contain"
                onError={(e) => {
                    e.target.onerror = null;
                    e.target.src = `${BACKEND_URL}/images/default-bike.png`;
                }}
            />

            <h2 className="mt-4 text-xl font-bold text-center">

                {bike.name}

            </h2>

            <p className="text-blue-600 font-semibold mt-2">

                {bike.price}

            </p>

            <p className="text-slate-500 mt-1">

                {bike.brand}

            </p>

        </div>

    );

    return (

        <section className="bg-white rounded-3xl shadow-sm border p-10 mb-8">

            <div className="grid grid-cols-3 items-center">

                <Card bike={bike1} />

                <div className="text-center">

                    <span className="text-5xl font-black text-blue-600">

                        VS

                    </span>

                </div>

                <Card bike={bike2} />

            </div>

        </section>

    );

}