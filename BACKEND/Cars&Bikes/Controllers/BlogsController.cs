using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Discovery;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Cars_Bikes.Controllers
{
    public class BlogsController : Controller
    {
        private readonly TwoWheelerDB _context;
        public BlogsController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allBlogs = _context.Blogs.OrderByDescending(m => m.Date).Take(100).ToList();
            ViewBag.allBlogs = allBlogs;
            return View();
        }
        [Route("blogs/mg-car-discounts")]
        public IActionResult Aug272024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("MG Car Discounts");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Aug272024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/best-indian-cars-under-₹8-lakh-on-road-price-(2024)")]
        public IActionResult Sep232024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Best Indian Cars Under ₹8 Lakh On-Road Price (2024)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Sep232024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/best-indian-cars-to-buy-under-₹10-lakh-on-road-price-(2024)")]
        public IActionResult Sep242024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Best Indian Cars to Buy Under ₹10 Lakh On-Road Price (2024)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Sep242024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/here-are-the-best-indian-bikes-under-150cc-segments")]
        public IActionResult Oct222024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Here are the best Indian Bikes under 150cc segments.");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Oct222024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-longest-range-electric-scooters-in-india-for-2024")]
        public IActionResult Oct232024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Longest Range Electric Scooters in India for 2024");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Oct232024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/news-best-cars-under-₹11-lakh-in-india-specific-variants-Offering-great-value-in-2024")]
        public IActionResult Oct242024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("News: Best Cars Under ₹11 Lakh in India – Specific Variants Offering Great Value in 2024");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Oct242024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-best-selling-royal-enfield-bikes-in-india-(2024)")]
        public IActionResult Oct282024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Best-Selling Royal Enfield Bikes in India (2024)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Oct282024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-adventure-bikes-for-indian-terrain:specifications-features-and-costs-in-india")]
        public IActionResult Nov12024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Adventure Bikes for Indian Terrain: Specifications, Features, and Costs in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Nov12024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-bikes-under-2-lakh-in-india-for-performance-style-and-value")]
        public IActionResult Nov82024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Bikes Under 2 Lakh in India for Performance, Style, and Value");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Nov82024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-five-selling-bikes-in-india-november-2024-overview")]
        public IActionResult Nov112024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top Five Selling Bikes in India: November 2024 Overview");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Nov112024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-affordable-car-variants-under-₹6-lakhs-in-india-value-for-money-choices")]
        public IActionResult Nov202024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top Affordable Car Variants Under ₹6 Lakhs in India: Value-for-Money Choices");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Nov202024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/discover-the-all-new-suzuki-alto-k10-small-car-big-possibilities")]
        public IActionResult Nov222024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Discover the All-New Suzuki Alto K10 – Small Car, Big Possibilities!");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Nov222024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/best-cars-under-₹7-lakhs-in-india-(2024)")]
        public IActionResult Nov252024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Best Cars Under ₹7 Lakhs in India (2024)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Nov252024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-bikes-in-india-under-₹3-lakh-best-picks-for-2024")]
        public IActionResult Nov282024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top Bikes in India Under ₹3 Lakh: Best Picks for 2024");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Nov282024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-best-selling-bajaj-motorcycles-in-india")]
        public IActionResult Dec32024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Best-Selling Bajaj Motorcycles in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Dec32024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-sports-bikes-under-₹4-lakh-in-india-features-specs-and-prices")]
        public IActionResult Dec42024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Sports Bikes Under ₹4 Lakh in India: Features, Specs, and Prices");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Dec42024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/the-all-new-honda-amaze-a-perfect-blend-of-style-comfort-and-performance")]
        public IActionResult Dec42024BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("The All-New Honda Amaze: A Perfect Blend of Style, Comfort, and Performance");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Dec42024BlogDetails2.cshtml", blogsDetails);
        }
        [Route("blogs/indias-top-5-most-expensive-motorcycles-a-luxury-on-two-wheels")]
        public IActionResult Dec62024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("India’s Top 5 Most Expensive Motorcycles: A Luxury on Two Wheels");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Dec62024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/electric-vs-petrol-two-wheelers-which-is-better-for-you")]
        public IActionResult Dec182024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Electric vs Petrol Two-Wheelers: Which is Better for You?");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Dec182024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-10-affordable-two-wheelers-under-₹1-lakh-in-india")]
        public IActionResult Dec202024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 10 Affordable Two-Wheelers Under ₹1 Lakh in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Dec202024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-five-cruiser-bikes-in-india-for-long-distance-riders")]
        public IActionResult Dec232024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top Five Cruiser Bikes in India for Long-Distance Riders");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Dec232024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-five-two-wheeler-electric-vehicles-under-2-lakh-in-india")]
        public IActionResult Dec252024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top Five Two Wheeler Electric Vehicles under 2 Lakh in India.");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Dec252024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/the-all-new-kia-syros-a-comprehensive-review")]
        public IActionResult Dec262024BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("The All-New Kia Syros: A Comprehensive Review");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2024/Dec262024BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/honda-qC1-electric-scooter-the-future-of-green-mobility")]
        public IActionResult Jan72025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Honda QC1 Electric Scooter: The Future of Green Mobility");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Jan72025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-10-two-wheeler-brands-for-commuters-in-2025")]
        public IActionResult Jan162025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 10 Two-Wheeler Brands for Commuters in 2025");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Jan162025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/toyota-taisor-vs-maruti-fronx-a-detailed-comparison")]
        public IActionResult Jan172025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Toyota Taisor vs Maruti Fronx: A Detailed Comparison");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Jan172025BlogDetails1.cshtml", blogsDetails);
        }


        [Route("blogs/hyundai-creta-ev-vs-maruti-suzuki-e-vitara-a-comprehensive-comparison")]
        public IActionResult Jan222025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Hyundai Creta EV vs. Maruti Suzuki e-Vitara: A Comprehensive Comparison");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Jan222025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/how-to-choose-the-best-two-wheeler-for-your-daily-commute")]
        public IActionResult Jan242025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("How to Choose the Best Two-Wheeler for Your Daily Commute");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Jan242025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-safety-tips-for-two-wheeler-riders")]
        public IActionResult Feb62025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top Safety Tips for Two-Wheeler Riders");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Feb62025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-two-wheeler-electric-vehicles-under-₹1-5-lakh-in-india")]
        public IActionResult Mar192025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Two-Wheeler Electric Vehicles Under ₹1.5 Lakh in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Mar192025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-electric-scooters-in-india-based-on-battery-capacity-&-highest-range-per-charge")]
        public IActionResult Mar202025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Electric Scooters in India Based on Battery Capacity & Highest Range Per Charge");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Mar202025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/best-5-electric-scooters-in-india-with-200-km-range")]
        public IActionResult Mar212025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Best 5 Electric Scooters in India With 200+ km Range");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Mar212025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/komaki-hi-speed-electric-scooters-best-models-&-prices")]
        public IActionResult Mar222025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Komaki Hi-Speed Electric Scooters: Best Models & Prices");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Mar222025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/the-10L-boosterjet-turbo-engine-the-heart-of-maruti-suzukis-sporty-side")]
        public IActionResult Apr142025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("The 1.0L Boosterjet Turbo Engine: The Heart of Maruti Suzuki’s Sporty Side");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Apr142025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/cFMoto-450MT-expected-launch-date-specifications-best-price-in-india")]
        public IActionResult Apr172025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("CFMoto 450MT: Expected Launch Date, Specifications & Best Price in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Apr172025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/tata-sierra-eV-and-iCE")]
        public IActionResult May122025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Tata Sierra EV vs. Tata Sierra ICE");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/May122025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/best-bikes-in-the-150cc-segment-in-india")]
        public IActionResult May232025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Best Bikes in the 150cc Segment in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/May232025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-royal-enfield-bikes-in-india-2025-edition")]
        public IActionResult May282025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Royal Enfield Bikes in India 2025 Edition");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/May282025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/suzuki-e-access-a-trusted-name-electrified-for-the-future")]
        public IActionResult June022025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Suzuki e Access A Trusted Name Electrified for the Future");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June022025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/top-5-budget-friendly-cars-with-sunroofs-in-india")]
        public IActionResult June022025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Top 5 Budget-Friendly Cars with Sunroofs in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June022025BlogDetails2.cshtml", blogsDetails);
        }
        [Route("blogs/tata-altroz-facelift-2025-what’s-new")]
        public IActionResult June042025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Tata Altroz Facelift 2025 – What’s New?");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June042025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/tata-harrier-eV")]
        public IActionResult June042025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Tata Harrier EV: Everything You Need to Know About the Upcoming Electric SUV");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June042025BlogDetails2.cshtml", blogsDetails);
        }
        [Route("blogs/kawasaki-z900")]
        public IActionResult June052025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("2025 Kawasaki Z900: What’s New in the King of Streetfighters");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June052025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/royal-enfield-guerrilla-450-price-features-specs-more")]
        public IActionResult June112025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Royal Enfield Guerrilla 450: Price, Features, Specs & More");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June112025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/top-5-trending-electric-scooters-in-india")]
        public IActionResult June132025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Trending Electric Scooters in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June132025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/best-bikes-for-long-rides-in-india-touring-friendly-picks")]
        public IActionResult June162025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Best Bikes for Long Rides in India – Touring Friendly Picks (2025 Edition)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June162025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/royal-enfield-vs-jawa–best-cruiser-bike-comparison-2025")]
        public IActionResult June172025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Royal Enfield vs Jawa – Best Cruiser Bike Comparison (2025) | BikeCarHub");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June172025BlogDetails1.cshtml", blogsDetails);
        }


        [Route("blogs/hyundai-i20-vs-tata-altroz-2025-comparison")]
        public IActionResult June182025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Hyundai i20 vs Tata Altroz – 2025 Comparison");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June182025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/manual-vs-automatic-cars-in-india-2025-which-one-right-for-you")]
        public IActionResult June182025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Manual vs Automatic Cars in India (2025): Which One’s Right for You?");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June182025BlogDetails2.cshtml", blogsDetails);
        }

        [Route("blogs/ev-vs-petrol-bikes-which-one-should-you-buy-in-2025")]
        public IActionResult June192025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("EV vs Petrol Bikes: Which One Should You Buy in 2025? | BikeCarHub");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June192025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/top-10-indian-150-160cc-bikes-in-india-2025-best-mileage-style-value")]
        public IActionResult June192025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Top 10 Indian 150-160cc Bikes in India (2025) – Best Mileage, Style & Value | BikeCarHub");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June192025BlogDetails2.cshtml", blogsDetails);
        }

        [Route("blogs/hunter-350-vs-bullet-350–detailed-cruiser-bike-comparison")]
        public IActionResult June202025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Hunter 350 vs Bullet 350 – Detailed Cruiser Bike Comparison (2025) | BikeCarHub");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June202025BlogDetails1.cshtml", blogsDetails);
        }


        [Route("blogs/best-electric-cars-in-india-under-15 lakh")]
        public IActionResult June202025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Best Electric Cars in India (Under ₹15 Lakh) – Mid 2025 Guide");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June202025BlogDetails2.cshtml", blogsDetails);
        }


        [Route("blogs/best-first-buy-cars-in-india-2025")]
        public IActionResult June232025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Best First buy Cars in India (2025)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June232025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/honda-activa-6g-vs-tvs-jupiter-125–full-comparison-of-mileage-features-performance-and-price")]
        public IActionResult June232025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Honda Activa 6G vs TVS Jupiter 125 – Full Comparison of Mileage, Features, Performance, and Price (2025) | BikeCarHub");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June232025BlogDetails2.cshtml", blogsDetails);
        }

        [Route("blogs/honda-amaze-vs-tata-tigor-detailed-comparison-price-mileage-features")]
        public IActionResult June232025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("Honda Amaze vs Tata Tigor: Detailed Comparison - Price, Mileage, Features");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June232025BlogDetails3.cshtml", blogsDetails);
        }

        [Route("blogs/bajaj-chetak-3501-vs-honda-activa-electric-a-complete-comparison-for-2025")]
        public IActionResult June242025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Bajaj Chetak 3501 vs Honda Activa Electric: A Complete Comparison for 2025");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June242025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/bajaj-chetak-3502-vs-tvs-iqube-detailed-comparison-of-indias-leading-electric-scooters-in-2025")]
        public IActionResult June242025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Bajaj Chetak 3502 vs TVS iQube: Detailed Comparison of India’s Leading Electric Scooters in 2025");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June242025BlogDetails2.cshtml", blogsDetails);
        }

        [Route("blogs/best-cars-under-10-lakh-in-india")]
        public IActionResult June242025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("Best Cars Under ₹10 Lakh in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June242025BlogDetails3.cshtml", blogsDetails);
        }

        [Route("blogs/the-maruti-brezza-and-skoda-kylaq-which-one-is-better-for-you")]
        public IActionResult June252025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("The Maruti Brezza and Škoda Kylaq, Which one is better for you.");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June252025BlogDetails3.cshtml", blogsDetails);
        }


        [Route("blogs/maruti-brezza-and-the-tata-nexon-which-one-is-best-for-you")]
        public IActionResult June252025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Maruti Brezza and the Tata Nexon, which one is best for you.");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June252025BlogDetails2.cshtml", blogsDetails);
        }


        [Route("blogs/the-maruti-brezza-and-the-kia-sonet-which-one-is-best-for-you")]
        public IActionResult June252025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("The Maruti Brezza and the Kia Sonet, which one is best for you.");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June252025BlogDetails3.cshtml", blogsDetails);
        }



        [Route("blogs/the-maruti-brezza-and-hyundai-venue-which-one-is-better-for-you")]
        public IActionResult June252025BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("The Maruti Brezza and Hyundai Venue, which one is better for you.");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June252025BlogDetails4.cshtml", blogsDetails);
        }


        [Route("blogs/kia-sonet-vs-hyundai-venue-the-ultimate-compact-suv-showdown")]
        public IActionResult June262025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Kia Sonet vs Hyundai Venue: The Ultimate Compact SUV Showdown");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June262025BlogDetails1.cshtml", blogsDetails);
        }



        [Route("blogs/kia-sonet-vs-hyundai-venue-vs-tata-nexon-vs-maruti-suzuki-brezza-vs-skoda-kylaq")]
        public IActionResult June262025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Kia Sonet vs Hyundai Venue vs Tata Nexon vs Maruti Suzuki Brezza vs Škoda Kylaq");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June262025BlogDetails2.cshtml", blogsDetails);
        }


        [Route("blogs/ktm-duke-200-vs-bajaj-pulsar-ns200-full-comparison-of-performance-features-mileage-and-price")]
        public IActionResult June262025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("KTM Duke 200 vs Bajaj Pulsar NS200 – Full Comparison of Performance, Features, Mileage, and Price (2025) | BikeCarHub");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June262025BlogDetails3.cshtml", blogsDetails);
        }


        [Route("blogs/ktm-duke-200-vs-yamaha-R15–full-comparison-of-performance-features-and-value")]
        public IActionResult June262025BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("KTM Duke 200 vs Yamaha R15 – Full Comparison of Performance, Features, and Value (2025) | BikeCarHub");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June262025BlogDetails4.cshtml", blogsDetails);
        }

        [Route("blogs/ bajaj-pulsar-150-vs-tvs-apache-rtr-160–detailed-comparison")]
        public IActionResult June272025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Bajaj Pulsar 150 vs TVS Apache RTR 160 – 2025 Detailed Comparison");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June272025BlogDetails1.cshtml", blogsDetails);
        }


        [Route("blogs/suzuki-gixxer-sf-vs-yamaha-fz25–detailed-comparison-of-performance-features-and-value")]
        public IActionResult June272025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Suzuki Gixxer SF vs Yamaha FZ25 – Detailed Comparison of Performance, Features, and Value (2025) | BikeCarHub");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June272025BlogDetails2.cshtml", blogsDetails);
        }


        [Route("blogs/the-tata-nexon-ev-and-mahindra-xuv400-ev")]
        public IActionResult June272025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("The Tata Nexon EV and Mahindra XUV400 EV");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June272025BlogDetails3.cshtml", blogsDetails);
        }

        [Route("blogs/tata-punch-vs-hyundai-exter-india-micro-suv-battle")]
        public IActionResult June272025BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("Tata Punch vs Hyundai Exter (2025): India’s Micro SUV Battle");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June272025BlogDetails4.cshtml", blogsDetails);
        }


        [Route("blogs/kia-sonet-vs-skoda-kylaq–compact-suvs-redefined")]
        public IActionResult June272025BlogDetails5()
        {
            var blogsDetails = GetBlogDetails("Kia Sonet vs Škoda Kylaq (2025) – Compact SUVs Redefined");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June272025BlogDetails5.cshtml", blogsDetails);
        }


        [Route("blogs/kia-sonet-vs-tata-nexon–which-subcompact-suv-wins")]
        public IActionResult June272025BlogDetails6()
        {
            var blogsDetails = GetBlogDetails("Kia Sonet vs Tata Nexon (2025) – Which Subcompact SUV Wins?");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June272025BlogDetails6.cshtml", blogsDetails);
        }

       

        [Route("blogs/hyundai-venue-vs-skoda-kylaq–2025-compact-suv-showdown")]
        public IActionResult June302025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Hyundai Venue vs Škoda Kylaq – 2025 Compact SUV Showdown");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June302025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/tvs-vs-hero")]
        public IActionResult July012025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("TVS Ntorq 125 vs Hero Xtreme 125R");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July012025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/tvs-jupiter-vs-honda-activa-2025-scooter-comparison")]
        public IActionResult June302025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("TVS Jupiter vs Honda Activa: 2025 Scooter Comparison");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June302025BlogDetails3.cshtml", blogsDetails);
        }

        [Route("blogs/top-5-long-range-evs-in-india-for-2025")]
        public IActionResult June302025BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("Top 5 Long Range EVs in India for 2025");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June302025BlogDetails4.cshtml", blogsDetails);
        }

        [Route("blogs/top-5-commuter-bikes-for-daily-use-in-india")]
        public IActionResult June302025BlogDetails5()
        {
            var blogsDetails = GetBlogDetails("Top 5 Commuter Bikes for Daily Use in India (2025 Guide)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June302025BlogDetails5.cshtml", blogsDetails);
        }

        [Route("blogs/top-10-mileage-fuel-efficient-cars-in-india")] 
        public IActionResult June302025BlogDetails6()
        {
            var blogsDetails = GetBlogDetails("Top 10 Mileage Fuel Efficient Cars in India"); 
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June302025BlogDetails6.cshtml", blogsDetails);
        }

        [Route("blogs/top-10-upcoming-bikes-in-india")]
        public IActionResult June302025BlogDetails7()
        {
            var blogsDetails = GetBlogDetails("Top 10 Upcoming Bikes in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June302025BlogDetails7.cshtml", blogsDetails);
        }

        [Route("blogs/top-5-budget-friendly-bikes-in-india-under-1-lakh")]
        public IActionResult June302025BlogDetails8()
        {
            var blogsDetails = GetBlogDetails("Top 5 Budget-Friendly Bikes in India Under ₹1 Lakh");
            if (blogsDetails == null)

            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June302025BlogDetails8.cshtml", blogsDetails);
        }

        [Route("blogs/yezdi-adventure-vs-royal-enfield-himalayan")]
        public IActionResult June302025BlogDetails9()
        {
            var blogsDetails = GetBlogDetails("Yezdi Adventure vs Royal Enfield Himalayan 450");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/June302025BlogDetails9.cshtml", blogsDetails);
        }

        [Route("blogs/tata-punch-vs-hyundai-exter-indias-micro-suv-battle")]
        public IActionResult July012025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Tata Punch vs Hyundai Exter (2025): India’s Micro SUV Battle");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July012025BlogDetails2.cshtml", blogsDetails);
        }

        [Route("blogs/meteor-vs-yezdi-roadster-cruiser-bike-comparison")]
        public IActionResult July022025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Meteor 350 vs Yezdi Roadster: Cruiser Bike Comparison 2025");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July022025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/maruti-swift-vs-tata-punch")]
        public IActionResult July022025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Maruti Swift vs Tata Punch");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July022025BlogDetails2.cshtml", blogsDetails);
        }

        [Route("blogs/hyundai-vs-maruti-swift")]
        public IActionResult July022025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("Hyundai vs Maruti Swift");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July022025BlogDetails3.cshtml", blogsDetails);
        }

        [Route("blogs/tata-motors-vs-maruti-suzuki")]
        public IActionResult July022025BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("Tata Motors vs Maruti Suzuki");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July022025BlogDetails4.cshtml", blogsDetails);
        }


        [Route("blogs/tata-nexon-vs-skoda-kylaq")]
        public IActionResult July022025BlogDetails5()
        {
            var blogsDetails = GetBlogDetails("Tata Nexon vs Škoda Kylaq");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July022025BlogDetails5.cshtml", blogsDetails);
        }


        [Route("blogs/honda-shine-vs-hero-splendor-plus")]
        public IActionResult July032025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Honda Shine vs Hero Splendor Plus – Which Is Better for You in 2025?");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July032025BlogDetails1.cshtml", blogsDetails);
        }



        [Route("blogs/how-to-apply-for-a-driving-license-online-in-india")]
        public IActionResult July032025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("How to Apply for a Driving License Online in India (2025 Guide)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July032025BlogDetails2.cshtml", blogsDetails);
        }



        [Route("blogs/bajaj-chetak-vs-tvs-iqube-vs-ather-rizta-s-vs-honda-activa-electric-vs-ola-s1-pro")]
        public IActionResult July032025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("Bajaj Chetak 3501 vs TVS iQube vs Ather Rizta s vs Honda Activa Electric vs Ola S1 Pro+ - Full Comparison");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July032025BlogDetails3.cshtml", blogsDetails);
        }



        [Route("blogs/indias-top-suvs-under-15 lakh")]
        public IActionResult July032025BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("India's Top SUVs Under ₹15 Lakh 2025 – Petrol & Diesel");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July032025BlogDetails4.cshtml", blogsDetails);
        }


        [Route("blogs/hatchback-vs-sedan")]
        public IActionResult July032025BlogDetails5()
        {
            var blogsDetails = GetBlogDetails("Hatchback vs Sedan");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July032025BlogDetails5.cshtml", blogsDetails);
        }


        [Route("blogs/rc-transfer-process-for-second-hand-vehicles")]
        public IActionResult July042025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("RC Transfer Process for Second-Hand Vehicles");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July042025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/how-to-check-rc-insurance-challan-online-in-india")]
        public IActionResult July042025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("How to check RC Insurance Challan Online in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July042025BlogDetails2.cshtml", blogsDetails);
        }

        [Route("blogs/how-to-transfer-bike-ownership-online-in-india")]
        public IActionResult July042025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("How to Transfer Bike Ownership Online in India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July042025BlogDetails3.cshtml", blogsDetails);
        }

        [Route("blogs/kia-sonet-hyundai-venue-tata-nexon-maruti-suzuki-brezza-and-skoda-kylaq")]
        public IActionResult July042025BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("Kia Sonet, Hyundai Venue, Tata Nexon, Maruti Suzuki Brezza, and Skoda Kylaq");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July042025BlogDetails4.cshtml", blogsDetails);
        }

        [Route("blogs/new-driving-rules-in-india–complete-guide-for-drivers")]
        public IActionResult July042025BlogDetails5()
        {
            var blogsDetails = GetBlogDetails("New Driving Rules in India 2025 – Complete Guide for Drivers");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July042025BlogDetails5.cshtml", blogsDetails);
        }

        [Route("blogs/tata-nexon-vs-skoda-kylaq-deep-dive-into-indias-b-segment-suv-battle")]
        public IActionResult July042025BlogDetails6()
        {
            var blogsDetails = GetBlogDetails("Tata Nexon vs Škoda Kylaq: Deep Dive into India's B Segment SUV Battle");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July042025BlogDetails6.cshtml", blogsDetails);
        }


        [Route("blogs/tata-nexon-vs-hyundai-venue-compact-suv-face-Off")]
        public IActionResult July042025BlogDetails7()
        {
            var blogsDetails = GetBlogDetails("Tata Nexon vs Hyundai Venue: Compact SUV Face-Off");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July042025BlogDetails7.cshtml", blogsDetails);
        }

        [Route("blogs/ kia-sonet-vs-skoda-kylaq–compact-suvs-redefined")]
        public IActionResult July052025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Kia Sonet vs Škoda Kylaq (2025) – Compact SUVs Redefined");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July052025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/ kia-Sonet-vs-tata-nexon–which-subcompact-suv-wins")]
        public IActionResult July052025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("Kia Sonet vs Tata Nexon (2025) – Which Subcompact SUV Wins?");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July052025BlogDetails2.cshtml", blogsDetails);
        }

        [Route("blogs/tata-nexon-ev-and-mahindra-xuv400-ev")]
        public IActionResult July052025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("Tata Nexon EV and Mahindra XUV400 EV");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July052025BlogDetails3.cshtml", blogsDetails);
        }

        [Route("blogs/things-to-check-before-buying-a-second-hand-bike-in-india")]
        public IActionResult July052025BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("Things to Check Before Buying a Second-Hand Bike in India (2025 Guide)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July052025BlogDetails4.cshtml", blogsDetails);
        }

        [Route("blogs/top-5-best-scooty-for-ladies-in-india")]
        public IActionResult July102025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Best Scooty for Ladies in India 2025 – Stylish, Lightweight & Easy to Ride");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July102025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/kia-carens-clavis-ev")]
        public IActionResult July172025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Kia Carens Clavis EV: The Bold New 7-Seater Electric SUV for India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July172025BlogDetails1.cshtml", blogsDetails);
        }


        [Route("blogs/vinfast-vf6-vf7-electric-suvs-launch-in-india")]
        public IActionResult July182025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("VinFast VF6 & VF7 Electric SUVs Launch in India – Price, Features, Range & Booking Info");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July182025BlogDetails1.cshtml", blogsDetails);
        }


        [Route("blogs/top-5-best-bikes-for-college-students-under-lakh-in-india")]
        public IActionResult July212025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Best Bikes for College Students Under ₹1.5 Lakh in India (2025)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July212025BlogDetails1.cshtml", blogsDetails);
        }


        [Route("blogs/top-5-super-bikes-in-india–bikecarhub-official")]
        public IActionResult July222025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Top 5 Super Bikes in India 2025 – BikeCarHub Official");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July222025BlogDetails1.cshtml", blogsDetails);
        }


        [Route("blogs/tesla-model-y-full-review-specs-variants-features")]
        public IActionResult July232025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Tesla Model Y: Full Review, Specs, Variants & Features – The Ultimate All-Electric SUV");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July232025BlogDetails1.cshtml", blogsDetails);
        }

        [Route("blogs/renault-triber-2025-facelift")]
        public IActionResult July242025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Renault Triber 2025 Facelift – India’s Most Versatile 7-Seater Just Got a Stylish Upgrade");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July242025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/most-powerful-bikes-under-two-lakhs-in-india-2025")]
        public IActionResult July292025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Most Powerful Bikes Under ₹2 Lakhs in India (2025)");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/July292025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/hero-vs-honda-Which-bike-brand-is-better-under-twolakh-in-india")]
        public IActionResult Aug042025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Hero vs Honda: Which Bike Brand is Better Under ₹1.5 Lakh in India (2025)?");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Aug042025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/royal-enfield-interceptor-650-vs-continental-GT-650")]
        public IActionResult Aug082025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Royal Enfield Interceptor 650 vs Continental GT 650: Which 650cc Twin Should You Ride in 2025?");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Aug082025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/renault-kiger-facelift-launching-on-24-august-2025-price-features-and-everything-you-need-to-know")]
        public IActionResult Aug192025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Renault Kiger Facelift Launching on 24 August 2025 – Price, Features, and Everything You Need to Know");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Aug192025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/road-and-highway-types-in-india-a-complete-guide-to-classifications-and-rules")]
        public IActionResult Sept122025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Road and Highway Types in India: A Complete Guide to Classifications and Rules");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Sept122025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/maruti-victoris-mileage-features-variants-complete-details")]
        public IActionResult Sept152025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Maruti Victoris: Mileage, Features, Variants & Complete Details");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Sept152025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/royal-enfield-bike-prices-after-GST-full-list-of-cheaper-costlier-models")]
        public IActionResult Sept162025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Royal Enfield Bike Prices After GST 2.0: Full List of Cheaper & Costlier Models in 2025");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Sept162025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/choosing-the-right-bike-insurance-coverage-types-policy-checklist-and-expert-tips")]
        public IActionResult Oct132025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Choosing the Right Bike Insurance: Coverage Types, Policy Checklist, and Expert Tips");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Oct132025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/new-mahindra-bolero-2025-boss")]
        public IActionResult Oct132025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("New Mahindra Bolero 2025 BOSS");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Oct132025BlogDetails2.cshtml", blogsDetails);
        }
        [Route("blogs/the-electric-orbit-detailed-review-of-the-tvs-orbiter-scooter-and-its-future-in-urban-mobility")]
        public IActionResult Oct142025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("The Electric Orbit: Detailed Review of the TVS Orbiter Scooter and Its Future in Urban Mobility");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Oct142025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/tvs-apache-rtx-the-definitive-review-of-the-rally-tourer-extreme-price-specs-and-features")]
        public IActionResult Oct162025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("TVS Apache RTX: The Definitive Review of the Rally Tourer Extreme - Price, Specs, and Features");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Oct162025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/the-ultimate-road-trip-prep")]
        public IActionResult Oct272025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("The Ultimate Road Trip Prep");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Oct272025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/hyundai-venue")]
        public IActionResult Nov102025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Hyundai VENUE: The New Urban Icon - Unpacking the Compact SUV's Tech, Design, and Value");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Nov102025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/tata-sierra")]
        public IActionResult Nov102025BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("The Legend Reborn: Unveiling the All-New Tata Sierra 2025 – A Definitive BikeCarHub Review");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Nov102025BlogDetails2.cshtml", blogsDetails);
        }
        [Route("blogs/tata-sierra-2025")]
        public IActionResult Nov102025BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("Tata Sierra: The Return of a Legend That Dares to Escape Mediocrity");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Nov102025BlogDetails3.cshtml", blogsDetails);
        }
        [Route("blogs/mahindraBE-formulaE-edition")]
        public IActionResult Nov102025BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("Mahindra BE 6 Formula E Edition");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Nov102025BlogDetails4.cshtml", blogsDetails);
        }
        [Route("blogs/kia-seltos")]
        public IActionResult Dec012025BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("The All-New KIA Seltos: A Comprehensive Review of the 'Badass. Forever.' Mid-Size SUV");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2025/Dec012025BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/mahindra-xUV-7XO")]
        public IActionResult Jan012026BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Mahindra XUV 7XO: Price, Features, Specifications, Mileage & Complete Review");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/Jan012026BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/tata-harrier-petrol")]
        public IActionResult Jan012026BlogDetails2()
        {
            var blogsDetails = GetBlogDetails("New Tata Harrier Petrol Version: A Powerful, Premium & Tech-Loaded SUV for Modern India");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/Jan012026BlogDetails2.cshtml", blogsDetails);
        }
        [Route("blogs/bMW-new-x3")]
        public IActionResult Jan012026BlogDetails3()
        {
            var blogsDetails = GetBlogDetails("BMW New X3: Price, Features, Specifications & Complete Review");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/Jan012026BlogDetails3.cshtml", blogsDetails);
        }
        [Route("blogs/all-new-tata-punch-facelift")]
        public IActionResult Jan012026BlogDetails4()
        {
            var blogsDetails = GetBlogDetails("All-New Tata Punch Facelift 2025 – Price, Variants, Features, Specifications & Complete Buyer’s Guide");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/Jan012026BlogDetails4.cshtml", blogsDetails);
        }
        [Route("blogs/new-bMW2-series-gran-coupe")]
        public IActionResult Jan012026BlogDetails5()
        {
            var blogsDetails = GetBlogDetails("The New BMW 2 Series Gran Coupe: Price, Features, Specs & Full Review");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/Jan012026BlogDetails5.cshtml", blogsDetails);
        }
        [Route("blogs/the-new-skoda-kushaq")]
        public IActionResult Jan012026BlogDetails6()
        {
            var blogsDetails = GetBlogDetails("The New Skoda Kushaq: A Perfect Blend of European Engineering and Indian Soul");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/Jan012026BlogDetails6.cshtml", blogsDetails);
        }
        [Route("blogs/nissan-gravite")]
        public IActionResult Feb012026BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("Nissan Gravite: The New Class of Togetherness Redefining Indian Family Mobility");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/Feb012026BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/mg-majestor")]
        public IActionResult Mar012026BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("MG Majestor 2026: India's Most Dominant Off-Road SUV");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/Mar012026BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/new-renault-duster")]
        public IActionResult Apr012026BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("The New Renault Duster: A Bold Comeback with Hybrid Power, Smart Tech & Rugged Style");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/Apr012026BlogDetails1.cshtml", blogsDetails);
        }
        [Route("blogs/bmw-F-450-GS")]
        public IActionResult May012026BlogDetails1()
        {
            var blogsDetails = GetBlogDetails("BMW F 450 GS India Launch: Price, Specs, Features & Complete Review");
            if (blogsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/Blogs/2026/May012026BlogDetails1.cshtml", blogsDetails);
        }
        private Cars_Bikes.Models.Blogs GetBlogDetails(string blogsHeading)
        {
            var blogsItem = _context.Blogs
                .FirstOrDefault(n => n.BlogHeading == blogsHeading);
            if (blogsItem == null)
            {
                // Handle the case where the bike is not found
                return null;
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.AllBrand = Allbrand;
            var Blogs = _context.Blogs.OrderByDescending(m => m.Date).Take(10).ToList();
            ViewBag.Blogs = Blogs;
            //var newsItem = _context.TWLatestNews.Where(n => n.NewsHeading == newsHeading).ToList();
            //var allNews = _context.TWLatestNews.OrderByDescending(m => m.Date).Take(90).ToList();
            //ViewBag.AllNews = allNews;
            //var brand = _context.TwowheelerBrands.ToList();
            //ViewBag.Brand = brand;
            return blogsItem;
        }
    }
}
