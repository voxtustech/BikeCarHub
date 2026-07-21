import SpecTable from "./SpecTable";

export default function BikeElectricals({ electricals }) {

    if (!electricals) return null;

    return (

        <SpecTable

            id="electricals"

            title="Electricals"

            rows={[

                {
                    label: "Headlight",
                    value: electricals.headlight
                },

                {
                    label: "Tail Light",
                    value: electricals.tailLight
                },

                {
                    label: "Turn Signal Lamp",
                    value: electricals.turnSignalLamp
                },

                {
                    label: "LED Tail Lights",
                    value: electricals.ledTailLights
                },

                {
                    label: "Low Fuel Indicator",
                    value: electricals.lowFuelIndicator
                },

                {
                    label: "Pilot Lamps",
                    value: electricals.pilotLamps
                },

                {
                    label: "Distance To Empty Indicator",
                    value: electricals.distanceToEmptyIndicator
                },

                {
                    label: "DRLs",
                    value: electricals.drls
                }

            ]}

        />

    );

}