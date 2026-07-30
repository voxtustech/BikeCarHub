import { useState } from "react";
import {
    MapPin,
    Mail,
    Phone,
} from "lucide-react";
import { sendContactMessage } from "../api/contactApi";
import ContactForm from "../components/contact/ContactForm";

export function ContactUsPage() {

    const [formData, setFormData] = useState({
        name: "",
        phoneNo: "",
        email: "",
        message: "",
    });

    const [loading, setLoading] = useState(false);
    const [successMessage, setSuccessMessage] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    function handleChange(e) {

        const { name, value } = e.target;

        setFormData(prev => ({
            ...prev,
            [name]: value,
        }));

    }

    async function handleSubmit(e) {

        e.preventDefault();

        setErrorMessage("");
        setSuccessMessage("");

        if (!formData.name.trim()) {
            setErrorMessage("Please enter your name.");
            return;
        }

        if (!formData.phoneNo.trim()) {
            setErrorMessage("Please enter your phone number.");
            return;
        }

        if (!/^[6-9]\d{9}$/.test(formData.phoneNo)) {
            setErrorMessage("Please enter a valid 10-digit phone number.");
            return;
        }

        if (!formData.email.trim()) {
            setErrorMessage("Please enter your email.");
            return;
        }

        const emailRegex =
            /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!emailRegex.test(formData.email)) {
            setErrorMessage("Please enter a valid email.");
            return;
        }

        if (!formData.message.trim()) {
            setErrorMessage("Please enter your message.");
            return;
        }

        try {

            setLoading(true);

            const result = await sendContactMessage(formData);

            setSuccessMessage(result.message);
            window.scrollTo({

                top: 0,

                behavior: "smooth"

            });

            setFormData({
                name: "",
                phoneNo: "",
                email: "",
                message: "",
            });

        }

        catch (error) {

            console.error(error);

            setErrorMessage(
                error.message || "Something went wrong."
            );

        }

        finally {

            setLoading(false);

        }

    }

    return (

        <main className="bg-gradient-to-b from-[#F8FAFC] to-[#EEF4F8] min-h-screen">

            {/* Hero */}

            <section className="max-w-7xl mx-auto px-6 pt-14 pb-10">

                <h1
                    className="text-5xl font-extrabold text-slate-900"
                >
                    Contact BikeCarHub
                </h1>

                <p className="mt-8 text-lg leading-9 text-slate-700">

                    Have questions about bikes, cars, comparisons, pricing,
                    or suggestions? Our team is here to help you with the
                    latest updates, vehicle information, and support related
                    to BikeCarHub.

                </p>

                <p className="mt-6 text-lg leading-9 text-slate-700">

                    Whether you're looking for bike or car information,
                    comparing vehicles, checking prices, or exploring the
                    latest automotive updates, our team is here to assist
                    you with accurate and reliable guidance.

                </p>

                <p className="mt-6 text-lg leading-9 text-slate-700">

                    At BikeCarHub, we focus on delivering simple,
                    trustworthy, and user-friendly automotive content to
                    help users make smarter decisions.

                    Feel free to reach out with your questions,
                    feedback, or suggestions.

                </p>

                <div className="mt-10 space-y-4">

                    <div className="flex items-center gap-3">

                        <span className="font-bold text-slate-900">
                            Email:
                        </span>

                        <span className="text-slate-700">
                            info@bikecarhub.com
                        </span>

                    </div>

                    <div className="flex items-center gap-3">

                        <span className="font-bold text-slate-900">
                            Support Hours:
                        </span>

                        <span className="text-slate-700">
                            Monday – Friday | 10:00 AM – 6:00 PM IST
                        </span>

                    </div>

                </div>

            </section>

            {/* Contact Section */}

            <section className="max-w-7xl mx-auto px-6 pb-14">

                <div className="grid lg:grid-cols-2 gap-10 items-start">

                    {/* LEFT */}

                    <div>

                        {/* Address */}

                        <div
                            className="
                                bg-white
                                rounded-3xl
                                shadow-lg
                                p-10
                                text-center
                            "
                        >

                            <div
                                className="
                                    w-16
                                    h-16
                                    rounded-full
                                    bg-blue-50
                                    flex
                                    items-center
                                    justify-center
                                    mx-auto
                                "
                            >

                                <MapPin
                                    size={34}
                                    className="text-[#165D8C]"
                                />

                            </div>

                            <h2
                                className="
                                    mt-8
                                    text-4xl
                                    font-bold
                                    text-[#165D8C]
                                "
                            >
                                Our Office Address
                            </h2>

                            <p
                                className="
                                    mt-8
                                    text-xl
                                    text-slate-700
                                    leading-9
                                "
                            >
                                Lane No 5F,
                                Shivraj Nagar,
                                Badonwala,
                                Uttarakhand – 248007,
                                India
                            </p>

                        </div>

                        {/* Bottom cards */}

                        <div
                            className="
                                grid
                                md:grid-cols-2
                                gap-8
                                mt-10
                            "
                        >

                            {/* Email */}

                            <div
                                className="
                                    bg-white
                                    rounded-3xl
                                    shadow-lg
                                    p-10
                                    text-center
                                "
                            >

                                <div
                                    className="
                                        w-16
                                        h-16
                                        rounded-full
                                        bg-blue-50
                                        flex
                                        items-center
                                        justify-center
                                        mx-auto
                                    "
                                >

                                    <Mail
                                        size={34}
                                        className="text-[#165D8C]"
                                    />

                                </div>

                                <h3
                                    className="
                                        mt-8
                                        text-3xl
                                        font-bold
                                        text-[#165D8C]
                                    "
                                >
                                    Email Support
                                </h3>

                                <p
                                    className="
                                        mt-8
                                        text-lg
                                        text-slate-700
                                    "
                                >
                                    info@bikecarhub.com
                                </p>

                                <p
                                    className="
                                        mt-4
                                        text-slate-500
                                    "
                                >
                                    Reply within 24 hours
                                </p>

                            </div>

                            {/* Phone */}

                            <div
                                className="
                                    bg-white
                                    rounded-3xl
                                    shadow-lg
                                    p-10
                                    text-center
                                "
                            >

                                <div
                                    className="
                                        w-16
                                        h-16
                                        rounded-full
                                        bg-blue-50
                                        flex
                                        items-center
                                        justify-center
                                        mx-auto
                                    "
                                >

                                    <Phone
                                        size={34}
                                        className="text-[#165D8C]"
                                    />

                                </div>

                                <h3
                                    className="
                                        mt-8
                                        text-3xl
                                        font-bold
                                        text-[#165D8C]
                                    "
                                >
                                    Call Us
                                </h3>

                                <p
                                    className="
                                        mt-8
                                        text-lg
                                        text-slate-700
                                    "
                                >
                                    +91 8630235507
                                </p>

                                <p
                                    className="
                                        mt-4
                                        text-slate-500
                                    "
                                >
                                    Mon – Fri Support
                                </p>

                            </div>

                        </div>

                    </div>

                    {/* RIGHT - Contact Form */}

                    <ContactForm />

                </div>

            </section>

            {/* Google Map */}

            <section className="pb-16">

                <div className="max-w-7xl mx-auto px-6">

                    <div
                        className="
                            overflow-hidden
                            rounded-3xl
                            shadow-lg
                            border
                            border-slate-200
                        "
                    >

                        <iframe
                            title="BikeCarHub Office Location"
                            src="https://www.google.com/maps?q=Voxtus%20Technologies%20Pvt.%20Ltd.%20Badonwala%20Dehradun&output=embed"
                            width="100%"
                            height="520"
                            loading="lazy"
                            allowFullScreen
                            referrerPolicy="no-referrer-when-downgrade"
                            style={{
                                border: 0
                            }}
                        />

                    </div>

                </div>

            </section>

        </main>

    );

}