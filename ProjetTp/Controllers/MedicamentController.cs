using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetTp.Models;

namespace ProjetTp.Controllers
{
    [Authorize]
    public class MedicamentController : Controller

    {
        private readonly AppDbContext _context; // Assuming you have a DbContext named ApplicationDbContext

        public MedicamentController(AppDbContext context)
        {
            _context = context;
        }
        // GET: MedicamentController
        public ActionResult Index()
        {
            var medicaments = _context.Medicaments.ToList();
            return View(medicaments);
        }

        // GET: MedicamentController/Details/5
        public ActionResult Details(int id)
        {
            var medicament = _context.Medicaments.Find(id);

            if (medicament == null)
            {
                return NotFound();
            }

            return View(medicament);
        }

        // GET: MedicamentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicamentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medicament medicament)
        {
            if (ModelState.IsValid)
            {
                _context.Medicaments.Add(medicament);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicament);
        }

        // GET: MedicamentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicamentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Medicament medicament)
        {
         
            if (ModelState.IsValid)
            {
                _context.Update(medicament);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicament);
        }

        // GET: MedicamentController/Delete/5
        public ActionResult Delete(int id)
        {
            var medicament = _context.Medicaments.Find(id);

            if (medicament == null)
            {
                return NotFound();
            }

            return View(medicament);
        }

        // POST: MedicamentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Medicament collection)
        {
            var medicament = _context.Medicaments.Find(id);

            if (medicament != null)
            {
                _context.Medicaments.Remove(medicament);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
