using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class ChannelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChannelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Channels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Channels
                .Include(g => g.Circuit)
                .ToListAsync());
        }

        // GET: Channels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await _context.Channels
                .Include(g => g.Circuit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (channel == null)
            {
                return NotFound();
            }

            return View(channel);
        }

        // GET: Channels/Create
        public IActionResult Create()
        {
            ViewData["CircuitId"] = new SelectList(_context.Circuits.ToList(), "Id", "Name");
            ViewData["CircuitIdPlaceholder"] = "Please select a Circuit";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name,Location,CircuitId,Description,Theme,Note")] Channel channel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(channel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircuitId"] = new SelectList(_context.Circuits, "Id", "Name");
            return View(channel);
        }

        // GET: Channels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await _context.Channels.FindAsync(id);
            if (channel == null)
            {
                return NotFound();
            }
            ViewData["CircuitId"] = new SelectList(_context.Circuits, "Id", "Name", channel.CircuitId);
            return View(channel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Name,Location,CircuitId,Description,Theme,Note")] Channel channel)
        {
            if (id != channel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(channel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChannelExists(channel.Id))
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
            ViewData["CircuitId"] = new SelectList(_context.Circuits, "Id", "Name");
            return View(channel);
        }

        // GET: Channels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await _context.Channels
                .Include(g => g.Circuit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (channel == null)
            {
                return NotFound();
            }

            return View(channel);
        }

        // POST: Channels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var channel = await _context.Channels.FindAsync(id);
            if (channel != null)
            {
                _context.Channels.Remove(channel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChannelExists(int id)
        {
            return _context.Channels.Any(e => e.Id == id);
        }

        #region Channel Details
        public async Task<IActionResult> Ch18(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var channel = await _context.Channels
                .Include(g => g.Circuit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (channel == null)
            {
                return NotFound();
            }

            return View(channel);
        }

        [HttpGet("Channels/ChannelDetails/{id}")]
        public async Task<IActionResult> ChannelDetails(int id)
        {
            var channel = await _context.Channels
                .Include(g => g.Circuit)  // Include additional navigation properties if needed
                .FirstOrDefaultAsync(m => m.Id == id);

            if (channel == null)
            {
                return NotFound();
            }

            return View(channel);
        }

        #endregion
    }
}
