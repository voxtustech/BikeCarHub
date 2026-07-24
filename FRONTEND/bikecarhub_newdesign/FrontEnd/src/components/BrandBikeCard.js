import React from "react";
import { useNavigate } from "react-router-dom";
import { VehicleCard } from "./VehicleCard";
import { slugify } from "../utils/slugify";

export default function BrandBikeCard({ bike }) {

    const navigate = useNavigate();

    if (!bike) return null;
    console.log(bike);

    const vehicle = {
        id: bike.id,
        name: bike.name,
        brand: bike.brand,
        image: bike.image,
        price: bike.price,
        fuelType: bike.isEV ? "Electric" : "Petrol",

        // Optional values to keep VehicleCard happy
        rating: bike.rating ?? "4.5",
        reviews: bike.reviews ?? "0",
        tag: bike.tag ?? null,
        tagColor: bike.tagColor
    };
    console.log(bike);
    console.log("Image URL:", bike.image);
    return (

        <div
            onClick={() => navigate(
                `/${slugify(bike.brand)}/${slugify(bike.name)}`
            )}
            className="cursor-pointer"
        >

            <VehicleCard
                vehicle={vehicle}
                size="md"
            />

        </div>
    console.log("Image URL:", bike.image);
    );



}