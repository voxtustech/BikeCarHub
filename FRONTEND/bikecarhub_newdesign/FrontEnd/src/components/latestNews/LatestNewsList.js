import React from "react";
import { CheckCircle2 } from "lucide-react";

export default function BulletList({

    points = []

}) {

    if (!points.length) return null;

    return (

        <div className="mt-4">

            <ul className="space-y-4">

                {points.map((point, index) => (

                    <li

                        key={index}

                        className="flex items-start gap-4"

                    >

                        <CheckCircle2

                            size={22}

                            className="text-blue-600 mt-1 shrink-0"

                        />

                        <span className="text-slate-700 text-lg leading-8">

                            {point}

                        </span>

                    </li>

                ))}

            </ul>

        </div>

    );

}