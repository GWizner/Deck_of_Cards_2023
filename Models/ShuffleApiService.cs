using Microsoft.Extensions.Hosting;

namespace Deck_of_Cards_Api_2023.Models
{
    public class ShuffleApiService
    {
        private readonly HttpClient _httpClient;
        public ShuffleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DeckResponse> GetDeck()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"shuffle/?deck_count=6");
            DeckResponse deck = await response.Content.ReadAsAsync<DeckResponse>();

            return deck;
        }
    }
}
