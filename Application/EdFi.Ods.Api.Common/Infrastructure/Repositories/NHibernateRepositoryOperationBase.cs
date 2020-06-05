// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Validation;
using NHibernate;
using NHibernate.Context;

namespace EdFi.Ods.Api.Common.Infrastructure.Repositories
{
    /// <summary>
    /// Provides session management for NHibernate-based repository implementations.
    /// </summary>
    public abstract class NHibernateRepositoryOperationBase
    {
        protected readonly ISessionFactory SessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateRepositoryOperationBase"/> class using the specified NHibernate session factory.
        /// </summary>
        /// <param name="sessionFactory"></param>
        protected NHibernateRepositoryOperationBase(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        /// <summary>
        /// Gets the current session (should wrap usage in a new <see cref="SessionScope"/> instance before accessing this property).
        /// </summary>
        protected ISession Session
        {
            get => SessionFactory.GetCurrentSession();
        }
    }

    public abstract class ValidatingNHibernateRepositoryOperationBase : NHibernateRepositoryOperationBase
    {
        private readonly IEnumerable<IEntityValidator> _validators;

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateRepositoryOperationBase"/> class using the specified NHibernate session factory.
        /// </summary>
        /// <param name="sessionFactory"></param>
        /// <param name="validators"></param>
        protected ValidatingNHibernateRepositoryOperationBase(ISessionFactory sessionFactory, IEnumerable<IEntityValidator> validators)
            : base(sessionFactory)
        {
            _validators = validators;
        }

        protected void ValidateEntity<TEntity>(TEntity entity)
        {
            var validationResults = _validators.ValidateObject(entity);

            if (!validationResults.IsValid())
            {
                throw new ValidationException(
                    $"Validation of '{entity.GetType().Name}' failed.{Environment.NewLine}{string.Join(Environment.NewLine, validationResults.GetAllMessages(indentLevel: 1))}");
            }
        }
    }
}
