using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class MotivationVariablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotivationVariablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MotivationVariables
        public async Task<IActionResult> Index()
        {
            return View(await _context.MotivationVariables.ToListAsync());
        }

        // GET: MotivationVariables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivationVariable = await _context.MotivationVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motivationVariable == null)
            {
                return NotFound();
            }

            return View(motivationVariable);
        }

        // GET: MotivationVariables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotivationVariables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,TransferredMotivation,LeftFacing,RightFacing,Note,Tips")] MotivationVariable motivationVariable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motivationVariable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motivationVariable);
        }

        // GET: MotivationVariables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivationVariable = await _context.MotivationVariables.FindAsync(id);
            if (motivationVariable == null)
            {
                return NotFound();
            }
            return View(motivationVariable);
        }

        // POST: MotivationVariables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,TransferredMotivation,LeftFacing,RightFacing,Note,Tips")] MotivationVariable motivationVariable)
        {
            if (id != motivationVariable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motivationVariable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotivationVariableExists(motivationVariable.Id))
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
            return View(motivationVariable);
        }

        // GET: MotivationVariables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivationVariable = await _context.MotivationVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motivationVariable == null)
            {
                return NotFound();
            }

            return View(motivationVariable);
        }

        // POST: MotivationVariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motivationVariable = await _context.MotivationVariables.FindAsync(id);
            if (motivationVariable != null)
            {
                _context.MotivationVariables.Remove(motivationVariable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotivationVariableExists(int id)
        {
            return _context.MotivationVariables.Any(e => e.Id == id);
        }
    }
}
