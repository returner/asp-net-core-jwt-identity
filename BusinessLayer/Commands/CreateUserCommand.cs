﻿using MediatR;
using SharedModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Commands
{
    public record CreateUserCommand(UserRequest userRequest) : IRequest<UserRequest>;
}
