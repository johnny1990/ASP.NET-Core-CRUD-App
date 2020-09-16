using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabAutomationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CabAutomationSystem.Controllers
{
    public class CabsController : Controller
    {
        private readonly CabDbContext _context;

        public CabsController(CabDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cab.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cab = await _context.Cab
                .FirstOrDefaultAsync(m => m.CabId == id);
            if (cab == null)
            {
                return NotFound();
            }

            return View(cab);
        }

        public IActionResult Create()
        {
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookTime,JourneyTime,JourneyPlace")] Cab cab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cab);
        }
    }
}