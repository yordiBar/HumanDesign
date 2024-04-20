using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class EnergyTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnergyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnergyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnergyType.ToListAsync());
        }

        // GET: EnergyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var energyType = await _context.EnergyType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (energyType == null)
            {
                return NotFound();
            }

            return View(energyType);
        }

        // GET: EnergyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnergyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Tips,Note")] EnergyType energyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(energyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(energyType);
        }

        // GET: EnergyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var energyType = await _context.EnergyType.FindAsync(id);
            if (energyType == null)
            {
                return NotFound();
            }
            return View(energyType);
        }

        // POST: EnergyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Tips,Note")] EnergyType energyType)
        {
            if (id != energyType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(energyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnergyTypeExists(energyType.Id))
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
            return View(energyType);
        }

        // GET: EnergyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var energyType = await _context.EnergyType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (energyType == null)
            {
                return NotFound();
            }

            return View(energyType);
        }

        // POST: EnergyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var energyType = await _context.EnergyType.FindAsync(id);
            if (energyType != null)
            {
                _context.EnergyType.Remove(energyType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnergyTypeExists(int id)
        {
            return _context.EnergyType.Any(e => e.Id == id);
        }
    }
}
