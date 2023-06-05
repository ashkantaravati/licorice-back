using System.Linq;

namespace LicoriceBack.Models
{
    public class Wall
    {
        public int  Id { get; set; }

        public string? Key { get; set; }
        public string? Title { get; set; }
        public string? Descriptions { get; set; }

        public bool IsPublic { get; set; }

        public IEnumerable<Cube> Cubes { get; set; } = Enumerable.Empty<Cube>();

        public DateTime CreateAt { get; set; }
    }
}
