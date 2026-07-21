import { useState } from "react";
import { Instagram, Linkedin } from "lucide-react";

const usefulLinks = [
  "Contact BikeCarHub",
  "About BikeCarHub",
  "Upcoming Bikes & Cars",
  "Compare",
  "Privacy Policy",
  "Terms and Conditions",
  "Disclaimer",
  "Admin Login",
];

export function Footer() {
  const [email, setEmail] = useState("");

  return (
    <footer
      style={{
        background:
          "linear-gradient(90deg,#121826 0%, #18212C 50%, #121826 100%)",
      }}
    >
      <div className="max-w-7xl mx-auto px-6 py-12">
        {/* Main Footer */}
        <div className="grid grid-cols-1 lg:grid-cols-3 gap-12">

          {/* Useful Links */}
          <div>
            <h3
              className="text-white uppercase mb-3"
              style={{
                fontWeight: 700,
                fontSize: "16px",
                letterSpacing: "0.04em",
              }}
            >
              Useful Links
            </h3>

            <div
              className="w-24 h-[3px] mb-6"
              style={{ background: "#2563EB" }}
            />

            <ul className="space-y-4">
              {usefulLinks.map((link) => (
                <li key={link}>
                  <a
                    href="#"
                    className="text-slate-300 hover:text-white transition-colors flex items-center gap-3"
                  >
                    <span className="text-slate-500">›</span>
                    {link}
                  </a>
                </li>
              ))}
            </ul>
          </div>

          {/* Newsletter */}
          <div>
            <h3
              className="text-white uppercase mb-3"
              style={{
                fontWeight: 700,
                fontSize: "16px",
                letterSpacing: "0.04em",
              }}
            >
              Newsletter
            </h3>

            <div
              className="w-24 h-[3px] mb-6"
              style={{ background: "#030c1fff" }}
            />

            <p className="text-slate-400 leading-8 mb-6">
              Keep up with our always evolving products, features and
              technology. Enter your email and subscribe to our newsletter.
            </p>

            <input
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="Enter your email address"
              className="w-full px-5 py-4 rounded-xl mb-4 outline-none"
              style={{
                background: "rgba(255,255,255,0.06)",
                border: "1px solid rgba(255,255,255,0.12)",
                color: "white",
              }}
            />

            <button
              className="w-full py-4 rounded-xl text-white font-semibold transition-all hover:opacity-90"
              style={{
                background: "#292f6dff",
              }}
            >
              SUBSCRIBE TO BIKECARHUB
            </button>
          </div>

          {/* About + Contact */}
          <div>
            <h3
              className="text-white uppercase mb-3"
              style={{
                fontWeight: 700,
                fontSize: "16px",
                letterSpacing: "0.04em",
              }}
            >
              About BikeCarHub
            </h3>

            <div
              className="w-24 h-[3px] mb-6"
              style={{ background: "#030915ff" }}
            />

            <p className="text-slate-400 leading-9 mb-8">
              BikeCarHub is a one-stop destination for Indian vehicle shoppers,
              combining pricing tools, informative reviews, comparison features,
              launch calendars, and news - all maintained by an established
              tech firm in Dehradun.
            </p>

            <div className="space-y-3 mb-6">
              <p className="text-slate-300">
                <span className="font-bold text-white">Phone:</span>{" "}
                +91 8630235507
              </p>

              <p className="text-slate-300">
                <span className="font-bold text-white">Email:</span>{" "}
                info@voxtus.com
              </p>
            </div>

            <div className="flex items-center gap-5">
              <a
              href="https://www.instagram.com/bikecarhub2024/?hl=en"
              target="_blank"
              rel="noopener noreferrer"
              aria-label="Instagram"
              className="text-slate-400 hover:text-[#2563EB] hover:scale-110 transition-all duration-200"
              >
              <Instagram size={22} />
              </a>

              <a
                href="https://x.com/bikecarhub"
                target="_blank"
                rel="noopener noreferrer"
                className="text-slate-400 hover:text-[#2563EB] hover:scale-110 transition-all duration-200"
              >
              <svg
                width="22"
                height="22"
                viewBox="0 0 24 24"
                fill="currentColor"
              >
              <path d="M18.901 1H22.58L14.54 10.19L24 23H16.594L10.793 15.235L3.891 23H.209L8.81 13.327L0 1H7.594L12.838 8.09L18.901 1Z"/>
              </svg>
              </a>

              <a
                href="https://www.linkedin.com/in/bikecar-hub-a42a81356/"
                target="_blank"
                rel="noopener noreferrer"
                aria-label="LinkedIn"
                className="text-slate-400 hover:text-[#2563EB] hover:scale-110 transition-all duration-200"
              >
              <Linkedin size={22} />
              </a>
            </div>
          </div>
        </div>

        {/* Bottom Bar */}
        <div className="mt-12 pt-6 border-t border-white/10">
          <div className="flex flex-col md:flex-row items-center justify-between gap-4">
            <p className="text-slate-500 text-sm">
              © 2026 BikeCarHub. All rights reserved.
            </p>

            <div className="flex items-center gap-4 text-slate-400 text-sm">
              <a href="#" className="hover:text-white transition-colors">
                About BikeCarHub
              </a>

              <span>|</span>

              <a href="#" className="hover:text-white transition-colors">
                Contact BikeCarHub
              </a>
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
}