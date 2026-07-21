import CompareTable from "./CompareTable";

export default function CompareTyres({ comparison }) {
    if (!comparison?.tyres) return null;

    const { bike1, bike2 } = comparison.tyres;

    const rows = [
        ["Front Brake", bike1.frontBrake, bike2.frontBrake],
        ["Rear Brake", bike1.rearBrake, bike2.rearBrake],
        ["Front Tyre", bike1.frontTyre, bike2.frontTyre],
        ["Rear Tyre", bike1.rearTyre, bike2.rearTyre],
        ["Wheel Type", bike1.wheelType, bike2.wheelType],
        ["Tubeless Tyres", bike1.tubelessTyres, bike2.tubelessTyres],
    ];

    return <CompareTable title="Tyres & Brakes" rows={rows} />;
}