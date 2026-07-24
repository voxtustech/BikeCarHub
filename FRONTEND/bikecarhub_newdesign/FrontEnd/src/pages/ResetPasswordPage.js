import { useState } from "react";
import { useNavigate, useSearchParams } from "react-router-dom";
import { resetPassword } from "../api/authApi";

export function ResetPasswordPage() {

    const navigate = useNavigate();

    const [params] = useSearchParams();

    const token = params.get("token");

    const email = params.get("email");

    const [password, setPassword] = useState("");

    const [confirmPassword, setConfirmPassword] = useState("");

    const [loading, setLoading] = useState(false);

    const [error, setError] = useState("");

    async function handleSubmit(e) {

        e.preventDefault();

        if (password !== confirmPassword) {

            setError("Passwords do not match.");

            return;

        }

        try {

            setLoading(true);

            setError("");

            await resetPassword({
                email,
                token,
                newPassword: password,
                confirmPassword: confirmPassword
            });

            alert("Password changed successfully.");

            navigate("/login");

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

                        Reset Password

                    </h1>

                    <form

                        onSubmit={handleSubmit}

                        className="space-y-5 mt-8"

                    >

                        <input

                            type="password"

                            placeholder="New Password"

                            value={password}

                            onChange={(e) =>
                                setPassword(e.target.value)
                            }

                            className="w-full border rounded-xl p-3"

                            required

                        />

                        <input

                            type="password"

                            placeholder="Confirm Password"

                            value={confirmPassword}

                            onChange={(e) =>
                                setConfirmPassword(e.target.value)
                            }

                            className="w-full border rounded-xl p-3"

                            required

                        />

                        {

                            error &&

                            <div className="text-red-600 text-sm">

                                {error}

                            </div>

                        }

                        <button

                            className="w-full bg-blue-600 text-white rounded-xl py-3"

                        >

                            {

                                loading

                                    ? "Updating..."

                                    : "Reset Password"

                            }

                        </button>

                    </form>

                </div>

            </section>

        </div>

    );

}