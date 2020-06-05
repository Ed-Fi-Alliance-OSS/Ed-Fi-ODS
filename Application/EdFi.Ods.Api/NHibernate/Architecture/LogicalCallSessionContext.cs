// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections;
using EdFi.Ods.Common.Context;
using NHibernate.Context;
using NHibernate.Engine;

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    [Serializable]
    public class LogicalCallSessionContext : MapBasedSessionContext
    {
        private const string SessionFactoryMapKey = "NHibernate.Context.LogicalCallSessionContext.SessionFactoryMapKey";

        public LogicalCallSessionContext(ISessionFactoryImplementor factory)
            : base(factory) { }

        /// <summary>
        /// The key is the session factory and the value is the bound session.
        /// </summary>
        protected override void SetMap(IDictionary value)
        {
            CallContext.SetData(SessionFactoryMapKey, value);
        }

        /// <summary>
        /// The key is the session factory and the value is the bound session.
        /// </summary>
        protected override IDictionary GetMap()
        {
            return CallContext.GetData(SessionFactoryMapKey) as IDictionary;
        }
    }
}
