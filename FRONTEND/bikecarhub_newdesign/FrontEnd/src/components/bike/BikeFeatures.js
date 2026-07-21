import SpecTable from "./SpecTable";

export default function BikeFeatures({
    features
}) {

    if (!features)
        return null;

    return (

        <SpecTable

            id="features"

            title="Features"

            rows={[

                {
                    label: "ABS",
                    value: features.abs
                },

                {
                    label: "Speedometer",
                    value: features.speedometer
                },

                {
                    label: "Tripmeter",
                    value: features.tripmeter
                },

                {
                    label: "Tachometer",
                    value: features.tachometer
                },

                {
                    label: "Fuel Gauge",
                    value: features.fuelGauge
                },

                {
                    label: "Instrument Console",
                    value: features.instrumentConsole
                },

                {
                    label: "Seat Type",
                    value: features.seatType
                },

                {
                    label: "LED Tail Light",
                    value: features.ledTailLight
                },

                {
                    label: "Clock",
                    value: features.clock
                },

                {
                    label: "Passenger Footrest",
                    value: features.passengerFootrest
                },

                {
                    label: "Body Graphics",
                    value: features.bodyGraphics
                },

                {
                    label: "Additional Features",
                    value: features.additionalFeatures
                },

                {
                    label: "Distance To Empty",
                    value: features.distanceToEmpty
                },

                {
                    label: "Adjustable Windshield",
                    value: features.adjustableWindshield
                }

            ]}

        />

    );

}