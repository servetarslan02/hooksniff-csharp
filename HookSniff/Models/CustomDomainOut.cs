#nullable enable
namespace HookSniff.Models
{
    public class CustomDomainOut
    {
        public string Id { get; set; } = "";
        public string Domain { get; set; } = "";
        public string Status { get; set; } = "";
        public string? VerificationToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class AddDomainRequest
    {
        public string Domain { get; set; } = "";
    }
}
