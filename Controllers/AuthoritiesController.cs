using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class AuthoritiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthoritiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Authorities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authority.ToListAsync());
        }

        // GET: Authorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authority = await _context.Authority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authority == null)
            {
                return NotFound();
            }

            return View(authority);
        }

        // GET: Authorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Who,Tips,Note")] Authority authority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authority);
        }

        // GET: Authorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authority = await _context.Authority.FindAsync(id);
            if (authority == null)
            {
                return NotFound();
            }
            return View(authority);
        }

        // POST: Authorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Who,Tips,Note")] Authority authority)
        {
            if (id != authority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorityExists(authority.Id))
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
            return View(authority);
        }

        // GET: Authorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authority = await _context.Authority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authority == null)
            {
                return NotFound();
            }

            return View(authority);
        }

        // POST: Authorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authority = await _context.Authority.FindAsync(id);
            if (authority != null)
            {
                _context.Authority.Remove(authority);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorityExists(int id)
        {
            return _context.Authority.Any(e => e.Id == id);
        }
    }
}
