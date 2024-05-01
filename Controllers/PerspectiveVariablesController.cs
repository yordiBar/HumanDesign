using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class PerspectiveVariablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerspectiveVariablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PerspectiveVariables
        public async Task<IActionResult> Index()
        {
            return View(await _context.PerspectiveVariables.ToListAsync());
        }

        // GET: PerspectiveVariables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perspectiveVariable = await _context.PerspectiveVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perspectiveVariable == null)
            {
                return NotFound();
            }

            return View(perspectiveVariable);
        }

        // GET: PerspectiveVariables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PerspectiveVariables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,TransferredPerspective,LeftFacing,RightFacing,Note,Tips")] PerspectiveVariable perspectiveVariable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perspectiveVariable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perspectiveVariable);
        }

        // GET: PerspectiveVariables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perspectiveVariable = await _context.PerspectiveVariables.FindAsync(id);
            if (perspectiveVariable == null)
            {
                return NotFound();
            }
            return View(perspectiveVariable);
        }

        // POST: PerspectiveVariables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,TransferredPerspective,LeftFacing,RightFacing,Note,Tips")] PerspectiveVariable perspectiveVariable)
        {
            if (id != perspectiveVariable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perspectiveVariable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerspectiveVariableExists(perspectiveVariable.Id))
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
            return View(perspectiveVariable);
        }

        // GET: PerspectiveVariables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perspectiveVariable = await _context.PerspectiveVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perspectiveVariable == null)
            {
                return NotFound();
            }

            return View(perspectiveVariable);
        }

        // POST: PerspectiveVariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perspectiveVariable = await _context.PerspectiveVariables.FindAsync(id);
            if (perspectiveVariable != null)
            {
                _context.PerspectiveVariables.Remove(perspectiveVariable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerspectiveVariableExists(int id)
        {
            return _context.PerspectiveVariables.Any(e => e.Id == id);
        }
    }
}
