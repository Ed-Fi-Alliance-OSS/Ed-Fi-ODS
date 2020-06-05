// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using NHibernate;
using NHibernate.Context;

namespace EdFi.Ods.Api.Common.Infrastructure.Architecture
{
    /// <summary>
    /// Implements a localized disposable scope for use of the "current" NHibernate session, abstracting any contextually 
    /// necessary activities around opening and disposing a new session (along with the binding and unbinding to the current context).
    /// </summary>
    public class SessionScope : IDisposable
    {
        private readonly ISessionFactory _sessionFactory;

        private ISession _session;
        private bool _shouldUnbindSession;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionScope" /> class using the specified NHibernate session factory.
        /// </summary>
        /// <param name="sessionFactory"></param>
        public SessionScope(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _shouldUnbindSession = EnsureSessionBinding();
        }

        /// <summary>
        /// Gets the current NHibernate session.
        /// </summary>
        public ISession Session => _sessionFactory.GetCurrentSession();

        /// <summary>
        /// Unbinds and disposes of the current session if it was established within the current <see cref="SessionScope"/>.
        /// </summary>
        public void Dispose()
        {
            if (_session != null && _shouldUnbindSession)
            {
                CurrentSessionContext.Unbind(_sessionFactory);
                _session.Dispose();
            }
        }

        private bool EnsureSessionBinding()
        {
            if (!CurrentSessionContext.HasBind(_sessionFactory))
            {
                _session = _sessionFactory.OpenSession();
                CurrentSessionContext.Bind(_session);
                return true;
            }
             
            if (!_sessionFactory.GetCurrentSession().IsOpen)
            {
                throw new Exception("CurrentSessionContext has binding to a session that is not open.");
            }

            return false;
        }
    }
}
