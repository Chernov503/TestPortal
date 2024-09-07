using AuthServce.Application.Interfaces;
using AuthService.Domain.Entityes;
using StackExchange.Redis;
using System.Text.Json;

namespace AuthService.Infrastructure.PostgreSQL.Repository
{
    public class SessionRepository(IConnectionMultiplexer muxer) : ISessionRepository
    {
        #region Props

        private readonly IDatabase _redis = muxer.GetDatabase();
        private const string SESSION_REDIS_KEY = "sessions:";
        private const int SESSION_REDIS_TTL_MINUTES = 120;

        #endregion

        #region Methods

        public async Task CreateSession(SessionRedis session, Guid userId)
            => await _redis.StringSetAndGetAsync(SESSION_REDIS_KEY + userId,
                                                 JsonSerializer.Serialize(session),
                                                 TimeSpan.FromMinutes(SESSION_REDIS_TTL_MINUTES));

        #endregion
    }
}
