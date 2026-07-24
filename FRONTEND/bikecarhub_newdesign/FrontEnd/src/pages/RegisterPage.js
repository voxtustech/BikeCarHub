import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { register } from "../api/authApi";
import { useAuth } from "../context/AuthContext";

export function RegisterPage() {

    const navigate = useNavigate();

    const { login } = useAuth();

    const [loading, setLoading] = useState(false);

    const [error, setError] = useState("");

    const [form, setForm] = useState({

        fullName: "",

        userName: "",

        email: "",

        phoneNumber: "",

        password: "",

        confirmPassword: ""

    });

    function change(e) {

        setForm({

            ...form,

            [e.target.name]: e.target.value

        });

    }

    async function submit(e) {

        e.preventDefault();

        if (form.password !== form.confirmPassword) {

            setError("Passwords do not match.");

            return;

        }

        try {

            setLoading(true);

            setError("");

            await register(form);

            await login({

                emailOrPhone: form.email,

                password: form.password,

                rememberMe: false

            });

            navigate("/");

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

                    <h1 className="text-4xl font-bold text-center">

                        Create Account

                    </h1>

                    <p className="text-center text-slate-500 mb-8">

                        Join BikeCarHub

                    </p>

                    <form
                        onSubmit={submit}
                        className="space-y-4"
                    >

                        <input
                            name="fullName"
                            placeholder="Full Name"
                            onChange={change}
                            className="w-full border rounded-xl p-3"
                        />

                        <input
                            name="userName"
                            placeholder="Username"
                            onChange={change}
                            className="w-full border rounded-xl p-3"
                        />

                        <input
                            name="email"
                            placeholder="Email"
                            onChange={change}
                            className="w-full border rounded-xl p-3"
                        />

                        <input
                            name="phoneNumber"
                            placeholder="Phone Number"
                            onChange={change}
                            className="w-full border rounded-xl p-3"
                        />

                        <input
                            type="password"
                            name="password"
                            placeholder="Password"
                            onChange={change}
                            className="w-full border rounded-xl p-3"
                        />

                        <input
                            type="password"
                            name="confirmPassword"
                            placeholder="Confirm Password"
                            onChange={change}
                            className="w-full border rounded-xl p-3"
                        />

                        {

                            error &&

                            <div className="text-red-600 text-sm">

                                {error}

                            </div>

                        }

                        <button
                            className="w-full py-3 rounded-xl bg-blue-600 text-white"
                        >

                            {

                                loading

                                    ? "Creating Account..."

                                    : "Register"

                            }

                        </button>

                        <div className="text-center">

                            Already have an account?

                            <Link
                                to="/login"
                                className="text-blue-600 ml-1"
                            >

                                Login

                            </Link>

                        </div>

                    </form>

                </div>

            </section>

        </div>

    );

}