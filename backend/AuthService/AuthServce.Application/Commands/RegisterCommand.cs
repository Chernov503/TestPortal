using AuthServce.Application.Clients.UserService.Interface;
using AuthServce.Application.Interfaces;
using AuthService.Contracts.Requests;
using AuthService.Contracts.Responses;
using AuthService.Domain.Entityes;
using AutoMapper;
using MediatR;

namespace AuthServce.Application.Commands
{
    public class RegisterCommand(RegisterRequest request) : IRequest<Result<string>>
    {
        public RegisterRequest _request = request;
    }

    public class RegisterCommandHandler(IBanRecordRepository banRepository,
                                        ISessionRepository sessionRepository,
                                        IUserServiceClient userServiceClient,
                                        IMapper mapper,
                                        IJwtProvider jwtProvider) : IRequestHandler<RegisterCommand, Result<string>>
    {
        private readonly IBanRecordRepository _banRepository = banRepository;
        private readonly ISessionRepository _sessionRepository = sessionRepository;
        private readonly IUserServiceClient _userServiceClient = userServiceClient;
        private readonly IMapper _mapper = mapper;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<Result<string>> Handle(RegisterCommand command, CancellationToken ct)
        {
            var isUserBaned = await _banRepository.GetUserBanCashed(command._request.Email, ct) is not null;
            if (isUserBaned)
            {
                return Result<string>.FromError("User baned");
            }

            var registerRequest = _mapper.Map<UserServiceRegistrationRequest>(command._request);
            var registerResult = await _userServiceClient.RegisterUserAsync(registerRequest, ct);
            if (!registerResult.IsSuccess())
            {
                return Result<string>.FromError($"{registerResult.Error}");
            }

            var session = _mapper.Map<SessionRedis>(registerResult.Value);
            await _sessionRepository.CreateSession(session, registerResult.Value.Id, ct);

            var jwt = _jwtProvider.GenerateToken(registerResult.Value.Id, ct);
            return Result<string>.FromSuccess(jwt);
        }
    }

}

