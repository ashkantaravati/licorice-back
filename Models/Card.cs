namespace LicoriceBack.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string? Content { get; set; }

        public Cube? Cube { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
