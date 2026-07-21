import CompareTable from "./CompareTable";

export default function CompareDimensions({ comparison }) {
    if (!comparison) return null;

    const d1 = comparison.dimensions?.bike1;
    const d2 = comparison.dimensions?.bike2;

    const rows = [
        ["Length", d1?.length, d2?.length],
        ["Width", d1?.width, d2?.width],
        ["Height", d1?.height, d2?.height],
        ["Wheelbase", d1?.wheelbase, d2?.wheelbase],
        ["Ground Clearance", d1?.groundClearance, d2?.groundClearance],
        ["Kerb Weight", d1?.kerbWeight, d2?.kerbWeight],
        ["Fuel Capacity", d1?.fuelCapacity, d2?.fuelCapacity],
        ["Saddle Height", d1?.saddleHeight, d2?.saddleHeight],
    ];

    return <CompareTable title="Dimensions" rows={rows} />;
}