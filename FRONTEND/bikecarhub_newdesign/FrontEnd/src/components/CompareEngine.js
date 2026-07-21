import CompareTable from "./CompareTable";

export default function CompareEngine({ comparison }) {
    if (!comparison) return null;

    const e1 = comparison.engine?.bike1;
    const e2 = comparison.engine?.bike2;

    const rows = [
        ["Engine Type", e1?.engineType, e2?.engineType],
        ["Displacement", e1?.displacement, e2?.displacement],
        ["Power", e1?.peakPower, e2?.peakPower],
        ["Torque", e1?.maxTorque, e2?.maxTorque],
        ["Gearbox", e1?.gearbox, e2?.gearbox],
        ["Cooling", e1?.coolingSystem, e2?.coolingSystem],
        ["Fuel Supply", e1?.fuelSupply, e2?.fuelSupply],
    ];

    return (
        <CompareTable
            title="Engine & Transmission"
            rows={rows}
        />
    );
}