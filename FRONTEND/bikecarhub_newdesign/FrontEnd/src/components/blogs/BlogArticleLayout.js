import React, { useState } from "react";
import { Link } from "react-router-dom";
import {
    Calendar,
    Clock,
    ChevronRight
} from "lucide-react";

import ArticleRelatedSections from "../common/ArticleRelatedSections";
import SEO from "../SEO/SEO";

/*
 * Reusable rich-text renderer
 *
 * Supported HTML:
 * <strong>Bold</strong>
 * <b>Bold</b>
 * <em>Italic</em>
 * <i>Italic</i>
 * <u>Underline</u>
 * <mark>Highlight</mark>
 * <span class="highlight">Custom highlight</span>
 * <span class="text-orange-600">Colored text</span>
 */
function RichText({ children, className = "" }) {

    if (children === null || children === undefined) {
        return null;
    }

    return (
        <span
            className={className}
            dangerouslySetInnerHTML={{
                __html: String(children)
            }}
        />
    );
}


export default function BlogArticleLayout({ article }) {

    const [openFAQ, setOpenFAQ] = useState(null);

    if (!article) {
        return null;
    }

    return (

        <div className="bg-white">
            <SEO
                title={article.title}
                description={article.description}
                keywords={article.keywords}
                canonical={`/blogs/${article.slug || article.url}`}
            />

            {/* =====================================================
                HERO
            ===================================================== */}

            <section className="max-w-7xl mx-auto px-6 pt-12">

                {/* Breadcrumb */}

                <section className="hidden md:block">

                    <div className="mb-4 text-sm text-slate-500 flex items-center gap-2">

                        <Link
                            to="/blogs"
                            className="hover:text-blue-700"
                        >
                            Blogs
                        </Link>

                        <ChevronRight size={14} />

                        <span>
                            <RichText>
                                {article.title}
                            </RichText>
                        </span>

                    </div>

                </section>


                {/* Blog Title */}

                <h1
                    className="text-5xl font-bold leading-tight"
                >
                    <RichText>
                        {article.title}
                    </RichText>
                </h1>


                {/* Blog Description */}

                <p
                    className="text-lg text-slate-600 mt-5 max-w-5xl"
                >
                    <RichText>
                        {article.description}
                    </RichText>
                </p>


                {/* Date + Read Time */}

                <div
                    className="flex gap-8 mt-6 text-slate-500"
                >

                    <div className="flex items-center gap-2">

                        <Calendar size={18} />

                        {article.date}

                    </div>


                    <div className="flex items-center gap-2">

                        <Clock size={18} />

                        {article.readTime}

                    </div>

                </div>


                {/* Hero Image */}

                <div className="flex justify-center w-full mb-6 mt-6">

                    <img
                        src={article.heroImage}
                        alt={article.title}
                        className="max-h-[60vh] max-w-full w-auto h-auto object-contain rounded-2xl shadow-md"
                    />

                </div>

            </section>


            {/* =====================================================
                MAIN CONTENT
            ===================================================== */}

            <section className="max-w-6xl mx-auto px-6 py-16">

                {article.sections?.map((section, index) => (

                    <div
                        key={index}
                        className="mb-16"
                    >

                        {/* Section Heading */}

                        {section.heading && (

                            <h2 className="text-3xl font-bold mb-6">

                                <RichText>
                                    {section.heading}
                                </RichText>

                            </h2>

                        )}


                        {/* Section Image */}

                        {section.image && (

                            <div className="flex justify-center w-full mb-8">

                                <img
                                    src={section.image}
                                    alt={section.heading}
                                    className="max-h-[60vh] max-w-full w-auto h-auto object-contain rounded-2xl shadow-md"
                                />

                            </div>

                        )}


                        {/* Paragraphs */}

                        {section.paragraphs?.map((paragraph, i) => (

                            <p
                                key={i}
                                className="text-lg leading-9 text-slate-700 mb-6"
                            >

                                <RichText>
                                    {paragraph}
                                </RichText>

                            </p>

                        ))}


                        {/* Bullets */}

                        {section.bullets?.length > 0 && (

                            <ul className="list-disc ml-8 text-xl leading-10 space-y-4">

                                {section.bullets.map((bullet, i) => (

                                    <li
                                        key={i}
                                        className="text-lg"
                                    >

                                        <RichText>
                                            {bullet}
                                        </RichText>

                                    </li>

                                ))}

                            </ul>

                        )}

                    </div>

                ))}

            </section>


            {/* =====================================================
                TABLES
            ===================================================== */}

            {article.tables?.length > 0 && (

                <section className="max-w-6xl mx-auto px-6">

                    {article.tables.map((table, index) => (

                        <div
                            key={index}
                            className="mb-16"
                        >

                            {/* Table Title */}

                            <h2 className="text-3xl font-bold mb-6">

                                <RichText>
                                    {table.title}
                                </RichText>

                            </h2>


                            {/* Table */}

                            <div className="rounded-2xl border shadow-md overflow-x-auto">

                                <table className="w-full min-w-max rounded-2xl shadow-md">

                                    {/* Header */}

                                    <thead>

                                        <tr>

                                            {table.headers?.map((header, i) => (

                                                <th
                                                    key={i}
                                                    className="border bg-slate-100 p-4 whitespace-nowrap"
                                                >

                                                    <RichText>
                                                        {header}
                                                    </RichText>

                                                </th>

                                            ))}

                                        </tr>

                                    </thead>


                                    {/* Body */}

                                    <tbody>

                                        {table.rows?.map((row, r) => (

                                            <tr key={r}>

                                                {row.map((cell, c) => (

                                                    <td
                                                        key={c}
                                                        className="border p-4"
                                                    >

                                                        <RichText>
                                                            {cell}
                                                        </RichText>

                                                    </td>

                                                ))}

                                            </tr>

                                        ))}

                                    </tbody>

                                </table>

                            </div>

                        </div>

                    ))}

                </section>

            )}


            {/* =====================================================
                ADDITIONAL SECTIONS AFTER TABLES
            ===================================================== */}

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

                                    <RichText>
                                        {section.heading}
                                    </RichText>

                                </h2>

                            )}


                            {/* Section Images */}

                            {section.images?.length > 0 && (

                                <div
                                    className={`grid gap-6 mb-8 ${section.images.length === 1
                                            ? "grid-cols-1"
                                            : "grid-cols-2"
                                        }`}
                                >

                                    {section.images.map((image, i) => (

                                        <div
                                            key={i}
                                            className="flex justify-center w-full mb-8"
                                        >

                                            <img
                                                src={image}
                                                alt={`${section.heading || article.title} ${i + 1}`}
                                                className="max-h-[60vh] max-w-full w-auto h-auto object-contain rounded-2xl shadow-md"
                                            />

                                        </div>

                                    ))}

                                </div>

                            )}


                            {/* Paragraphs */}

                            {section.paragraphs?.map((paragraph, i) => (

                                <p
                                    key={i}
                                    className="text-lg leading-9 text-slate-700 mb-6"
                                >

                                    <RichText>
                                        {paragraph}
                                    </RichText>

                                </p>

                            ))}


                            {/* Bullets */}

                            {section.bullets?.length > 0 && (

                                <ul className="list-disc ml-8 text-lg leading-9 space-y-3">

                                    {section.bullets.map((bullet, i) => (

                                        <li key={i}>

                                            <RichText>
                                                {bullet}
                                            </RichText>

                                        </li>

                                    ))}

                                </ul>

                            )}

                        </div>

                    ))}

                </section>

            )}


            {/* =====================================================
                FAQ
            ===================================================== */}

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

                                    {/* FAQ Question */}

                                    <button
                                        onClick={() =>
                                            setOpenFAQ(
                                                isOpen ? null : index
                                            )
                                        }
                                        className="w-full flex items-center justify-between px-6 py-5 bg-white hover:bg-slate-50 transition"
                                    >

                                        <span className="text-left font-semibold text-lg">

                                            <RichText>
                                                {faq.question}
                                            </RichText>

                                        </span>


                                        <span
                                            className={`text-2xl transition-transform duration-300 ${isOpen
                                                    ? "rotate-45"
                                                    : ""
                                                }`}
                                        >
                                            +
                                        </span>

                                    </button>


                                    {/* FAQ Answer */}

                                    <div
                                        className={`transition-all duration-300 overflow-hidden ${isOpen
                                                ? "max-h-96"
                                                : "max-h-0"
                                            }`}
                                    >

                                        <div className="px-6 pb-6 pt-2 text-slate-700 text-lg leading-8">

                                            <RichText>
                                                {faq.answer}
                                            </RichText>

                                        </div>

                                    </div>

                                </div>

                            );

                        })}

                    </div>

                </section>

            )}


          

            <ArticleRelatedSections />

        </div>

    );

}