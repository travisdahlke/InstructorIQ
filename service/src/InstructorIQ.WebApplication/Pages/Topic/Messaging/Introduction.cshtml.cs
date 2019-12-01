﻿using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Messaging
{
    [Authorize(Policy = UserPolicies.InstructorPolicy)]
    public class IntroductionModel : EntityIdentifierModelBase<TopicUpdateModel>
    {
        public IntroductionModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory) 
            : base(tenant, mediator, loggerFactory)
        {
        }
    }
}