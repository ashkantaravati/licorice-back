namespace LicoriceBack.Contracts
{
    public class CreateWallDto
    {
        public string? Title { get; set; }
        public string? Creator { get; set; }
        public string? Descriptions { get; set; }

        public bool IsPublic { get; set; }
    }
}
