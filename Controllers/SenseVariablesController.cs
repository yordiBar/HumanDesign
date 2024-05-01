using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class SenseVariablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SenseVariablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SenseVariables
        public async Task<IActionResult> Index()
        {
            return View(await _context.SenseVariables.ToListAsync());
        }

        // GET: SenseVariables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senseVariable = await _context.SenseVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (senseVariable == null)
            {
                return NotFound();
            }

            return View(senseVariable);
        }

        // GET: SenseVariables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SenseVariables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Note,Tips")] SenseVariable senseVariable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(senseVariable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(senseVariable);
        }

        // GET: SenseVariables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senseVariable = await _context.SenseVariables.FindAsync(id);
            if (senseVariable == null)
            {
                return NotFound();
            }
            return View(senseVariable);
        }

        // POST: SenseVariables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Note,Tips")] SenseVariable senseVariable)
        {
            if (id != senseVariable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(senseVariable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SenseVariableExists(senseVariable.Id))
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
            return View(senseVariable);
        }

        // GET: SenseVariables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var senseVariable = await _context.SenseVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (senseVariable == null)
            {
                return NotFound();
            }

            return View(senseVariable);
        }

        // POST: SenseVariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var senseVariable = await _context.SenseVariables.FindAsync(id);
            if (senseVariable != null)
            {
                _context.SenseVariables.Remove(senseVariable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SenseVariableExists(int id)
        {
            return _context.SenseVariables.Any(e => e.Id == id);
        }
    }
}
