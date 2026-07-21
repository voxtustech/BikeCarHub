import SpecTable from "./SpecTable";

export default function BikeCharging({ charging }) {

    if (!charging) return null;

    return (

        <SpecTable

            id="charging"

            title="Charging"

            rows={[

                {
                    label: "Charging At Home",
                    value: charging.chargingAtHome
                },

                {
                    label: "Charging Station",
                    value: charging.chargingAtChargingStation
                }

            ]}

        />

    );

}