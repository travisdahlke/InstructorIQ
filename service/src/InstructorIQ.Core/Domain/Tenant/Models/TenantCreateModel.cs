using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class TenantCreateModel
        : EntityCreateModel<Guid>
    {
        public TenantCreateModel()
        {
            TimeZone = "Central Standard Time";
        }

        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'Name'.
        /// </summary>
        /// <value>
        /// The property value for 'Name'.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Slug'.
        /// </summary>
        /// <value>
        /// The property value for 'Slug'.
        /// </value>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Description'.
        /// </summary>
        /// <value>
        /// The property value for 'Description'.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'City'.
        /// </summary>
        /// <value>
        /// The property value for 'City'.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'StateProvince'.
        /// </summary>
        /// <value>
        /// The property value for 'StateProvince'.
        /// </value>
        public string StateProvince { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TimeZone'.
        /// </summary>
        /// <value>
        /// The property value for 'TimeZone'.
        /// </value>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'DomainName'.
        /// </summary>
        /// <value>
        /// The property value for 'DomainName'.
        /// </value>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'IsDeleted'.
        /// </summary>
        /// <value>
        /// The property value for 'IsDeleted'.
        /// </value>
        public bool IsDeleted { get; set; }

        #endregion

    }
}
