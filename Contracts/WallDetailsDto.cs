namespace LicoriceBack.Contracts
{
    public class WallDetailsDto
    {
        public string? Key { get; set; }
        public string? Descriptions { get; set; }

        public string? Creator { get; set; }
        public int CubeCount { get; set; }
        public List<CubeOverviewDto>? Cubes { get; set; }
    }
}
