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
import { AskQuestionPage } from "./pages/AskQuestionPage";
import { PopularBrandsPage } from "./pages/PopularBrandsPage";
import { RegisterPage } from "./pages/RegisterPage";
import { ForgotPasswordPage } from "./pages/ForgotPasswordPage";
import { ResetPasswordPage } from "./pages/ResetPasswordPage";
import { TermsAndConditionsPage } from "./pages/TermsAndConditionsPage";
import { PrivacyPolicyPage } from "./pages/PrivacyPolicyPage";
import { DisclaimerPage } from "./pages/DisclaimerPage";
import { ContactUsPage } from "./pages/ContactUsPage";
import AboutUsPage from "./pages/AboutUsPage";
import WishlistPage from "./pages/WishlistPage";
import MyReviewsPage from "./pages/MyReviewsPage";

function App() {
    return (
        <div className="min-h-screen bg-white">

            <Header />

            <Routes>

                <Route path="/" element={<HomePage />} />

                <Route path="/blogs" element={<BlogsPage />} />

                <Route path="/moto-ai" element={<MotoAIPage />} />

                <Route path="/emi-calculator" element={<EMICalculatorPage />} />

                <Route path="/price-alerts" element={<div>Price Alerts Coming Soon</div>} />

        

                <Route path="/launch-tracker" element={<div>Launch Tracker Coming Soon</div>} />

                <Route path="/blogs/:slug" element={<BlogDetailsPage />} />

                <Route
                    path="/brands"
                    element={<PopularBrandsPage />}
                />

                <Route
                    path="/:brandName"
                    element={<BrandPage />}
                />

                <Route
                    path="/:brandName/:bikeName"
                    element={<BikeDetailsPage />}
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

                <Route path="/ask-question" element={<AskQuestionPage />} />

                <Route
                    path="/login"
                    element={<LoginPage />}
                />

                <Route
                    path="/register"
                    element={<RegisterPage />}
                />

                <Route
                    path="/forgot-password"
                    element={<ForgotPasswordPage />}
                />

                <Route
                    path="/reset-password"
                    element={<ResetPasswordPage />}
                />

                <Route
                    path="/terms-and-conditions"
                    element={<TermsAndConditionsPage />}
                />

                <Route
                    path="/privacy-policy"
                    element={<PrivacyPolicyPage />}
                />

                <Route
                    path="/disclaimer"
                    element={<DisclaimerPage />}
                />

                <Route
                    path="/contact-us"
                    element={<ContactUsPage />}
                />

                <Route
                    path="/about"
                    element={<AboutUsPage />}
                />

                <Route
                    path="/wishlist"
                    element={<WishlistPage />}
                />
                <Route
                    path="/my-reviews"
                    element={<MyReviewsPage />}
                />

            </Routes>

            

            <Footer />

        </div>
    );
}

export default App;