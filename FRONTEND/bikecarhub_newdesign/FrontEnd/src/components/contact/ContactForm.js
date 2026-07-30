import { useState } from "react";
import { Send } from "lucide-react";
import { sendContactMessage } from "../../api/contactApi";

export default function ContactForm({
    title = "Send Us a Message",
    subtitle = "Fill out the form below and our team will get back to you shortly.",
}) {

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
                behavior: "smooth",
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

        <div
            className="
                bg-white
                rounded-3xl
                shadow-lg
                p-10
            "
        >

            <h2
                className="
                    text-4xl
                    font-bold
                    text-[#165D8C]
                "
            >
                {title}
            </h2>

            <p
                className="
                    mt-4
                    text-slate-500
                    text-lg
                "
            >
                {subtitle}
            </p>

            {
                successMessage && (

                    <div
                        className="
                            mt-8
                            rounded-xl
                            bg-green-50
                            border
                            border-green-300
                            text-green-700
                            px-5
                            py-4
                        "
                    >
                        {successMessage}
                    </div>

                )
            }

            {
                errorMessage && (

                    <div
                        className="
                            mt-8
                            rounded-xl
                            bg-red-50
                            border
                            border-red-300
                            text-red-700
                            px-5
                            py-4
                        "
                    >
                        {errorMessage}
                    </div>

                )
            }

            <form
                onSubmit={handleSubmit}
                className="mt-10 space-y-8"
            >

                <div>

                    <label
                        className="
                            block
                            font-semibold
                            text-slate-800
                            mb-3
                        "
                    >
                        Name
                    </label>

                    <input
                        type="text"
                        name="name"
                        value={formData.name}
                        maxLength={60}
                        onChange={handleChange}
                        placeholder="Enter your full name"
                        required
                        className="
                            w-full
                            rounded-xl
                            border
                            border-slate-300
                            px-5
                            py-4
                            outline-none
                            focus:ring-2
                            focus:ring-blue-500
                        "
                    />

                </div>

                <div>

                    <label
                        className="
                            block
                            font-semibold
                            text-slate-800
                            mb-3
                        "
                    >
                        Phone No.
                    </label>

                    <input
                        type="tel"
                        name="phoneNo"
                        value={formData.phoneNo}
                        maxLength={10}
                        onChange={(e) => {

                            const value =
                                e.target.value.replace(/\D/g, "");

                            setFormData(prev => ({
                                ...prev,
                                phoneNo: value
                            }));

                        }}
                        placeholder="Enter your phone number"
                        required
                        className="
                            w-full
                            rounded-xl
                            border
                            border-slate-300
                            px-5
                            py-4
                            outline-none
                            focus:ring-2
                            focus:ring-blue-500
                        "
                    />

                </div>

                <div>

                    <label
                        className="
                            block
                            font-semibold
                            text-slate-800
                            mb-3
                        "
                    >
                        Email
                    </label>

                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        placeholder="Enter your email address"
                        required
                        className="
                            w-full
                            rounded-xl
                            border
                            border-slate-300
                            px-5
                            py-4
                            outline-none
                            focus:ring-2
                            focus:ring-blue-500
                        "
                    />
                </div>

                <div>

                    <label
                        className="
                            block
                            font-semibold
                            text-slate-800
                            mb-3
                        "
                    >
                        Message
                    </label>

                    <textarea
                        rows={5}
                        name="message"
                        value={formData.message}
                        maxLength={500}
                        onChange={handleChange}
                        placeholder="Write your message here..."
                        required
                        className="
                            w-full
                            rounded-xl
                            border
                            border-slate-300
                            px-5
                            py-4
                            outline-none
                            resize-none
                            focus:ring-2
                            focus:ring-blue-500
                        "
                    />

                    <p
                        className="
                            mt-2
                            text-sm
                            text-slate-500
                            text-right
                        "
                    >
                        {formData.message.length}/500
                    </p>

                </div>

                <button
                    type="submit"
                    disabled={loading}
                    className="
                        w-full
                        rounded-xl
                        py-5
                        font-bold
                        text-xl
                        text-white
                        transition
                        hover:opacity-90
                        disabled:opacity-70
                        flex
                        items-center
                        justify-center
                        gap-3
                    "
                    style={{
                        background: "#165D8C"
                    }}
                >

                    <Send size={20} />

                    {
                        loading
                            ? "Sending Message..."
                            : "Send Message"
                    }

                </button>

            </form>

        </div>

    );

}