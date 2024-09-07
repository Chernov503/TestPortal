using AuthServce.Application;
using AuthService.Domain.Entityes;

namespace AuthServce.Application.Interfaces
{
    public interface IBanRecordRepository
    {
        Task<BanRecordEntity> GetUserBanCashed(string userEmail);
        Task<BanRecordEntity> GetUserBan(string userEmail);
    }
}