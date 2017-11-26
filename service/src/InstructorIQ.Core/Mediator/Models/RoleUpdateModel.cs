﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class RoleUpdateModel : EntityUpdateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        #region "Custom Properties"
        // The contents of this region will also be preserved during generation.
        #endregion
    }
}