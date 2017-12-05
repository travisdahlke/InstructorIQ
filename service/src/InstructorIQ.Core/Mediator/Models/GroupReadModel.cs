﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class GroupReadModel : EntityReadModel
    #region "Custom Interfaces"
        , InstructorIQ.Core.Data.Definitions.IHaveOrganization
    #endregion
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.
        public string OrganizationName { get; set; }
        #endregion
    }
}