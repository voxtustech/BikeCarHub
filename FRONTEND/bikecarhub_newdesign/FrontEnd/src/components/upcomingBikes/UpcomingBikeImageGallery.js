/*
import React from "react";
import { BACKEND_URL } from "../../config";

export default function ImageGallery({

    images = []

}) {

    if (!images.length) return null;

    
    |--------------------------------------------------------------------------
    | Single Image
    |--------------------------------------------------------------------------
    

    if (images.length === 1) {

        return (

            <div className="rounded-2xl overflow-hidden border border-slate-200 shadow-sm">

                <img

                    src={`${BACKEND_URL}${images[0]}`}

                    alt="Article"

                    className="w-full h-[450px] object-cover"

                />

            </div>

        );

    }
*/
import React from "react";

export default function ImageGallery({ images = [] }) {

    if (!images.length) return null;

    if (images.length === 1) {
        return (
            <div className="rounded-2xl overflow-hidden border border-slate-200 shadow-sm">
                <img
                    src={images[0]}
                    alt="Article"
                    className="w-full h-[450px] object-cover"
                />
            </div>
        );
    }

    /*
    |--------------------------------------------------------------------------
    | Two Images
    |--------------------------------------------------------------------------
    */

    if (images.length === 2) {

        return (

            <div className="grid md:grid-cols-2 gap-5">

                {images.map((image, index) => (

                    <div

                        key={index}

                        className="rounded-2xl overflow-hidden border border-slate-200 shadow-sm"

                    >

                        <img

                            src={image}

                            alt={`Image ${index + 1}`}

                            className="w-full h-[320px] object-cover hover:scale-105 transition-transform duration-500"

                        />

                    </div>

                ))}

            </div>

        );

    }

    /*
    |--------------------------------------------------------------------------
    | Three or More Images
    |--------------------------------------------------------------------------
    */

    return (

        <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-5">

            {images.map((image, index) => (

                <div

                    key={index}

                    className="rounded-2xl overflow-hidden border border-slate-200 shadow-sm"

                >

                    <img

                        src={image}

                        alt={`Image ${index + 1}`}

                        className="w-full h-72 object-cover hover:scale-105 transition-transform duration-500"

                    />

                </div>

            ))}

        </div>

    );

}