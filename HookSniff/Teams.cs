#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Team(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<ListResponseTeamOut> ListAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ListResponseTeamOut>(HttpMethod.Get, "/api/v1/teams", cancellationToken: ct);
            return r.Data;
        }

        public ListResponseTeamOut List()
        {
            var r = _client.HookSniffHttpClient.SendRequest<ListResponseTeamOut>(HttpMethod.Get, "/api/v1/teams");
            return r.Data;
        }

        public async Task<TeamOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<TeamOut>(HttpMethod.Get, $"/api/v1/teams/{id}", cancellationToken: ct);
            return r.Data;
        }

        public TeamOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<TeamOut>(HttpMethod.Get, $"/api/v1/teams/{id}");
            return r.Data;
        }

        public async Task<TeamOut> CreateAsync(CreateTeamRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<TeamOut>(HttpMethod.Post, "/api/v1/teams", content: req, cancellationToken: ct);
            return r.Data;
        }

        public TeamOut Create(CreateTeamRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<TeamOut>(HttpMethod.Post, "/api/v1/teams", content: req);
            return r.Data;
        }

        public async Task AcceptInviteAsync(AcceptInviteRequest req, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Post, "/api/v1/teams/accept-invite", content: req, cancellationToken: ct);
        }

        public void AcceptInvite(AcceptInviteRequest req)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Post, "/api/v1/teams/accept-invite", content: req);
        }

        public async Task InviteAsync(string teamId, InviteMemberRequest req, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Post, $"/api/v1/teams/{teamId}/invite", content: req, cancellationToken: ct);
        }

        public void Invite(string teamId, InviteMemberRequest req)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Post, $"/api/v1/teams/{teamId}/invite", content: req);
        }

        public async Task<List<TeamMemberOut>> ListMembersAsync(string teamId, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<TeamMemberOut>>(HttpMethod.Get, $"/api/v1/teams/{teamId}/members", cancellationToken: ct);
            return r.Data;
        }

        public List<TeamMemberOut> ListMembers(string teamId)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<TeamMemberOut>>(HttpMethod.Get, $"/api/v1/teams/{teamId}/members");
            return r.Data;
        }

        public async Task RemoveMemberAsync(string teamId, string userId, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/api/v1/teams/{teamId}/members/{userId}", cancellationToken: ct);
        }

        public void RemoveMember(string teamId, string userId)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/api/v1/teams/{teamId}/members/{userId}");
        }

        public async Task ChangeRoleAsync(string teamId, string userId, ChangeRoleRequest req, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Put, $"/api/v1/teams/{teamId}/members/{userId}/role", content: req, cancellationToken: ct);
        }

        public void ChangeRole(string teamId, string userId, ChangeRoleRequest req)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Put, $"/api/v1/teams/{teamId}/members/{userId}/role", content: req);
        }
    }
}
