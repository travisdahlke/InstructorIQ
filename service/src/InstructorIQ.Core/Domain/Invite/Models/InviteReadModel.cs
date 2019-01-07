using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public partial class InviteReadModel
        : EntityReadModel<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'DisplayName'.
        /// </summary>
        /// <value>
        /// The property value for 'DisplayName'.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'EmailAddress'.
        /// </summary>
        /// <value>
        /// The property value for 'EmailAddress'.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'UserId'.
        /// </summary>
        /// <value>
        /// The property value for 'UserId'.
        /// </value>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TenantId'.
        /// </summary>
        /// <value>
        /// The property value for 'TenantId'.
        /// </value>
        public Guid TenantId { get; set; }

        #endregion

    }
}
