import React from "react";
import { useParams } from "react-router-dom";

import ArticleLayout from "../components/valueForMoney/ArticleLayout";

import { BlogsSection } from "../components/BlogsSection";
import { LatestNewsSection } from "../components/LatestNewsSection";
import { CompareBikesSection } from "../components/CompareBikesSection";
import { EcosystemSection } from "../components/EcosystemSection";
import { AdPlaceholder } from "../components/AdPlaceholder";

import tataPunch from "../data/valueForMoney/tataPunch";
import AltoK10 from "../data/valueForMoney/AltoK10";
import TataTiago from "../data/valueForMoney/TataTiago";
import TataAltrozFacelift from "../data/valueForMoney/TataAltrozFacelift";
import MarutiSuzukiWagonR2025 from "../data/valueForMoney/MarutiSuzukiWagonR2025";
import SkodaKylaq from "../data/valueForMoney/SkodaKylaq";
import MarutiSuzukiSwift2025 from "../data/valueForMoney/MarutiSuzukiSwift2025";
import MarutiSuzukiSPresso from "../data/valueForMoney/MarutiSuzukiSPresso";
import MarutiSuzukiNexaIgnis from "../data/valueForMoney/MarutiSuzukiNexaIgnis";
import MarutiSuzukiErtigaZXIO from "../data/valueForMoney/MarutiSuzukiErtigaZXIO";
import MarutiSuzukiDzire2025 from "../data/valueForMoney/MarutiSuzukiDzire2025";
import MarutiSuzukiCelerio from "../data/valueForMoney/MarutiSuzukiCelerio";
import MarutiSuzukiBrezza from "../data/valueForMoney/MarutiSuzukiBrezza";
import KiaSyros from "../data/valueForMoney/KiaSyros";

const articles = {

    tatapunch: tataPunch,

    altok10: AltoK10,

    tatatiago: TataTiago,

    tataaltrozfacelift: TataAltrozFacelift,

    marutisuzukiwagonr2025: MarutiSuzukiWagonR2025,

    skodakylaq: SkodaKylaq,

    marutisuzukiswift2025: MarutiSuzukiSwift2025,

    marutisuzukispresso: MarutiSuzukiSPresso,

    marutisuzukinexaignis: MarutiSuzukiNexaIgnis,

    marutisuzukiertigazxio: MarutiSuzukiErtigaZXIO,

    marutisuzukidzire2025: MarutiSuzukiDzire2025,

    marutisuzukicelerio: MarutiSuzukiCelerio,

    marutisuzukibrezza: MarutiSuzukiBrezza,

    kiasyros: KiaSyros

};

export default function ValueForMoneyDetails() {

    const { slug } = useParams();

    const article = articles[slug];

    if (!article) {

        return (

            <div className="max-w-7xl mx-auto px-6 py-20">

                <div className="bg-red-50 border border-red-200 rounded-2xl p-8 text-center">

                    <h2 className="text-3xl font-bold text-slate-900">

                        Article Not Found

                    </h2>

                    <p className="mt-3 text-slate-600">

                        The Value For Money article you are looking for does not exist.

                    </p>

                </div>

            </div>

        );

    }

    return (

        <main className="bg-slate-50 min-h-screen">

            <ArticleLayout article={article} />

            <div className="max-w-7xl mx-auto px-6 py-4">

                <AdPlaceholder

                    label="Advertisement"

                    height="h-20"

                />

            </div>

            <BlogsSection />

            <LatestNewsSection />

            <CompareBikesSection />

            <EcosystemSection />

        </main>

    );

}