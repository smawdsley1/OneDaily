namespace OneDaily.Models
{
    public class UpdateUser
    {
        public long UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Username { get; set; } = null!;

        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Bio { get; set; }

        public string? ProfilePicture { get; set; }
    }
}
