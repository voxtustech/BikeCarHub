import SpecTable from "./SpecTable";

export default function BikeDimensions({ dimensions }) {

    if (!dimensions) return null;

    return (

        <SpecTable

            id="dimensions"

            title="Dimensions & Capacity"

            rows={[

                {
                    label: "Width",
                    value: dimensions.width
                        ? `${dimensions.width} mm`
                        : null
                },

                {
                    label: "Length",
                    value: dimensions.length
                        ? `${dimensions.length} mm`
                        : null
                },

                {
                    label: "Height",
                    value: dimensions.height
                        ? `${dimensions.height} mm`
                        : null
                },

                {
                    label: "Fuel Capacity",
                    value: dimensions.fuelCapacity
                        ? `${dimensions.fuelCapacity} L`
                        : null
                },

                {
                    label: "Ground Clearance",
                    value: dimensions.groundClearance
                        ? `${dimensions.groundClearance} mm`
                        : null
                },

                {
                    label: "Wheelbase",
                    value: dimensions.wheelbase
                        ? `${dimensions.wheelbase} mm`
                        : null
                },

                {
                    label: "Kerb Weight",
                    value: dimensions.kerbWeight
                        ? `${dimensions.kerbWeight} kg`
                        : null
                },

                {
                    label: "Fuel Reserve",
                    value: dimensions.fuelReserve
                },

                {
                    label: "Saddle Height",
                    value: dimensions.saddleHeight
                        ? `${dimensions.saddleHeight} mm`
                        : null
                }

            ]}

        />

    );

}