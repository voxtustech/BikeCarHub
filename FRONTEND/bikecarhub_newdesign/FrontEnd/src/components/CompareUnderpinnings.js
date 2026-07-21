import CompareTable from "./CompareTable";

export default function CompareUnderpinnings({ comparison }) {
    if (!comparison?.underpinnings) return null;

    const { bike1, bike2 } = comparison.underpinnings;

    const rows = [
        ["Frame", bike1.frame, bike2.frame],
        ["Front Suspension", bike1.frontSuspension, bike2.frontSuspension],
        ["Rear Suspension", bike1.rearSuspension, bike2.rearSuspension],
    ];

    return <CompareTable title="Underpinnings" rows={rows} />;
}