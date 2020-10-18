// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using Autofac;
using NHibernate.Bytecode;

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public class NHibernateAutofacObjectsFactory : IObjectsFactory
    {
        private readonly IComponentContext _container;

        public NHibernateAutofacObjectsFactory(ILifetimeScope container)
        {
            _container = container;
        }

        public object CreateInstance(Type type)
        {
            return _container.ResolveOptional(type) ?? Activator.CreateInstance(type);
        }

        public object CreateInstance(Type type, bool nonPublic)
        {
            return _container.ResolveOptional(type) ?? Activator.CreateInstance(type, nonPublic);
        }

        public object CreateInstance(Type type, params object[] ctorArgs)
        {
            return _container.ResolveOptional(
                       type,
                       (ctorArgs ?? Enumerable.Empty<object>()).Select((p, i) => new PositionalParameter(i, p))) ??
                   Activator.CreateInstance(type, ctorArgs);
        }
    }
}
