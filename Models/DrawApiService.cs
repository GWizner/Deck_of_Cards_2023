namespace Deck_of_Cards_Api_2023.Models
{
    public class DrawApiService
    {
      
        private readonly HttpClient _httpClient;
        public DrawApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DrawResponse> GetCards(DeckResponse deckResponse)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{deckResponse.deck_id}/draw/?count=5");
            DrawResponse draw = await response.Content.ReadAsAsync<DrawResponse>();

            return draw;
        }
    }
}

