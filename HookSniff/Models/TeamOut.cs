#nullable enable
namespace HookSniff.Models
{
    public class TeamOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public int MemberCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class TeamMemberOut
    {
        public string Id { get; set; } = "";
        public string UserId { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Name { get; set; }
        public string Role { get; set; } = "";
        public DateTime JoinedAt { get; set; }
    }

    public class TeamInviteOut
    {
        public string Id { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }

    public class CreateTeamRequest
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
    }

    public class InviteMemberRequest
    {
        public string Email { get; set; } = "";
        public string Role { get; set; } = "member";
    }

    public class ChangeRoleRequest
    {
        public string Role { get; set; } = "";
    }

    public class AcceptInviteRequest
    {
        public string Token { get; set; } = "";
    }

    public class ListResponseTeamOut
    {
        public List<TeamOut> Data { get; set; } = new();
    }
}
