import { useEffect, useState } from "react";
import { Calendar } from "lucide-react";
import { useNavigate } from "react-router-dom";
import { SectionTitle } from "./SectionTitle";
import { HScrollCarousel } from "./HScrollCarousel";
import { getUpcomingBikeArticles } from "../api/upcomingBikeApi";
import { BACKEND_URL } from "../config";

export function UpcomingBikesSection() {

    const [bikes, setBikes] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const navigate = useNavigate();

    useEffect(() => {

        async function loadUpcomingBikes() {

            try {

                const data = await getUpcomingBikeArticles();

                setBikes(data);

            }
            catch (err) {

                console.error(err);
                setError("Unable to load upcoming bikes.");

            }
            finally {

                setLoading(false);

            }

        }

        loadUpcomingBikes();

    }, []);

    if (loading) {

        return (

            <section className="py-10 bg-white border-t border-slate-100">

                <div className="max-w-7xl mx-auto px-6">

                    <SectionTitle
                        onClick={() => navigate("/upcoming-bikes")}
                    >

                        Upcoming Bikes

                    </SectionTitle>

                    <p className="text-slate-500">

                        Loading upcoming bikes...

                    </p>

                </div>

            </section>

        );

    }

    if (error) {

        return (

            <section className="py-10 bg-white border-t border-slate-100">

                <div className="max-w-7xl mx-auto px-6">

                    <SectionTitle
                        onClick={() => navigate("/upcoming-bikes")}
                    >

                        Upcoming Bikes

                    </SectionTitle>

                    <p className="text-red-500">

                        {error}

                    </p>

                </div>

            </section>

        );

    }

    const slugMap = {

        "upcoming-bikes/triumph-tiger-sport-800": "triumphtigersport800",

        // add remaining bikes here

    };

    return (

        <section className="py-10 bg-white border-t border-slate-100">

            <div className="max-w-7xl mx-auto px-6">

                <SectionTitle
                    onClick={() => navigate("/upcoming-bikes")}
                >

                    Upcoming Bikes

                </SectionTitle>

                <HScrollCarousel itemWidth={300}>

                    {bikes.map((bike) => (

                        <div
                            key={bike.id}
                            onClick={() => {

                                const route = slugMap[bike.slug];

                                if (route) {

                                    navigate(`/upcoming-bike/${route}`);

                                }

                            }}
                            className="group
                            w-72
                            bg-white
                            rounded-xl
                            overflow-hidden
                            shadow-sm
                            hover:shadow-xl
                            transition-all
                            duration-300
                            cursor-pointer
                            border
                            border-slate-100
                            hover:-translate-y-1"
                        >

                            <div className="h-44 overflow-hidden bg-slate-50">

                                <img
                                    src={`${BACKEND_URL}${bike.image}`}
                                    alt={bike.name}
                                    className="block
                                    w-full
                                    h-full
                                    object-cover
                                    group-hover:scale-105
                                    transition-transform
                                    duration-500"
                                />

                            </div>

                            <div className="p-4 border-t border-slate-100">

                                <p
                                    className="text-slate-800 mb-2 line-clamp-2"
                                    style={{
                                        fontFamily: "var(--font-display)",
                                        fontWeight: 700,
                                        fontSize: "14px"
                                    }}
                                >

                                    {bike.name}

                                </p>

                                <div className="flex items-center gap-1.5 text-slate-500 text-xs mb-3">

                                    <span>

                                        {bike.brand || "BikeCarHub"}

                                    </span>

                                    <span>|</span>

                                    <Calendar size={11} />

                                    <span>

                                        {bike.launchDate}

                                    </span>

                                </div>

                                <button
                                    className="text-xs hover:underline transition-colors"
                                    style={{
                                        color: "#0A0A2B",
                                        fontWeight: 600
                                    }}
                                >

                                    Read More →

                                </button>

                            </div>

                        </div>

                    ))}

                </HScrollCarousel>

            </div>

        </section>

    );

}