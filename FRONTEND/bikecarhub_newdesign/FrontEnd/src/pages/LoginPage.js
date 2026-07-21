export function LoginPage() {
  return (
    <div className="min-h-screen bg-slate-50">
      {/* Page Banner - Same style as Blogs page */}
      <div
        className="w-full py-2 px-6 flex flex-col items-center justify-center"
        style={{
          background: "#0A0A2B",
          borderTop: "1px solid rgba(255,255,255,0.08)",
        }}
      >
        <h1
          style={{
            fontFamily: "var(--font-display)",
            fontWeight: 800,
            fontSize: "clamp(1.6rem, 3vw, 2.2rem)",
            color: "#ffffff",
            letterSpacing: "-0.02em",
          }}
        >
          Sign In
        </h1>

        <p
          style={{
            color: "rgba(255,255,255,0.55)",
            fontSize: "14px",
            marginTop: "0px",
          }}
        >
          Login to continue to BikeCarHub
        </p>
      </div>

      {/* Login Card */}
      <section className="py-12 px-4">
        <div
          className="max-w-md mx-auto bg-white rounded-2xl shadow-lg p-8"
          style={{
            border: "1px solid #E5E7EB",
          }}
        >
          <h2
            className="text-center mb-2"
            style={{
              fontSize: "38px",
              fontWeight: 800,
              color: "#111827",
              fontFamily: "var(--font-display)",
            }}
          >
            Welcome Back
          </h2>

          <p className="text-center text-slate-500 mb-8">
            Login to continue to BikeCarHub
          </p>

          <form className="space-y-5">
            <div>
              <label className="block mb-2 font-semibold">
                Email or Username
              </label>

              <input
                type="text"
                placeholder="Enter Email or Username"
                className="w-full px-4 py-3 border rounded-xl outline-none focus:border-blue-500"
              />
            </div>

            <div>
              <label className="block mb-2 font-semibold">
                Password
              </label>

              <input
                type="password"
                placeholder="Enter Password"
                className="w-full px-4 py-3 border rounded-xl outline-none focus:border-blue-500"
              />
            </div>

            <div className="flex items-center gap-2">
              <input type="checkbox" />
              <span>Remember Me</span>
            </div>

            <button
              type="submit"
              className="w-full py-3 rounded-xl text-white font-semibold transition-opacity hover:opacity-90"
              style={{
                background: "#2563EB",
              }}
            >
              Login
            </button>

            <div className="text-center">
              <a
                href="#"
                className="text-blue-600 font-medium"
              >
                Forgot Password?
              </a>
            </div>

            <div className="text-center text-slate-500">
              Don't have an account?{" "}
              <a
                href="#"
                className="text-blue-600 font-semibold"
              >
                Register
              </a>
            </div>
          </form>
        </div>
      </section>
    </div>
  );
}