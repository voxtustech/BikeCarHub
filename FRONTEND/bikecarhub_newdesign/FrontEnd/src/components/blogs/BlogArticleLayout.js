import React, { useState } from "react";
import { Link } from "react-router-dom";
import {
    Calendar,
    Clock,
    ChevronRight
} from "lucide-react";

export default function BlogArticleLayout({ article }) {
    const [openFAQ, setOpenFAQ] = useState(null);

    return (

        <div className="bg-white">

            {/* HERO */}

            <section className="max-w-7xl mx-auto px-6 pt-12">

                <div className="mb-4 text-sm text-slate-500 flex items-center gap-2">

                    <Link
                        to="/blogs"
                        className="hover:text-blue-700"
                    >
                        Blogs
                    </Link>

                    <ChevronRight size={14} />

                    <span>

                        {article.title}

                    </span>

                </div>

                <h1
                    className="text-5xl font-bold leading-tight"
                >

                    {article.title}

                </h1>

                <p
                    className="text-lg text-slate-600 mt-5 max-w-5xl"
                >

                    {article.description}

                </p>

                <div
                    className="flex gap-8 mt-6 text-slate-500"
                >

                    <div
                        className="flex items-center gap-2"
                    >

                        <Calendar size={18} />

                        {article.date}

                    </div>

                    <div
                        className="flex items-center gap-2"
                    >

                        <Clock size={18} />

                        {article.readTime}

                    </div>

                </div>

                <img

                    src={article.heroImage}

                    alt={article.title}

                    className="w-full max-h-[500px] object-contain rounded-2xl shadow-lg"

                />

            </section>

            {/* CONTENT */}

            <section

                className="max-w-6xl mx-auto px-6 py-16"

            >

                {

                    article.sections.map(

                        (section, index) => (

                            <div

                                key={index}

                                className="mb-16"

                            >

                                {

                                    section.heading && (

                                        <h2

                                            className="text-3xl font-bold mb-6"

                                        >

                                            {section.heading}

                                        </h2>

                                    )

                                }

                                {

                                    section.image && (

                                        <img

                                            src={section.image}

                                            alt={section.heading}

                                            className="rounded-2xl mb-8 w-full"

                                        />

                                    )

                                }

                                {

                                    section.paragraphs.map(

                                        (paragraph, i) => (

                                            <p

                                                key={i}

                                                className="text-lg leading-9 text-slate-700 mb-6"

                                            >

                                                {paragraph}

                                            </p>

                                        )

                                    )

                                }

                                {

                                    section.bullets && (

                                        <ul

                                            className="list-disc ml-8 text-xl leading-10 space-y-4"

                                        >

                                            {

                                                section.bullets.map(

                                                    (

                                                        bullet,

                                                        i

                                                    ) => (

                                                        <li

                                                            key={i}

                                                            className="text-lg"

                                                        >

                                                            {bullet}

                                                        </li>

                                                    )

                                                )

                                            }

                                        </ul>

                                    )

                                }

                            </div>

                        )

                    )

                }

            </section>
             {/*TABLES */}

            {

                article.tables.length > 0 && (

                    <section className="max-w-6xl mx-auto px-6">

                        {

                            article.tables.map(

                                (

                                    table,

                                    index

                                ) => (

                                    <div

                                        key={index}

                                        className="mb-16"

                                    >

                                        <h2 className="text-3xl font-bold mb-6">

                                            {table.title}

                                        </h2>

                                        <div className="rounded-2xl overflow-hidden border shadow-md">

                                            <table className="w-full overflow-hidden rounded-2xl shadow-md">

                                                <thead>

                                                    <tr>

                                                        {

                                                            table.headers.map(

                                                                (

                                                                    header,

                                                                    i

                                                                ) => (

                                                                    <th

                                                                        key={i}

                                                                        className="border bg-slate-100 p-4"

                                                                    >

                                                                        {header}

                                                                    </th>

                                                                )

                                                            )

                                                        }

                                                    </tr>

                                                </thead>

                                                <tbody>

                                                    {

                                                        table.rows.map(

                                                            (

                                                                row,

                                                                r

                                                            ) => (

                                                                <tr key={r}>

                                                                    {

                                                                        row.map(

                                                                            (

                                                                                cell,

                                                                                c

                                                                            ) => (

                                                                                <td

                                                                                    key={c}

                                                                                    className="border p-4"

                                                                                >

                                                                                    {cell}

                                                                                </td>

                                                                            )

                                                                        )

                                                                    }

                                                                </tr>

                                                            )

                                                        )

                                                    }

                                                </tbody>

                                            </table>

                                        </div>

                                    </div>

                                )

                            )

                        }

                    </section>

                )


            }

            {/* ADDITIONAL SECTIONS AFTER TABLES */}
            
            {article.afterTableSections?.length > 0 && (

                <section className="max-w-6xl mx-auto px-6 py-8">

                    {article.afterTableSections.map((section, index) => (

                        <div
                            key={index}
                            className="mb-16"
                        >

                            {/* Section Heading */}

                            {section.heading && (

                                <h2 className="text-3xl font-bold mb-6">

                                    {section.heading}

                                </h2>

                            )}

            {/*                */}{/* Section Image */}

                            {/*{section.image && (*/}

                            {/*    <img*/}
                            {/*        src={section.image}*/}
                            {/*        alt={section.heading || article.title}*/}
                            {/*        className="rounded-2xl mb-8 w-full"*/}
                            {/*    />*/}

                            {/*)}*/}
                            {section.images?.length > 0 && (

                                <div
                                    className={`grid gap-6 mb-8 ${section.images.length === 1
                                            ? "grid-cols-1"
                                            : "grid-cols-2"
                                        }`}
                                >

                                    {section.images.map((image, i) => (

                                        <img
                                            key={i}
                                            src={image}
                                            alt={`${section.heading || article.title} ${i + 1}`}
                                            className="w-full h-auto rounded-2xl shadow-md object-cover"
                                        />

                                    ))}

                                </div>

                            )}


            {/*                */}{/* Paragraphs */}

                            {section.paragraphs?.map((paragraph, i) => (

                                <p
                                    key={i}
                                    className="text-lg leading-9 text-slate-700 mb-6"
                                >

                                    {paragraph}

                                </p>

                            ))}

            {/*                */}{/* Bullets */}

                            {section.bullets?.length > 0 && (

                                <ul className="list-disc ml-8 text-lg leading-9 space-y-3">

                                    {section.bullets.map((bullet, i) => (

                                        <li key={i}>
                                            {bullet}
                                        </li>

                                    ))}

                                </ul>

                            )}

                        </div>

                    ))}

                </section>

            )}

            {/* FAQ */}

            {article.faqs?.length > 0 && (

                <section className="max-w-6xl mx-auto px-6 pb-24">

                    <h2 className="text-4xl font-bold mb-10">

                        Frequently Asked Questions

                    </h2>

                    <div className="space-y-4">

                        {article.faqs.map((faq, index) => {

                            const isOpen = openFAQ === index;

                            return (

                                <div
                                    key={index}
                                    className="border border-slate-200 rounded-xl overflow-hidden"
                                >

                                    <button

                                        onClick={() =>
                                            setOpenFAQ(
                                                isOpen ? null : index
                                            )
                                        }

                                        className="w-full flex items-center justify-between px-6 py-5 bg-white hover:bg-slate-50 transition"

                                    >

                                        <span className="text-left font-semibold text-lg">

                                            {faq.question}

                                        </span>

                                        <span
                                            className={`text-2xl transition-transform duration-300 ${isOpen ? "rotate-45" : ""
                                                }`}
                                        >

                                            +

                                        </span>

                                    </button>

                                    <div
                                        className={`transition-all duration-300 overflow-hidden ${isOpen
                                                ? "max-h-96"
                                                : "max-h-0"
                                            }`}
                                    >

                                        <div className="px-6 pb-6 pt-2 text-slate-700 text-lg leading-8">

                                            {faq.answer}

                                        </div>

                                    </div>

                                </div>

                            );

                        })}

                    </div>

                </section>

            )}
     )

            

        </div>

    );

}