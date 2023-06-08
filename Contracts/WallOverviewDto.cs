using LicoriceBack.Models;

namespace LicoriceBack.Contracts
{
    public class WallOverviewDto
    {
        public string? Key { get; set; }
        public string? Title { get; set; }
        public string? Creator { get; set; }

        public bool IsPublic { get; set; }

        public int CubeCount { get; set; }

    }
}
