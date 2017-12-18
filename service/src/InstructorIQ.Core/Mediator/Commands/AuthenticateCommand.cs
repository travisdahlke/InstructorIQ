﻿using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Security;
using MediatR;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class AuthenticateCommand : IRequest<TokenResponse>
    {
        public AuthenticateCommand(UserAgentModel userAgent, TokenRequest tokenRequest)
        {
            UserAgent = userAgent;
            TokenRequest = tokenRequest;
        }

        public TokenRequest TokenRequest { get; set; }

        public UserAgentModel UserAgent { get; set; }
    }
}
