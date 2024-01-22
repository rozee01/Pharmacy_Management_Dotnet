using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetTp.Models;

namespace ProjetTp.Controllers
{
    [Authorize]
    public class MedicamentController : Controller

    {
        private readonly AppDbContext _context;
        private readonly IQueryable<MedicamentJoinResult> query;
        public MedicamentController(AppDbContext context)
        {
            _context = context;
            query = from medicament in _context.Medicaments
                    join format in _context.Formats on medicament.FormatId equals format.Id
                    join fabriquant in _context.Fabriquants on medicament.FabriquantId equals fabriquant.Id
                    select new MedicamentJoinResult
                    {
                        Medicament = medicament,
                        Format = format,
                        Fabriquant = fabriquant
                    };
        }
        // GET: MedicamentController
        public ActionResult Index()
        {
            var result = query.ToList();

            // medicaments = _context.Medicaments.;
            return View(result);
        }

        // GET: MedicamentController/Details/5
        public ActionResult Details(Guid id) 
        {
            var query = from medicament in _context.Medicaments
                    join format in _context.Formats on medicament.FormatId equals format.Id
                    join fabriquant in _context.Fabriquants on medicament.FabriquantId equals fabriquant.Id
                    where id == medicament.Id
                    select new MedicamentJoinResult
                    {
                        Medicament = medicament,
                        Format = format,
                        Fabriquant = fabriquant
                    };
            var result = query.FirstOrDefault();
            //var medicament = _context.Medicaments.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: MedicamentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicamentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medicament medicament, string FormatName, string FabriquantName)
        {
            if (ModelState.IsValid)
            {
                var format = _context.Formats.FirstOrDefault(f => f.Name == FormatName);
            var fabriquant = _context.Fabriquants.FirstOrDefault(f => f.Name == FabriquantName);

            if (format != null && fabriquant != null)
            {
                // Assigner les identifiants au modèle
                medicament.FormatId = format.Id;
                medicament.FabriquantId = fabriquant.Id;

                _context.Medicaments.Add(medicament);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            return View(medicament);
        }

        // GET: MedicamentController/Edit/5
        public ActionResult Edit(Guid id)
        {
            //var medicament = _context.Medicaments.Find(id);
            var query = from medicament in _context.Medicaments
                        join format in _context.Formats on medicament.FormatId equals format.Id
                        join fabriquant in _context.Fabriquants on medicament.FabriquantId equals fabriquant.Id
                        where id == medicament.Id
                        select new MedicamentJoinResult
                        {
                            Medicament = medicament,
                            Format = format,
                            Fabriquant = fabriquant
                        };
            var result = query.FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: MedicamentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Medicament medicament,string FormatName, string FabriquantName)
        {
            var format = _context.Formats.FirstOrDefault(f => f.Name == FormatName);
            var fabriquant = _context.Fabriquants.FirstOrDefault(f => f.Name == FabriquantName);

            if (format != null && fabriquant != null)
            {
                // Assigner les identifiants au modèle
                medicament.FormatId = format.Id;
                medicament.FabriquantId = fabriquant.Id;
                _context.Update(medicament);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicament);
        }

        // GET: MedicamentController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var query = from medicament in _context.Medicaments
                        join format in _context.Formats on medicament.FormatId equals format.Id
                        join fabriquant in _context.Fabriquants on medicament.FabriquantId equals fabriquant.Id
                        where id == medicament.Id
                        select new MedicamentJoinResult
                        {
                            Medicament = medicament,
                            Format = format,
                            Fabriquant = fabriquant
                        };
            var result = query.FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: MedicamentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Medicament medicament, string FormatName, string FabriquantName)
        {
            var format = _context.Formats.FirstOrDefault(f => f.Name == FormatName);
            var fabriquant = _context.Fabriquants.FirstOrDefault(f => f.Name == FabriquantName);

            if (format != null && fabriquant != null)
            {
                // Assigner les identifiants au modèle
                medicament.FormatId = format.Id;
                medicament.FabriquantId = fabriquant.Id;
                _context.Medicaments.Remove(medicament);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Recherche(string nomMed)
        {
            var query = from medicament in _context.Medicaments
                        join format in _context.Formats on medicament.FormatId equals format.Id
                        join fabriquant in _context.Fabriquants on medicament.FabriquantId equals fabriquant.Id
                        where nomMed == medicament.Name
                        select new MedicamentJoinResult
                        {
                            Medicament = medicament,
                            Format = format,
                            Fabriquant = fabriquant
                        };
            var result = query.FirstOrDefault() != null ? new List<MedicamentJoinResult> { query.FirstOrDefault() } : new List<MedicamentJoinResult>();

            if (result == null)
            {
                return NotFound();
            }

            return View("Index", result);
        }

    }
}
