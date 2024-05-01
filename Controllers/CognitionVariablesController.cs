using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class CognitionVariablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CognitionVariablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CognitionVariables
        public async Task<IActionResult> Index()
        {
            return View(await _context.CognitionVariables.ToListAsync());
        }

        // GET: CognitionVariables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cognitionVariable = await _context.CognitionVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cognitionVariable == null)
            {
                return NotFound();
            }

            return View(cognitionVariable);
        }

        // GET: CognitionVariables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CognitionVariables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Note,Tips")] CognitionVariable cognitionVariable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cognitionVariable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cognitionVariable);
        }

        // GET: CognitionVariables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cognitionVariable = await _context.CognitionVariables.FindAsync(id);
            if (cognitionVariable == null)
            {
                return NotFound();
            }
            return View(cognitionVariable);
        }

        // POST: CognitionVariables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Note,Tips")] CognitionVariable cognitionVariable)
        {
            if (id != cognitionVariable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cognitionVariable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CognitionVariableExists(cognitionVariable.Id))
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
            return View(cognitionVariable);
        }

        // GET: CognitionVariables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cognitionVariable = await _context.CognitionVariables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cognitionVariable == null)
            {
                return NotFound();
            }

            return View(cognitionVariable);
        }

        // POST: CognitionVariables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cognitionVariable = await _context.CognitionVariables.FindAsync(id);
            if (cognitionVariable != null)
            {
                _context.CognitionVariables.Remove(cognitionVariable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CognitionVariableExists(int id)
        {
            return _context.CognitionVariables.Any(e => e.Id == id);
        }
    }
}
