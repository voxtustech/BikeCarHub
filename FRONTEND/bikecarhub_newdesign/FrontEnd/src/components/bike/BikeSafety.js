import SpecTable from "./SpecTable";

export default function BikeSafety({
    safety
}) {

    if (!safety)
        return null;

    return (

        <SpecTable

            id="safety"

            title="Safety"

            rows={[

                {
                    label: "Pass Switch",
                    value: safety.passSwitch
                },

                {
                    label: "Engine Kill Switch",
                    value: safety.engineKillSwitch
                },

                {
                    label: "Display",
                    value: safety.display
                },

                {
                    label: "Riding Modes",
                    value: safety.ridingModes
                },

                {
                    label: "Traction Control",
                    value: safety.tractionControl
                },

                {
                    label: "Additional Features",
                    value: safety.additionalFeatures
                }

            ]}

        />

    );

}