using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class ProfileLinesController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        // GET: ProfileLines
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfileLine.ToListAsync());
        }

        // GET: ProfileLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileLine = await _context.ProfileLine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileLine == null)
            {
                return NotFound();
            }

            return View(profileLine);
        }

        // GET: ProfileLines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfileLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LineNumber,Name,Description,Tips,Note")] ProfileLine profileLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileLine);
        }

        // GET: ProfileLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileLine = await _context.ProfileLine.FindAsync(id);
            if (profileLine == null)
            {
                return NotFound();
            }
            return View(profileLine);
        }

        // POST: ProfileLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LineNumber,Name,Description,Tips,Note")] ProfileLine profileLine)
        {
            if (id != profileLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileLineExists(profileLine.Id))
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
            return View(profileLine);
        }

        // GET: ProfileLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileLine = await _context.ProfileLine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileLine == null)
            {
                return NotFound();
            }

            return View(profileLine);
        }

        // POST: ProfileLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profileLine = await _context.ProfileLine.FindAsync(id);
            if (profileLine != null)
            {
                _context.ProfileLine.Remove(profileLine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileLineExists(int id)
        {
            return _context.ProfileLine.Any(e => e.Id == id);
        }
    }
}
