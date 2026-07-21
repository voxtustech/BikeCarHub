import React, { useState } from "react";
import { ChevronDown } from "lucide-react";

export default function FAQSection({

    faqs = []

}) {

    const [openIndex, setOpenIndex] = useState(null);

    if (!faqs.length) return null;

    function toggle(index) {

        if (openIndex === index) {

            setOpenIndex(null);

            return;

        }

        setOpenIndex(index);

    }

    return (

        <section className="bg-white rounded-3xl border border-slate-200 shadow-sm p-8 mb-10">

            <h2 className="text-3xl font-bold text-slate-900 mb-8">

                Frequently Asked Questions

            </h2>

            <div className="space-y-4">

                {faqs.map((faq, index) => {

                    const open = openIndex === index;

                    return (

                        <div

                            key={index}

                            className="border border-slate-200 rounded-2xl overflow-hidden"

                        >

                            <button

                                onClick={() => toggle(index)}

                                className="w-full flex items-center justify-between px-6 py-5 text-left hover:bg-slate-50 transition-colors"

                            >

                                <span className="font-semibold text-slate-800 text-lg">

                                    {faq.question}

                                </span>

                                <ChevronDown

                                    size={22}

                                    className={`transition-transform duration-300 ${open ? "rotate-180" : ""
                                        }`}

                                />

                            </button>

                            <div

                                className={`grid transition-all duration-300 ease-in-out ${open
                                    ? "grid-rows-[1fr]"
                                    : "grid-rows-[0fr]"
                                    }`}

                            >

                                <div className="overflow-hidden">

                                    <div className="px-6 pb-6 text-slate-600 leading-8">

                                        {faq.answer}

                                    </div>

                                </div>

                            </div>

                        </div>

                    );

                })}

            </div>

        </section>

    );

}