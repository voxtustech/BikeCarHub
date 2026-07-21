import CompareTable from "./CompareTable";

export default function CompareSafety({ comparison }) {
    if (!comparison) return null;

    const s1 = comparison.safety?.bike1;
    const s2 = comparison.safety?.bike2;

    const rows = [
        ["Pass Switch", s1?.passSwitch, s2?.passSwitch],
        ["Engine Kill Switch", s1?.engineKillSwitch, s2?.engineKillSwitch],
        ["Display", s1?.display, s2?.display],
        ["Traction Control", s1?.tractionControl, s2?.tractionControl],
        ["Riding Modes", s1?.ridingModes, s2?.ridingModes],
    ];

    return <CompareTable title="Safety" rows={rows} />;
}