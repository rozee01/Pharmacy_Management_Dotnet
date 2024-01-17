
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetTp.Models;

namespace ProjetTp.Controllers
{
    [Authorize]
    public class FabriquantController : Controller
    {
        private readonly AppDbContext _context;

        public FabriquantController(AppDbContext context)
        {
            _context = context;
        }
        // GET: FabriquantController
        public ActionResult Index()
        {
            var fabriquants = _context.Fabriquants.ToList();
            return View(fabriquants);
        }

        // GET: FabriquantController/Details/5
        public ActionResult Details(int id)
        {

            // Assuming _context is your database context
            Fabriquant fabriquant = _context.Fabriquants.Find(id);

            if (fabriquant == null)
            {
                return NotFound(); // Or another appropriate action for a not found result
            }

            return View(fabriquant);
        } 

    // GET: FabriquantController/Create
    public ActionResult Create()
        {
            return View();
        }

        // POST: FabriquantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabriquant fabriquant)
        {

            if (ModelState.IsValid)
            {
                _context.Fabriquants.Add(fabriquant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabriquant);
        }

        // GET: FabriquantController/Edit/5
        public ActionResult Edit(int id)
        {
            var fabriquant = _context.Fabriquants.Find(id);

            if (fabriquant == null)
            {
                return NotFound();
            }

            return View(fabriquant);
        }

        // POST: FabriquantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Fabriquant fabriquant)
        {
            if (id != fabriquant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(fabriquant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabriquant);
        }

        // GET: FabriquantController/Delete/5
        public ActionResult Delete(int id)
        {
            var fabriquant = _context.Fabriquants.Find(id);

            if (fabriquant == null)
            {
                return NotFound();
            }

            return View(fabriquant);
        }

        // POST: FabriquantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Fabriquant fab)
        {
            var fabriquant = _context.Fabriquants.Find(id);

            if (fabriquant != null)
            {
                _context.Fabriquants.Remove(fabriquant);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
