using HumanDesign.Data;
using HumanDesign.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HumanDesign.Controllers
{
    public class CircuitsController : Controller
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructors
        public CircuitsController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Index
        // GET: Circuits
        public async Task<IActionResult> Index()
        {
            var circuits = _context.Circuits
                .Include(c => c.CircuitChannels)
                .ThenInclude(cc => cc.Channel)
                .AsNoTracking();
            return View(await circuits.ToListAsync());
        }
        #endregion

        #region Details
        // GET: Circuits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits
                .Include(c => c.CircuitChannels)
                .ThenInclude(cc => cc.Channel)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (circuit == null)
            {
                return NotFound();
            }

            return View(circuit);
        }
        #endregion

        #region Create
        // GET: Circuits/Create
        public IActionResult Create()
        {
            PopulateChannelsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Theme,Note")] Circuit circuit, int[] selectedChannelIds = null)
        {
            if (selectedChannelIds != null && selectedChannelIds.Length != 0)
            {
                circuit.CircuitChannels = [];
                foreach (var channelId in selectedChannelIds)
                {
                    circuit.CircuitChannels.Add(new CircuitChannel { CircuitId = circuit.Id, ChannelId = channelId });
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(circuit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateChannelsDropDownList(selectedChannelIds);

            return View(circuit);
        }


        #endregion

        #region Edit
        // GET: Circuits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits.FindAsync(id);
            if (circuit == null)
            {
                return NotFound();
            }
            // Repopulate ViewBag.ChannelId when returning to the view
            PopulateChannelsDropDownList(circuit.CircuitChannels.Select(x => x.ChannelId).ToArray());
            return View(circuit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Theme,Note")] Circuit circuit, int[] selectedChannelIds = null)
        {
            ModelState.Remove("SelectedChannelIds");

            if (id != circuit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var circuitToUpdate = await _context.Circuits
                    .Include(i => i.CircuitChannels)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (circuitToUpdate == null)
                {
                    return NotFound();
                }

                circuitToUpdate.Name = circuit.Name;
                circuitToUpdate.Theme = circuit.Theme;
                circuitToUpdate.Note = circuit.Note;

                // Clear existing channels
                circuitToUpdate.CircuitChannels.Clear();

                // Add selected channels
                if (selectedChannelIds != null)
                {
                    foreach (var channelId in selectedChannelIds)
                    {
                        circuitToUpdate.CircuitChannels.Add(new CircuitChannel { CircuitId = id, ChannelId = channelId });
                    }
                }

                try
                {
                    _context.Update(circuitToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CircuitExists(circuit.Id))
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

            PopulateChannelsDropDownList(selectedChannelIds);
            return View(circuit);
        }


        #endregion

        #region Delete
        // GET: Circuits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (circuit == null)
            {
                return NotFound();
            }

            return View(circuit);
        }

        // POST: Circuits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var circuit = await _context.Circuits.FindAsync(id);
            if (circuit != null)
            {
                _context.Circuits.Remove(circuit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Helpers
        private bool CircuitExists(int id)
        {
            return _context.Circuits.Any(e => e.Id == id);
        }

        // Utility method to populate channels dropdown list
        private void PopulateChannelsDropDownList(object selectedChannels = null)
        {
            var channelsQuery = _context.Channels.OrderBy(c => c.Name).AsNoTracking();
            ViewBag.ChannelId = new SelectList(channelsQuery, "Id", "Name", selectedChannels);
        }
        #endregion
    }
}
