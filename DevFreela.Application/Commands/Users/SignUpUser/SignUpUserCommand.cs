﻿using DevFreela.Core.Enums.Users;
using MediatR;

namespace DevFreela.Application.Commands.Users.SignUpUser;

public class SignUpUserCommand : IRequest<int>
{
    public string FullName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public UserRoleEnum Role { get; set; }
}