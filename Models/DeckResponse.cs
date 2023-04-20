namespace Deck_of_Cards_Api_2023.Models
{
    public class DeckResponse
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public bool shuffled { get; set; }
        public int remaining { get; set; }
    }
}
