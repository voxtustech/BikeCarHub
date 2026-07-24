export function DisclaimerPage() {
    return (
        <div className="max-w-5xl mx-auto px-6 py-16">

            <h1 className="text-4xl font-bold mb-3">
                Disclaimer
            </h1>

            <p className="text-gray-600 mb-8">
                <strong>Last Updated:</strong> 1 Jan 2025
            </p>

            <p className="mb-8 leading-8 text-gray-700">
                The information provided on{" "}
                <a
                    href="/"
                    className="font-semibold text-blue-600 hover:text-blue-700 hover:underline"
                >
                    BikeCarHub.com
                </a>{" "}
                is intended only for
                general informational purposes.
            </p>

            <div className="space-y-8">

                <section>

                    <h2 className="text-2xl font-semibold mb-2">
                        1. No Professional Advice
                    </h2>

                    <p>
                        Information on this website should not be considered
                        automotive, financial or legal advice.
                    </p>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-2">
                        2. Accuracy of Information
                    </h2>

                    <p>
                        We strive to keep information accurate but make no
                        warranties regarding completeness or reliability.
                    </p>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-2">
                        3. External Links
                    </h2>

                    <p>
                        External links are provided for convenience. We are not
                        responsible for their content.
                    </p>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-2">
                        4. Sponsored and Affiliate Content
                    </h2>

                    <p>
                        Some content may contain sponsored or affiliate links.
                        This never affects our editorial integrity.
                    </p>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-2">
                        5. Use at Your Own Risk
                    </h2>

                    <p>
                        Any action taken based on the information available on
                        BikeCarHub is entirely at your own risk.
                    </p>

                </section>

            </div>

        </div>
    );
}
