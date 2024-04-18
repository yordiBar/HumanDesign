using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class ReactivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReactivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reactives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reactives.ToListAsync());
        }

        // GET: Reactives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reactive = await _context.Reactives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reactive == null)
            {
                return NotFound();
            }

            return View(reactive);
        }

        // GET: Reactives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reactives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Note")] Reactive reactive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reactive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reactive);
        }

        // GET: Reactives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reactive = await _context.Reactives.FindAsync(id);
            if (reactive == null)
            {
                return NotFound();
            }
            return View(reactive);
        }

        // POST: Reactives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Note")] Reactive reactive)
        {
            if (id != reactive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reactive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReactiveExists(reactive.Id))
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
            return View(reactive);
        }

        // GET: Reactives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reactive = await _context.Reactives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reactive == null)
            {
                return NotFound();
            }

            return View(reactive);
        }

        // POST: Reactives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reactive = await _context.Reactives.FindAsync(id);
            if (reactive != null)
            {
                _context.Reactives.Remove(reactive);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReactiveExists(int id)
        {
            return _context.Reactives.Any(e => e.Id == id);
        }
    }
}
