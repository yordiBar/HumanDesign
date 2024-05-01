using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class EnvironmentVariablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnvironmentVariablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnvironmentVariables
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnvironmentVariables.ToListAsync());
        }

        // GET: EnvironmentVariables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var environmentVariable = await _context.EnvironmentVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (environmentVariable == null)
            {
                return NotFound();
            }

            return View(environmentVariable);
        }

        // GET: EnvironmentVariables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnvironmentVariables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,LeftFacing,RightFacing,Note,Tips")] EnvironmentVariable environmentVariable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(environmentVariable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(environmentVariable);
        }

        // GET: EnvironmentVariables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var environmentVariable = await _context.EnvironmentVariables.FindAsync(id);
            if (environmentVariable == null)
            {
                return NotFound();
            }
            return View(environmentVariable);
        }

        // POST: EnvironmentVariables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,LeftFacing,RightFacing,Note,Tips")] EnvironmentVariable environmentVariable)
        {
            if (id != environmentVariable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(environmentVariable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvironmentVariableExists(environmentVariable.Id))
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
            return View(environmentVariable);
        }

        // GET: EnvironmentVariables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var environmentVariable = await _context.EnvironmentVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (environmentVariable == null)
            {
                return NotFound();
            }

            return View(environmentVariable);
        }

        // POST: EnvironmentVariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var environmentVariable = await _context.EnvironmentVariables.FindAsync(id);
            if (environmentVariable != null)
            {
                _context.EnvironmentVariables.Remove(environmentVariable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvironmentVariableExists(int id)
        {
            return _context.EnvironmentVariables.Any(e => e.Id == id);
        }
    }
}
