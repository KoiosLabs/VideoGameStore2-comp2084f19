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
    public class GameManagerController : Controller
    {
        private readonly GameStoreDBContext _context;

        public GameManagerController(GameStoreDBContext context)
        {
            _context = context;
        }

        // GET: GameManager
        public async Task<IActionResult> Index()
        {
            var gameStoreDBContext = _context.Game.Include(g => g.Dev).Include(g => g.GameGenre);
            return View(await gameStoreDBContext.ToListAsync());
        }

        // GET: GameManager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Dev)
                .Include(g => g.GameGenre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: GameManager/Create
        public IActionResult Create()
        {
            ViewData["DeveloperId"] = new SelectList(_context.Set<Developer>(), "DeveloperId", "DeveloperId");
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Description");
            return View();
        }

        // POST: GameManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,MinimumRequirements,Price,DeveloperId,GenreId")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeveloperId"] = new SelectList(_context.Set<Developer>(), "DeveloperId", "DeveloperId", game.DeveloperId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Description", game.GenreId);
            return View(game);
        }

        // GET: GameManager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["DeveloperId"] = new SelectList(_context.Set<Developer>(), "DeveloperId", "Name", game.DeveloperId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Name", game.GenreId);
            return View(game);
        }

        // POST: GameManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,MinimumRequirements,Price,DeveloperId,GenreId,ImageUrl")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            ViewData["DeveloperId"] = new SelectList(_context.Set<Developer>(), "DeveloperId", "DeveloperId", game.DeveloperId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Description", game.GenreId);
            return View(game);
        }

        // GET: GameManager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Dev)
                .Include(g => g.GameGenre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: GameManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
