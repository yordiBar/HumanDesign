using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class SiddhisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiddhisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Siddhis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Siddhis.ToListAsync());
        }

        // GET: Siddhis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siddhi = await _context.Siddhis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siddhi == null)
            {
                return NotFound();
            }

            return View(siddhi);
        }

        // GET: Siddhis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Siddhis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Note")] Siddhi siddhi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siddhi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siddhi);
        }

        // GET: Siddhis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siddhi = await _context.Siddhis.FindAsync(id);
            if (siddhi == null)
            {
                return NotFound();
            }
            return View(siddhi);
        }

        // POST: Siddhis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Note")] Siddhi siddhi)
        {
            if (id != siddhi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siddhi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiddhiExists(siddhi.Id))
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
            return View(siddhi);
        }

        // GET: Siddhis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siddhi = await _context.Siddhis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siddhi == null)
            {
                return NotFound();
            }

            return View(siddhi);
        }

        // POST: Siddhis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siddhi = await _context.Siddhis.FindAsync(id);
            if (siddhi != null)
            {
                _context.Siddhis.Remove(siddhi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiddhiExists(int id)
        {
            return _context.Siddhis.Any(e => e.Id == id);
        }
    }
}
