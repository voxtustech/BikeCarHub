import Hero from "../components/about/Hero";
import AboutSection from "../components/about/AboutSection";
import MissionSection from "../components/about/MissionSection";
import FeaturesSection from "../components/about/FeaturesSection";
import WhyChooseSection from "../components/about/WhyChooseSection";
import ContactForm from "../components/contact/ContactForm";
import SEO from "../components/SEO/SEO";
export default function AboutUsPage() {

    return (

        <main className="bg-slate-50">
            <SEO
                title="Get the details about BikeCarHub"
                description="If you want to know about the BikeCarHub contact us."
                keywords="about bikecarhub, about bike,about new bikes,about bike comparison,about bikes prices"
                canonical="/"
            />

            <Hero />

            <AboutSection />

            <MissionSection />

            <FeaturesSection />

            <WhyChooseSection />

            <section className="py-24 bg-white">

                <div className="max-w-4xl mx-auto px-6">

                    <ContactForm
                        title="Get In Touch"
                        subtitle="Have questions, suggestions, or feedback? We'd love to hear from you. Fill out the form below and our team will get back to you as soon as possible."
                    />

                </div>

            </section>

        </main>

    );

}