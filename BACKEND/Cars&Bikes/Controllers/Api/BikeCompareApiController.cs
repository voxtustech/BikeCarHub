using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeCompareApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public BikeCompareApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        [HttpGet("{bike1Id:int}/{variant1Id:int}/{bike2Id:int}/{variant2Id:int}")]
        public async Task<IActionResult> GetCompare(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id)
        {
            var bike1 = await _context.Twowheelers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TwoWheelerId == bike1Id);

            var bike2 = await _context.Twowheelers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TwoWheelerId == bike2Id);

            //if (bike1 == null || bike2 == null)
            //    return NotFound();
            if (bike1 == null || bike2 == null)
            {
                return BadRequest(new
                {
                    message = "Bike not found",
                    bike1Id,
                    bike2Id,
                    bike1Found = bike1 != null,
                    bike2Found = bike2 != null
                });
            }

            var variant1Exists = await _context.TWVarients
                .AsNoTracking()
                .AnyAsync(x => x.TwoWheelerId == bike1Id && x.TWVarientId == variant1Id);

            var variant2Exists = await _context.TWVarients
                .AsNoTracking()
                .AnyAsync(x => x.TwoWheelerId == bike2Id && x.TWVarientId == variant2Id);

            //if (!variant1Exists || !variant2Exists)
            //    return NotFound("One or both variants were not found for the selected bikes.");
            if (!variant1Exists || !variant2Exists)
            {
                return BadRequest(new
                {
                    message = "Variant not found",
                    variant1Id,
                    variant2Id,
                    variant1Exists,
                    variant2Exists
                });
            }

            var bike1EV = bike1.IsEV ?? false;
            var bike2EV = bike2.IsEV ?? false;

            var response = new
            {
                bike1 = await BuildBikeResponse(bike1),
                bike2 = await BuildBikeResponse(bike2),

                bike1Variants = await GetVariants(bike1Id),
                bike2Variants = await GetVariants(bike2Id),

                engine = await GetEngineComparison(bike1Id, variant1Id, bike2Id, variant2Id, bike1EV, bike2EV),
                performance = await GetPerformanceComparison(bike1Id, variant1Id, bike2Id, variant2Id, bike1EV, bike2EV),
                dimensions = await GetDimensionsComparison(bike1Id, variant1Id, bike2Id, variant2Id, bike1EV, bike2EV),
                features = await GetFeaturesComparison(bike1Id, variant1Id, bike2Id, variant2Id, bike1EV, bike2EV),
                safety = await GetSafetyComparison(bike1Id, variant1Id, bike2Id, variant2Id, bike1EV, bike2EV),
                electricals = await GetElectricalComparison(bike1Id, variant1Id, bike2Id, variant2Id, bike1EV, bike2EV),
                tyres = await GetTyresComparison(bike1Id, variant1Id, bike2Id, variant2Id, bike1EV, bike2EV),
                underpinnings = await GetUnderpinningComparison(bike1Id, variant1Id, bike2Id, variant2Id, bike1EV, bike2EV)
            };

            return Ok(response);
        }

        private async Task<object> BuildBikeResponse(Cars_Bikes.Models.TwoWheeler bike)
        {
            return new
            {
                id = bike.TwoWheelerId,
                name = bike.TwoWheelerName,
                brand = bike.Brand,
                image = await GetPrimaryImage(bike.TwoWheelerId),

                price = !string.IsNullOrWhiteSpace(bike.Price)
                    ? bike.Price
                    : $"₹{bike.BasePrice:N0} - ₹{bike.TopPrice:N0}",

                basePrice = bike.BasePrice,
                topPrice = bike.TopPrice,
                launchDate = bike.LaunchDate,
                isEV = bike.IsEV
            };
        }

        private async Task<string?> GetPrimaryImage(int bikeId)
        {
            var image = await _context.TWImageColorPrices
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == bikeId)
                .OrderBy(x => x.TWImageColorPriceId)
                .Select(x => x.ImageURL)
                .FirstOrDefaultAsync();

            if (!string.IsNullOrWhiteSpace(image))
                return image;

            return await _context.Twowheelers
                .Where(x => x.TwoWheelerId == bikeId)
                .Select(x => x.TWImage)
                .FirstOrDefaultAsync();
        }

        private async Task<IReadOnlyList<object>> GetVariants(int bikeId)
        {
            return await _context.TWVarients
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == bikeId)
                .OrderBy(x => x.TWVarientId)
                .Select(x => new
                {
                    id = x.TWVarientId,
                    name = x.Varients ?? x.TWName,
                    price = _context.TWImageColorPrices
                        .Where(p => p.TwoWheelerId == bikeId && p.TWVarientId == x.TWVarientId)
                        .OrderBy(p => p.TWImageColorPriceId)
                        .Select(p => p.Price)
                        .FirstOrDefault()
                        ??
                        _context.Twowheelers
                        .Where(t => t.TwoWheelerId == bikeId)
                        .Select(t => t.BasePrice)
                        .FirstOrDefault()  
                })
                .Cast<object>()
                .ToListAsync();
        }

        private async Task<object?> GetVariantSpec<T>(
            int bikeId,
            int variantId,
            Expression<Func<T, object>> selector)
            where T : class
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Where(x =>
                    EF.Property<int?>(x, "TwoWheelerId") == bikeId &&
                    EF.Property<int?>(x, "TWVarientId") == variantId)
                .Select(selector)
                .FirstOrDefaultAsync();
        }

        private async Task<object> CompareSection<TIce, TEv>(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id,
            bool bike1EV,
            bool bike2EV,
            Expression<Func<TIce, object>> iceSelector,
            Expression<Func<TEv, object>> evSelector)
            where TIce : class
            where TEv : class
        {
            var first = bike1EV
                ? await GetVariantSpec(bike1Id, variant1Id, evSelector)
                : await GetVariantSpec(bike1Id, variant1Id, iceSelector);

            var second = bike2EV
                ? await GetVariantSpec(bike2Id, variant2Id, evSelector)
                : await GetVariantSpec(bike2Id, variant2Id, iceSelector);

            return new
            {
                bike1 = first,
                bike2 = second
            };
        }

        private Task<object> GetEngineComparison(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id,
            bool bike1EV,
            bool bike2EV)
        {
            return CompareSection<TWEngineAndTransmission, TWEVEngineAndTransmission>(
                bike1Id,
                variant1Id,
                bike2Id,
                variant2Id,
                bike1EV,
                bike2EV,
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    engineType = x.EngineType,
                    displacement = x.Displacement,
                    maxTorque = x.MaxTorque,
                    cylinders = x.NumOfCylinders,
                    coolingSystem = x.CoolingSystem,
                    valvesPerCylinder = x.ValvePerCylinder,
                    starting = x.Starting,
                    fuelSupply = x.FuelSupply,
                    clutch = x.Clutch,
                    gearbox = x.GearBox,
                    ignition = x.Ignition,
                    compressionRatio = x.CompressionRatio,
                    emissionType = x.EmissionType
                },
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    motorPower = x.MotorPower,
                    coolingSystem = x.CoolingSystem,
                    starting = x.Starting,
                    rangeEcoMode = x.RangeEcoMode,
                    rangeNormalMode = x.RangeNormalMode,
                    rangeSportsMode = x.RangeSportsMode,
                    motorIPRating = x.MotorIPRating,
                    batteries = x.NumOfBattries
                });
        }

        private Task<object> GetPerformanceComparison(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id,
            bool bike1EV,
            bool bike2EV)
        {
            return CompareSection<TWMileageAndPerformance, TWEVPerformance>(
                bike1Id,
                variant1Id,
                bike2Id,
                variant2Id,
                bike1EV,
                bike2EV,
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    overallMileage = x.OverallMileage,
                    cityMileage = x.CityMileage,
                    highwayMileage = x.HighwayMileage
                },
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    scooterSpeed = x.ScooterSpeed,
                    topSpeed = x.TopSpeed,
                    zeroTo40 = x.ZeroTo40Kmphsec,
                    zeroTo100 = x.ZeroTo100Kmphsec
                });
        }

        private Task<object> GetFeaturesComparison(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id,
            bool bike1EV,
            bool bike2EV)
        {
            return CompareSection<TWFeatures, TWEVFeatures>(
                bike1Id,
                variant1Id,
                bike2Id,
                variant2Id,
                bike1EV,
                bike2EV,
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    abs = x.ABS,
                    speedometer = x.Speedometer,
                    tripmeter = x.Tripmeter,
                    tachometer = x.Tachometer,
                    ledTailLight = x.LEDTailLight,
                    odometer = x.Odometer,
                    fuelGauge = x.FuelGauge,
                    console = x.InstrumentConsole,
                    seat = x.SeatType,
                    bodyGraphics = x.BodyGraphics,
                    clock = x.Clock,
                    passengerFootrest = x.PassengerFootrest,
                    additional = x.AdditionalFeaturesOfVariant,
                    distanceToEmpty = x.DistanceToEmptyIndicator,
                    adjustableWindshield = x.AdjustableWindshield
                },
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    speedometer = x.Speedometer,
                    tripmeter = x.Tripmeter,
                    odometer = x.Odometer,
                    console = x.InstrumentConsole,
                    bluetoothConnectivity = x.BluetoothConnectivity,
                    navigation = x.Navigation,
                    callSmsAlerts = x.CallSMSAlerts,
                    roadsideAssistance = x.RoadsideAssistance,
                    antiTheftAlarm = x.AntiTheftAlarm,
                    usbChargingPort = x.USBChargingPort,
                    musicControl = x.MusicControl,
                    ota = x.OTA,
                    clock = x.Clock,
                    seat = x.SeatType,
                    passengerFootrest = x.PassengerFootrest,
                    carryHook = x.CarryHook,
                    underseatStorage = x.UnderseatStorage,
                    chargerOutput = x.ChargerOutput,
                    regenerativeBraking = x.RegenerativeBraking,
                    hillHold = x.HillHold,
                    keylessIgnition = x.KeylessIgnition,
                    additional = x.AdditionalFeaturesOfVariant
                });
        }

        private Task<object> GetSafetyComparison(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id,
            bool bike1EV,
            bool bike2EV)
        {
            return CompareSection<TWSafety, TWEVSafety>(
                bike1Id,
                variant1Id,
                bike2Id,
                variant2Id,
                bike1EV,
                bike2EV,
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    passSwitch = x.PassSwitch,
                    engineKillSwitch = x.EngineKillSwitch,
                    display = x.Display,
                    ridingModes = x.RidingModes,
                    tractionControl = x.TractionControl,
                    additional = x.AdditionalFeatures
                },
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    brakingType = x.BrakingType,
                    chargingPoint = x.ChargingPoint,
                    fastCharging = x.FastCharging,
                    mobileApplication = x.MobileApplication,
                    internetConnectivity = x.InternetConnectivity,
                    operatingSystem = x.OperatingSystem,
                    processor = x.Processor,
                    gradeability = x.Gradeability,
                    serviceDueIndicator = x.ServiceDueIndicator,
                    ridingModes = x.RidingModes,
                    display = x.Display,
                    switchableAbs = x.SwitchableABS,
                    ebs = x.EBS,
                    seatOpeningSwitch = x.SeatOpeningSwitch
                });
        }

        private Task<object> GetDimensionsComparison(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id,
            bool bike1EV,
            bool bike2EV)
        {
            return CompareSection<TWDimensionsAndCapacity, TWEVDimensionsAndCapacity>(
                bike1Id,
                variant1Id,
                bike2Id,
                variant2Id,
                bike1EV,
                bike2EV,
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    width = x.Width,
                    length = x.Length,
                    height = x.Height,
                    fuelCapacity = x.FuelCapacity,
                    groundClearance = x.GroundClearance,
                    wheelbase = x.Wheelbase,
                    kerbWeight = x.KerbWeight,
                    fuelReserve = x.FuelReserve,
                    saddleHeight = x.SaddleHeight
                },
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    width = x.Width,
                    length = x.Length,
                    height = x.Height,
                    saddleHeight = x.SaddleHeight,
                    groundClearance = x.GroundClearance,
                    wheelbase = x.Wheelbase,
                    kerbWeight = x.KerbWeight,
                    storage = x.AdditionalStorage
                });
        }

        private Task<object> GetElectricalComparison(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id,
            bool bike1EV,
            bool bike2EV)
        {
            return CompareSection<TWElectricals, TWEVElectricals>(
                bike1Id,
                variant1Id,
                bike2Id,
                variant2Id,
                bike1EV,
                bike2EV,
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    headlight = x.Headlight,
                    tailLight = x.TailLight,
                    turnSignalLamp = x.TurnSignalLamp,
                    ledTailLights = x.LEDTailLights,
                    lowFuelIndicator = x.LowFuelIndicato,
                    pilotLamps = x.PilotLamps,
                    distanceToEmptyIndicator = x.DistanceToEmptyIndicator,
                    drls = x.DRLs
                },
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    headlight = x.Headlight,
                    tailLight = x.TailLight,
                    turnSignalLamp = x.TurnSignalLamp,
                    ledTailLights = x.LEDTailLights,
                    lowBatteryIndicator = x.LowBatteryIndicator
                });
        }

        private Task<object> GetTyresComparison(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id,
            bool bike1EV,
            bool bike2EV)
        {
            return CompareSection<TWTyresAndBrakes, TWEVTyresAndBrakes>(
                bike1Id,
                variant1Id,
                bike2Id,
                variant2Id,
                bike1EV,
                bike2EV,
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    frontBrakeDiameter = x.FrontBrakeDiameter,
                    rearBrakeDiameter = x.RearBrakeDiameter,
                    radialTyre = x.RadialTyre,
                    frontSuspension = x.FrontSuspension,
                    rearSuspension = x.RearSuspension
                },
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    frontBrakeDiameter = x.FrontBrakeDiameter,
                    rearBrakeDiameter = x.RearBrakeDiameter,
                    frontTyrePressureRider = x.FrontTyrePressureRider,
                    frontTyrePressureRiderAndPillion = x.FrontTyrePressureRiderAndPillion,
                    rearTyrePressureRider = x.RearTyrePressureRider,
                    rearTyrePressureRiderAndPillion = x.RearTyrePressureRiderAndPillion
                });
        }

        private Task<object> GetUnderpinningComparison(
            int bike1Id,
            int variant1Id,
            int bike2Id,
            int variant2Id,
            bool bike1EV,
            bool bike2EV)
        {
            return CompareSection<TWUnderpinning, TWEVUnderpinning>(
                bike1Id,
                variant1Id,
                bike2Id,
                variant2Id,
                bike1EV,
                bike2EV,
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    suspensionFront = x.SuspensionFront,
                    suspensionRear = x.SuspensionRear,
                    brakesFront = x.BrakesFront,
                    brakesRear = x.BrakesRear,
                    tyreSize = x.TyreSize,
                    wheelSize = x.WheelSize,
                    wheelType = x.WheelType,
                    tubelessTyre = x.TubelessTyre
                },
                x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    suspensionFront = x.SuspensionFront,
                    suspensionRear = x.SuspensionRear,
                    brakesFront = x.BrakesFront,
                    brakesRear = x.BrakesRear,
                    abs = x.ABS,
                    tyreSize = x.TyreSize,
                    wheelSize = x.WheelSize,
                    wheelType = x.WheelType,
                    frame = x.Frame,
                    tubelessTyre = x.TubelessTyre
                });
        }
    }
}
