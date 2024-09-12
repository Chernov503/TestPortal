namespace AuthServce.Application.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(Guid userId, CancellationToken ct);
}