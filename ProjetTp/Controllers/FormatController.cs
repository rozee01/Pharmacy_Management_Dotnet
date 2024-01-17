using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using ProjetTp.Models;
using Format = ProjetTp.Models.Format;

namespace ProjetTp.Controllers
{
    public class FormatController : Controller
    {
        private readonly AppDbContext _context;

        public FormatController(AppDbContext context)
        {
            _context = context;
        }
        // GET: FormatController
        public ActionResult Index()
        {
            var formats = _context.Formats.ToList();
            return View(formats);
        }

        // GET: FormatController/Details/5
        public ActionResult Details(int id)
        {
            // Assuming _context is your database context
            Format format = _context.Formats.Find(id);

            if (format == null)
            {
                return NotFound(); // Or another appropriate action for a not found result
            }

            return View(format);
        }

        // GET: FormatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Format format)
        {
            if (ModelState.IsValid)
            {
                _context.Formats.Add(format);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(format);
        }

        // GET: FormatController/Edit/5
        public ActionResult Edit(int id)
        {
            var format = _context.Formats.Find(id);

            if (format == null)
            {
                return NotFound();
            }

            return View(format);
        }

        // POST: FormatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Format format)
        {
            if (id != format.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(format);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(format);
        }

        // GET: FormatController/Delete/5
        public ActionResult Delete(int id)
        {
            var format = _context.Formats.Find(id);

            if (format == null)
            {
                return NotFound();
            }

            return View(format);
        }

        // POST: FormatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var format = _context.Formats.Find(id);

            if (format != null)
            {
                _context.Formats.Remove(format);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
