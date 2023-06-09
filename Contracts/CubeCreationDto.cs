namespace LicoriceBack.Contracts
{
    public class CubeCreationDto
    {
        public string? Name { get; set; }

        public string? Passphrase { get; set; }
        public string? PassphraseConfirmation { get; set; }
        public string? WallKey { get; set; }

    }
}
