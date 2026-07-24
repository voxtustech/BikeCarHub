export function PrivacyPolicyPage() {
    return (
        <div className="max-w-5xl mx-auto px-6 py-16">

            <h1 className="text-4xl font-bold mb-3">
                Privacy Policy
            </h1>

            <p className="text-gray-600 mb-8">
                <strong>Effective Date:</strong> 1 June 2025
            </p>

            <p className="mb-8 leading-8 text-gray-700">
                At{" "}
                <a
                    href="/"
                    className="font-semibold text-blue-600 hover:text-blue-700 hover:underline"
                >
                    BikeCarHub.com 
                </a>
                , your privacy is important to us. This policy
                explains how we collect, use and protect your personal
                information.
            </p>

            <div className="space-y-8">

                <section>

                    <h2 className="text-2xl font-semibold mb-3">
                        1. Information We Collect
                    </h2>

                    <ul className="list-disc ml-6 space-y-2">
                        <li>Personal information such as name and email (only when voluntarily provided).</li>
                        <li>Browser, IP address and usage statistics.</li>
                        <li>Cookies to improve user experience.</li>
                    </ul>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-3">
                        2. How We Use Your Information
                    </h2>

                    <ul className="list-disc ml-6 space-y-2">
                        <li>Improve website functionality.</li>
                        <li>Analyse website traffic.</li>
                        <li>Send newsletters if subscribed.</li>
                    </ul>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-3">
                        3. Google AdSense & Third-Party Advertising
                    </h2>

                    <p className="mb-3">
                        We use Google AdSense for advertising.
                    </p>

                    <ul className="list-disc ml-6 space-y-2">
                        <li>Google may use cookies for personalised ads.</li>
                        <li>
                            You can manage ad preferences through{" "}
                            <a
                                href="https://www.google.com/settings/ads"
                                target="_blank"
                                rel="noreferrer"
                                className="text-blue-600"
                            >
                                Google Ads Settings
                            </a>.
                        </li>
                    </ul>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-2">
                        4. Sharing Your Information
                    </h2>

                    <p>
                        We never sell or rent your personal information. Limited
                        sharing may occur with trusted services such as Google
                        Analytics or AdSense.
                    </p>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-2">
                        5. Links to Other Sites
                    </h2>

                    <p>
                        We are not responsible for privacy practices of external
                        websites linked from BikeCarHub.
                    </p>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-2">
                        6. GDPR Compliance
                    </h2>

                    <p>
                        EU users may request access, correction or deletion of
                        their personal data.
                    </p>

                </section>

                <section>

                    <h2 className="text-2xl font-semibold mb-2">
                        7. Contact
                    </h2>

                    <p>
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