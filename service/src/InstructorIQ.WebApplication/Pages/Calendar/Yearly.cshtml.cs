﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Calendar
{
    public class YearlyModel : MediatorModelBase
    {
        public YearlyModel(IMediator mediator, ILoggerFactory loggerFactory) : base(mediator, loggerFactory)
        {
            Year = DateTime.Now.Year;
        }

        [BindProperty(Name = "year", SupportsGet = true)]
        public int Year { get; set; }

        public IReadOnlyCollection<SessionCalendarModel> Items { get; set; }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            var year = Year;

            if (year == 0)
                year = DateTime.Now.Year;

            var command = new SessionCalendarQuery(User, year);
            var result = await Mediator.Send(command);

            Items = result;

            return Page();
        }

    }
}