﻿using System;
using FluentValidation;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Validation
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(p => p.EmailAddress).NotEmpty();
            RuleFor(p => p.EmailAddress).EmailAddress();
            RuleFor(p => p.EmailAddress).MaximumLength(256);

            RuleFor(p => p.DisplayName).NotEmpty();
            RuleFor(p => p.DisplayName).MaximumLength(256);
        }
    }
}