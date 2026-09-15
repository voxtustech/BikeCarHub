import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { submitQuestion } from "../api/contactApi";

export function AskQuestionPage() {

    const navigate = useNavigate();

    const [form, setForm] = useState({
        name: "",
        email: "",
        message: ""
    });

    const [loading, setLoading] = useState(false);

    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value
        });
    };


    const handleSubmit = async (e) => {

        e.preventDefault();

        if (loading) return;

        try {

            setLoading(true);

            const result = await submitQuestion({
                name: form.name,
                email: form.email,
                question: form.message
            });

            alert(
                result.message ||
                "Your question has been submitted successfully."
            );

            setForm({
                name: "",
                email: "",
                message: ""
            });

            navigate("/");

        } catch (error) {

            console.error("Question submission error:", error);

            alert(
                error.message ||
                "Unable to submit your question."
            );

        } finally {

            setLoading(false);

        }
    };


    return (

        <div className="max-w-3xl mx-auto px-6 py-16">

            <h1 className="text-4xl font-bold mb-3">
                Ask a Question
            </h1>

            <p className="text-slate-600 mb-8">
                Have a question about any vehicle?
                Fill out the form below and our experts will get back to you.
            </p>


            <form
                onSubmit={handleSubmit}
                className="bg-white rounded-2xl shadow border p-8 space-y-6"
            >

                {/* Name */}

                <div>

                    <label>
                        Name
                    </label>

                    <input
                        className="w-full border rounded-xl p-3 mt-2"
                        name="name"
                        value={form.name}
                        onChange={handleChange}
                        required
                    />

                </div>


                {/* Email */}

                <div>

                    <label>
                        Email
                    </label>

                    <input
                        className="w-full border rounded-xl p-3 mt-2"
                        type="email"
                        name="email"
                        value={form.email}
                        onChange={handleChange}
                        required
                    />

                </div>


                {/* Question */}

                <div>

                    <label>
                        Question
                    </label>

                    <textarea
                        rows={6}
                        className="w-full border rounded-xl p-3 mt-2"
                        name="message"
                        value={form.message}
                        onChange={handleChange}
                        required
                    />

                </div>


                {/* Buttons */}

                <div className="flex gap-4">

                    <button
                        type="submit"
                        disabled={loading}
                        className="bg-[#0A0A2B] text-white px-8 py-3 rounded-xl disabled:opacity-50"
                    >
                        {loading ? "Submitting..." : "Submit"}
                    </button>


                    <button
                        type="button"
                        onClick={() => navigate("/")}
                        disabled={loading}
                        className="border px-8 py-3 rounded-xl"
                    >
                        Cancel
                    </button>

                </div>

            </form>

        </div>

    );
}