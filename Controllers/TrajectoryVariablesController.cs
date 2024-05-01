using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class TrajectoryVariablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrajectoryVariablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrajectoryVariables
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrajectoryVariables.ToListAsync());
        }

        // GET: TrajectoryVariables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trajectoryVariable = await _context.TrajectoryVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trajectoryVariable == null)
            {
                return NotFound();
            }

            return View(trajectoryVariable);
        }

        // GET: TrajectoryVariables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrajectoryVariables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Note,Tips")] TrajectoryVariable trajectoryVariable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trajectoryVariable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trajectoryVariable);
        }

        // GET: TrajectoryVariables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trajectoryVariable = await _context.TrajectoryVariables.FindAsync(id);
            if (trajectoryVariable == null)
            {
                return NotFound();
            }
            return View(trajectoryVariable);
        }

        // POST: TrajectoryVariables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Note,Tips")] TrajectoryVariable trajectoryVariable)
        {
            if (id != trajectoryVariable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trajectoryVariable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrajectoryVariableExists(trajectoryVariable.Id))
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
            return View(trajectoryVariable);
        }

        // GET: TrajectoryVariables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trajectoryVariable = await _context.TrajectoryVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trajectoryVariable == null)
            {
                return NotFound();
            }

            return View(trajectoryVariable);
        }

        // POST: TrajectoryVariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trajectoryVariable = await _context.TrajectoryVariables.FindAsync(id);
            if (trajectoryVariable != null)
            {
                _context.TrajectoryVariables.Remove(trajectoryVariable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrajectoryVariableExists(int id)
        {
            return _context.TrajectoryVariables.Any(e => e.Id == id);
        }
    }
}
