import React from 'react';
import './index.css';
import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import { AuthProvider } from "./context/AuthContext";
import ScrollToTop from "./components/ScrollToTop";
import { HelmetProvider } from "react-helmet-async";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
    <HelmetProvider>
        <BrowserRouter>
            <ScrollToTop />
            <AuthProvider>
                <App />
            </AuthProvider>
        </BrowserRouter>
    </HelmetProvider>
);

