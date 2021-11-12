// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using NHibernate;

namespace EdFi.Ods.Api.Infrastructure.Pipelines
{
    public interface IPipeline
    {
        object Process(object context);

        Task<object> ProcessAsync(object context, CancellationToken cancellationToken);
    }

    public abstract class PipelineBase<TContext, TResult> : IPipeline
        where TResult : PipelineResultBase, new()
    {
        private readonly IStep<TContext, TResult>[] _steps;
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Initializes an instance of the PipelineBase.
        /// </summary>
        /// <param name="steps">The pipeline steps to be executed.</param>
        protected PipelineBase(IStep<TContext, TResult>[] steps)
        {
            _steps = steps;
        }
        
        /// <summary>
        /// Initializes an instance of the PipelineBase with a session factory for enabling NHibernate 
        /// lazy loading features to function under exceptional conditions during GET request processing.
        /// </summary>
        /// <param name="steps">The pipeline steps to be executed.</param>
        /// <param name="sessionFactory">The NHibernate <see cref="ISessionFactory" />.</param>
        protected PipelineBase(IStep<TContext, TResult>[] steps, ISessionFactory sessionFactory)
            : this(steps)
        {
            _sessionFactory = sessionFactory;
        }

        public object Process(object context) => ProcessAsync((TContext) context, CancellationToken.None).GetResultSafely();

        async Task<object> IPipeline.ProcessAsync(object context, CancellationToken cancellationToken)
        {
            return await ProcessAsync((TContext) context, cancellationToken);
        }

        public async Task<TResult> ProcessAsync(TContext context, CancellationToken cancellationToken)
        {
            var result = new TResult();

            // NOTE: The sessionScope will allow NHibernate lazy-loading features to function correctly in exceptional
            // conditions during GET request processing. In particular, this can be an issue if during mapping of the
            // entity data to resource data, the "ReferenceData" object hasn't been properly hydrated by NHibernate due to
            // a casing mismatch between the value for the property on the current entity and the referenced entity's value
            // as it exists the database. While SQL Server uses case-insensitive collation by default, NHibernate
            // fails to recognize the "reference data" that has already been retrieved for the reference as relevant for
            // hydrating the ReferenceData object. This leaves an uninitialized "proxy" object, which when referenced by
            // the entity-to-resource mapper, causes NHibernate to perform lazy initialization and go back to the
            // database to fetch it. Without the session still available here, an exception will occur.

            // Establish a session scope if we have a session factory available here
            var sessionScope = _sessionFactory == null 
                ? null 
                : new SessionScope(_sessionFactory);

            try
            {
                foreach (var step in _steps)
                {
                    await step.ExecuteAsync(context, result, cancellationToken);

                    // If we have experienced an exception, quit processing steps now
                    if (result.Exception != null)
                    {
                        break;
                    }
                }
            }
            finally
            {
                // Close the session, if one exists
                sessionScope?.Dispose();
            }

            return result;
        }
    }
}
