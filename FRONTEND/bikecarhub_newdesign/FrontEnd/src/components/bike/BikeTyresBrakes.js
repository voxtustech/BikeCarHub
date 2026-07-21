import SpecTable from "./SpecTable";

export default function BikeTyresBrakes({ tyres }) {

    if (!tyres) return null;

    return (

        <SpecTable

            id="tyres"

            title="Tyres & Brakes"

            rows={[

                {
                    label: "Front Brake Diameter",
                    value: tyres.frontBrakeDiameter
                        ? `${tyres.frontBrakeDiameter} mm`
                        : null
                },

                {
                    label: "Rear Brake Diameter",
                    value: tyres.rearBrakeDiameter
                        ? `${tyres.rearBrakeDiameter} mm`
                        : null
                },

                {
                    label: "Radial Tyre",
                    value: tyres.radialTyre
                },

                {
                    label: "Front Suspension",
                    value: tyres.frontSuspension
                },

                {
                    label: "Rear Suspension",
                    value: tyres.rearSuspension
                }

            ]}

        />

    );

}