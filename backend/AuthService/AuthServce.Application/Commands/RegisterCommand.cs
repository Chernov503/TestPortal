using MediatR;

namespace AuthServce.Application.Commands
{
    //public class RegisterCommand : IRequest<>
    //{
    //    public string Email { get; set; }
    //    public string Password { get; set; }
    //    public string Firstname { get; set; }
    //    public string Surname { get; set; }
    //    public string Company { get; set; }

    //    public RegisterCommand(RegisterRequest)
    //    {
    //        Email = email;
    //        Name = name;
    //        Password = password;
    //    }
    //}

    //public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
    //{
    //    private readonly IPasswordHasher _passwordHasher;
    //    private readonly IUserRepository _userRepository;

    //    public RegisterCommandHandler(IPasswordHasher passwordHasher, IUserRepository userRepository)
    //    {
    //        _passwordHasher = passwordHasher;
    //        _userRepository = userRepository;
    //    }

    //    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    //    {
    //        var userExist = await _userRepository.ExistAsync(request.Email, cancellationToken);
    //        if (userExist)
    //            throw new UserAlreadyCreatedException(request.Email);

    //        var user = new User
    //        {
    //            Id = Guid.NewGuid(),
    //            Email = request.Email,
    //            Name = request.Name,
    //            CreatedAt = DateTime.UtcNow,
    //            PasswordHash = _passwordHasher.HashPassword(request.Password)
    //        };
    //        var id = await _userRepository.Register(user, cancellationToken);

    //        return id;
    //    }
    //}

}

