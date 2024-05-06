namespace BaseLibrary.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}