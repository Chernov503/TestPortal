
namespace AuthServce.Application.JWT
{
    public interface IJwtProvider
    {
        string GenerateToken(Guid userId);
    }
}