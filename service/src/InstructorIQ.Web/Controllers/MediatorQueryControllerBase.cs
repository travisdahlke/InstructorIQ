﻿using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using MediatR;

namespace InstructorIQ.Web.Controllers
{
    public abstract class MediatorQueryControllerBase<TKey, TEntity, TReadModel> : MediatorControllerBase
        where TEntity : class, new()
    {
        protected MediatorQueryControllerBase(IMediator mediator) : base(mediator)
        {
        }

        protected virtual async Task<TReadModel> GetQuery(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityIdentifierQuery<TKey, TEntity, TReadModel>(id, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<EntityListResult<TReadModel>> ListQuery(EntityQuery entityQuery, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityListQuery<TEntity, TReadModel>(entityQuery, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}