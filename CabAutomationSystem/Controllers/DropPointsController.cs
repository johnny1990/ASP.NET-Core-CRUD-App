using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CabAutomationSystem.Models;

namespace CabAutomationSystem.Controllers
{
    public class DropPointsController : Controller
    {
        private readonly CabDbContext _context;

        public DropPointsController(CabDbContext context)
        {
            _context = context;
        }

        // GET: DropPoints
        public async Task<IActionResult> Index()
        {
            var cabDbContext = _context.DropPoint.Include(d => d.Route);
            return View(await cabDbContext.ToListAsync());
        }

        // GET: DropPoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dropPoint = await _context.DropPoint
                .Include(d => d.Route)
                .FirstOrDefaultAsync(m => m.DropPointId == id);
            if (dropPoint == null)
            {
                return NotFound();
            }

            return View(dropPoint);
        }

        // GET: DropPoints/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Route, "RouteId", "RouteName");
            return View();
        }

        // POST: DropPoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DropPointName,NewDropPointName,RouteId")] DropPoint dropPoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dropPoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "RouteId", "RouteName", dropPoint.RouteId);
            return View(dropPoint);
        }

        // GET: DropPoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dropPoint = await _context.DropPoint.FindAsync(id);
            if (dropPoint == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Route, "RouteId", "RouteName", dropPoint.RouteId);
            return View(dropPoint);
        }

        // POST: DropPoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DropPointName,NewDropPointName,RouteId")] DropPoint dropPoint)
        {
            if (id != dropPoint.DropPointId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dropPoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DropPointExists(dropPoint.DropPointId))
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
            ViewData["RouteId"] = new SelectList(_context.Route, "RouteId", "RouteName", dropPoint.RouteId);
            return View(dropPoint);
        }

        // GET: DropPoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dropPoint = await _context.DropPoint
                .Include(d => d.Route)
                .FirstOrDefaultAsync(m => m.DropPointId == id);
            if (dropPoint == null)
            {
                return NotFound();
            }

            return View(dropPoint);
        }

        // POST: DropPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dropPoint = await _context.DropPoint.FindAsync(id);
            _context.DropPoint.Remove(dropPoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DropPointExists(int id)
        {
            return _context.DropPoint.Any(e => e.DropPointId == id);
        }
    }
}
