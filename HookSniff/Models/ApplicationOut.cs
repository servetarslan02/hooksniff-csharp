#nullable enable
namespace HookSniff.Models
{
    public class ApplicationOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string? Uid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateApplicationRequest
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string? Uid { get; set; }
    }

    public class UpdateApplicationRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class ListResponseApplicationOut
    {
        public List<ApplicationOut> Data { get; set; } = new();
    }
}
