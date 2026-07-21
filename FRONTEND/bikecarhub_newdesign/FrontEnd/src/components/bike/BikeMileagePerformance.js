import SpecTable from "./SpecTable";

export default function BikeMileagePerformance({ performance }) {

    if (!performance) return null;

    return (

        <SpecTable

            id="mileage"

            title="Mileage & Performance"

            rows={[

                {
                    label: "Overall Mileage",
                    value: performance.overallMileage
                        ? `${performance.overallMileage} kmpl`
                        : null
                },

                {
                    label: "City Mileage",
                    value: performance.cityMileage
                        ? `${performance.cityMileage} kmpl`
                        : null
                },

                {
                    label: "Highway Mileage",
                    value: performance.highwayMileage
                        ? `${performance.highwayMileage} kmpl`
                        : null
                }

            ]}

        />

    );

}