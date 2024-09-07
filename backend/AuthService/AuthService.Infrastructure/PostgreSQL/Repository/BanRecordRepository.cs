﻿using AuthServce.Application;
using AuthServce.Application.Interfaces;
using AuthService.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace AuthService.Infrastructure.PostgreSQL.Repository;

public class BanRecordRepository(AuthDbContext authDbContext,
                                     IConnectionMultiplexer muxer) : IBanRecordRepository
{
    #region Props

    private readonly IDatabase _redis = muxer.GetDatabase();
    private readonly AuthDbContext _context = authDbContext;
    private const string BAN_RECORD_REDIS_KEY = "baned_users:";
    private const int BAN_RECORD_TTL_MINUTES = 10;

    #endregion

    #region Methods
    public async Task<BanRecordEntity> GetUserBanCashed(string userEmail)
    {
        var banRecordJson = await _redis.StringGetAsync($"{BAN_RECORD_REDIS_KEY}:{userEmail}");

        if (!banRecordJson.IsNullOrEmpty)
        {
            var banRecord = JsonSerializer.Deserialize<BanRecordEntity>(banRecordJson!);
            return banRecord!;
        }

        var banRecordEntity = await _context.BanRecords.SingleOrDefaultAsync(bre => bre.Email == userEmail);
        if (banRecordEntity != null)
        {
            await _redis.StringSetAsync(BAN_RECORD_REDIS_KEY + userEmail,
                            JsonSerializer.Serialize(banRecordEntity),
                            TimeSpan.FromMinutes(BAN_RECORD_TTL_MINUTES));
        }

        return banRecordEntity;
    }


    public async Task<BanRecordEntity> GetUserBan(string userEmail)
    {
        var banRecordEntity = await _context.BanRecords.SingleOrDefaultAsync(bre => bre.Email == userEmail);
        return banRecordEntity;
    }

    #endregion
}
