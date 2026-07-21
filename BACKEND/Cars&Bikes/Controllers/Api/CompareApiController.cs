using System.Collections.Generic;
using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/compare")]
    public class CompareApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public CompareApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        private static readonly Dictionary<string, string> ImageMap = new()
        {
            { "CompareHondaActiva125VsTVSJupiter", "/images/CompareBikes/Honda Activa 125 vs TVS Jupiter.webp" },

            { "CompareTVSApacheRR310VsRoyalEnfieldBullet350", "/images/CompareBikes/royalvsapache.webp" },

            { "CompareBajajPulsar125vsBajajPulsar150", "/images/CompareBikes/pulsarvspulsar.webp" },

            { "CompareTVSApacheRTR1604VvsBajajDominar250", "/images/CompareBikes/apachevsdominar.webp" },

            { "CompareBajajPulsarRS200vsBajajPulsarNS200", "/images/CompareBikes/Bajaj Pulsar RS200 vs Bajaj Pulsar NS200.webp" },

            { "CompareRoyalEnfieldHunter350vsTVSRonin", "/images/CompareBikes/Royal Enfield Hunter 350 vs TVS Ronin.webp" },

            { "CompareHondaActiva125vsSuzukiAccess125", "/images/CompareBikes/Honda Activa 125 vs Suzuki Access 125.webp" },

            { "CompareSuzukiGixxervsTVSApacheRTR160", "/images/CompareBikes/Suzuki Gixxer vs TVS Apache RTR 160.webp" },

            { "CompareTVSRadeonvsHeroSplendorPlus", "/images/CompareBikes/TVS Radeon vs Hero Splendor Plus.webp" },

            { "CompareBajajPulsar150vsTVSApacheRTR160", "/images/CompareBikes/Bajaj Pulsar 150 vs TVS Apache RTR 160.webp" },

            { "CompareBajajPlatina110vsTVSSport", "/images/CompareBikes/Bajaj Platina 110 vs TVS Sport.webp" },

            { "CompareSuzukiAccess125vsTVSJupiter", "/images/CompareBikes/Suzuki Access 125 vs TVS Jupiter 125.webp" },

            { "CompareHondaUnicornvsSuzukiGixxer", "/images/CompareBikes/Honda Unicorn vs Suzuki Gixxer.webp" },

            { "CompareHondaActiva6GVsTVSJupiter", "/images/CompareBikes/Honda Activa 6G vs TVS Jupiter.webp" },

            { "CompareKawasakiNinjavsBMWS1000RR", "/images/CompareBikes/Kawasaki Ninja vs BMW S 1000 RR.webp" },

            { "CompareBajajPulsarRS200vsHeroKarizmaXMR", "/images/CompareBikes/Bajaj Pulsar RS200 vs Hero Karizma XMR.webp" }
        };

        private static readonly Dictionary<string, string[]> CompareBikeNames = new()
        {
            { "CompareHondaActiva125VsTVSJupiter", new[] { "Honda Activa 125", "TVS Jupiter" } },
            { "CompareTVSApacheRR310VsRoyalEnfieldBullet350", new[] { "TVS Apache RR 310", "Royal Enfield Bullet 350" } },
            { "CompareBajajPulsar125vsBajajPulsar150", new[] { "Bajaj Pulsar 125", "Bajaj Pulsar 150" } },
            { "CompareTVSApacheRTR1604VvsBajajDominar250", new[] { "TVS Apache RTR 160 4V", "Bajaj Dominar 250" } },
            { "CompareBajajPulsarRS200vsBajajPulsarNS200", new[] { "Bajaj Pulsar RS200", "Bajaj Pulsar NS200" } },
            { "CompareRoyalEnfieldHunter350vsTVSRonin", new[] { "Royal Enfield Hunter 350", "TVS Ronin" } },
            { "CompareHondaActiva125vsSuzukiAccess125", new[] { "Honda Activa 125", "Suzuki Access 125" } },
            { "CompareSuzukiGixxervsTVSApacheRTR160", new[] { "Suzuki Gixxer", "TVS Apache RTR 160" } },
            { "CompareTVSRadeonvsHeroSplendorPlus", new[] { "TVS Radeon", "Hero Splendor Plus" } },
            { "CompareBajajPulsar150vsTVSApacheRTR160", new[] { "Bajaj Pulsar 150", "TVS Apache RTR 160" } },
            { "CompareBajajPlatina110vsTVSSport", new[] { "Bajaj Platina 110", "TVS Sport" } },
            { "CompareSuzukiAccess125vsTVSJupiter", new[] { "Suzuki Access 125", "TVS Jupiter" } },
            { "CompareHondaUnicornvsSuzukiGixxer", new[] { "Honda Unicorn", "Suzuki Gixxer" } },
            { "CompareHondaActiva6GVsTVSJupiter", new[] { "Honda Activa 6G", "TVS Jupiter" } },
            { "CompareKawasakiNinjavsBMWS1000RR", new[] { "Kawasaki Ninja", "BMW S 1000 RR" } },
            { "CompareBajajPulsarRS200vsHeroKarizmaXMR", new[] { "Bajaj Pulsar RS200", "Hero Karizma XMR" } }
        };

        [HttpGet]
        public async Task<IActionResult> GetCompareCards()
        {
            var items = await _context.CompareItems
                .Select(x => new
                {
                    x.Id,
                    x.Topic,
                    x.CompareUrl
                })
                .ToListAsync();

            var cards = new List<object>();

            foreach (var item in items)
            {
                var bikeNames = GetBikeNames(item.Topic, item.CompareUrl);
                var bike1 = bikeNames == null ? null : await GetDefaultBikeSelection(bikeNames[0]);
                var bike2 = bikeNames == null ? null : await GetDefaultBikeSelection(bikeNames[1]);

                cards.Add(new
                {
                    id = item.Id,
                    title = item.Topic,
                    image = ImageMap.TryGetValue(item.CompareUrl, out var image)
                    ? image
                    : "/images/CompareBikes/default.webp",
                    bike1Id = bike1?.BikeId,
                    bike2Id = bike2?.BikeId,
                    bike1VariantId = bike1?.VariantId,
                    bike2VariantId = bike2?.VariantId
                });
            }

            return Ok(cards);
        }

        private static string[]? GetBikeNames(string title, string compareUrl)
        {
            if (CompareBikeNames.TryGetValue(compareUrl, out var mappedNames))
                return mappedNames;

            var separatorIndex = title.IndexOf(" vs ", StringComparison.OrdinalIgnoreCase);
            if (separatorIndex < 0)
                return null;

            var bike1 = title[..separatorIndex].Trim();
            var bike2 = title[(separatorIndex + 4)..].Trim();

            return string.IsNullOrWhiteSpace(bike1) || string.IsNullOrWhiteSpace(bike2)
                ? null
                : new[] { bike1, bike2 };
        }

        private async Task<CompareBikeSelection?> GetDefaultBikeSelection(string bikeName)
        {
            var normalizedName = NormalizeBikeName(bikeName);

            return await _context.TWVarients
                .AsNoTracking()
                .Where(x =>
                    x.TwoWheeler != null &&
                    x.TwoWheelerId.HasValue &&
                    x.TwoWheeler.TwoWheelerName != null &&
                    x.TwoWheeler.TwoWheelerName.Trim().ToLower() == normalizedName)
                .OrderBy(x => x.TWVarientId)
                .Select(x => new CompareBikeSelection
                {
                    BikeId = x.TwoWheelerId.Value,
                    VariantId = x.TWVarientId
                })
                .FirstOrDefaultAsync();
        }

        private static string NormalizeBikeName(string bikeName)
        {
            return bikeName.Trim().ToLower();
        }

        private sealed class CompareBikeSelection
        {
            public int BikeId { get; set; }
            public int VariantId { get; set; }
        }
    }
    
}
