﻿using System;
using EntityFrameworkCore.CommandQuery.Definitions;
using InstructorIQ.Core.Data.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Session : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated, IHaveOrganization
    {

    }
}