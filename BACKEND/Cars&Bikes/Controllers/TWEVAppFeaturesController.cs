using System.Diagnostics;
using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers
{
    public class TWEVAppFeaturesController : Controller
    {
        private readonly TwoWheelerDB _context;
        public IActionResult Index()
        {
            return View();
        }
        public TWEVAppFeaturesController(TwoWheelerDB context)
        {
            _context = context;
        }

        // LIST with optional search
        public IActionResult ListEVAppFeatures(string search)
        {
            var features = _context.TWEVAppFeatures
                .Include(f => f.TwoWheeler)
                .Include(f => f.TWVarients)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                features = features.Where(f => f.TWName.Contains(search) || f.Varients.Contains(search));
            }

            return View(features.ToList());
        }

        // GET Create
        public IActionResult CreateEVAppFeatures()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "TWName");
            return View();
        }

        // POST Create
        [HttpPost]
        public IActionResult CreateEVAppFeatures(TWEVAppFeatures model)
        {
            if (ModelState.IsValid)
            {
                model.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == model.TwoWheelerId);
                model.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == model.TWVarientId);
                _context.TWEVAppFeatures.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View(model);
        }

        // GET Edit
        public IActionResult EditEVAppFeatures(int id)
        {
            var model = _context.TWEVAppFeatures.Find(id);
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "TWName", model.TWVarientId);
            return View(model);
        }

        // POST Edit
        [HttpPost]
        public IActionResult EditEVAppFeatures(TWEVAppFeatures model)
        {
            if (ModelState.IsValid)
            {
                model.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == model.TwoWheelerId);
                model.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == model.TWVarientId);
                _context.TWEVAppFeatures.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // DELET
        public IActionResult DeleteEVAppFeatures(int id)
        {
            var safety = _context.TWEVAppFeatures
                .Include(s => s.TwoWheeler)
                .Include(s => s.TWVarients)
                .FirstOrDefault(s => s.TWEVAppFeaturesId == id);
            if (safety == null) return NotFound();

            return View(safety);
        }
        [HttpPost, ActionName("DeleteEVAppFeatures")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEVAppFeaturesConfirmed(int id)
        {
            var item = _context.TWEVAppFeatures.FirstOrDefault(s => s.TWEVAppFeaturesId == id);
            if (item == null) return NotFound();

            _context.TWEVAppFeatures.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("ListTWSafety");
        }
        [HttpGet]
        public IActionResult CreateTWEVCharging()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWEVCharging(TWEVCharging model)
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
                if (twoWheeler != null) model.TWName = twoWheeler.TwoWheelerName;
                if (varient != null) model.Varients = varient.Varients;
                Debug.WriteLine("Adding data to table");
                _context.TWEVChargings.Add(model);
                Debug.WriteLine("Saving changes to TW Tyre");
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);

            return View(model);
        }

        
        public IActionResult ListTWEVCharging(string searchTerm)
        {
            var query = _context.TWEVChargings.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(t => t.TWName.Contains(searchTerm) || t.Varients.Contains(searchTerm));
            }

            var list = query.ToList();
            return View(list);
        }

        
        [HttpGet]
        public IActionResult EditTWEVCharging(int id)
        {
            var tyres = _context.TWEVChargings.FirstOrDefault(t => t.TWEVChargingId == id);
            if (tyres == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", tyres.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", tyres.TWVarientId);

            return View(tyres);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWEVCharging(TWEVCharging model)
        {
            if (ModelState.IsValid)
            {
                var twoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == model.TwoWheelerId);
                var varient = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == model.TWVarientId);

                if (twoWheeler != null) model.TWName = twoWheeler.TwoWheelerName;
                if (varient != null) model.Varients = varient.Varients;

                _context.TWEVChargings.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }
        
        [HttpGet]
        public IActionResult DeleteTWEVCharging(int id)
        {
            var record = _context.TWEVChargings.FirstOrDefault(x => x.TWEVChargingId == id);
            return View(record);
        }

        [HttpPost, ActionName("DeleteTWEVCharging")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTyresAndBrakes(int id)
        {
            var record = _context.TWEVChargings.Find(id);
            if (record != null)
            {
                _context.TWEVChargings.Remove(record);
                _context.SaveChanges();
            }

            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult CreateTWEVChassisAndSuspension()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWEVChassisAndSuspension(TWEVChassisAndSuspension model)
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
                if (twoWheeler != null) model.TWName = twoWheeler.TwoWheelerName;
                if (varient != null) model.Varients = varient.Varients;
                Debug.WriteLine("Adding data to table");
                _context.TWEVChassisAndSuspensions.Add(model);
                Debug.WriteLine("Saving changes to TW Tyre");
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);

            return View(model);
        }


        public IActionResult ListTWEVChassisAndSuspension(string searchTerm)
        {
            var query = _context.TWEVChassisAndSuspensions.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(t => t.TWName.Contains(searchTerm) || t.Varients.Contains(searchTerm));
            }

            var list = query.ToList();
            return View(list);
        }


        [HttpGet]
        public IActionResult EditTWEVChassisAndSuspension(int id)
        {
            var tyres = _context.TWEVChassisAndSuspensions.FirstOrDefault(t => t.TWEVChassisAndSuspensionId == id);
            if (tyres == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", tyres.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", tyres.TWVarientId);

            return View(tyres);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWEVChassisAndSuspension(TWEVChassisAndSuspension model)
        {
            if (ModelState.IsValid)
            {
                var twoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == model.TwoWheelerId);
                var varient = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == model.TWVarientId);

                if (twoWheeler != null) model.TWName = twoWheeler.TwoWheelerName;
                if (varient != null) model.Varients = varient.Varients;

                _context.TWEVChassisAndSuspensions.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", model.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", model.TWVarientId);
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteTWEVChassisAndSuspension(int id)
        {
            var record = _context.TWEVChassisAndSuspensions.FirstOrDefault(x => x.TWEVChassisAndSuspensionId == id);
            return View(record);
        }

        [HttpPost, ActionName("DeleteTWEVChassisAndSuspension")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWEVChassisAndSuspension(int id)
        {
            var record = _context.TWEVChassisAndSuspensions.Find(id);
            if (record != null)
            {
                _context.TWEVChassisAndSuspensions.Remove(record);
                _context.SaveChanges();
            }

            return RedirectToAction("Success");
        }
        [HttpGet]
        public IActionResult CreateTWEVDimensions()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWEVDimensions(TWDimensionsAndCapacity model)
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
        public IActionResult EditTWEVDimensions(int id)
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
        public IActionResult EditTWEVDimensions(TWDimensionsAndCapacity model)
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
        public IActionResult DeleteTWEVDimensions(int id)
        {
            var model = _context.TWDimensionsAndCapacities.Find(id);
            return View(model);
        }

        // POST: Delete
        [HttpPost, ActionName("DeleteTWEVDimensions")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWEVDimensions(int id)
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
        public IActionResult ListEVTWDimensions(string searchString)
        {
            var query = _context.TWDimensionsAndCapacities.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.TWName.Contains(searchString) || x.Varients.Contains(searchString));
            }

            return View(query.ToList());
        }

        [HttpGet]
        public IActionResult CreateTWEVElectricals()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWEVElectricals(TWElectricals model)
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
        public IActionResult EditTWEVElectricals(int id)
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
        public IActionResult EditTWEVElectricals(TWElectricals model)
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
        public IActionResult DeleteTWEVElectricals(int id)
        {
            var model = _context.TWElectricals.Find(id);
            return View(model);
        }

        // DELETE - POST
        [HttpPost, ActionName("DeleteTWEVElectricals")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWEVElectricals(int id)
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
        public IActionResult ListTWEVElectricals(string searchString)
        {
            var data = _context.TWEVElectricals.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(x => x.TWName.Contains(searchString) || x.Varients.Contains(searchString));
            }

            return View(data.ToList());
        }
        [HttpGet]
        public IActionResult CreateTWEVEngine()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWEVEngine(TWEVEngineAndTransmission engine)
        {
            if (ModelState.IsValid)
            {
                engine.TwoWheeler = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == engine.TwoWheelerId);
                engine.TWVarients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == engine.TWVarientId);
                _context.TWEVEngineAndTransmissions.Add(engine);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Or wherever you want to redirect
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", engine.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", engine.TWVarientId);
            return View(engine);
        }
        [HttpGet]
        public IActionResult EditTWEVEngine(int id)
        {
            var engine = _context.TWEVEngineAndTransmissions.FirstOrDefault(e => e.TWEVEngineAndTransmissionId == id);
            if (engine == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", engine.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", engine.TWVarientId);

            return View(engine);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWEVEngine(TWEVEngineAndTransmission engine)
        {
            if (ModelState.IsValid)
            {
                // Preserve TWName and Varients manually if not included in form
                engine.EVName = _context.Twowheelers.FirstOrDefault(t => t.TwoWheelerId == engine.TwoWheelerId)?.TwoWheelerName;
                engine.Varients = _context.TWVarients.FirstOrDefault(v => v.TWVarientId == engine.TWVarientId)?.Varients;

                _context.TWEVEngineAndTransmissions.Update(engine);
                _context.SaveChanges();
                return RedirectToAction("ListTWEngine");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", engine.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", engine.TWVarientId);
            return View(engine);
        }

        [HttpGet]
        public IActionResult DeleteTWEVEngine(int id)
        {
            var engine = _context.TWEVEngineAndTransmissions.FirstOrDefault(e => e.TWEVEngineAndTransmissionId == id);
            if (engine == null) return NotFound();
            return View(engine);
        }
        [HttpPost, ActionName("DeleteTWEVEngine")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWEVEngine(int id)
        {
            var engine = _context.TWEVEngineAndTransmissions.FirstOrDefault(e => e.TWEVEngineAndTransmissionId == id);
            if (engine != null)
            {
                _context.TWEVEngineAndTransmissions.Remove(engine);
                _context.SaveChanges();
            }
            return RedirectToAction("ListTWEVEngine");
        }
        public IActionResult ListTWEVEngine(string search)
        {
            var query = _context.TWEVEngineAndTransmissions.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e =>
                    e.EVName.Contains(search) || e.Varients.Contains(search));
            }

            var list = query.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult CreateTWEVFeatures()
        {
            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName");
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTWEVFeatures(TWEVFeatures features)
        {
            if (ModelState.IsValid)
            {
                _context.TWEVFeatures.Add(features);
                _context.SaveChanges();
                return RedirectToAction("ListTWEVFeatures");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", features.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", features.TWVarientId);
            return View(features);
        }


        public IActionResult ListTWEVFeatures(string searchString)
        {
            var features = _context.TWEVFeatures.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                features = features.Where(f =>
                    f.EVName.ToLower().Contains(searchString.ToLower()) ||
                    f.Varients.Contains(searchString) ||
                    f.Speedometer.Contains(searchString));
            }

            return View(features.ToList());
        }


        // GET: Edit
        [HttpGet]
        public IActionResult EditTWEVFeatures(int id)
        {
            var feature = _context.TWEVFeatures.Find(id);
            if (feature == null) return NotFound();

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", feature.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", feature.TWVarientId);
            return View(feature);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTWEVFeatures(TWEVFeatures feature)
        {
            if (ModelState.IsValid)
            {
                _context.TWEVFeatures.Update(feature);
                _context.SaveChanges();
                return RedirectToAction("ListTWEVFeatures");
            }

            ViewBag.TwoWheelers = new SelectList(_context.Twowheelers, "TwoWheelerId", "TwoWheelerName", feature.TwoWheelerId);
            ViewBag.TWVarients = new SelectList(_context.TWVarients, "TWVarientId", "Varients", feature.TWVarientId);
            return View(feature);
        }

        // GET: Delete
        [HttpGet]
        public IActionResult DeleteTWEVFeatures(int id)
        {
            var feature = _context.TWFeatures.Find(id);
            return View(feature);
        }

        // POST: Delete Confirmed
        [HttpPost, ActionName("DeleteTWEVFeatures")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedTWEVFeatures(int id)
        {
            var feature = _context.TWEVFeatures.Find(id);
            if (feature != null)
            {
                _context.TWEVFeatures.Remove(feature);
                _context.SaveChanges();
            }
            return RedirectToAction("ListTWEVFeatures");
        }

    }
}
