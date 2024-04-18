using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class RepressivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepressivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Repressives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repressives.ToListAsync());
        }

        // GET: Repressives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repressive = await _context.Repressives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repressive == null)
            {
                return NotFound();
            }

            return View(repressive);
        }

        // GET: Repressives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repressives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Note")] Repressive repressive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repressive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repressive);
        }

        // GET: Repressives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repressive = await _context.Repressives.FindAsync(id);
            if (repressive == null)
            {
                return NotFound();
            }
            return View(repressive);
        }

        // POST: Repressives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Note")] Repressive repressive)
        {
            if (id != repressive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repressive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepressiveExists(repressive.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(repressive);
        }

        // GET: Repressives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repressive = await _context.Repressives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repressive == null)
            {
                return NotFound();
            }

            return View(repressive);
        }

        // POST: Repressives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repressive = await _context.Repressives.FindAsync(id);
            if (repressive != null)
            {
                _context.Repressives.Remove(repressive);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepressiveExists(int id)
        {
            return _context.Repressives.Any(e => e.Id == id);
        }
    }
}
