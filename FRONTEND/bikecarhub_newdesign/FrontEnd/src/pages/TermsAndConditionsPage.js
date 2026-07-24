export function TermsAndConditionsPage() {
    return (
        <div className="max-w-5xl mx-auto px-6 py-16">
            <h1 className="text-4xl font-bold mb-3">
                Terms and Conditions
            </h1>

            <p className="text-gray-600 mb-8">
                <strong>Effective Date:</strong> 1 Jan 2025
            </p>

            <p className="mb-8 leading-8 text-gray-700">
                Welcome to{" "}
                <a
                    href="/"
                    className="font-semibold text-blue-600 hover:text-blue-700 hover:underline"
                >
                    BikeCarHub.com
                </a>
                . By accessing or
                using this website, you agree to comply with and be bound by
                the following terms.
            </p>

            <div className="space-y-8">

                <section>
                    <h2 className="text-2xl font-semibold mb-2">
                        1. Use of Website
                    </h2>

                    <p>
                        You agree to use this site only for lawful purposes and
                        in a manner that does not infringe the rights of others.
                    </p>
                </section>

                <section>
                    <h2 className="text-2xl font-semibold mb-2">
                        2. Intellectual Property
                    </h2>

                    <p>
                        All content including text, images, logos and graphics
                        belongs to BikeCarHub unless stated otherwise.
                        Unauthorized use is prohibited.
                    </p>
                </section>

                <section>
                    <h2 className="text-2xl font-semibold mb-2">
                        3. Accuracy of Information
                    </h2>

                    <p>
                        We strive to provide accurate specifications, pricing,
                        features and vehicle information. However, we do not
                        guarantee completeness or accuracy.
                    </p>
                </section>

                <section>
                    <h2 className="text-2xl font-semibold mb-2">
                        4. External Links
                    </h2>

                    <p>
                        Third-party links are provided only for convenience.
                        BikeCarHub is not responsible for their content or
                        policies.
                    </p>
                </section>

                <section>
                    <h2 className="text-2xl font-semibold mb-2">
                        5. Limitation of Liability
                    </h2>

                    <p>
                        BikeCarHub shall not be liable for any direct or indirect
                        damages arising from use of this website.
                    </p>
                </section>

                <section>
                    <h2 className="text-2xl font-semibold mb-2">
                        6. Changes to Terms
                    </h2>

                    <p>
                        We reserve the right to update these terms at any time.
                        Continued use of the website constitutes acceptance of
                        the revised terms.
                    </p>
                </section>

                <section>
                    <h2 className="text-2xl font-semibold mb-2">
                        7. Contact
                    </h2>

                    <p>
                        Questions? Reach us at{" "}
                        <a
                            href="mailto:info@bikecarhub.com"
                            className="text-blue-600"
                        >
                            info@bikecarhub.com
                        </a>
                    </p>
                </section>

            </div>
        </div>
    );
}