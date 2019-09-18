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
    public class ShopController : Controller
    {
        private readonly GameStoreDBContext _context;

        public ShopController(GameStoreDBContext context)
        {
            _context = context;
        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            var gameStoreDBContext = _context.Game.Include(g => g.Dev).Include(g => g.GameGenre);
            return View(await gameStoreDBContext.ToListAsync());
        }

        // GET: Shop/Details/5
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

        
        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
