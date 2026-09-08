using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/bikes")]
    public class BikeDetailsApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public BikeDetailsApiController(TwoWheelerDB context)
        {
            _context = context;
        }


        // ============================================================
        // GET BIKE DETAILS BY ID
        // ============================================================

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetBikeDetails(int id)
        {
            // --------------------------------------------------------
            // BIKE
            // --------------------------------------------------------

            var bike = await _context.Twowheelers
                .Include(x => x.TwoWheelerBrands)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TwoWheelerId == id);

            if (bike == null)
            {
                return NotFound(new
                {
                    message = "Bike not found."
                });
            }


            // --------------------------------------------------------
            // IMPORTANT:
            // IsEV is bool?, therefore DO NOT use !bike.IsEV
            //
            // Correct:
            // bike.IsEV == true
            // --------------------------------------------------------

            bool isEV = bike.IsEV == true;


            // --------------------------------------------------------
            // BIKE DTO
            // --------------------------------------------------------

            var bikeDto = new
            {
                id = bike.TwoWheelerId,
                name = bike.TwoWheelerName,
                brand = bike.Brand,
                price = bike.Price,
                basePrice = bike.BasePrice,
                topPrice = bike.TopPrice,
                image = bike.TWImage,
                description = bike.Discription == "NULL"
                    ? ""
                    : bike.Discription,
                launchDate = bike.LaunchDate,
                type = bike.Type,
                isEV = isEV
            };


            // ========================================================
            // VARIANTS
            // ========================================================

            var variants = await _context.TWVarients
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    id = x.TWVarientId,
                    name = x.Varients
                })
                .ToListAsync();


            // ========================================================
            // DATA VARIABLES
            //
            // object is intentionally used here because EV and
            // non-EV tables have different column structures.
            // ========================================================

            object specs;
            object engine;
            object features;
            object safety;
            object performance;
            object dimensions;
            object electricals;
            object tyres;
            object motorBattery;
            object charging;
            object underpinnings;

            object appFeatures;
            object range;
            object chassis;


            // ========================================================
            // EV DATA
            // ========================================================

            if (isEV)
            {
                // ----------------------------------------------------
                // EV SPECIFICATIONS
                //
                // No TWEV specification model was provided.
                // Therefore return empty array for now.
                // ----------------------------------------------------

                specs = new List<object>();


                // ====================================================
                // EV ENGINE & TRANSMISSION
                // ====================================================

                engine = await _context
                    .Set<TWEVEngineAndTransmission>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        // EV fields
                        engineType = (string?)null,
                        displacement = (decimal?)null,
                        maxTorque = (decimal?)null,
                        cylinders = (int?)null,
                        valvesPerCylinder = (int?)null,

                        coolingSystem = x.CoolingSystem,
                        starting = x.Starting,

                        fuelSupply = (string?)null,
                        clutch = (string?)null,
                        gearbox = (string?)null,
                        ignition = (string?)null,
                        compressionRatio = (string?)null,
                        emissionType = (string?)null,

                        numOfBatteries = x.NumOfBattries,
                        motorPower = x.MotorPower,
                        rangeEcoMode = x.RangeEcoMode,
                        rangeNormalMode = x.RangeNormalMode,
                        rangeSportsMode = x.RangeSportsMode,
                        motorIPRating = x.MotorIPRating
                    })
                    .ToListAsync();


                // ====================================================
                // EV FEATURES
                // ====================================================

                features = await _context
                    .Set<TWEVFeatures>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        // Existing common feature fields
                        abs = (string?)null,
                        speedometer = x.Speedometer,
                        tripmeter = x.Tripmeter,
                        tachometer = (string?)null,
                        ledTailLight = (string?)null,
                        odometer = x.Odometer,
                        fuelGauge = (string?)null,

                        instrumentConsole = x.InstrumentConsole,
                        seatType = x.SeatType,
                        bodyGraphics = (string?)null,
                        clock = x.Clock,
                        passengerFootrest = x.PassengerFootrest,

                        additionalFeatures =
                            x.AdditionalFeaturesOfVariant,

                        distanceToEmpty = (string?)null,
                        adjustableWindshield = (string?)null,

                        // EV-specific features
                        bluetoothConnectivity =
                            x.BluetoothConnectivity,

                        navigation = x.Navigation,

                        callSMSAlerts =
                            x.CallSMSAlerts,

                        roadsideAssistance =
                            x.RoadsideAssistance,

                        antiTheftAlarm =
                            x.AntiTheftAlarm,

                        usbChargingPort =
                            x.USBChargingPort,

                        musicControl =
                            x.MusicControl,

                        ota = x.OTA,

                        carryHook = x.CarryHook,

                        underseatStorage =
                            x.UnderseatStorage,

                        chargerOutput =
                            x.ChargerOutput,

                        regenerativeBraking =
                            x.RegenerativeBraking,

                        hillHold = x.HillHold,

                        keylessIgnition =
                            x.KeylessIgnition
                    })
                    .ToListAsync();


                // ====================================================
                // EV APP FEATURES
                // ====================================================

                appFeatures = await _context
                    .Set<TWEVAppFeatures>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        chargingStationLocate =
                            x.ChargingStationLocate,

                        geofencing = x.Geofencing,

                        antiTheftAlarm =
                            x.AntiTheftAlarm,

                        callsAndMessaging =
                            x.CallsAndMessaging,

                        navigationAssis =
                            x.NavigationAssis,

                        lowBatteryAlert =
                            x.LowBatteryAlert
                    })
                    .ToListAsync();


                // ====================================================
                // EV SAFETY
                // ====================================================

                safety = await _context
                    .Set<TWEVSafety>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        passSwitch = (string?)null,
                        engineKillSwitch = (string?)null,

                        display = x.Display,
                        ridingModes = x.RidingModes,

                        tractionControl = (string?)null,

                        additionalFeatures = (string?)null,

                        brakingType = x.BrakingType,
                        chargingPoint = x.ChargingPoint,
                        fastCharging = x.FastCharging,

                        mobileApplication =
                            x.MobileApplication,

                        internetConnectivity =
                            x.InternetConnectivity,

                        operatingSystem =
                            x.OperatingSystem,

                        processor = x.Processor,

                        gradeability = x.Gradeability,

                        serviceDueIndicator =
                            x.ServiceDueIndicator,

                        switchableABS =
                            x.SwitchableABS,

                        ebs = x.EBS,

                        seatOpeningSwitch =
                            x.SeatOpeningSwitch
                    })
                    .ToListAsync();


                // ====================================================
                // EV PERFORMANCE
                // ====================================================

                performance = await _context
                    .Set<TWEVPerformance>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        overallMileage = (decimal?)null,
                        cityMileage = (decimal?)null,
                        highwayMileage = (decimal?)null,

                        scooterSpeed = x.ScooterSpeed,

                        zeroTo40Kmphsec =
                            x.ZeroTo40Kmphsec,

                        topSpeed = x.TopSpeed,

                        zeroTo100Kmphsec =
                            x.ZeroTo100Kmphsec
                    })
                    .ToListAsync();


                // ====================================================
                // EV RANGE
                // ====================================================

                range = await _context
                    .Set<TWEVRange>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        claimedRange = x.ClaimedRange
                    })
                    .ToListAsync();


                // ====================================================
                // EV DIMENSIONS & CAPACITY
                // ====================================================

                dimensions = await _context
                    .Set<TWEVDimensionsAndCapacity>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        width = x.Width,
                        length = x.Length,
                        height = x.Height,

                        fuelCapacity = (decimal?)null,

                        saddleHeight = x.SaddleHeight,

                        groundClearance =
                            x.GroundClearance,

                        wheelbase = x.Wheelbase,

                        kerbWeight = x.KerbWeight,

                        fuelReserve = (decimal?)null,

                        additionalStorage =
                            x.AdditionalStorage
                    })
                    .ToListAsync();


                // ====================================================
                // EV ELECTRICALS
                // ====================================================

                electricals = await _context
                    .Set<TWEVElectricals>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        headlight = x.Headlight,
                        tailLight = x.TailLight,
                        turnSignalLamp = x.TurnSignalLamp,

                        ledTailLights =
                            x.LEDTailLights,

                        lowFuelIndicator =
                            x.LowBatteryIndicator,

                        pilotLamps = (string?)null,

                        distanceToEmptyIndicator =
                            (string?)null,

                        drls = (string?)null,

                        lowBatteryIndicator =
                            x.LowBatteryIndicator
                    })
                    .ToListAsync();


                // ====================================================
                // EV TYRES & BRAKES
                // ====================================================

                tyres = await _context
                    .Set<TWEVTyresAndBrakes>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        frontBrakeDiameter =
                            x.FrontBrakeDiameter,

                        rearBrakeDiameter =
                            x.RearBrakeDiameter,

                        radialTyre = (string?)null,

                        frontSuspension = (string?)null,
                        rearSuspension = (string?)null,

                        frontTyrePressureRider =
                            x.FrontTyrePressureRider,

                        frontTyrePressureRiderAndPillion =
                            x.FrontTyrePressureRiderAndPillion,

                        rearTyrePressureRider =
                            x.RearTyrePressureRider,

                        rearTyrePressureRiderAndPillion =
                            x.RearTyrePressureRiderAndPillion
                    })
                    .ToListAsync();


                // ====================================================
                // EV MOTOR & BATTERY
                // ====================================================

                motorBattery = await _context
                    .Set<TWEVMotorAndBattery>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        peakPower = x.PeakPower,

                        driveType = x.MotorType,

                        transmission = x.Transmission,

                        batteryCapacity =
                            x.BatteryCapacity,

                        motorType = x.MotorType,

                        torqueMotor = x.TorqueMotor,

                        batteryType = x.BatteryType,

                        batteryWarranty =
                            x.BatteryWarranty,

                        waterProofRating =
                            x.WaterProofRating,

                        reverseAssist =
                            x.ReverseAssist
                    })
                    .ToListAsync();


                // ====================================================
                // EV CHARGING
                // ====================================================

                charging = await _context
                    .Set<TWEVCharging>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        chargingAtHome =
                            x.ChargingAtHome,

                        chargingAtChargingStation =
                            x.ChargingAtChargingStation,

                        chargingTimeZeroTo80Percent =
                            x.ChargingTimeZeroTo80Percent,

                        chargingTimeZeroTo100Percent =
                            x.ChargingTimeZeroTo100Percent,

                        chargingNetworkBatterySwappingNetwork =
                            x.ChargingNetworkBatterySwappingNetwork
                    })
                    .ToListAsync();


                // ====================================================
                // EV UNDERPINNINGS
                // ====================================================

                underpinnings = await _context
                    .Set<TWEVUnderpinning>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        suspensionFront =
                            x.SuspensionFront,

                        suspensionRear =
                            x.SuspensionRear,

                        brakesFront =
                            x.BrakesFront,

                        brakesRear =
                            x.BrakesRear,

                        tyreSize = x.TyreSize,

                        wheelSize = x.WheelSize,

                        wheelType = x.WheelType,

                        tubelessTyre =
                            x.TubelessTyre,

                        abs = x.ABS,

                        frame = x.Frame
                    })
                    .ToListAsync();


                // ====================================================
                // EV CHASSIS & SUSPENSION
                // ====================================================

                chassis = await _context
                    .Set<TWEVChassisAndSuspension>()
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        bodyType = x.BodyType
                    })
                    .ToListAsync();
            }


            // ========================================================
            // NON-EV DATA
            // ========================================================

            else
            {
                // ----------------------------------------------------
                // SPECIFICATIONS
                // ----------------------------------------------------

                specs = await _context.TWSpec
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,

                        mileage = x.Milage,
                        fuelCapacity = x.FuelCapacity,

                        frontBrake = x.FrontBrake,
                        rearBrake = x.RearBrake,

                        bodyType = x.BodyType
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // ENGINE & TRANSMISSION
                // ----------------------------------------------------

                engine = await _context.TWEngineAndTransmissions
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        engineType = x.EngineType,
                        displacement = x.Displacement,
                        maxTorque = x.MaxTorque,
                        cylinders = x.NumOfCylinders,

                        coolingSystem =
                            x.CoolingSystem,

                        valvesPerCylinder =
                            x.ValvePerCylinder,

                        starting = x.Starting,
                        fuelSupply = x.FuelSupply,
                        clutch = x.Clutch,
                        gearbox = x.GearBox,
                        ignition = x.Ignition,

                        compressionRatio =
                            x.CompressionRatio,

                        emissionType =
                            x.EmissionType
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // FEATURES
                // ----------------------------------------------------

                features = await _context.TWFeatures
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        abs = x.ABS,
                        speedometer = x.Speedometer,
                        tripmeter = x.Tripmeter,
                        tachometer = x.Tachometer,

                        ledTailLight =
                            x.LEDTailLight,

                        odometer = x.Odometer,
                        fuelGauge = x.FuelGauge,

                        instrumentConsole =
                            x.InstrumentConsole,

                        seatType = x.SeatType,
                        bodyGraphics = x.BodyGraphics,
                        clock = x.Clock,

                        passengerFootrest =
                            x.PassengerFootrest,

                        additionalFeatures =
                            x.AdditionalFeaturesOfVariant,

                        distanceToEmpty =
                            x.DistanceToEmptyIndicator,

                        adjustableWindshield =
                            x.AdjustableWindshield
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // APP FEATURES
                // ----------------------------------------------------

                appFeatures = new List<object>();


                // ----------------------------------------------------
                // SAFETY
                // ----------------------------------------------------

                safety = await _context.TWSafety
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        passSwitch = x.PassSwitch,

                        engineKillSwitch =
                            x.EngineKillSwitch,

                        display = x.Display,
                        ridingModes = x.RidingModes,

                        tractionControl =
                            x.TractionControl,

                        additionalFeatures =
                            x.AdditionalFeatures
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // PERFORMANCE
                // ----------------------------------------------------

                performance =
                    await _context.TWMileageAndPerformances
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        overallMileage =
                            x.OverallMileage,

                        cityMileage =
                            x.CityMileage,

                        highwayMileage =
                            x.HighwayMileage
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // RANGE
                // ----------------------------------------------------

                range = new List<object>();


                // ----------------------------------------------------
                // DIMENSIONS
                // ----------------------------------------------------

                dimensions =
                    await _context.TWDimensionsAndCapacities
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        width = x.Width,
                        length = x.Length,
                        height = x.Height,

                        fuelCapacity =
                            x.FuelCapacity,

                        groundClearance =
                            x.GroundClearance,

                        wheelbase = x.Wheelbase,

                        kerbWeight =
                            x.KerbWeight,

                        fuelReserve =
                            x.FuelReserve,

                        saddleHeight =
                            x.SaddleHeight
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // ELECTRICALS
                // ----------------------------------------------------

                electricals =
                    await _context.TWElectricals
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        headlight = x.Headlight,
                        tailLight = x.TailLight,

                        turnSignalLamp =
                            x.TurnSignalLamp,

                        ledTailLights =
                            x.LEDTailLights,

                        lowFuelIndicator =
                            x.LowFuelIndicato,

                        pilotLamps =
                            x.PilotLamps,

                        distanceToEmptyIndicator =
                            x.DistanceToEmptyIndicator,

                        drls = x.DRLs
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // TYRES & BRAKES
                // ----------------------------------------------------

                tyres =
                    await _context.TWTyresAndBrakes
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        frontBrakeDiameter =
                            x.FrontBrakeDiameter,

                        rearBrakeDiameter =
                            x.RearBrakeDiameter,

                        radialTyre =
                            x.RadialTyre,

                        frontSuspension =
                            x.FrontSuspension,

                        rearSuspension =
                            x.RearSuspension
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // MOTOR & BATTERY
                // ----------------------------------------------------

                motorBattery =
                    await _context.TWMotorAndBatteries
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        peakPower = x.PeakPower,
                        driveType = x.DriveType,

                        transmission =
                            x.Transmission,

                        batteryCapacity =
                            x.BatteryCapacity
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // CHARGING
                // ----------------------------------------------------

                charging =
                    await _context.TWChargings
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        chargingAtHome =
                            x.ChargingAtHome,

                        chargingAtChargingStation =
                            x.ChargingAtChargingStation
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // UNDERPINNINGS
                // ----------------------------------------------------

                underpinnings =
                    await _context.TWUnderpinnings
                    .AsNoTracking()
                    .Where(x => x.TwoWheelerId == id)
                    .Select(x => new
                    {
                        variantId = x.TWVarientId,
                        variant = x.Varients,

                        suspensionFront =
                            x.SuspensionFront,

                        suspensionRear =
                            x.SuspensionRear,

                        brakesFront =
                            x.BrakesFront,

                        brakesRear =
                            x.BrakesRear,

                        tyreSize =
                            x.TyreSize,

                        wheelSize =
                            x.WheelSize,

                        wheelType =
                            x.WheelType,

                        tubelessTyre =
                            x.TubelessTyre
                    })
                    .ToListAsync();


                // ----------------------------------------------------
                // CHASSIS
                // ----------------------------------------------------

                chassis = new List<object>();
            }


            // ========================================================
            // IMAGES
            // ========================================================

            var images = await _context.TWImageColorPrices
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    image = x.ImageURL,
                    color = x.Color,
                    price = x.Price,
                    variantId = x.TWVarientId,

                    topColorCode =
                        x.TopColorCode,

                    bottomColorCode =
                        x.BottomColorCode
                })
                .ToListAsync();


            // ========================================================
            // SIMILAR BIKES
            // ========================================================

            var similarBikes = await _context.Twowheelers
                .AsNoTracking()
                .Where(x =>
                    x.TwoWheelerId != bike.TwoWheelerId &&
                    x.Type == bike.Type &&
                    x.IsActive == true)
                .OrderBy(x => x.BasePrice)
                .Take(8)
                .Select(x => new
                {
                    id = x.TwoWheelerId,
                    name = x.TwoWheelerName,
                    image = x.TWImage,
                    price = x.Price,
                    brand = x.Brand
                })
                .ToListAsync();


            // ========================================================
            // LATEST NEWS
            // ========================================================

            var news = await _context.TWLatestNews
                .AsNoTracking()
                .Where(x => x.BrandName == bike.Brand)
                .OrderByDescending(x => x.Date)
                .Take(5)
                .Select(x => new
                {
                    id = x.TWLatestNewsId,
                    title = x.NewsHeading,
                    image = x.ImageURL,
                    summary = x.NewsSummary,
                    date = x.Date
                })
                .ToListAsync();


            // ========================================================
            // BLOGS
            // ========================================================

            var blogs = await _context.Blogs
                .AsNoTracking()
                .Where(x => x.IsTwoWheeler == true)
                .OrderByDescending(x => x.Date)
                .Take(6)
                .Select(x => new
                {
                    id = x.BlogId,
                    title = x.BlogHeading,
                    summary = x.BlogSummary,
                    image = x.ImageURL,
                    date = x.Date
                })
                .ToListAsync();


            // ========================================================
            // REVIEWS
            // ========================================================

            var reviews = await _context.Reviews
                .AsNoTracking()
                .Where(x => x.TwoWheelerID == id)
                .OrderByDescending(x => x.CreatedAt)
                .Take(10)
                .Select(x => new
                {
                    id = x.ReviewID,
                    user = x.Username,
                    rating = x.Rating,
                    review = x.ReviewText,
                    date = x.CreatedAt
                })
                .ToListAsync();


            // ========================================================
            // RATING
            // ========================================================

            double rating = reviews.Any()
                ? Math.Round(
                    reviews.Average(x => (double)x.rating),
                    1)
                : 0;


            var reviewCount = reviews.Count;


            // ========================================================
            // WISHLIST
            // ========================================================

            bool isWishlisted = false;


            // ========================================================
            // FINAL RESPONSE
            // ========================================================

            return Ok(new
            {
                bike = new
                {
                    bikeDto.id,
                    bikeDto.name,
                    bikeDto.brand,
                    bikeDto.price,
                    bikeDto.basePrice,
                    bikeDto.topPrice,
                    bikeDto.image,
                    bikeDto.description,
                    bikeDto.launchDate,
                    bikeDto.type,
                    bikeDto.isEV,

                    rating,
                    reviewCount,
                    isWishlisted
                },

                variants,

                specs,
                engine,
                features,
                appFeatures,

                safety,
                performance,
                range,

                dimensions,
                electricals,
                tyres,

                motorBattery,
                charging,
                underpinnings,
                chassis,

                images,

                similarBikes,
                news,
                blogs,
                reviews
            });
        }


        // ============================================================
        // GET BIKE DETAILS BY BRAND + BIKE NAME
        // ============================================================

        [HttpGet("details/{brandName}/{bikeName}")]
        public async Task<IActionResult> GetBikeDetails(
            string brandName,
            string bikeName)
        {
            var bike = await _context.Twowheelers
                .FirstOrDefaultAsync(x =>
                    x.Brand
                        .ToLower()
                        .Trim()
                        .Replace(" ", "-") ==
                    brandName.ToLower()
                    &&
                    x.TwoWheelerName
                        .ToLower()
                        .Trim()
                        .Replace(" ", "-") ==
                    bikeName.ToLower());

            if (bike == null)
            {
                return NotFound(new
                {
                    message = "Bike not found."
                });
            }

            return await GetBikeDetails(bike.TwoWheelerId);
        }
    }
}