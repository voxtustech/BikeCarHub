import React from "react";
import { useParams } from "react-router-dom";

import BlogArticleLayout from "../components/blogs/BlogArticleLayout";

// Import every hard-coded blog article here
import BMWF450GS from "../data/blogs/BMWF450GS";
// import MGMajestor from "../data/blogs/MGMajestor";
// import RenaultDuster from "../data/blogs/RenaultDuster";
// import NissanGravite from "../data/blogs/NissanGravite";
// import BMW2SeriesGranCoupe from "../data/blogs/BMW2SeriesGranCoupe";

const articles = {

    [BMWF450GS.slug]: BMWF450GS,

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