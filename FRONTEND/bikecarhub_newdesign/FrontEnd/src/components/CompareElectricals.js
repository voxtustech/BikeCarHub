import CompareTable from "./CompareTable";

export default function CompareElectricals({ comparison }) {
    if (!comparison?.electricals) return null;

    const { bike1, bike2 } = comparison.electricals;

    const rows = [
        ["Headlight", bike1.headlight, bike2.headlight],
        ["Tail Light", bike1.tailLight, bike2.tailLight],
        ["Turn Signal Lamp", bike1.turnSignalLamp, bike2.turnSignalLamp],
        ["DRLs", bike1.drls, bike2.drls],
        ["Low Battery Indicator", bike1.lowBatteryIndicator, bike2.lowBatteryIndicator],
    ];

    return <CompareTable title="Electricals" rows={rows} />;
}