import { useState } from "react";
import { Link } from "react-router-dom";
import { forgotPassword } from "../api/authApi";

export function ForgotPasswordPage() {

    const [emailOrUsername, setEmailOrUsername] = useState("");

    const [loading, setLoading] = useState(false);

    const [success, setSuccess] = useState("");

    const [error, setError] = useState("");

    async function handleSubmit(e) {

        e.preventDefault();

        setLoading(true);

        setError("");

        setSuccess("");

        try {

            const response = await forgotPassword({

                emailOrUsername

            });

            setSuccess(response.message);

        }

        catch (err) {

            setError(err.message);

        }

        finally {

            setLoading(false);

        }

    }

    return (

        <div className="min-h-screen bg-slate-50">

            <section className="py-12 px-4">

                <div className="max-w-md mx-auto bg-white rounded-2xl shadow-lg p-8">

                    <h1 className="text-3xl font-bold text-center">

                        Forgot Password

                    </h1>

                    <p className="text-center text-slate-500 mt-2 mb-8">

                        Enter your email or username.

                    </p>

                    <form
                        onSubmit={handleSubmit}
                        className="space-y-5"
                    >

                        <input

                            type="text"

                            value={emailOrUsername}

                            onChange={(e) =>
                                setEmailOrUsername(e.target.value)
                            }

                            placeholder="Email or Username"

                            className="w-full border rounded-xl p-3"

                            required

                        />

                        {

                            error &&

                            <div className="text-red-600 text-sm">

                                {error}

                            </div>

                        }

                        {

                            success &&

                            <div className="text-green-600 text-sm">

                                {success}

                            </div>

                        }

                        <button

                            className="w-full bg-blue-600 text-white rounded-xl py-3"

                        >

                            {

                                loading

                                    ? "Sending..."

                                    : "Send Reset Link"

                            }

                        </button>

                        <div className="text-center">

                            <Link

                                to="/login"

                                className="text-blue-600"

                            >

                                Back to Login

                            </Link>

                        </div>

                    </form>

                </div>

            </section>

        </div>

    );

}