import SpecTable from "./SpecTable";

export default function BikeMotorBattery({ motorBattery }) {

    if (!motorBattery) return null;

    return (

        <SpecTable

            id="motor"

            title="Motor & Battery"

            rows={[

                {
                    label: "Peak Power",
                    value: motorBattery.peakPower
                },

                {
                    label: "Drive Type",
                    value: motorBattery.driveType
                },

                {
                    label: "Transmission",
                    value: motorBattery.transmission
                },

                {
                    label: "Battery Capacity",
                    value: motorBattery.batteryCapacity
                }

            ]}

        />

    );

}