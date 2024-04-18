using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HumanDesign.Data;
using HumanDesign.Models;

namespace HumanDesign.Controllers
{
    public class GatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gates
                .Include(g => g.Location)
                .Include(g => g.Circuit)
                .Include(g => g.Shadow)
                .Include(g => g.Repressive)
                .Include(g => g.Reactive)
                .Include(g => g.Gift)
                .Include(g => g.Siddhi).ToListAsync());
        }

        // GET: Gates/GateDetails/5
        [HttpGet("Gates/GateDetails/{id}")]
        public async Task<IActionResult> GateDetails(int id)
        {
            var gate = await _context.Gates
                .Include(g => g.Location)
                .Include(g => g.Circuit)
                .Include(g => g.Shadow)
                .Include(g => g.Repressive)
                .Include(g => g.Reactive)
                .Include(g => g.Gift)
                .Include(g => g.Siddhi)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (gate == null)
            {
                return NotFound();
            }

            return View(gate);
        }

        // GET: Gates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gate = await _context.Gates
                .Include(g => g.Location)
                .Include(g => g.Circuit)
                .Include(g => g.Shadow)
                .Include(g => g.Repressive)
                .Include(g => g.Reactive)
                .Include(g => g.Gift)
                .Include(g => g.Siddhi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gate == null)
            {
                return NotFound();
            }

            return View(gate);
        }

        // GET: Gates/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations.ToList(), "Id", "Name");
            ViewData["LocationIdPlaceholder"] = "Please select a Location";
            ViewData["CircuitId"] = new SelectList(_context.Circuits.ToList(), "Id", "Name");
            ViewData["CircuitIdPlaceholder"] = "Please select a Circuit";
            ViewData["ShadowId"] = new SelectList(_context.Shadows.ToList(), "Id", "Name");
            ViewData["ShadowIdPlaceholder"] = "Please select a Shadow";
            ViewData["RepressiveId"] = new SelectList(_context.Repressives.ToList(), "Id", "Name");
            ViewData["RepressiveIdPlaceholder"] = "Please select a Repressive";
            ViewData["ReactiveId"] = new SelectList(_context.Reactives.ToList(), "Id", "Name");
            ViewData["ReactiveIdPlaceholder"] = "Please select a Reactive";
            ViewData["GiftId"] = new SelectList(_context.Gifts.ToList(), "Id", "Name");
            ViewData["GiftIdPlaceholder"] = "Please select a Gift";
            ViewData["SiddhiId"] = new SelectList(_context.Siddhis.ToList(), "Id", "Name");
            ViewData["SiddhiIdPlaceholder"] = "Please select a Siddhi";
            return View();
        }

        // POST: Gates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Notes,LocationId,CircuitId,SiddhiId,GiftId,ReactiveId,RepressiveId,ShadowId")] Gate gate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
            ViewData["CircuitId"] = new SelectList(_context.Circuits, "Id", "Name");
            ViewData["ShadowId"] = new SelectList(_context.Shadows, "Id", "Name");
            ViewData["RepressiveId"] = new SelectList(_context.Repressives, "Id", "Name");
            ViewData["ReactiveId"] = new SelectList(_context.Reactives, "Id", "Name");
            ViewData["GiftId"] = new SelectList(_context.Gifts, "Id", "Name");
            ViewData["SiddhiId"] = new SelectList(_context.Siddhis, "Id", "Name");
            return View(gate);
        }

        // GET: Gates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gate = await _context.Gates.FindAsync(id);
            if (gate == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", gate.LocationId);
            ViewData["CircuitId"] = new SelectList(_context.Circuits, "Id", "Name", gate.CircuitId);
            ViewData["ShadowId"] = new SelectList(_context.Shadows, "Id", "Name", gate.ShadowId);
            ViewData["RepressiveId"] = new SelectList(_context.Repressives, "Id", "Name", gate.RepressiveId);
            ViewData["ReactiveId"] = new SelectList(_context.Reactives, "Id", "Name", gate.ReactiveId);
            ViewData["GiftId"] = new SelectList(_context.Gifts, "Id", "Name", gate.GiftId);
            ViewData["SiddhiId"] = new SelectList(_context.Siddhis, "Id", "Name", gate.SiddhiId);
            return View(gate);
        }

        // POST: Gates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Notes,LocationId,CircuitId,SiddhiId,GiftId,ReactiveId,RepressiveId,ShadowId")] Gate gate)
        {
            if (id != gate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GateExists(gate.Id))
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
            ViewData["CircuitId"] = new SelectList(_context.Circuits, "Id", "Name");
            ViewData["ShadowId"] = new SelectList(_context.Shadows, "Id", "Name");
            ViewData["RepressiveId"] = new SelectList(_context.Repressives, "Id", "Name");
            ViewData["ReactiveId"] = new SelectList(_context.Reactives, "Id", "Name");
            ViewData["GiftId"] = new SelectList(_context.Gifts, "Id", "Name");
            ViewData["SiddhiId"] = new SelectList(_context.Siddhis, "Id", "Name");
            return View(gate);
        }

        // GET: Gates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gate = await _context.Gates
                .Include(g => g.Location)
                .Include(g => g.Circuit)
                .Include(g => g.Shadow)
                .Include(g => g.Repressive)
                .Include(g => g.Reactive)
                .Include(g => g.Gift)
                .Include(g => g.Siddhi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gate == null)
            {
                return NotFound();
            }

            return View(gate);
        }

        // POST: Gates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gate = await _context.Gates.FindAsync(id);
            if (gate != null)
            {
                _context.Gates.Remove(gate);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool GateExists(int id)
        {
            return _context.Gates.Any(e => e.Id == id);
        }
    }
}
