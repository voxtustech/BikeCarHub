import React from "react";
import { Routes, Route } from "react-router-dom";

import { Header } from "./components/Header";
import { Footer } from "./components/Footer";

import HomePage from "./pages/HomePage";
import { BlogsPage } from "./pages/BlogsPage";
import { ComparePage } from "./pages/ComparePage";
import { EMICalculatorPage } from "./pages/EMICalculatorPage";
import { LoginPage } from "./pages/LoginPage";
import { MotoAIPage } from "./pages/MotoAIPage";
import { PriceAlertsPage } from "./pages/PriceAlertsPage";
import { WishlistPage } from "./pages/WishlistPage";
import { LaunchTrackerPage } from "./pages/LaunchTrackerPage";
import BlogDetailsPage from "./pages/BlogDetailsPage";
import BikeDetailsPage from "./pages/BikeDetailsPage";
import BikeComparePage from "./pages/BikeComparePage";
import BrandPage from "./pages/BrandPage";
import ValueForMoneyDetails from "./pages/ValueForMoneyDetails";
import ValueForMoneyListing from "./pages/ValueForMoneyListing";
import UpcomingBikeListing from "./pages/UpcomingBikeListing";
import UpcomingBikeDetails from "./pages/UpcomingBikeDetails";
import LatestNewsListing from "./pages/LatestNewsListing";
import LatestNewsDetails from "./pages/LatestNewsDetails";

function App() {
    return (
        <div className="min-h-screen bg-white">

            <Header />

            <Routes>

                <Route path="/" element={<HomePage />} />

                <Route path="/blogs" element={<BlogsPage />} />

                <Route
                    path="/emi-calculator"
                    element={<EMICalculatorPage />}
                />

                <Route path="/login" element={<LoginPage />} />

                <Route path="/moto-ai" element={<MotoAIPage />} />

                <Route path="/emi-calculator" element={<EMICalculatorPage />} />

                <Route path="/price-alerts" element={<div>Price Alerts Coming Soon</div>} />

                <Route path="/wishlist" element={<div>Wishlist Coming Soon</div>} />

                <Route path="/launch-tracker" element={<div>Launch Tracker Coming Soon</div>} />

                <Route path="/blogs/:slug" element={<BlogDetailsPage />} />

                <Route
                    path="/bike/:id"
                    element={<BikeDetailsPage />}
                />

                <Route
                    path="/brand/:brandId"
                    element={<BrandPage />}
                />

                <Route
                    path="/compare"
                    element={<BikeComparePage />}
                />


                <Route

                    path="/value-for-money"

                    element={<ValueForMoneyListing />}

                />

                <Route

                    path="/value-for-money/:slug"

                    element={<ValueForMoneyDetails />}

                />

                <Route
                    path="/upcoming-bikes"
                    element={<UpcomingBikeListing />}
                />

                <Route
                    path="/upcoming-bike/:slug"
                    element={<UpcomingBikeDetails />}
                />

                <Route
                    path="/latest-news"
                    element={<LatestNewsListing />}
                />

                <Route
                    path="/latest-news/:slug"
                    element={<LatestNewsDetails />}
                />

            </Routes>

            

            <Footer />

        </div>
    );
}

export default App;