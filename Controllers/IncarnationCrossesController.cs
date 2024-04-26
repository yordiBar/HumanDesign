using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class IncarnationCrossesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncarnationCrossesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IncarnationCrosses
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncarnationCrosses.ToListAsync());
        }

        // GET: IncarnationCrosses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incarnationCross = await _context.IncarnationCrosses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incarnationCross == null)
            {
                return NotFound();
            }

            return View(incarnationCross);
        }

        // GET: IncarnationCrosses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncarnationCrosses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name,Description,Note")] IncarnationCross incarnationCross)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incarnationCross);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incarnationCross);
        }

        // GET: IncarnationCrosses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incarnationCross = await _context.IncarnationCrosses.FindAsync(id);
            if (incarnationCross == null)
            {
                return NotFound();
            }
            return View(incarnationCross);
        }

        // POST: IncarnationCrosses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Name,Description,Note")] IncarnationCross incarnationCross)
        {
            if (id != incarnationCross.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incarnationCross);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncarnationCrossExists(incarnationCross.Id))
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
            return View(incarnationCross);
        }

        // GET: IncarnationCrosses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incarnationCross = await _context.IncarnationCrosses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incarnationCross == null)
            {
                return NotFound();
            }

            return View(incarnationCross);
        }

        // POST: IncarnationCrosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incarnationCross = await _context.IncarnationCrosses.FindAsync(id);
            if (incarnationCross != null)
            {
                _context.IncarnationCrosses.Remove(incarnationCross);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncarnationCrossExists(int id)
        {
            return _context.IncarnationCrosses.Any(e => e.Id == id);
        }
    }
}
