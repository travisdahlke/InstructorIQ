﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Validation
{
    public class SessionUpdateModelValidator : AbstractValidator<SessionUpdateModel>
    {
        public SessionUpdateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}