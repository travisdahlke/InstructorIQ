﻿using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Definitions;
using InstructorIQ.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace InstructorIQ.WebService.Controllers
{
    public abstract class MediatorCommandControllerBase<TKey, TReadModel, TCreateModel, TUpdateModel>
        : MediatorQueryControllerBase<TKey, TReadModel>
    {
        protected MediatorCommandControllerBase(IMediator mediator) : base(mediator)
        {
        }

        protected virtual async Task<TReadModel> CreateCommand(TCreateModel createModel, CancellationToken cancellationToken = default(CancellationToken))
        {

            SetTenant(createModel);

            var command = new EntityCreateCommand<TCreateModel, TReadModel>(createModel, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }


        protected virtual async Task<TReadModel> UpdateCommand(TKey id, TUpdateModel updateModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityUpdateCommand<TKey, TUpdateModel, TReadModel>(id, updateModel, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<TReadModel> PatchCommand(TKey id, IJsonPatchDocument jsonPatch, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityPatchCommand<TKey, TReadModel>(id, jsonPatch, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<TReadModel> DeleteCommand(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityDeleteCommand<TKey, TReadModel>(id, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected void SetTenant<T>(T model)
        {
            if (!(model is IHaveTenant<Guid> tenantModel))
                return;

            var tenantString = User.Identity?.GetTenantId();
            if (Guid.TryParse(tenantString, out var tenantId))
                tenantModel.TenantId = tenantId;
        }

    }
}