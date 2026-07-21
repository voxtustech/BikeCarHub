import SpecTable from "./SpecTable";

export default function BikeUnderpinnings({ underpinnings }) {

    if (!underpinnings) return null;

    return (

        <SpecTable

            id="underpinnings"

            title="Underpinnings"

            rows={[

                {
                    label: "Front Suspension",
                    value: underpinnings.suspensionFront
                },

                {
                    label: "Rear Suspension",
                    value: underpinnings.suspensionRear
                },

                {
                    label: "Front Brake",
                    value: underpinnings.brakesFront
                },

                {
                    label: "Rear Brake",
                    value: underpinnings.brakesRear
                },

                {
                    label: "Tyre Size",
                    value: underpinnings.tyreSize
                },

                {
                    label: "Wheel Size",
                    value: underpinnings.wheelSize
                },

                {
                    label: "Wheel Type",
                    value: underpinnings.wheelType
                },

                {
                    label: "Tubeless Tyre",
                    value: underpinnings.tubelessTyre
                }

            ]}

        />

    );

}