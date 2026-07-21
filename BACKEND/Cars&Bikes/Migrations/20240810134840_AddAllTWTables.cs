using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTWTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsLetters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TWBrands",
                columns: table => new
                {
                    TWBrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPetrol = table.Column<bool>(type: "bit", nullable: true),
                    IsEV = table.Column<bool>(type: "bit", nullable: true),
                    BrandLogoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWBrands", x => x.TWBrandId);
                });

            migrationBuilder.CreateTable(
                name: "TWOrFWContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(60)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWOrFWContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TWLatestNews",
                columns: table => new
                {
                    TWLatestNewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsHeading = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NewsSummary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NewsDetail = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TwoWBrandId = table.Column<int>(type: "int", nullable: true),
                    BrandName = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWLatestNews", x => x.TWLatestNewsId);
                    table.ForeignKey(
                        name: "FK_TWLatestNews_TWBrands_TwoWBrandId",
                        column: x => x.TwoWBrandId,
                        principalTable: "TWBrands",
                        principalColumn: "TWBrandId");
                });

            migrationBuilder.CreateTable(
                name: "TwoWheelers",
                columns: table => new
                {
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TwoWheelerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasePrice = table.Column<int>(type: "int", nullable: true),
                    TopPrice = table.Column<int>(type: "int", nullable: true),
                    Brand = table.Column<string>(type: "varchar(30)", nullable: true),
                    Type = table.Column<string>(type: "varchar(30)", nullable: true),
                    TwoWBrandId = table.Column<int>(type: "int", nullable: false),
                    TWImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaunchDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEV = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    NotesOrComments = table.Column<string>(type: "varchar(100)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoWheelers", x => x.TwoWheelerId);
                    table.ForeignKey(
                        name: "FK_TwoWheelers_TWBrands_TwoWBrandId",
                        column: x => x.TwoWBrandId,
                        principalTable: "TWBrands",
                        principalColumn: "TWBrandId");
                });

            migrationBuilder.CreateTable(
                name: "TWUpcomingBikes",
                columns: table => new
                {
                    UpcomingBikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpcomingBikeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpcomingBikeDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedLaunchDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWBrandId = table.Column<int>(type: "int", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterLaunchDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWUpcomingBikes", x => x.UpcomingBikeId);
                    table.ForeignKey(
                        name: "FK_TWUpcomingBikes_TWBrands_TwoWBrandId",
                        column: x => x.TwoWBrandId,
                        principalTable: "TWBrands",
                        principalColumn: "TWBrandId");
                });

            migrationBuilder.CreateTable(
                name: "TWVarients",
                columns: table => new
                {
                    TWVarientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWVarients", x => x.TWVarientId);
                    table.ForeignKey(
                        name: "FK_TWVarients_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWChargings",
                columns: table => new
                {
                    TWChargingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargingAtHome = table.Column<string>(type: "varchar(5)", nullable: true),
                    ChargingAtChargingStation = table.Column<string>(type: "varchar(5)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWChargings", x => x.TWChargingId);
                    table.ForeignKey(
                        name: "FK_TWChargings_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWChargings_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWDimensionsAndCapacities",
                columns: table => new
                {
                    TWDimensionsAndCapacityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FuelCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GroundClearance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Wheelbase = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KerbWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FuelReserve = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaddleHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWDimensionsAndCapacities", x => x.TWDimensionsAndCapacityId);
                    table.ForeignKey(
                        name: "FK_TWDimensionsAndCapacities_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWDimensionsAndCapacities_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWElectricals",
                columns: table => new
                {
                    TWElectricalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headlight = table.Column<string>(type: "varchar(20)", nullable: true),
                    TailLight = table.Column<string>(type: "varchar(20)", nullable: true),
                    TurnSignalLamp = table.Column<string>(type: "varchar(20)", nullable: true),
                    LEDTailLights = table.Column<string>(type: "varchar(10)", nullable: true),
                    LowFuelIndicato = table.Column<string>(type: "varchar(10)", nullable: true),
                    PilotLamps = table.Column<string>(type: "varchar(10)", nullable: true),
                    DistanceToEmptyIndicator = table.Column<string>(type: "varchar(10)", nullable: true),
                    DRLs = table.Column<string>(type: "varchar(10)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWElectricals", x => x.TWElectricalsId);
                    table.ForeignKey(
                        name: "FK_TWElectricals_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWElectricals_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWEngineAndTransmissions",
                columns: table => new
                {
                    TWEngineAndTransmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Displacement = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxTorque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfCylinders = table.Column<int>(type: "int", nullable: true),
                    CoolingSystem = table.Column<string>(type: "varchar(30)", nullable: true),
                    ValvePerCylinder = table.Column<int>(type: "int", nullable: true),
                    Starting = table.Column<string>(type: "varchar(30)", nullable: true),
                    FuelSupply = table.Column<string>(type: "varchar(40)", nullable: true),
                    Clutch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GearBox = table.Column<string>(type: "varchar(10)", nullable: true),
                    EmissionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompressionRatio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ignition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEngineAndTransmissions", x => x.TWEngineAndTransmissionId);
                    table.ForeignKey(
                        name: "FK_TWEngineAndTransmissions_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWEngineAndTransmissions_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWFeatures",
                columns: table => new
                {
                    TWFeaturesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ABS = table.Column<string>(type: "varchar(50)", nullable: true),
                    Speedometer = table.Column<string>(type: "varchar(20)", nullable: true),
                    Tripmeter = table.Column<string>(type: "varchar(20)", nullable: true),
                    Tachometer = table.Column<string>(type: "varchar(20)", nullable: true),
                    LEDTailLight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odometer = table.Column<string>(type: "varchar(20)", nullable: true),
                    FuelGauge = table.Column<string>(type: "varchar(10)", nullable: true),
                    InstrumentConsole = table.Column<string>(type: "varchar(30)", nullable: true),
                    SeatType = table.Column<string>(type: "varchar(20)", nullable: true),
                    BodyGraphics = table.Column<string>(type: "varchar(20)", nullable: true),
                    Clock = table.Column<string>(type: "varchar(20)", nullable: true),
                    PassengerFootrest = table.Column<string>(type: "varchar(10)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    AdditionalFeaturesOfVariant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanceToEmptyIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdjustableWindshield = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWFeatures", x => x.TWFeaturesId);
                    table.ForeignKey(
                        name: "FK_TWFeatures_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWFeatures_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWImageColorPrices",
                columns: table => new
                {
                    TWImageColorPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWImageColorPrices", x => x.TWImageColorPriceId);
                    table.ForeignKey(
                        name: "FK_TWImageColorPrices_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWImageColorPrices_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWMileageAndPerformances",
                columns: table => new
                {
                    TWMileageAndPerformanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallMileage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CityMileage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HighwayMileage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWMileageAndPerformances", x => x.TWMileageAndPerformanceId);
                    table.ForeignKey(
                        name: "FK_TWMileageAndPerformances_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWMileageAndPerformances_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWMotorAndBatteries",
                columns: table => new
                {
                    TWMotorAndBatteryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeakPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveType = table.Column<string>(type: "varchar(20)", nullable: true),
                    Transmission = table.Column<string>(type: "varchar(20)", nullable: true),
                    BatteryCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWMotorAndBatteries", x => x.TWMotorAndBatteryId);
                    table.ForeignKey(
                        name: "FK_TWMotorAndBatteries_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWMotorAndBatteries_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWSafety",
                columns: table => new
                {
                    TWSafetyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassSwitch = table.Column<string>(type: "varchar(10)", nullable: true),
                    EngineKillSwitch = table.Column<string>(type: "varchar(10)", nullable: true),
                    Display = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    RidingModes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TractionControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWSafety", x => x.TWSafetyId);
                    table.ForeignKey(
                        name: "FK_TWSafety_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWSafety_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWSpec",
                columns: table => new
                {
                    TWSpecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Milage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FrontBrake = table.Column<string>(type: "varchar(10)", nullable: true),
                    RearBrake = table.Column<string>(type: "varchar(10)", nullable: true),
                    FuelCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWSpec", x => x.TWSpecId);
                    table.ForeignKey(
                        name: "FK_TWSpec_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWSpec_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWTyresAndBrakes",
                columns: table => new
                {
                    TWTyresAndBrakesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontBrakeDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RearBrakeDiameter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RadialTyre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontSuspension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RearSuspension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWTyresAndBrakes", x => x.TWTyresAndBrakesId);
                    table.ForeignKey(
                        name: "FK_TWTyresAndBrakes_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWTyresAndBrakes_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWUnderpinnings",
                columns: table => new
                {
                    TWUnderpinningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspensionFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspensionRear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrakesFront = table.Column<string>(type: "varchar(10)", nullable: true),
                    BrakesRear = table.Column<string>(type: "varchar(10)", nullable: true),
                    TyreSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WheelSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WheelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubelessTyre = table.Column<string>(type: "varchar(10)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWUnderpinnings", x => x.TWUnderpinningId);
                    table.ForeignKey(
                        name: "FK_TWUnderpinnings_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TWUnderpinnings_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TWChargings_TwoWheelerId",
                table: "TWChargings",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWChargings_TWVarientId",
                table: "TWChargings",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWDimensionsAndCapacities_TwoWheelerId",
                table: "TWDimensionsAndCapacities",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWDimensionsAndCapacities_TWVarientId",
                table: "TWDimensionsAndCapacities",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWElectricals_TwoWheelerId",
                table: "TWElectricals",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWElectricals_TWVarientId",
                table: "TWElectricals",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEngineAndTransmissions_TwoWheelerId",
                table: "TWEngineAndTransmissions",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWEngineAndTransmissions_TWVarientId",
                table: "TWEngineAndTransmissions",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWFeatures_TwoWheelerId",
                table: "TWFeatures",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWFeatures_TWVarientId",
                table: "TWFeatures",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWImageColorPrices_TwoWheelerId",
                table: "TWImageColorPrices",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWImageColorPrices_TWVarientId",
                table: "TWImageColorPrices",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWLatestNews_TwoWBrandId",
                table: "TWLatestNews",
                column: "TwoWBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TWMileageAndPerformances_TwoWheelerId",
                table: "TWMileageAndPerformances",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWMileageAndPerformances_TWVarientId",
                table: "TWMileageAndPerformances",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWMotorAndBatteries_TwoWheelerId",
                table: "TWMotorAndBatteries",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWMotorAndBatteries_TWVarientId",
                table: "TWMotorAndBatteries",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TwoWheelers_TwoWBrandId",
                table: "TwoWheelers",
                column: "TwoWBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TWSafety_TwoWheelerId",
                table: "TWSafety",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWSafety_TWVarientId",
                table: "TWSafety",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWSpec_TwoWheelerId",
                table: "TWSpec",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWSpec_TWVarientId",
                table: "TWSpec",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWTyresAndBrakes_TwoWheelerId",
                table: "TWTyresAndBrakes",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWTyresAndBrakes_TWVarientId",
                table: "TWTyresAndBrakes",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWUnderpinnings_TwoWheelerId",
                table: "TWUnderpinnings",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWUnderpinnings_TWVarientId",
                table: "TWUnderpinnings",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWUpcomingBikes_TwoWBrandId",
                table: "TWUpcomingBikes",
                column: "TwoWBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TWVarients_TwoWheelerId",
                table: "TWVarients",
                column: "TwoWheelerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.DropTable(
                name: "TWChargings");

            migrationBuilder.DropTable(
                name: "TWDimensionsAndCapacities");

            migrationBuilder.DropTable(
                name: "TWElectricals");

            migrationBuilder.DropTable(
                name: "TWEngineAndTransmissions");

            migrationBuilder.DropTable(
                name: "TWFeatures");

            migrationBuilder.DropTable(
                name: "TWImageColorPrices");

            migrationBuilder.DropTable(
                name: "TWLatestNews");

            migrationBuilder.DropTable(
                name: "TWMileageAndPerformances");

            migrationBuilder.DropTable(
                name: "TWMotorAndBatteries");

            migrationBuilder.DropTable(
                name: "TWOrFWContactUs");

            migrationBuilder.DropTable(
                name: "TWSafety");

            migrationBuilder.DropTable(
                name: "TWSpec");

            migrationBuilder.DropTable(
                name: "TWTyresAndBrakes");

            migrationBuilder.DropTable(
                name: "TWUnderpinnings");

            migrationBuilder.DropTable(
                name: "TWUpcomingBikes");

            migrationBuilder.DropTable(
                name: "TWVarients");

            migrationBuilder.DropTable(
                name: "TwoWheelers");

            migrationBuilder.DropTable(
                name: "TWBrands");
        }
    }
}
