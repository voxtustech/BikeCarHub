using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddEVTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TWEVAppFeatures",
                columns: table => new
                {
                    TWEVAppFeaturesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargingStationLocate = table.Column<string>(type: "varchar(20)", nullable: true),
                    Geofencing = table.Column<string>(type: "varchar(20)", nullable: true),
                    AntiTheftAlarm = table.Column<string>(type: "varchar(20)", nullable: true),
                    CallsAndMessaging = table.Column<string>(type: "varchar(20)", nullable: true),
                    NavigationAssis = table.Column<string>(type: "varchar(20)", nullable: true),
                    LowBatteryAlert = table.Column<string>(type: "varchar(20)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVAppFeatures", x => x.TWEVAppFeaturesId);
                    table.ForeignKey(
                        name: "FK_TWEVAppFeatures_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVAppFeatures_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVChargings",
                columns: table => new
                {
                    TWEVChargingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargingAtHome = table.Column<string>(type: "varchar(30)", nullable: true),
                    ChargingAtChargingStation = table.Column<string>(type: "varchar(30)", nullable: true),
                    ChargingTimeZeroTo80Percent = table.Column<string>(type: "varchar(30)", nullable: true),
                    ChargingTimeZeroTo100Percent = table.Column<string>(type: "varchar(30)", nullable: true),
                    ChargingNetworkBatterySwappingNetwork = table.Column<string>(type: "varchar(20)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVChargings", x => x.TWEVChargingId);
                    table.ForeignKey(
                        name: "FK_TWEVChargings_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVChargings_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVChassisAndSuspensions",
                columns: table => new
                {
                    TWEVChassisAndSuspensionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVChassisAndSuspensions", x => x.TWEVChassisAndSuspensionId);
                    table.ForeignKey(
                        name: "FK_TWEVChassisAndSuspensions_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVChassisAndSuspensions_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVDimensionsAndCapacities",
                columns: table => new
                {
                    TWEVDimensionsAndCapacityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaddleHeight = table.Column<string>(type: "varchar(20)", nullable: true),
                    GroundClearance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Wheelbase = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KerbWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdditionalStorage = table.Column<string>(type: "varchar(20)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVDimensionsAndCapacities", x => x.TWEVDimensionsAndCapacityId);
                    table.ForeignKey(
                        name: "FK_TWEVDimensionsAndCapacities_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVDimensionsAndCapacities_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVElectricals",
                columns: table => new
                {
                    TWEVElectricalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headlight = table.Column<string>(type: "varchar(30)", nullable: true),
                    TailLight = table.Column<string>(type: "varchar(30)", nullable: true),
                    TurnSignalLamp = table.Column<string>(type: "varchar(30)", nullable: true),
                    LEDTailLights = table.Column<string>(type: "varchar(30)", nullable: true),
                    LowBatteryIndicator = table.Column<string>(type: "varchar(30)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVElectricals", x => x.TWEVElectricalsId);
                    table.ForeignKey(
                        name: "FK_TWEVElectricals_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVElectricals_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVEngineAndTransmissions",
                columns: table => new
                {
                    TWEVEngineAndTransmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EVName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfBattries = table.Column<int>(type: "int", nullable: true),
                    CoolingSystem = table.Column<string>(type: "varchar(30)", nullable: true),
                    MotorPower = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RangeEcoMode = table.Column<string>(type: "varchar(30)", nullable: true),
                    RangeNormalMode = table.Column<string>(type: "varchar(30)", nullable: true),
                    RangeSportsMode = table.Column<string>(type: "varchar(30)", nullable: true),
                    Starting = table.Column<string>(type: "varchar(50)", nullable: true),
                    MotorIPRating = table.Column<string>(type: "varchar(30)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVEngineAndTransmissions", x => x.TWEVEngineAndTransmissionId);
                    table.ForeignKey(
                        name: "FK_TWEVEngineAndTransmissions_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVEngineAndTransmissions_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVFeatures",
                columns: table => new
                {
                    TWEVFeaturesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EVName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrumentConsole = table.Column<string>(type: "varchar(30)", nullable: true),
                    BluetoothConnectivity = table.Column<string>(type: "varchar(60)", nullable: true),
                    Navigation = table.Column<string>(type: "varchar(30)", nullable: true),
                    CallSMSAlerts = table.Column<string>(type: "varchar(30)", nullable: true),
                    RoadsideAssistance = table.Column<string>(type: "varchar(30)", nullable: true),
                    AntiTheftAlarm = table.Column<string>(type: "varchar(30)", nullable: true),
                    USBChargingPort = table.Column<string>(type: "varchar(30)", nullable: true),
                    MusicControl = table.Column<string>(type: "varchar(30)", nullable: true),
                    OTA = table.Column<string>(type: "varchar(30)", nullable: true),
                    Speedometer = table.Column<string>(type: "varchar(20)", nullable: true),
                    Tripmeter = table.Column<string>(type: "varchar(20)", nullable: true),
                    Odometer = table.Column<string>(type: "varchar(20)", nullable: true),
                    AdditionalFeaturesOfVariant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatType = table.Column<string>(type: "varchar(20)", nullable: true),
                    Clock = table.Column<string>(type: "varchar(20)", nullable: true),
                    PassengerFootrest = table.Column<string>(type: "varchar(10)", nullable: true),
                    CarryHook = table.Column<string>(type: "varchar(10)", nullable: true),
                    UnderseatStorage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChargerOutput = table.Column<string>(type: "varchar(30)", nullable: true),
                    RegenerativeBraking = table.Column<string>(type: "varchar(10)", nullable: true),
                    HillHold = table.Column<string>(type: "varchar(10)", nullable: true),
                    KeylessIgnition = table.Column<string>(type: "varchar(10)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVFeatures", x => x.TWEVFeaturesId);
                    table.ForeignKey(
                        name: "FK_TWEVFeatures_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVFeatures_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVMotorAndBatteries",
                columns: table => new
                {
                    TWEVMotorAndBatteryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotorType = table.Column<string>(type: "varchar(50)", nullable: true),
                    TorqueMotor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PeakPower = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BatteryType = table.Column<string>(type: "varchar(20)", nullable: true),
                    BatteryCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BatteryWarranty = table.Column<string>(type: "varchar(50)", nullable: true),
                    WaterProofRating = table.Column<string>(type: "varchar(80)", nullable: true),
                    ReverseAssist = table.Column<string>(type: "varchar(20)", nullable: true),
                    Transmission = table.Column<string>(type: "varchar(20)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVMotorAndBatteries", x => x.TWEVMotorAndBatteryId);
                    table.ForeignKey(
                        name: "FK_TWEVMotorAndBatteries_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVMotorAndBatteries_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVPerformances",
                columns: table => new
                {
                    TWEVPerformanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScooterSpeed = table.Column<string>(type: "varchar(20)", nullable: true),
                    ZeroTo40Kmphsec = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TopSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ZeroTo100Kmphsec = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVPerformances", x => x.TWEVPerformanceId);
                    table.ForeignKey(
                        name: "FK_TWEVPerformances_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVPerformances_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVRanges",
                columns: table => new
                {
                    TWEVRangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimedRange = table.Column<string>(type: "varchar(30)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVRanges", x => x.TWEVRangeId);
                    table.ForeignKey(
                        name: "FK_TWEVRanges_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVRanges_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVSafety",
                columns: table => new
                {
                    TWEVSafetyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrakingType = table.Column<string>(type: "varchar(50)", nullable: true),
                    ChargingPoint = table.Column<string>(type: "varchar(10)", nullable: true),
                    FastCharging = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileApplication = table.Column<string>(type: "varchar(10)", nullable: true),
                    InternetConnectivity = table.Column<string>(type: "varchar(10)", nullable: true),
                    OperatingSystem = table.Column<string>(type: "varchar(30)", nullable: true),
                    Processor = table.Column<string>(type: "varchar(30)", nullable: true),
                    Gradeability = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceDueIndicator = table.Column<string>(type: "varchar(10)", nullable: true),
                    RidingModes = table.Column<string>(type: "varchar(10)", nullable: true),
                    Display = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwitchableABS = table.Column<string>(type: "varchar(10)", nullable: true),
                    EBS = table.Column<string>(type: "varchar(10)", nullable: true),
                    SeatOpeningSwitch = table.Column<string>(type: "varchar(10)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVSafety", x => x.TWEVSafetyId);
                    table.ForeignKey(
                        name: "FK_TWEVSafety_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVSafety_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVTyresAndBrakes",
                columns: table => new
                {
                    TWEVTyresAndBrakesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontBrakeDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RearBrakeDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FrontTyrePressureRider = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FrontTyrePressureRiderAndPillion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RearTyrePressureRider = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RearTyrePressureRiderAndPillion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVTyresAndBrakes", x => x.TWEVTyresAndBrakesId);
                    table.ForeignKey(
                        name: "FK_TWEVTyresAndBrakes_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVTyresAndBrakes_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TWEVUnderpinnings",
                columns: table => new
                {
                    TWEVUnderpinningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspensionFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspensionRear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrakesFront = table.Column<string>(type: "varchar(20)", nullable: true),
                    BrakesRear = table.Column<string>(type: "varchar(20)", nullable: true),
                    ABS = table.Column<string>(type: "varchar(50)", nullable: true),
                    TyreSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WheelSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WheelType = table.Column<string>(type: "varchar(50)", nullable: true),
                    Frame = table.Column<string>(type: "varchar(100)", nullable: true),
                    TubelessTyre = table.Column<string>(type: "varchar(20)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVUnderpinnings", x => x.TWEVUnderpinningId);
                    table.ForeignKey(
                        name: "FK_TWEVUnderpinnings_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWEVUnderpinnings_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TWEVAppFeatures_TwoWheelerId",
                table: "TWEVAppFeatures",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVAppFeatures_TWVarientId",
                table: "TWEVAppFeatures",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVChargings_TwoWheelerId",
                table: "TWEVChargings",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVChargings_TWVarientId",
                table: "TWEVChargings",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVChassisAndSuspensions_TwoWheelerId",
                table: "TWEVChassisAndSuspensions",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVChassisAndSuspensions_TWVarientId",
                table: "TWEVChassisAndSuspensions",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVDimensionsAndCapacities_TwoWheelerId",
                table: "TWEVDimensionsAndCapacities",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVDimensionsAndCapacities_TWVarientId",
                table: "TWEVDimensionsAndCapacities",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVElectricals_TwoWheelerId",
                table: "TWEVElectricals",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVElectricals_TWVarientId",
                table: "TWEVElectricals",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVEngineAndTransmissions_TwoWheelerId",
                table: "TWEVEngineAndTransmissions",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVEngineAndTransmissions_TWVarientId",
                table: "TWEVEngineAndTransmissions",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVFeatures_TwoWheelerId",
                table: "TWEVFeatures",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVFeatures_TWVarientId",
                table: "TWEVFeatures",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVMotorAndBatteries_TwoWheelerId",
                table: "TWEVMotorAndBatteries",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVMotorAndBatteries_TWVarientId",
                table: "TWEVMotorAndBatteries",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVPerformances_TwoWheelerId",
                table: "TWEVPerformances",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVPerformances_TWVarientId",
                table: "TWEVPerformances",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVRanges_TwoWheelerId",
                table: "TWEVRanges",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVRanges_TWVarientId",
                table: "TWEVRanges",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVSafety_TwoWheelerId",
                table: "TWEVSafety",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVSafety_TWVarientId",
                table: "TWEVSafety",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVTyresAndBrakes_TwoWheelerId",
                table: "TWEVTyresAndBrakes",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVTyresAndBrakes_TWVarientId",
                table: "TWEVTyresAndBrakes",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVUnderpinnings_TwoWheelerId",
                table: "TWEVUnderpinnings",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEVUnderpinnings_TWVarientId",
                table: "TWEVUnderpinnings",
                column: "TWVarientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TWEVAppFeatures");

            migrationBuilder.DropTable(
                name: "TWEVChargings");

            migrationBuilder.DropTable(
                name: "TWEVChassisAndSuspensions");

            migrationBuilder.DropTable(
                name: "TWEVDimensionsAndCapacities");

            migrationBuilder.DropTable(
                name: "TWEVElectricals");

            migrationBuilder.DropTable(
                name: "TWEVEngineAndTransmissions");

            migrationBuilder.DropTable(
                name: "TWEVFeatures");

            migrationBuilder.DropTable(
                name: "TWEVMotorAndBatteries");

            migrationBuilder.DropTable(
                name: "TWEVPerformances");

            migrationBuilder.DropTable(
                name: "TWEVRanges");

            migrationBuilder.DropTable(
                name: "TWEVSafety");

            migrationBuilder.DropTable(
                name: "TWEVTyresAndBrakes");

            migrationBuilder.DropTable(
                name: "TWEVUnderpinnings");
        }
    }
}
