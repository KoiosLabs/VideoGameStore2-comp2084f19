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
        [HttpPost]
        public IActionResult Index(string query)
        {
            var games = GetGames(query);
            return PartialView(games);
        }

        public JsonResult autocomplete(string term)
        {
            var games = GetGames(term);
            String[] Results = games.Select(game => game.Name).ToArray();
            return new JsonResult(Results); // ["Kerbal Space Program","Kerbal Space Program 2"]
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