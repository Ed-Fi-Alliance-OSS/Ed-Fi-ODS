// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Exceptions;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.GetMany;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Put;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Security;
using NHibernate.Exceptions;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi.Controllers
{
    public class SimpleResourceCreationStep<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : IHasPersistentModel<TEntityModel>, IHasIdentifier, IHasETag
        where TResult : PipelineResultBase, IHasResource<TResourceModel>
        where TResourceModel : IHasETag, IHasIdentifier, new()
        where TEntityModel : class, IMappable
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            var resource = new TResourceModel
            {
                Id = context.Id, ETag = context.ETag
            };

            result.Resource = resource;

            return Task.CompletedTask;
        }
    }

    public class PersistNewModel<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : PutContext<TResourceModel, TEntityModel>
        where TResult : PutResult
        where TEntityModel : class, IHasIdentifier, new()
        where TResourceModel : IHasETag, IMappable
    {
        private readonly IETagProvider etagProvider;

        public PersistNewModel(IETagProvider etagProvider)
        {
            this.etagProvider = etagProvider;
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            try
            {
                var model = new TEntityModel();
                context.Resource.Map(model);
                result.ResourceWasCreated = true;
                result.ETag = etagProvider.GetETag(context.Resource.ETag);

                result.ResourceId = model.Id == default(Guid)
                    ? new Guid(context.Resource.ETag)
                    : model.Id;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return Task.CompletedTask;
        }
    }

    public class PersistExistingModel<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : PutContext<TResourceModel, TEntityModel>
        where TResult : PutResult
        where TEntityModel : class, IHasIdentifier, new()
        where TResourceModel : IHasETag, IMappable, IHasIdentifier
    {
        private readonly IETagProvider _etagProvider;

        public PersistExistingModel(IETagProvider etagProvider)
        {
            _etagProvider = etagProvider;
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            try
            {
                result.ResourceWasCreated = false;
                result.ResourceWasUpdated = true;
                result.ETag = _etagProvider.GetETag(context.Resource.ETag);

                result.ResourceId = context.Resource.Id == default(Guid)
                    ? new Guid(context.Resource.ETag)
                    : context.Resource.Id;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return Task.CompletedTask;
        }
    }

    public class SqlExceptionStep<TContext, TResult, TResourceModel, TEntityModel>
        : ExceptionStep<TContext, TResult, TResourceModel, TEntityModel, SqlException>
        where TResult : PipelineResultBase { }

    public class DeleteReferentialExceptionStep<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TResult : PipelineResultBase
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            result.Exception = new GenericADOException(
                string.Empty,
                ExceptionCreator.Create(
                    typeof(SqlException),
                    @"The DELETE statement conflicted with the REFERENCE constraint ""FK_SomeForeignKey"". The conflict occurred in database ""DB_NAME"", table ""schema.TableName"", column 'ColumnName'."));
                
            return Task.CompletedTask;
        }
    }

    public class UpdateReferentialExceptionStep<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TResult : PipelineResultBase
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            result.Exception = new GenericADOException(
                string.Empty,
                ExceptionCreator.Create(
                    typeof(SqlException),
                    @"The UPDATE statement conflicted with the FOREIGN KEY constraint ""FK_SomeForeignKey"". The conflict occurred in database ""DB_NAME"", table ""schema.TableName"", column 'ColumnName'."));

            return Task.CompletedTask;
        }
    }

    public class InsertReferentialExceptionStep<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TResult : PipelineResultBase
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            result.Exception = new GenericADOException(
                string.Empty,
                ExceptionCreator.Create(
                    typeof(SqlException),
                    @"The INSERT statement conflicted with the FOREIGN KEY constraint ""FK_SomeForeignKey"". The conflict occurred in database ""DB_NAME"", table ""schema.TableName"", column 'ColumnName'."));
                
            return Task.CompletedTask;
        }
    }

    public class InsertUniqueIdExceptionStep<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TResult : PipelineResultBase
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            result.Exception = new GenericADOException(
                string.Empty,
                ExceptionCreator.Create(
                    typeof(SqlException),
                    @"Violation of UNIQUE KEY constraint 'FK_SomeIndex'. Cannot insert duplicate key in object 'edfi.SomeTable'."));

            return Task.CompletedTask;
        }
    }

    public class ValidationExceptionStep<TContext, TResult, TResourceModel, TEntityModel>
        : ExceptionStep<TContext, TResult, TResourceModel, TEntityModel, ValidationException>
        where TResult : PipelineResultBase { }

    public class GenericAdoExceptionStep<TContext, TResult, TResourceModel, TEntityModel>
        : ExceptionStep<TContext, TResult, TResourceModel, TEntityModel, GenericADOException>
        where TResult : PipelineResultBase { }

    public class ConcurrencyExceptionStep<TContext, TResult, TResourceModel, TEntityModel>
        : ExceptionStep<TContext, TResult, TResourceModel, TEntityModel, ConcurrencyException>
        where TResult : PipelineResultBase { }

    public class NotModifiedExceptionStep<TContext, TResult, TResourceModel, TEntityModel>
        : ExceptionStep<TContext, TResult, TResourceModel, TEntityModel, NotModifiedException>
        where TResult : PipelineResultBase { }

    public class NotFoundExceptionStep<TContext, TResult, TResourceModel, TEntityModel>
        : ExceptionStep<TContext, TResult, TResourceModel, TEntityModel, NotFoundException>
        where TResult : PipelineResultBase { }

    public class EdFiSecurityExceptionStep<TContext, TResult, TResourceModel, TEntityModel>
        : ExceptionStep<TContext, TResult, TResourceModel, TEntityModel, EdFiSecurityException>
        where TResult : PipelineResultBase { }

    public class UnhandledExceptionStep<TContext, TResult, TResourceModel, TEntityModel>
        : ExceptionStep<TContext, TResult, TResourceModel, TEntityModel, Exception>
        where TResult : PipelineResultBase { }

    public abstract class ExceptionStep<TContext, TResult, TResourceModel, TEntityModel, TException> 
        : IStep<TContext, TResult>
        where TResult : PipelineResultBase
        where TException : Exception
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            result.Exception = ExceptionCreator.Create(typeof(TException), "Exception for testing");

            return Task.CompletedTask;
        }
    }

    public static class ExceptionCreator
    {
        public static Exception Create(Type exceptionType, string message)
        {
            var exception = (Exception) FormatterServices.GetUninitializedObject(exceptionType);
            var m = typeof(Exception).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField);
            m.SetValue(exception, message);
            return exception;
        }
    }

    public class SimpleGetManyResourceCreationStep<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : GetManyContext<TResourceModel, TEntityModel>
        where TResult : PipelineResultBase, IHasResources<TResourceModel>
        where TResourceModel : IHasETag, new()
        where TEntityModel : class, IHasIdentifier, IDateVersionedEntity
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            result.Resources = new List<TResourceModel>();

            for (var i = 0; i < (context.QueryParameters.Limit ?? 25); i++)
            {
                result.Resources.Add(new TResourceModel());
            }

            return Task.CompletedTask;
        }
    }

    public class SetNullResourceStep<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TResult : IHasResource<TResourceModel>
        where TResourceModel : IHasETag
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            result.Resource = default(TResourceModel);

            return Task.CompletedTask;
        }
    }

    public class EmptyResourceStep<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    public class SingleStepPipelineProviderForTest
        : IGetPipelineStepsProvider,
          IPutPipelineStepsProvider,
          IDeletePipelineStepsProvider,
          IGetBySpecificationPipelineStepsProvider
    {
        private readonly Type _type;

        public SingleStepPipelineProviderForTest(Type type)
        {
            _type = type;
        }

        public Type[] GetSteps()
        {
            return new[]
                   {
                       _type
                   };
        }
    }
}
