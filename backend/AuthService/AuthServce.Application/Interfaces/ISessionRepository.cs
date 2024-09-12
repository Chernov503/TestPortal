using AuthService.Domain.Entityes;

namespace AuthServce.Application.Interfaces
{
    public interface ISessionRepository
    {
        public Task CreateSession(SessionRedis session, Guid userId, CancellationToken ct);
    }
}