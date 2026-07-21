import CompareTable from "./CompareTable";

export default function ComparePerformance({ comparison }) {
    if (!comparison) return null;

    const p1 = comparison.performance?.bike1;
    const p2 = comparison.performance?.bike2;

    const rows = [
        ["Mileage", p1?.overallMileage, p2?.overallMileage],
        ["City Mileage", p1?.cityMileage, p2?.cityMileage],
        ["Highway Mileage", p1?.highwayMileage, p2?.highwayMileage],
    ];

    return <CompareTable title="Performance" rows={rows} />;
}