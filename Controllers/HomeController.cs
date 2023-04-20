using Deck_of_Cards_Api_2023.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Deck_of_Cards_Api_2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShuffleApiService _shuffleApiService;
        private readonly DrawApiService _drawApiService;
        public HomeController(ShuffleApiService shuffleApiService, DrawApiService drawApiService)
        {
            _shuffleApiService = shuffleApiService;
            _drawApiService = drawApiService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                DeckResponse decks = await _shuffleApiService.GetDeck();
                DrawResponse result = await _drawApiService.GetCards(decks);
                return View(result);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                Debug.WriteLine(ex);
                return View();
            }
            
        }
      
    }
}
