namespace BaseLibrary.Models
{
    public class RefreshTokenInfo
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public int UserId { get; set; }
    }
}