// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using Castle.MicroKernel;
using Castle.Windsor;
using NHibernate.Bytecode;

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    public class WindsorObjectsFactory : IObjectsFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorObjectsFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public object CreateInstance(Type type, params object[] ctorArgs)
        {
            // NOTE: From NHibernate Repo [Obsolete("This method has no more usages and will be removed in a future version")]
            if (_container.Kernel.HasComponent(type) || _container.Kernel.HasComponent(type.FullName))
            {
                return _container.Resolve(type, Arguments.FromProperties(ctorArgs));
            }

            return Activator.CreateInstance(type, ctorArgs);
        }

        public object CreateInstance(Type type, bool nonPublic)
        {
            // NOTE: From NHibernate Repo [Obsolete("This method has no more usages and will be removed in a future version")]
            if (_container.Kernel.HasComponent(type) || _container.Kernel.HasComponent(type.FullName))
            {
                return _container.Resolve(type);
            }

            return Activator.CreateInstance(type, nonPublic);
        }

        public object CreateInstance(Type type)
        {
            if (_container.Kernel.HasComponent(type) || _container.Kernel.HasComponent(type.FullName))
            {
                return _container.Resolve(type);
            }

            return Activator.CreateInstance(type);
        }
    }
}
#endif