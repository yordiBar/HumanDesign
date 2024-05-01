using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class VariablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VariablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Variables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Variables.ToListAsync());
        }

        // GET: Variables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variable = await _context.Variables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variable == null)
            {
                return NotFound();
            }

            return View(variable);
        }

        // GET: Variables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Variables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Note,Tips")] Variable variable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(variable);
        }

        // GET: Variables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variable = await _context.Variables.FindAsync(id);
            if (variable == null)
            {
                return NotFound();
            }
            return View(variable);
        }

        // POST: Variables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Note,Tips")] Variable variable)
        {
            if (id != variable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VariableExists(variable.Id))
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
            return View(variable);
        }

        // GET: Variables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variable = await _context.Variables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variable == null)
            {
                return NotFound();
            }

            return View(variable);
        }

        // POST: Variables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var variable = await _context.Variables.FindAsync(id);
            if (variable != null)
            {
                _context.Variables.Remove(variable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VariableExists(int id)
        {
            return _context.Variables.Any(e => e.Id == id);
        }
    }
}
