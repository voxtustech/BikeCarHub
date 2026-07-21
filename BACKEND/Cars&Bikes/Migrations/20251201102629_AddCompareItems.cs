using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars_Bikes.Migrations
{
    /// <inheritdoc />
    public partial class AddCompareItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Blogs",
            //    columns: table => new
            //    {
            //        BlogId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BlogHeading = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        BlogSummary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
            //        BlogDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IsTwoWheeler = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Blogs", x => x.BlogId);
            //    });

            migrationBuilder.CreateTable(
                name: "CompareItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompareUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompareItems", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "LoginModel",
            //    columns: table => new
            //    {
            //        LoginId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LoginModel", x => x.LoginId);
            //    });

           /* migrationBuilder.CreateTable(
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
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTWBrand = table.Column<bool>(type: "bit", nullable: true),
                    IsFWBrand = table.Column<bool>(type: "bit", nullable: true),
                    TitleTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "ValueForMoney",
                columns: table => new
                {
                    VFMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VFMHeading = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsTwoWheeler = table.Column<bool>(type: "bit", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueForMoney", x => x.VFMId);
                });

            migrationBuilder.CreateTable(
                name: "LatestNews",
                columns: table => new
                {
                    TWLatestNewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsHeading = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NewsSummary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NewsDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TwoWBrandId = table.Column<int>(type: "int", nullable: true),
                    BrandName = table.Column<string>(type: "varchar(30)", nullable: true),
                    ImageFolderURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTwoWheeler = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatestNews", x => x.TWLatestNewsId);
                    table.ForeignKey(
                        name: "FK_LatestNews_TWBrands_TwoWBrandId",
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
                    TwoWBrandId = table.Column<int>(type: "int", nullable: true),
                    TWImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaunchDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEV = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    NotesOrComments = table.Column<string>(type: "varchar(100)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageFolderURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWVarients", x => x.TWVarientId);
                    table.ForeignKey(
                        name: "FK_TWVarients_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
                });

            migrationBuilder.CreateTable(
                name: "TWChargings",
                columns: table => new
                {
                    TWChargingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargingAtHome = table.Column<string>(type: "varchar(30)", nullable: true),
                    ChargingAtChargingStation = table.Column<string>(type: "varchar(30)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWChargings", x => x.TWChargingId);
                    table.ForeignKey(
                        name: "FK_TWChargings_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWChargings_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
                });

            migrationBuilder.CreateTable(
                name: "TWChassisAndSuspensions",
                columns: table => new
                {
                    TWChassisAndSuspensionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyGraphics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: false),
                    TWVarientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWChassisAndSuspensions", x => x.TWChassisAndSuspensionId);
                    table.ForeignKey(
                        name: "FK_TWChassisAndSuspensions_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TWChassisAndSuspensions_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId",
                        onDelete: ReferentialAction.Cascade);
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWDimensionsAndCapacities", x => x.TWDimensionsAndCapacityId);
                    table.ForeignKey(
                        name: "FK_TWDimensionsAndCapacities_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWDimensionsAndCapacities_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
                });

            migrationBuilder.CreateTable(
                name: "TWElectricals",
                columns: table => new
                {
                    TWElectricalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TWName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headlight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TailLight = table.Column<string>(type: "varchar(50)", nullable: true),
                    TurnSignalLamp = table.Column<string>(type: "varchar(50)", nullable: true),
                    LEDTailLights = table.Column<string>(type: "varchar(50)", nullable: true),
                    LowFuelIndicato = table.Column<string>(type: "varchar(50)", nullable: true),
                    PilotLamps = table.Column<string>(type: "varchar(50)", nullable: true),
                    DistanceToEmptyIndicator = table.Column<string>(type: "varchar(50)", nullable: true),
                    DRLs = table.Column<string>(type: "varchar(50)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWElectricals", x => x.TWElectricalsId);
                    table.ForeignKey(
                        name: "FK_TWElectricals_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWElectricals_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEngineAndTransmissions", x => x.TWEngineAndTransmissionId);
                    table.ForeignKey(
                        name: "FK_TWEngineAndTransmissions_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEngineAndTransmissions_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
                });

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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVAppFeatures", x => x.TWEVAppFeaturesId);
                    table.ForeignKey(
                        name: "FK_TWEVAppFeatures_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVAppFeatures_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVChargings", x => x.TWEVChargingId);
                    table.ForeignKey(
                        name: "FK_TWEVChargings_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVChargings_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVDimensionsAndCapacities", x => x.TWEVDimensionsAndCapacityId);
                    table.ForeignKey(
                        name: "FK_TWEVDimensionsAndCapacities_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVDimensionsAndCapacities_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVElectricals", x => x.TWEVElectricalsId);
                    table.ForeignKey(
                        name: "FK_TWEVElectricals_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVElectricals_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVEngineAndTransmissions", x => x.TWEVEngineAndTransmissionId);
                    table.ForeignKey(
                        name: "FK_TWEVEngineAndTransmissions_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVEngineAndTransmissions_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVFeatures", x => x.TWEVFeaturesId);
                    table.ForeignKey(
                        name: "FK_TWEVFeatures_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVFeatures_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVMotorAndBatteries", x => x.TWEVMotorAndBatteryId);
                    table.ForeignKey(
                        name: "FK_TWEVMotorAndBatteries_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVMotorAndBatteries_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVPerformances", x => x.TWEVPerformanceId);
                    table.ForeignKey(
                        name: "FK_TWEVPerformances_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVPerformances_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVRanges", x => x.TWEVRangeId);
                    table.ForeignKey(
                        name: "FK_TWEVRanges_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVRanges_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVSafety", x => x.TWEVSafetyId);
                    table.ForeignKey(
                        name: "FK_TWEVSafety_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVSafety_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVTyresAndBrakes", x => x.TWEVTyresAndBrakesId);
                    table.ForeignKey(
                        name: "FK_TWEVTyresAndBrakes_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVTyresAndBrakes_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWEVUnderpinnings", x => x.TWEVUnderpinningId);
                    table.ForeignKey(
                        name: "FK_TWEVUnderpinnings_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWEVUnderpinnings_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    AdditionalFeaturesOfVariant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanceToEmptyIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdjustableWindshield = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWFeatures", x => x.TWFeaturesId);
                    table.ForeignKey(
                        name: "FK_TWFeatures_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWFeatures_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TopColorCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BottomColorCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageAltTag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWImageColorPrices", x => x.TWImageColorPriceId);
                    table.ForeignKey(
                        name: "FK_TWImageColorPrices_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWImageColorPrices_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWMileageAndPerformances", x => x.TWMileageAndPerformanceId);
                    table.ForeignKey(
                        name: "FK_TWMileageAndPerformances_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWMileageAndPerformances_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWMotorAndBatteries", x => x.TWMotorAndBatteryId);
                    table.ForeignKey(
                        name: "FK_TWMotorAndBatteries_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWMotorAndBatteries_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    RidingModes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TractionControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWSafety", x => x.TWSafetyId);
                    table.ForeignKey(
                        name: "FK_TWSafety_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWSafety_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    FrontBrake = table.Column<string>(type: "varchar(30)", nullable: true),
                    RearBrake = table.Column<string>(type: "varchar(30)", nullable: true),
                    FuelCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWSpec_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWTyresAndBrakes", x => x.TWTyresAndBrakesId);
                    table.ForeignKey(
                        name: "FK_TWTyresAndBrakes_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWTyresAndBrakes_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
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
                    BrakesFront = table.Column<string>(type: "varchar(20)", nullable: true),
                    BrakesRear = table.Column<string>(type: "varchar(20)", nullable: true),
                    TyreSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WheelSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WheelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubelessTyre = table.Column<string>(type: "varchar(10)", nullable: true),
                    TwoWheelerId = table.Column<int>(type: "int", nullable: true),
                    TWVarientId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWUnderpinnings", x => x.TWUnderpinningId);
                    table.ForeignKey(
                        name: "FK_TWUnderpinnings_TWVarients_TWVarientId",
                        column: x => x.TWVarientId,
                        principalTable: "TWVarients",
                        principalColumn: "TWVarientId");
                    table.ForeignKey(
                        name: "FK_TWUnderpinnings_TwoWheelers_TwoWheelerId",
                        column: x => x.TwoWheelerId,
                        principalTable: "TwoWheelers",
                        principalColumn: "TwoWheelerId");
                });
           
            migrationBuilder.CreateIndex(
                name: "IX_LatestNews_TwoWBrandId",
                table: "LatestNews",
                column: "TwoWBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TWChargings_TwoWheelerId",
                table: "TWChargings",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWChargings_TWVarientId",
                table: "TWChargings",
                column: "TWVarientId");

            migrationBuilder.CreateIndex(
                name: "IX_TWChassisAndSuspensions_TwoWheelerId",
                table: "TWChassisAndSuspensions",
                column: "TwoWheelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TWChassisAndSuspensions_TWVarientId",
                table: "TWChassisAndSuspensions",
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
           */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "CompareItems");

            migrationBuilder.DropTable(
                name: "LatestNews");

            migrationBuilder.DropTable(
                name: "LoginModel");

            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.DropTable(
                name: "TWChargings");

            migrationBuilder.DropTable(
                name: "TWChassisAndSuspensions");

            migrationBuilder.DropTable(
                name: "TWDimensionsAndCapacities");

            migrationBuilder.DropTable(
                name: "TWElectricals");

            migrationBuilder.DropTable(
                name: "TWEngineAndTransmissions");

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

            migrationBuilder.DropTable(
                name: "TWFeatures");

            migrationBuilder.DropTable(
                name: "TWImageColorPrices");

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
                name: "ValueForMoney");

            migrationBuilder.DropTable(
                name: "TWVarients");

            migrationBuilder.DropTable(
                name: "TwoWheelers");

            migrationBuilder.DropTable(
                name: "TWBrands");
        }
    }
}
