import React from "react";
import { useParams } from "react-router-dom";

import BlogArticleLayout from "../components/blogs/BlogArticleLayout";

// Import every hard-coded blog article here
import NissanTekton from "../data/blogs/NissanTekton";
import ScorpioNFacelift from "../data/blogs/ScorpioNFacelift";
import ToyotaHilux2026 from "../data/blogs/ToyotaHilux2026";
import MarutiSuzukiBrezza2026 from "../data/blogs/MarutiSuzukiBrezza2026"; 
import BMWF450GS from "../data/blogs/BMWF450GS";
// import MGMajestor from "../data/blogs/MGMajestor";
// import RenaultDuster from "../data/blogs/RenaultDuster";
// import NissanGravite from "../data/blogs/NissanGravite";
// import BMW2SeriesGranCoupe from "../data/blogs/BMW2SeriesGranCoupe";

const articles = {

    [BMWF450GS.slug]: BMWF450GS,
    [MarutiSuzukiBrezza2026.slug]: MarutiSuzukiBrezza2026,
    [ToyotaHilux2026.slug]: ToyotaHilux2026,
    [ScorpioNFacelift.slug]: ScorpioNFacelift,
    [NissanTekton.slug]: NissanTekton,

    // [MGMajestor.slug]: MGMajestor,

    // [RenaultDuster.slug]: RenaultDuster,

    // [NissanGravite.slug]: NissanGravite,

};

export default function BlogDetailsPage() {

    const { slug } = useParams();

    const article = articles[slug];

    if (!article) {

        return (

            <div className="max-w-6xl mx-auto py-24 text-center">

                <h2 className="text-3xl font-bold">

                    Blog Not Found

                </h2>

                <p className="text-slate-500 mt-4">

                    The requested blog article does not exist.

                </p>

            </div>

        );

    }

    return (

        <BlogArticleLayout

            article={article}

        />

    );

}