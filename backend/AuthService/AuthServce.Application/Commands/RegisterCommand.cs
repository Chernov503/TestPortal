using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServce.Application.Commands
{
    public class RegisterCommand : IRequest<Guid>
    {
        //    public string Email { get; set; }
        //    public string Name { get; set; }
        //    public string Password { get; set; }

        //    public RegisterCommand(string email, string name, string password)
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

    }
}
