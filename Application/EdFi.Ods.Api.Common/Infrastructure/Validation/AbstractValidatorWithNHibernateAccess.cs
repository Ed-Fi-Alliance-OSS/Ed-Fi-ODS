// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using FluentValidation;
using NHibernate;
using NHibernate.Context;

namespace EdFi.Ods.Api.Common.Infrastructure.Validation
{
    /// <summary>
    /// Provides a base class for writing FluentValidation validators that need access to the ODS through the NHibernate model.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the model being validated.</typeparam>
    public abstract class AbstractValidatorWithNHibernateAccess<T> : AbstractValidator<T>
    {
        protected readonly ISessionFactory SessionFactory;

        protected AbstractValidatorWithNHibernateAccess(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        /// <summary>
        /// Gets the current session (should call <see cref="EnsureSessionContextBinding"/> before accessing this property).
        /// </summary>
        private ISession Session
        {
            get { return SessionFactory.GetCurrentSession(); }
        }

        /// <summary>
        /// Ensures that the current context has a session (connection) binding, opening
        /// a new session if necessary.
        /// </summary>
        /// <returns><b>true</b> if a session had to be created (and thus should be subsequently released); otherwise <b>false</b>.</returns>
        private bool EnsureSessionContextBinding()
        {
            if (CurrentSessionContext.HasBind(SessionFactory))
            {
                return false;
            }

            CurrentSessionContext.Bind(SessionFactory.OpenSession());

            return true;
        }

        /// <summary>
        /// Invokes the supplied function with a Session, handling the details of binding/unbinding with the <see cref="CurrentSessionContext"/>.
        /// </summary>
        /// <param name="validation">The function to be invoked.</param>
        /// <returns>The return value from the supplied function.</returns>
        protected bool ValidateUsingSession(Func<ISession, bool> validation)
        {
            var shouldReleaseBind = EnsureSessionContextBinding();

            try
            {
                return validation(Session);
            }
            finally
            {
                if (shouldReleaseBind)
                {
                    CurrentSessionContext.Unbind(SessionFactory);
                }
            }
        }
    }
}
