﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Data.Queries
{
    public static partial class SessionGroupExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static InstructorIQ.Core.Data.Entities.SessionGroup GetByKey(this System.Linq.IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> queryable, Guid id)
        {
            var dbSet = queryable as Microsoft.EntityFrameworkCore.DbSet<InstructorIQ.Core.Data.Entities.SessionGroup>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(s => s.Id == id);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> BySessionIdGroupId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> queryable, Guid sessionId, Guid groupId)
        {
            return queryable.Where(s => s.SessionId == sessionId
                && s.GroupId == groupId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> BySessionId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> queryable, Guid sessionId)
        {
            return queryable.Where(s => s.SessionId == sessionId);
        }

        public static IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> ByGroupId(this IQueryable<InstructorIQ.Core.Data.Entities.SessionGroup> queryable, Guid groupId)
        {
            return queryable.Where(s => s.GroupId == groupId);
        }
    }
}
