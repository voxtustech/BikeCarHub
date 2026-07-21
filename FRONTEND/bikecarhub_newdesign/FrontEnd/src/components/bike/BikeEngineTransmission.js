import SpecTable from "./SpecTable";

export default function BikeEngineTransmission({
    engine
}) {

    if (!engine)
        return null;

    return (

        <SpecTable

            id="engine"

            title="Engine & Transmission"

            rows={[

                {
                    label: "Engine Type",
                    value: engine.engineType
                },

                {
                    label: "Displacement",
                    value: engine.displacement
                        ? `${engine.displacement} cc`
                        : null
                },

                {
                    label: "Max Torque",
                    value: engine.maxTorque
                },

                {
                    label: "No. of Cylinders",
                    value: engine.cylinders
                },

                {
                    label: "Cooling System",
                    value: engine.coolingSystem
                },

                {
                    label: "Valves Per Cylinder",
                    value: engine.valvesPerCylinder
                },

                {
                    label: "Starting",
                    value: engine.starting
                },

                {
                    label: "Fuel Supply",
                    value: engine.fuelSupply
                },

                {
                    label: "Clutch",
                    value: engine.clutch
                },

                {
                    label: "Gearbox",
                    value: engine.gearbox
                },

                {
                    label: "Compression Ratio",
                    value: engine.compressionRatio
                },

                {
                    label: "Ignition",
                    value: engine.ignition
                },

                {
                    label: "Emission Type",
                    value: engine.emissionType
                }

            ]}

        />

    );

}