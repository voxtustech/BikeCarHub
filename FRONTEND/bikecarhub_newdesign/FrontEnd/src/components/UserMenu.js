import { useState, useRef, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import "./UserMenu.css";

export default function UserMenu() {

    const [open, setOpen] = useState(false);

    const menuRef = useRef(null);

    const navigate = useNavigate();


    // Close dropdown when clicking outside
    useEffect(() => {

        function handleClickOutside(event) {

            if (
                menuRef.current &&
                !menuRef.current.contains(event.target)
            ) {
                setOpen(false);
            }

        }

        document.addEventListener(
            "mousedown",
            handleClickOutside
        );

        return () => {
            document.removeEventListener(
                "mousedown",
                handleClickOutside
            );
        };

    }, []);


    const handleLogout = async () => {

        try {

            // Use your actual logout API endpoint here
            const response = await fetch(
                "https://localhost:7135/api/auth/logout",
                {
                    method: "POST",
                    credentials: "include"
                }
            );

            if (!response.ok) {
                throw new Error("Logout failed");
            }

            setOpen(false);

            navigate("/login");

        } catch (error) {

            console.error(
                "Logout error:",
                error
            );

        }

    };


    return (

        <div
            className="user-menu-container"
            ref={menuRef}
        >

            {/* User Icon */}
            <button
                className="user-menu-button"
                onClick={() => setOpen(!open)}
                aria-label="User menu"
            >
                👤
            </button>


            {/* Dropdown */}
            {open && (

                <div className="user-dropdown">

                    <Link
                        to="/my-reviews"
                        className="user-dropdown-item"
                        onClick={() => setOpen(false)}
                    >
                        ⭐ My Reviews
                    </Link>


                    <Link
                        to="/wishlist"
                        className="user-dropdown-item"
                        onClick={() => setOpen(false)}
                    >
                        ❤️ My Wishlist
                    </Link>


                    <button
                        className="user-dropdown-item logout-item"
                        onClick={handleLogout}
                    >
                        🚪 Logout
                    </button>

                </div>

            )}

        </div>

    );
}