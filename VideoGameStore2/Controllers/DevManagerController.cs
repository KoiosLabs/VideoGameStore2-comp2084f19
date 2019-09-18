using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoGameStore2.Models;

namespace VideoGameStore2.Controllers
{
    public class DevManagerController : Controller
    {
        private readonly GameStoreDBContext _context;

        public DevManagerController(GameStoreDBContext context)
        {
            _context = context;
        }

        // GET: DevManager
        public async Task<IActionResult> Index()
        {
            return View(await _context.Developer.ToListAsync());
        }

        // GET: DevManager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developer
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        // GET: DevManager/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DevManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeveloperId,Name,StreetAddress,City,Telephone")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(developer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(developer);
        }

        // GET: DevManager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developer.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }
            return View(developer);
        }

        // POST: DevManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeveloperId,Name,StreetAddress,City,Telephone")] Developer developer)
        {
            if (id != developer.DeveloperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeveloperExists(developer.DeveloperId))
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
            return View(developer);
        }

        // GET: DevManager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developer
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        // POST: DevManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var developer = await _context.Developer.FindAsync(id);
            _context.Developer.Remove(developer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developer.Any(e => e.DeveloperId == id);
        }
    }
}
