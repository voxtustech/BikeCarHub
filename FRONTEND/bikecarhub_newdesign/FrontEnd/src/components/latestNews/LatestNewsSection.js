import React from "react";
import ImageGallery from "./LatestNewsImageGallery";
import BulletList from "./LatestNewsList";

export default function ArticleSection({

    section

}) {

    if (!section) return null;

    return (

        <section className="bg-white rounded-3xl border border-slate-200 shadow-sm p-8 mb-10">

            {/* Heading */}

            {section.title && (

                <h2 className="text-3xl font-bold text-slate-900 mb-6">

                    {section.title}

                </h2>

            )}

            {/* Images */}

            {section.images?.length > 0 && (

                <div className="mb-8">

                    <ImageGallery

                        images={section.images}

                    />

                </div>

            )}

            {/* Paragraphs */}

            {section.paragraphs?.map((paragraph, index) => (

                <p

                    key={index}

                    className="text-slate-700 leading-8 text-lg mb-5"

                >

                    {paragraph}

                </p>

            ))}

            {/* Bullet Points */}

            {section.points?.length > 0 && (

                <div className="mt-6">

                    <BulletList

                        points={section.points}

                    />

                </div>

            )}

        </section>

    );

}