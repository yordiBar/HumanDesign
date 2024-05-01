using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class DeterminationDigestionVariablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeterminationDigestionVariablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeterminationDigestionVariables
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeterminationDigestionVariables.ToListAsync());
        }

        // GET: DeterminationDigestionVariables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var determinationDigestionVariable = await _context.DeterminationDigestionVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (determinationDigestionVariable == null)
            {
                return NotFound();
            }

            return View(determinationDigestionVariable);
        }

        // GET: DeterminationDigestionVariables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeterminationDigestionVariables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,LeftFacing,RightFacing,Note,Tips")] DeterminationDigestionVariable determinationDigestionVariable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(determinationDigestionVariable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(determinationDigestionVariable);
        }

        // GET: DeterminationDigestionVariables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var determinationDigestionVariable = await _context.DeterminationDigestionVariables.FindAsync(id);
            if (determinationDigestionVariable == null)
            {
                return NotFound();
            }
            return View(determinationDigestionVariable);
        }

        // POST: DeterminationDigestionVariables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,LeftFacing,RightFacing,Note,Tips")] DeterminationDigestionVariable determinationDigestionVariable)
        {
            if (id != determinationDigestionVariable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(determinationDigestionVariable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeterminationDigestionVariableExists(determinationDigestionVariable.Id))
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
            return View(determinationDigestionVariable);
        }

        // GET: DeterminationDigestionVariables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var determinationDigestionVariable = await _context.DeterminationDigestionVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (determinationDigestionVariable == null)
            {
                return NotFound();
            }

            return View(determinationDigestionVariable);
        }

        // POST: DeterminationDigestionVariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var determinationDigestionVariable = await _context.DeterminationDigestionVariables.FindAsync(id);
            if (determinationDigestionVariable != null)
            {
                _context.DeterminationDigestionVariables.Remove(determinationDigestionVariable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeterminationDigestionVariableExists(int id)
        {
            return _context.DeterminationDigestionVariables.Any(e => e.Id == id);
        }
    }
}
