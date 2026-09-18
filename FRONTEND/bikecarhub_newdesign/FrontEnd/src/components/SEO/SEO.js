import React from "react";
import { Helmet } from "react-helmet-async";

const SITE_NAME = "BikeCarHub";
const SITE_URL = "https://bikecarhub.com";

export default function SEO({
    title,
    description,
    keywords,
    canonical,
    image,
    noindex = false
}) {
    const pageTitle = title
        ? `${title} | ${SITE_NAME}`
        : `${SITE_NAME} - Compare Bikes, Prices, Features & Reviews`;

    const pageDescription =
        description ||
        "Compare bikes in India with prices, specifications, features, reviews, EMI calculations and the latest bike news on BikeCarHub.";

    const canonicalUrl = canonical
        ? `${SITE_URL}${canonical.startsWith("/") ? canonical : `/${canonical}`}`
        : SITE_URL;

    const imageUrl = image
        ? image.startsWith("http")
            ? image
            : `${SITE_URL}${image.startsWith("/") ? image : `/${image}`}`
        : `${SITE_URL}/logo.png`;

    return (
        <Helmet>
            <title>{pageTitle}</title>

            <meta
                name="description"
                content={pageDescription}
            />
            <meta
                name="keywords"
                content={keywords}
            />
            <link
                rel="canonical"
                href={canonicalUrl}
            />

            {noindex && (
                <meta
                    name="robots"
                    content="noindex, nofollow"
                />
            )}

            {/* Open Graph */}
            <meta
                property="og:title"
                content={pageTitle}
            />

            <meta
                property="og:description"
                content={pageDescription}
            />

            <meta
                property="og:type"
                content="website"
            />

            <meta
                property="og:url"
                content={canonicalUrl}
            />

            <meta
                property="og:image"
                content={imageUrl}
            />

            <meta
                property="og:site_name"
                content={SITE_NAME}
            />

            {/* Twitter */}
            <meta
                name="twitter:card"
                content="summary_large_image"
            />

            <meta
                name="twitter:title"
                content={pageTitle}
            />

            <meta
                name="twitter:description"
                content={pageDescription}
            />

            <meta
                name="twitter:image"
                content={imageUrl}
            />
        </Helmet>
    );
}