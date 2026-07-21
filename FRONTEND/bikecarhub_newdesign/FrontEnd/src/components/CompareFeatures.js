import CompareTable from "./CompareTable";

export default function CompareFeatures({ comparison }) {
    if (!comparison) return null;

    const f1 = comparison.features?.bike1;
    const f2 = comparison.features?.bike2;

    const rows = [
        ["ABS", f1?.abs, f2?.abs],
        ["Speedometer", f1?.speedometer, f2?.speedometer],
        ["Trip Meter", f1?.tripmeter, f2?.tripmeter],
        ["Tachometer", f1?.tachometer, f2?.tachometer],
        ["Instrument Console", f1?.instrumentConsole, f2?.instrumentConsole],
        ["Fuel Gauge", f1?.fuelGauge, f2?.fuelGauge],
        ["Seat Type", f1?.seatType, f2?.seatType],
        ["Clock", f1?.clock, f2?.clock],
        ["Body Graphics", f1?.bodyGraphics, f2?.bodyGraphics],
    ];

    return <CompareTable title="Features" rows={rows} />;
}