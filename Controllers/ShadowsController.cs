using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class ShadowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShadowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shadows
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shadows.ToListAsync());
        }

        // GET: Shadows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shadow = await _context.Shadows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shadow == null)
            {
                return NotFound();
            }

            return View(shadow);
        }

        // GET: Shadows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shadows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Note")] Shadow shadow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shadow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shadow);
        }

        // GET: Shadows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shadow = await _context.Shadows.FindAsync(id);
            if (shadow == null)
            {
                return NotFound();
            }
            return View(shadow);
        }

        // POST: Shadows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Note")] Shadow shadow)
        {
            if (id != shadow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shadow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShadowExists(shadow.Id))
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
            return View(shadow);
        }

        // GET: Shadows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shadow = await _context.Shadows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shadow == null)
            {
                return NotFound();
            }

            return View(shadow);
        }

        // POST: Shadows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shadow = await _context.Shadows.FindAsync(id);
            if (shadow != null)
            {
                _context.Shadows.Remove(shadow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShadowExists(int id)
        {
            return _context.Shadows.Any(e => e.Id == id);
        }
    }
}
