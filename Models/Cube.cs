using System.Text.Json.Serialization;

namespace LicoriceBack.Models
{
    public class Cube
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Wall? Wall { get; set; }
        public IEnumerable<Card>? Cards { get; set; }

        [JsonIgnore]
        public string? PassphraseHash { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
