using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars_Bikes.Models;
using Cars_Bikes.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Cars_Bikes.Controllers
{
    public class TWController : Controller
    {
        private readonly TwoWheelerDB _context;
        public TWController(TwoWheelerDB context)
        {
            _context = context;
        }
        //function for creating TwoWheelerBrands
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.BrandList = _context.TwowheelerBrands
        .Select(b => new SelectListItem
        {
            Value = b.TWBrandId.ToString(),
            //Value = b.BrandName,
            Text = b.BrandName
            //Text = b.TWBrandId.ToString()
        })
        .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cars_Bikes.Models.TwoWheeler model)
        {
            Debug.WriteLine("Saving data");
            ViewBag.BrandList = _context.TwowheelerBrands
                               .Select(b => new SelectListItem
                               {
                                   Value = b.TWBrandId.ToString(),
                                   Text = b.BrandName
                               })
                               .ToList();
            model.TwoWheelerBrands = _context.TwowheelerBrands.FirstOrDefault(b => b.TWBrandId == model.TwoWBrandId);
            Debug.WriteLine("Twowheelerbrandsvalue");
            Debug.WriteLine(model.TwoWheelerBrands);
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    Debug.WriteLine($"Field: {state.Key} — Error: {state.Value.Errors[0].ErrorMessage}");
                }
            }
            if (ModelState.IsValid)
            {
                /*var twoWheeler = new TwoWheeler
                {
                    TwoWheelerName = model.TwoWheelerName,
                    Price = model.Price,
                    BasePrice = model.BasePrice,
                    TopPrice = model.TopPrice,
                    Brand = model.Brand,
                    Type = model.Type,
                    TwoWBrandId = model.TwoWBrandId,
                    TWImage = model.TWImage,
                    LaunchDate = model.LaunchDate,
                    IsEV = model.IsEV ?? false,
                    IsActive = model.IsActive ?? false,
                    NotesOrComments = model.NotesOrComments,
                    Discription = model.Discription,
                    CreatedDateTime = DateTime.Now
                };*/
                _context.Twowheelers.Add(model);
                Debug.WriteLine("Saving brand");
                _context.SaveChanges();
                Debug.WriteLine("Saving to datbase");
                return RedirectToAction("Success");
            }
            Debug.WriteLine("Saving failed");
            return View(model);
        }
        public IActionResult Success(string source)
        {
            ViewBag.Source = source;
            return View();
        }
        //function for creating TWVarient
        [HttpGet]
        public IActionResult CreateTWVarient()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            return View();
        }

        [HttpPost]
        public IActionResult CreateTWVarient(TWVarient varient)
        {
            Debug.WriteLine("Saving data");
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    Debug.WriteLine($"Field: {state.Key} — Error: {state.Value.Errors[0].ErrorMessage}");
                }
            }
            if (ModelState.IsValid)
            {
                varient.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == varient.TwoWheelerId);
                Debug.WriteLine("Varient2whellervalue");
                Debug.WriteLine(varient.TwoWheeler);
                _context.TWVarients.Add(varient);
                Debug.WriteLine("Saving variant");
                _context.SaveChanges();
                Debug.WriteLine("Saving to datbase");
                // return RedirectToAction("Success"); // Or Dashboard
                //return RedirectToAction("Index", "AdminLogin");
                //return RedirectToAction("CreateTWSpec");
                return RedirectToAction("CreateTWSpec");
                //TempData["TwoWheelerId"] = varient.TwoWheelerId;
                //TempData["TWVarientId"] = varient.TWVarientId;
                //return RedirectToAction("CreateSpecAndSafety");
            }
            Debug.WriteLine("Saving failed");
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", varient.TwoWheelerId);
           
            return View(varient);
        }
        //function for creating TWSpecification
        [HttpGet]
        public IActionResult CreateTWSpec()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            //return View();
            var spec = new TWSpec();  
            ViewData["Title"] = "Add Two Wheeler Specification";
            return View(spec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWSpec(TWSpec spec)
        {
            Debug.WriteLine("Saving data");
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    Debug.WriteLine($"Field: {state.Key} — Error: {state.Value.Errors[0].ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {
                Debug.WriteLine("Specs value enter");
                spec.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == spec.TwoWheelerId);
                spec.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == spec.TWVarientId);
                _context.TWSpec.Add(spec);
                Debug.WriteLine("Saving changes");
                _context.SaveChanges();
                Debug.WriteLine("Saved successfully");
                return RedirectToAction("CreateTWSafety");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", spec.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", spec.TWVarientId);
            Debug.WriteLine("Not saved");
            return View(spec);
        }

        //[HttpGet]
        //public IActionResult EditTWSpec(int? id)
        //{
        //    Debug.WriteLine("Editing spec details");
        //    if (id == null) return NotFound();

        //    var spec = _context.TWSpec.Find(id);
        //    if (spec == null) return NotFound();

        //    ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", spec.TwoWheelerId);
        //    ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", spec.TWVarientId);

        //    return View("CreateTWSpec", spec); // Reuse same view
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditTWSpec(TWSpec spec)
        //{
        //    Debug.WriteLine("Editing spec details post");
        //    if (ModelState.IsValid)
        //    {
        //        spec.TwoWheeler = null; // Prevent EF from trying to re-insert navigation properties
        //        spec.TWVarients = null;
        //        Debug.WriteLine("Updating spec details");
        //        _context.TWSpec.Update(spec);
        //        Debug.WriteLine("Update successfully");
        //        _context.SaveChanges();

        //        return RedirectToAction("Success"); // Or wherever you want
        //    }
        //    Debug.WriteLine("Editing spec failed");
        //    ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", spec.TwoWheelerId);
        //    ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", spec.TWVarientId);

        //    return View("CreateTWSpec", spec);
        //}

        //public IActionResult Index()
        //{
        //    var specs = _context.TWSpec
        //        .Include(s => s.TwoWheeler)
        //        .Include(s => s.TWVarients)
        //        .ToList();
        //    return View(specs);
        //}
        //function for showing table for updating and deleting TWSpec
        public IActionResult Index(string searchTerm)
        {
            var specs = _context.TWSpec
                .Include(s => s.TwoWheeler)
                .Include(s => s.TWVarients)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                specs = specs.Where(s => s.TWName.Contains(searchTerm));
            }

            return View(specs.ToList());
        }

        //function updating TWSpec
        [HttpGet]
        public IActionResult EditTWSpec(int id)
        {
            var spec = _context.TWSpec.FirstOrDefault(s => s.TWSpecId == id);

            if (spec == null)
            {
                return NotFound();
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", spec.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", spec.TWVarientId);

            return View(spec);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWSpec(TWSpec spec)
        {
            Debug.WriteLine("Edit TW Spec Called");
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Model is Valid");
                spec.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == spec.TwoWheelerId);
                spec.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == spec.TWVarientId);
                Debug.WriteLine("Updating Changes");
                _context.TWSpec.Update(spec);
                Debug.WriteLine("Saving chnages to DB");
                _context.SaveChanges();
                Debug.WriteLine("Redirect to success");
                return RedirectToAction("Success"); // or a success page
            }
            Debug.WriteLine("Update failed");
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", spec.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", spec.TWVarientId);

            return View(spec);
        }
        //function for creating DeleteTWSpec
        public IActionResult DeleteTWSpec(int id)
        {
            var spec = _context.TWSpec
                .Include(s => s.TwoWheeler)
                .Include(s => s.TWVarients)
                .FirstOrDefault(s => s.TWSpecId == id);

            if (spec == null)
            {
                return NotFound();
            }

            return View(spec);
        }

       
        [HttpPost, ActionName("DeleteTWSpec")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var spec = _context.TWSpec.Find(id);
            if (spec != null)
            {
                _context.TWSpec.Remove(spec);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //function for creating TWSafety
        [HttpGet]
        public IActionResult CreateTWSafety()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWSafety(TWSafety safety)
        {
            Debug.WriteLine("Saving data");
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    Debug.WriteLine($"Field: {state.Key} — Error: {state.Value.Errors[0].ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {
                Debug.WriteLine("Specs value enter");
                safety.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == safety.TwoWheelerId);
                safety.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == safety.TWVarientId);
                _context.TWSafety.Add(safety);
                Debug.WriteLine("Saving changes");
                _context.SaveChanges();
                Debug.WriteLine("Saved successfully");
                //return RedirectToAction("Success");
                return RedirectToAction("CreateSpecAndSafety");
            }
            
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", safety.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", safety.TWVarientId);
            Debug.WriteLine("Not saved");
            return View(safety);
        }
        //function for creating Spec andSafety together by submitting a form
        [HttpGet]
        public IActionResult CreateSpecAndSafety()
        {
        
              var model = new TWCombinedViewModel
          {
                  //TWSpec = new TWSpec(),
                  //TWSafety = new TWSafety(),
                  //TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName"),
                  //TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients")
                  TwoWheelers = _context.Twowheelers
            .Select(t => new SelectListItem { Value = t.TwoWheelerId.ToString(), Text = t.TwoWheelerName })
            .ToList(),

                  TWVarients = _context.TWVarients
            .Select(v => new SelectListItem { Value = v.TWVarientId.ToString(), Text = v.Varients })
            .ToList()

              };

            //return View(model);
            if (TempData["TwoWheelerId"] != null && TempData["TWVarientId"] != null)
            {
                ViewBag.TwoWheelerId = TempData["TwoWheelerId"];
                ViewBag.TWVarientId = TempData["TWVarientId"];
            }

            return View(new TWCombinedViewModel
            {
                Spec = new TWSpec(),
                Safety = new TWSafety()
            });
        }

    [HttpPost]
        public IActionResult CreateSpecAndSafety(TWCombinedViewModel model)
        {
                Debug.WriteLine("Saving data");
                foreach (var state in ModelState)
                {
                    if (state.Value.Errors.Count > 0)
                    {
                        Debug.WriteLine($"Field: {state.Key} — Error: {state.Value.Errors[0].ErrorMessage}");
                    }
                }
                model.TwoWheelers = _context.Twowheelers
         .Select(t => new SelectListItem { Value = t.TwoWheelerId.ToString(), Text = t.TwoWheelerName })
         .ToList();

                model.TWVarients = _context.TWVarients
                    .Select(v => new SelectListItem { Value = v.TWVarientId.ToString(), Text = v.Varients })
                    .ToList();
                if (ModelState.IsValid)
            {
                    //model.TwoWheelers = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId);
                    //model.TWVarients = _context.TWVarients.FirstOrDefault(v => model == model.TWVarientId);
                    Debug.WriteLine("Assigning ID");
                    int twoWheelerId = int.Parse(Request.Form["TwoWheelerId"]);
                    int twVarientId = int.Parse(Request.Form["TWVarientId"]);

                    // Assign manually
                    model.Spec.TwoWheelerId = twoWheelerId;
                    model.Spec.TWVarientId = twVarientId;
                    model.Safety.TwoWheelerId = twoWheelerId;
                    model.Safety.TWVarientId = twVarientId;

                    // Optional: Load navigation entities if required
                    model.Spec.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == twoWheelerId);
                    model.Spec.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == twVarientId);
                    model.Safety.TwoWheeler = model.Spec.TwoWheeler;
                    model.Safety.TWVarients = model.Spec.TWVarients;
                    Debug.WriteLine("TwowheelerId" ,model.Spec.TwoWheeler);
                    Debug.WriteLine("TwovarientId", model.Spec.TWVarients);
                    Debug.WriteLine("saving specs");
                    _context.TWSpec.Add(model.Spec);
                    Debug.WriteLine("saving safetyspecs");
                    _context.TWSafety.Add(model.Safety);
                    Debug.WriteLine("saving successfully");
                    _context.SaveChanges();
                return RedirectToAction("Success");
                }

                // If model is invalid, reload dropdowns
                //model.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
                //model.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
         
                Debug.WriteLine("Not saved");
                return View(model);
            
          
        }
        //function for updating TWSafety
        [HttpGet]
        public IActionResult EditTWSafety(int id)
        {
            var safety = _context.TWSafety.FirstOrDefault(s => s.TWSafetyId == id);
            if (safety == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", safety.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", safety.TWVarientId);

            return View(safety);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWSafety(TWSafety safety)
        {
            if (ModelState.IsValid)
            {
                var twoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == safety.TwoWheelerId);
                var varient = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == safety.TWVarientId);

                if (twoWheeler != null)
                    safety.TWName = twoWheeler.TwoWheelerName;

                if (varient != null)
                    safety.Varients = varient.Varients;

                _context.TWSafety.Update(safety);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", safety.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", safety.TWVarientId);

            return View(safety);
        }
        //function for listing TWSafety
        public IActionResult ListTWSafety(string search)
        {
            var safetyList = _context.TWSafety
                .Include(s => s.TwoWheeler)
                .Include(s => s.TWVarients)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                safetyList = safetyList.Where(s =>
                    s.TWName.Contains(search) ||
                    s.Varients.Contains(search) ||
                    s.AdditionalFeatures.Contains(search)
                );
            }

            return View(safetyList.ToList());
        }

        public IActionResult DeleteTWSafety(int id)
        {
            var safety = _context.TWSafety
                .Include(s => s.TwoWheeler)
                .Include(s => s.TWVarients)
                .FirstOrDefault(s => s.TWSafetyId == id);
            if (safety == null) return NotFound();

            return View(safety);
        }
        [HttpPost, ActionName("DeleteTWSafety")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTWSafetyConfirmed(int id)
        {
            var safety = _context.TWSafety.FirstOrDefault(s => s.TWSafetyId == id);
            if (safety == null) return NotFound();

            _context.TWSafety.Remove(safety);
            _context.SaveChanges();
            return RedirectToAction("ListTWSafety");
        }

        //functions for TWTyresandBrakes
        [HttpGet]
        public IActionResult CreateTWTyresAndBrakes()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWTyresAndBrakes(TWTyresAndBrakes model)
        {
            Debug.WriteLine("Saving data");
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    Debug.WriteLine($"Field: {state.Key} — Error: {state.Value.Errors[0].ErrorMessage}");
                }
            }
            if (ModelState.IsValid)
            {
                var twoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == model.TwoWheelerId);
                var varient = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == model.TWVarientId);
                //model.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == model.TwoWheelerId);
                //model.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == model.TWVarientId);
                if (twoWheeler != null) model.TWName = twoWheeler.TwoWheelerName;
                if (varient != null) model.Varients = varient.Varients;
                Debug.WriteLine("Adding data to table");
                _context.TWTyresAndBrakes.Add(model);
                Debug.WriteLine("Saving changes to TW Tyre");
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);

            return View(model);
        }

        //for showing tyreandbrake in table format
        public IActionResult ListTWTyresAndBrakes(string searchTerm)
        {
            var query = _context.TWTyresAndBrakes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(t => t.TWName.Contains(searchTerm) || t.Varients.Contains(searchTerm));
            }

            var list = query.ToList();
            return View(list);
        }

        //for editing tyrebrakes
        [HttpGet]
        public IActionResult EditTWTyresAndBrakes(int id)
        {
            var tyres = _context.TWTyresAndBrakes.FirstOrDefault(t => t.TWTyresAndBrakesId == id);
            if (tyres == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", tyres.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", tyres.TWVarientId);

            return View(tyres);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWTyresAndBrakes(TWTyresAndBrakes model)
        {
            if (ModelState.IsValid)
            {
                var twoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == model.TwoWheelerId);
                var varient = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == model.TWVarientId);

                if (twoWheeler != null) model.TWName = twoWheeler.TwoWheelerName;
                if (varient != null) model.Varients = varient.Varients;

                _context.TWTyresAndBrakes.Update(model);
                _context.SaveChanges();
                return RedirectToAction("ListTWTyresAndBrakes");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }
        //for deleting tyrebrake
        [HttpGet]
        public IActionResult DeleteTWTyresAndBrakes(int id)
        {
            var record = _context.TWTyresAndBrakes.FirstOrDefault(x => x.TWTyresAndBrakesId == id);
            return View(record);
        }

        [HttpPost, ActionName("DeleteTWTyresAndBrakes")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTyresAndBrakes(int id)
        {
            var record = _context.TWTyresAndBrakes.Find(id);
            if (record != null)
            {
                _context.TWTyresAndBrakes.Remove(record);
                _context.SaveChanges();
            }

            return RedirectToAction("ListTWTyresAndBrakes");
        }

        //for tw underpinning
        [HttpGet]
        public IActionResult CreateTWUnderpinning()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWUnderpinning(TWUnderpinning underpinning)
        {
            Debug.WriteLine("Saving data");
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    Debug.WriteLine($"Field: {state.Key} — Error: {state.Value.Errors[0].ErrorMessage}");
                }
            }
                    if (ModelState.IsValid)
            {
                Debug.WriteLine("Setting underpinning data");
                underpinning.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == underpinning.TwoWheelerId);
                underpinning.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == underpinning.TWVarientId);
                Debug.WriteLine("Addding data in table TWunderpinning");
                _context.TWUnderpinnings.Add(underpinning);
                Debug.WriteLine("Ssaving data successsfully");
                _context.SaveChanges();
                return RedirectToAction("ListTWUnderpinning"); // Or wherever you want to redirect
            }
            Debug.WriteLine("Saving failed");
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", underpinning.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", underpinning.TWVarientId);
            return View(underpinning);
        }

        public IActionResult ListTWUnderpinning()
        {
            var list = _context.TWUnderpinnings
                        .Include(u => u.TwoWheeler)
                        .Include(u => u.TWVarients)
                        .ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult EditTWUnderpinning(int id)
        {
            var item = _context.TWUnderpinnings.FirstOrDefault(u => u.TWUnderpinningId == id);
            if (item == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", item.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", item.TWVarientId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWUnderpinning(TWUnderpinning underpinning)
        {
            if (ModelState.IsValid)
            {
                underpinning.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == underpinning.TwoWheelerId);
                underpinning.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == underpinning.TWVarientId);

                _context.TWUnderpinnings.Update(underpinning);
                _context.SaveChanges();
                return RedirectToAction("ListTWUnderpinning");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", underpinning.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", underpinning.TWVarientId);
            return View(underpinning);
        }
        [HttpGet]
        public IActionResult DeleteTWUnderpinning(int id)
        {
            var item = _context.TWUnderpinnings
                .Include(t => t.TwoWheeler)
                .Include(t => t.TWVarients)
                .FirstOrDefault(t => t.TWUnderpinningId == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("DeleteTWUnderpinning")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWUnderpinning(int id)
        {
            var item = _context.TWUnderpinnings.Find(id);
            if (item == null) return NotFound();

            _context.TWUnderpinnings.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("ListTWUnderpinning");
        }
        //Function for engine and transmission
        [HttpGet]
        public IActionResult CreateTWEngineAndTransmission()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWEngineAndTransmission(TWEngineAndTransmission engine)
        {
            if (ModelState.IsValid)
            {
                engine.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == engine.TwoWheelerId);
                engine.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == engine.TWVarientId);
                _context.TWEngineAndTransmissions.Add(engine);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Or wherever you want to redirect
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", engine.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", engine.TWVarientId);
            return View(engine);
        }
        [HttpGet]
        public IActionResult EditTWEngine(int id)
        {
            var engine = _context.TWEngineAndTransmissions.FirstOrDefault(e => e.TWEngineAndTransmissionId == id);
            if (engine == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", engine.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", engine.TWVarientId);

            return View(engine);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWEngine(TWEngineAndTransmission engine)
        {
            if (ModelState.IsValid)
            {
                // Preserve TWName and Varients manually if not included in form
                engine.TWName = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == engine.TwoWheelerId)?.TwoWheelerName;
                engine.Varients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == engine.TWVarientId)?.Varients;

                _context.TWEngineAndTransmissions.Update(engine);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", engine.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", engine.TWVarientId);
            return View(engine);
        }

        [HttpGet]
        public IActionResult DeleteTWEngine(int id)
        {
            var engine = _context.TWEngineAndTransmissions.FirstOrDefault(e => e.TWEngineAndTransmissionId == id);
            if (engine == null) return NotFound();
            return View(engine);
        }
        [HttpPost, ActionName("DeleteTWEngine")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWEngine(int id)
        {
            var engine = _context.TWEngineAndTransmissions.FirstOrDefault(e => e.TWEngineAndTransmissionId == id);
            if (engine != null)
            {
                _context.TWEngineAndTransmissions.Remove(engine);
                _context.SaveChanges();
            }
            return RedirectToAction("ListTWEngine");
        }
        public IActionResult ListTWEngine(string search)
        {
            var query = _context.TWEngineAndTransmissions.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e =>
                    e.TWName.Contains(search) || e.Varients.Contains(search) || e.EngineType.Contains(search));
            }

            var list = query.ToList();
            return View(list);
        }
        //for TW charging
        // GET: Create Charging form
        [HttpGet]
        public IActionResult CreateTWCharging()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        // POST: Submit Charging form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWCharging(TWCharging charging)
        {
            if (ModelState.IsValid)
            {
                charging.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == charging.TwoWheelerId);
                charging.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == charging.TWVarientId);

                _context.TWChargings.Add(charging);
                _context.SaveChanges();
                return RedirectToAction("ListTWCharging");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", charging.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", charging.TWVarientId);
            return View(charging);
        }
        // GET: List
        public IActionResult ListTWCharging()
        {
            var data = _context.TWChargings.Include(c => c.TwoWheeler).Include(c => c.TWVarients).ToList();
            return View(data);
        }

        // GET: Edit
        public IActionResult EditTWCharging(int id)
        {
            var charging = _context.TWChargings.Find(id);
            if (charging == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", charging.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", charging.TWVarientId);

            return View(charging);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWCharging(TWCharging charging)
        {
            if (ModelState.IsValid)
            {
                _context.Update(charging);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", charging.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", charging.TWVarientId);

            return View(charging);
        }

        // GET: Delete
        public IActionResult DeleteTWCharging(int id)
        {
            var charging = _context.TWChargings.FirstOrDefault(c => c.TWChargingId == id);
            if (charging == null) return NotFound();

            return View(charging);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWCharging(int id)
        {
            var charging = _context.TWChargings.Find(id);
            if (charging != null)
            {
                _context.TWChargings.Remove(charging);
                _context.SaveChanges();
            }

            return RedirectToAction("ListTWCharging");
        }
        //function for twchasisandsuspension
        // GET: Create
        [HttpGet]
        public IActionResult CreateTWChassis()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWChassis(TWChassisAndSuspension chassis)
        {
            if (ModelState.IsValid)
            {
                _context.TWChassisAndSuspensions.Add(chassis);
                _context.SaveChanges();
                return RedirectToAction("ListTWChassis");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", chassis.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", chassis.TWVarientId);
            return View(chassis);
        }

        // GET: Edit
        [HttpGet]
        public IActionResult EditTWChassis(int id)
        {
            var chassis = _context.TWChassisAndSuspensions.Find(id);
            if (chassis == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", chassis.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", chassis.TWVarientId);
            return View(chassis);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWChassis(TWChassisAndSuspension chassis)
        {
            if (ModelState.IsValid)
            {
                _context.TWChassisAndSuspensions.Update(chassis);
                _context.SaveChanges();
                return RedirectToAction("ListTWChassis");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", chassis.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", chassis.TWVarientId);
            return View(chassis);
        }

        // GET: Delete
        [HttpGet]
        public IActionResult DeleteTWChassis(int id)
        {
            var chassis = _context.TWChassisAndSuspensions.FirstOrDefault(c => c.TWChassisAndSuspensionId == id);
            return View(chassis);
        }

        // POST: Delete
        [HttpPost, ActionName("DeleteTWChassis")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWChassis(int id)
        {
            var chassis = _context.TWChassisAndSuspensions.Find(id);
            if (chassis != null)
            {
                _context.TWChassisAndSuspensions.Remove(chassis);
                _context.SaveChanges();
            }
            return RedirectToAction("ListTWChassis");
        }

        // GET: List/Search
        [HttpGet]
        public IActionResult ListTWChassis(string searchString)
        {
            var data = _context.TWChassisAndSuspensions.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(c => c.TWName.Contains(searchString) || c.Varients.Contains(searchString));
            }

            return View(data.ToList());
        }
        //For TW Dimension
        // GET: Create
        [HttpGet]
        public IActionResult CreateTWDimensions()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWDimensions(TWDimensionsAndCapacity model)
        {
            if (ModelState.IsValid)
            {
                _context.TWDimensionsAndCapacities.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ListTWDimensions");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }

        // GET: Edit
        [HttpGet]
        public IActionResult EditTWDimensions(int id)
        {
            var model = _context.TWDimensionsAndCapacities.Find(id);
            if (model == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWDimensions(TWDimensionsAndCapacity model)
        {
            if (ModelState.IsValid)
            {
                _context.TWDimensionsAndCapacities.Update(model);
                _context.SaveChanges();
                return RedirectToAction("ListTWDimensions");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }

        // GET: Delete
        [HttpGet]
        public IActionResult DeleteTWDimensions(int id)
        {
            var model = _context.TWDimensionsAndCapacities.Find(id);
            return View(model);
        }

        // POST: Delete
        [HttpPost, ActionName("DeleteTWDimensions")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWDimensions(int id)
        {
            var model = _context.TWDimensionsAndCapacities.Find(id);
            if (model != null)
            {
                _context.TWDimensionsAndCapacities.Remove(model);
                _context.SaveChanges();
            }
            return RedirectToAction("ListTWDimensions");
        }

        // GET: List/Search
        [HttpGet]
        public IActionResult ListTWDimensions(string searchString)
        {
            var query = _context.TWDimensionsAndCapacities.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.TWName.Contains(searchString) || x.Varients.Contains(searchString));
            }

            return View(query.ToList());
        }
        //Functions for TW Electricals
        // CREATE - GET
        [HttpGet]
        public IActionResult CreateTWElectricals()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWElectricals(TWElectricals model)
        {
            if (ModelState.IsValid)
            {
                _context.TWElectricals.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ListTWElectricals");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }

        // EDIT - GET
        [HttpGet]
        public IActionResult EditTWElectricals(int id)
        {
            var model = _context.TWElectricals.Find(id);
            if (model == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWElectricals(TWElectricals model)
        {
            if (ModelState.IsValid)
            {
                _context.TWElectricals.Update(model);
                _context.SaveChanges();
                return RedirectToAction("ListTWElectricals");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }

        // DELETE - GET
        [HttpGet]
        public IActionResult DeleteTWElectricals(int id)
        {
            var model = _context.TWElectricals.Find(id);
            return View(model);
        }

        // DELETE - POST
        [HttpPost, ActionName("DeleteTWElectricals")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWElectricals(int id)
        {
            var model = _context.TWElectricals.Find(id);
            if (model != null)
            {
                _context.TWElectricals.Remove(model);
                _context.SaveChanges();
            }
            return RedirectToAction("ListTWElectricals");
        }

        // LIST & SEARCH
        [HttpGet]
        public IActionResult ListTWElectricals(string searchString)
        {
            var data = _context.TWElectricals.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(x => x.TWName.Contains(searchString) || x.Varients.Contains(searchString));
            }

            return View(data.ToList());
        }
        //to list tw features
        // GET: Create
        [HttpGet]
        public IActionResult CreateTWFeatures()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWFeatures(TWFeatures features)
        {
            if (ModelState.IsValid)
            {
                _context.TWFeatures.Add(features);
                _context.SaveChanges();
                return RedirectToAction("ListTWFeatures");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", features.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", features.TWVarientId);
            return View(features);
        }

        // GET: List
        //public IActionResult ListTWFeatures()
        //{
        //    var features = _context.TWFeatures.Include(f => f.TwoWheeler).Include(f => f.TWVarients).ToList();
        //    return View(features);
        //}

        public IActionResult ListTWFeatures(string searchString)
        {
            var features = _context.TWFeatures.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                features = features.Where(f =>
                    f.TWName.ToLower().Contains(searchString.ToLower()) ||
                    f.Varients.Contains(searchString) ||
                    f.ABS.Contains(searchString) ||
                    f.Speedometer.Contains(searchString));
            }

            return View(features.ToList());
        }


        // GET: Edit
        [HttpGet]
        public IActionResult EditTWFeatures(int id)
        {
            var feature = _context.TWFeatures.Find(id);
            if (feature == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", feature.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", feature.TWVarientId);
            return View(feature);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWFeatures(TWFeatures feature)
        {
            if (ModelState.IsValid)
            {
                feature.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == feature.TwoWheelerId);
                feature.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == feature.TWVarientId);
                _context.TWFeatures.Update(feature);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", feature.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", feature.TWVarientId);
            return View(feature);
        }

        // GET: Delete
        [HttpGet]
        public IActionResult DeleteTWFeatures(int id)
        {
            var feature = _context.TWFeatures.Find(id);
            return View(feature);
        }

        // POST: Delete Confirmed
        [HttpPost, ActionName("DeleteTWFeatures")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWFeatures(int id)
        {
            var feature = _context.TWFeatures.Find(id);
            if (feature != null)
            {
                _context.TWFeatures.Remove(feature);
                _context.SaveChanges();
            }
            return RedirectToAction("ListTWFeatures");
        }
        //For TW Image Feature
        

            // List + Search
            public IActionResult ListTWImageColorPrice(string searchString)
            {
                var records = _context.TWImageColorPrices
                    .Include(x => x.TwoWheeler)
                    .Include(x => x.TWVarients)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(searchString))
                {
                    records = records.Where(x => x.TWName.Contains(searchString) || x.Varients.Contains(searchString));
                }

                return View(records.ToList());
            }

            // Create - GET
            public IActionResult CreateTWImageColorPrice()
            {
                ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
                ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
                return View();
            }

            // Create - POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult CreateTWImageColorPrice(TWImageColorPrice model)
            {
                if (ModelState.IsValid)
                {
                    _context.TWImageColorPrices.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
                ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
                return View(model);
            }

            // Edit - GET
            public IActionResult EditTWImageColorPrice(int id)
            {
                var item = _context.TWImageColorPrices.Find(id);
                if (item == null) return NotFound();

                ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", item.TwoWheelerId);
                ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", item.TWVarientId);

                return View(item);
            }

            // Edit - POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult EditTWImageColorPrice(TWImageColorPrice model)
            {
                if (ModelState.IsValid)
                {
                    _context.TWImageColorPrices.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
                ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
                return View(model);
            }

            // Delete - GET
            public IActionResult DeleteTWImageColorPrice(int id)
            {
                var item = _context.TWImageColorPrices.Find(id);
                return View(item);
            }

            // Delete - POST
            [HttpPost, ActionName("DeleteTWImageColorPrice")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmedTWImageColorPrice(int id)
            {
                var item = _context.TWImageColorPrices.Find(id);
                if (item != null)
                {
                    _context.TWImageColorPrices.Remove(item);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        //for mileage and performance
        public IActionResult ListTWMileageAndPerformances(string searchString)
        {
            //var data = _context.TWMileageAndPerformances
            //            .Include(x => x.TwoWheeler)
            //            .Include(x => x.TWVarients)
            //            .ToList();
            //return View(data);
            var query = _context.TWMileageAndPerformances
        .Include(x => x.TwoWheeler)
        .Include(x => x.TWVarients)
        .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x =>
                    x.TWName.Contains(searchString) ||
                    x.Varients.Contains(searchString));
            }

            return View(query.ToList());
        }

        // CREATE - GET
        public IActionResult CreateTWMileageAndPerformances()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWMileageAndPerformances(TWMileageAndPerformance model)
        {
            if (ModelState.IsValid)
            {
                _context.TWMileageAndPerformances.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }

        // EDIT - GET
        public IActionResult EditTWMileageAndPerformances(int id)
        {
            var item = _context.TWMileageAndPerformances.Find(id);
            if (item == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", item.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", item.TWVarientId);

            return View(item);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWMileageAndPerformances(TWMileageAndPerformance model)
        {
            if (ModelState.IsValid)
            {
                _context.TWMileageAndPerformances.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }

        // DELETE - GET
        public IActionResult DeleteTWMileageAndPerformances(int id)
        {
            var item = _context.TWMileageAndPerformances.Find(id);
            return View(item);
        }

        // DELETE - POST
        [HttpPost, ActionName("DeleteTWMileageAndPerformances")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWMileageAndPerformances(int id)
        {
            var item = _context.TWMileageAndPerformances.Find(id);
            if (item != null)
            {
                _context.TWMileageAndPerformances.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //for battery 
        public async Task<IActionResult> ListTWMotorAndBattery(string searchString)
        {
            var query = _context.TWMotorAndBatteries
                .Include(x => x.TwoWheeler)
                .Include(x => x.TWVarients)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x =>
                    x.TWName.Contains(searchString) ||
                    x.Varients.Contains(searchString));
            }

            return View(await query.ToListAsync());
        }

        public IActionResult CreateTWMotorAndBattery()
        {
            ViewBag.TwoWheelerId = new SelectList(_context.Twowheelers, "TwoWheelerId", "TWName");
            ViewBag.TWVarientId = new SelectList(_context.TWVarients, "TWVarientId", "VarientName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTWMotorAndBattery(TWMotorAndBattery motor)
        {
            if (ModelState.IsValid)
            {
                _context.TWMotorAndBatteries.Add(motor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TwoWheelerId = new SelectList(_context.Twowheelers, "TwoWheelerId", "TWName", motor.TwoWheelerId);
            ViewBag.TWVarientId = new SelectList(_context.TWVarients, "TWVarientId", "VarientName", motor.TWVarientId);
            return View(motor);
        }

        public IActionResult EditTWMotorAndBattery(int id)
        {
            //var motor = await _context.TWMotorAndBatteries.FindAsync(id);
            var motor = _context.TWMotorAndBatteries.Find(id);
            if (motor == null) return NotFound();

            ViewBag.TwoWheelerId = new SelectList(_context.Twowheelers, "TwoWheelerId", "TWName", motor.TwoWheelerId);
            ViewBag.TWVarientId = new SelectList(_context.TWVarients, "TWVarientId", "VarientName", motor.TWVarientId);
            return View(motor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWMotorAndBattery(TWMotorAndBattery motor)
        {
            //if (id != motor.TWMotorAndBatteryId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(motor);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.TwoWheelerId = new SelectList(_context.Twowheelers, "TwoWheelerId", "TWName", motor.TwoWheelerId);
            ViewBag.TWVarientId = new SelectList(_context.TWVarients, "TWVarientId", "VarientName", motor.TWVarientId);
            return View(motor);
        }

        public async Task<IActionResult> DeleteTWMotorAndBattery(int id)
        {
            var motor = await _context.TWMotorAndBatteries
                .Include(x => x.TwoWheeler)
                .Include(x => x.TWVarients)
                .FirstOrDefaultAsync(x => x.TWMotorAndBatteryId == id);

            if (motor == null) return NotFound();

            return View(motor);
        }

        [HttpPost, ActionName("DeleteTWMotorAndBattery")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedTWMotorAndBattery(int id)
        {
            var motor = await _context.TWMotorAndBatteries.FindAsync(id);
            if (motor != null)
            {
                _context.TWMotorAndBatteries.Remove(motor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        //to list forms in tab format
        //public async Task<IActionResult> Details(int twoWheelerId, int varientId)
        //public IActionResult Details(int id)
        //{
        //var viewModel = new TwoWheelerFullDetailsViewModel
        //{
        //    TWSpec = await _context.TWSpec.FirstOrDefaultAsync(x => x.TwoWheelerId == twoWheelerId && x.TWVarientId == varientId),
        //    TWMotorAndBattery = await _context.TWMotorAndBatteries.FirstOrDefaultAsync(x => x.TwoWheelerId == twoWheelerId && x.TWVarientId == varientId),
        //    TWFeatures = await _context.TWFeatures.FirstOrDefaultAsync(x => x.TwoWheelerId == twoWheelerId && x.TWVarientId == varientId),

        //};
        //return View(viewModel);


        //     var twoWheelerList = _context.Twowheelers
        //.Select(t => new SelectListItem
        //{
        //    Value = t.TwoWheelerId.ToString(),
        //    Text = t.TwoWheelerName
        //}).ToList();

        //     ViewBag.TwoWheelers = twoWheelerList;

        //     // Empty initially; to be filled dynamically with JS
        //     ViewBag.TWVarients = new List<SelectListItem>();

        //     return View();
        // }
        //public IActionResult Details()
        //{
        //    var viewModel = new TwoWheelerFullDetailsViewModel(); // Create a valid model

        //    ViewBag.TwoWheelers = _context.Twowheelers
        //        .Select(t => new SelectListItem
        //        {
        //            Value = t.TwoWheelerId.ToString(),
        //            Text = t.TwoWheelerName
        //        }).ToList();

        //    //ViewBag.TWVarients = new List<SelectListItem>();
        //    ViewBag.TWVarients = _context.TWVarients
        //.Select(v => new SelectListItem
        //{
        //    Value = v.TWVarientId.ToString(),
        //    Text = v.TWName
        //}).ToList();
        //    return View(viewModel); 
        //}
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = _context.Twowheelers
                .FirstOrDefault(x => x.TwoWheelerId == id);
            Console.WriteLine($"Bike Id = {bike.TwoWheelerId}");
            if (bike == null)
            {
                return NotFound();
            }

            var viewModel = new TwoWheelerFullDetailsViewModel
            {
                TwoWheeler = bike
            };
            var reviews = _context.Reviews
            .Where(r => r.TwoWheelerID == bike.TwoWheelerId)
            .OrderByDescending(r => r.CreatedAt)
            .ToList();

            ViewBag.Reviews = reviews;

            ViewBag.ReviewCount = reviews.Count;

            ViewBag.AverageRating = reviews.Any()
                ? reviews.Average(r => r.Rating)
                : 0;
            ViewBag.TwoWheelers = _context.Twowheelers
                .Select(t => new SelectListItem
                {
                    Value = t.TwoWheelerId.ToString(),
                    Text = t.TwoWheelerName
                }).ToList();

            ViewBag.TWVarients = _context.TWVarients
                .Select(v => new SelectListItem
                {
                    Value = v.TWVarientId.ToString(),
                    Text = v.TWName
                }).ToList();

            return View(viewModel);
        }

        public IActionResult GetBrands()
        {
            var brands = _context.Twowheelers.Select(b => new { b.TwoWheelerId, b.TwoWheelerName }).ToList();
            return Json(brands);
        }

        public IActionResult GetVariants(int brandId)
        {
            Console.WriteLine("GetVariants called with brandId: " + brandId);
            var variants = _context.TWVarients
                .Where(v => v.TwoWheelerId == brandId)
                .Select(v => new { v.TWVarientId, v.TWName })
                .ToList();
            return Json(variants);
        }
        public IActionResult GetDetails(int brandId, int variantId)
        {
            var viewModel = new TwoWheelerFullDetailsViewModel
            {
                TWSpec = _context.TWSpec.FirstOrDefault(s => s.TwoWheelerId == brandId && s.TWVarientId == variantId),
                TWFeatures = _context.TWFeatures.FirstOrDefault(f => f.TwoWheelerId == brandId && f.TWVarientId == variantId),
                
            };
            return PartialView("_DetailsPartial", viewModel);
        }

        
        public IActionResult LoadTabPartial(int brandId, int variantId, string tab)
        {
            var viewModel = new TwoWheelerFullDetailsViewModel
            {
                TWSpec = _context.TWSpec.FirstOrDefault(x => x.TwoWheelerId == brandId && x.TWVarientId == variantId),
                TWFeatures = _context.TWFeatures.FirstOrDefault(x => x.TwoWheelerId == brandId && x.TWVarientId == variantId),
                TWMileageAndPerformance = _context.TWMileageAndPerformances.FirstOrDefault(x => x.TwoWheelerId == brandId && x.TWVarientId == variantId)
            };

            return tab switch
            {
                "specTab" => PartialView("_SpecPartial", viewModel.TWSpec),
                "featuresTab" => PartialView("_FeaturesPartial", viewModel.TWFeatures),
                "performanceTab" => PartialView("_PerformancePartial", viewModel.TWMileageAndPerformance),
                _ => Content("Invalid tab.")
            };
        }

        public IActionResult LoadUpdateForm(string tab, int variantId)
        {
            var variant = _context.TWVarients
                .Include(v => v.TwoWheeler)
                .FirstOrDefault(v => v.TWVarientId == variantId);

            if (variant == null)
                return Content("Variant not found.");

            return tab switch
            {
                "specTab" => PartialView("_UpdateSpecificationPartial", _context.TWSpec.FirstOrDefault(x => x.TWVarientId == variantId)),
                "featuresTab" => PartialView("_UpdateFeaturesPartial", _context.TWFeatures.FirstOrDefault(x => x.TWVarientId == variantId)),
                "motorTab" => PartialView("_UpdateMotorAndBatteryPartial", _context.TWMotorAndBatteries.FirstOrDefault(x => x.TWVarientId == variantId)),
                _ => Content("Invalid tab name.")
            };
        }
    }
}