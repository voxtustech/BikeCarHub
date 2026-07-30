import Hero from "../components/about/Hero";
import AboutSection from "../components/about/AboutSection";
import MissionSection from "../components/about/MissionSection";
import FeaturesSection from "../components/about/FeaturesSection";
import WhyChooseSection from "../components/about/WhyChooseSection";
import ContactForm from "../components/contact/ContactForm";

export default function AboutUsPage() {

    return (

        <main className="bg-slate-50">

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