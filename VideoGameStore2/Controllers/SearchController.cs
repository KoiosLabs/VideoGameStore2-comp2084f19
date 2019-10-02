using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore2.Models;

namespace VideoGameStore2.Controllers
{
    public class SearchController : Controller
    {
        private readonly GameStoreDBContext _context;
        public SearchController(GameStoreDBContext context)
        {
            _context = context;
        }
        public IActionResult Index(string query)
        {
            var games = GetGames(query);
            return PartialView(games);
        }
        private List<Game> GetGames(String query)
        {
            return _context
                .Game
                .Where(game => game.Name
                            .ToLower()
                            .Contains(query.ToLower()))
                .ToList();
        }
    }
}