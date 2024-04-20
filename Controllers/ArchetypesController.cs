using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class ArchetypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArchetypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Archetypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Archetype.ToListAsync());
        }

        // GET: Archetypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archetype = await _context.Archetype
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archetype == null)
            {
                return NotFound();
            }

            return View(archetype);
        }

        // GET: Archetypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Archetypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Lines,Characteristics,Tips,Note")] Archetype archetype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archetype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(archetype);
        }

        // GET: Archetypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archetype = await _context.Archetype.FindAsync(id);
            if (archetype == null)
            {
                return NotFound();
            }
            return View(archetype);
        }

        // POST: Archetypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Lines,Characteristics,Tips,Note")] Archetype archetype)
        {
            if (id != archetype.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archetype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchetypeExists(archetype.Id))
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
            return View(archetype);
        }

        // GET: Archetypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archetype = await _context.Archetype
                .FirstOrDefaultAsync(m => m.Id == id);
            if (archetype == null)
            {
                return NotFound();
            }

            return View(archetype);
        }

        // POST: Archetypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archetype = await _context.Archetype.FindAsync(id);
            if (archetype != null)
            {
                _context.Archetype.Remove(archetype);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchetypeExists(int id)
        {
            return _context.Archetype.Any(e => e.Id == id);
        }
    }
}
