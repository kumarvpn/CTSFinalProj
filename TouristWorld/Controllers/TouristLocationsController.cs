using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristWorld.Models.EF;

namespace TouristWorld.Controllers
{
    public class TouristLocationsController : Controller
    {
        private readonly tourismDbContext _context = new tourismDbContext();

        //public TouristLocationsController(tourismDbContext context)
        //{
        //    _context = context;
        //}

        // GET: TouristLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbTouristLocation.ToListAsync());
        }

        // GET: TouristLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTouristLocation = await _context.TbTouristLocation
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (tbTouristLocation == null)
            {
                return NotFound();
            }

            return View(tbTouristLocation);
        }

        // GET: TouristLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TouristLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaceId,LocationName,City,Country,LocationImage")] TbTouristLocation tbTouristLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTouristLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbTouristLocation);
        }

        // GET: TouristLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTouristLocation = await _context.TbTouristLocation.FindAsync(id);
            if (tbTouristLocation == null)
            {
                return NotFound();
            }
            return View(tbTouristLocation);
        }

        // POST: TouristLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaceId,LocationName,City,Country,LocationImage")] TbTouristLocation tbTouristLocation)
        {
            if (id != tbTouristLocation.PlaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTouristLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTouristLocationExists(tbTouristLocation.PlaceId))
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
            return View(tbTouristLocation);
        }

        // GET: TouristLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTouristLocation = await _context.TbTouristLocation
                .FirstOrDefaultAsync(m => m.PlaceId == id);
            if (tbTouristLocation == null)
            {
                return NotFound();
            }

            return View(tbTouristLocation);
        }

        // POST: TouristLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTouristLocation = await _context.TbTouristLocation.FindAsync(id);
            _context.TbTouristLocation.Remove(tbTouristLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTouristLocationExists(int id)
        {
            return _context.TbTouristLocation.Any(e => e.PlaceId == id);
        }
    }
}
