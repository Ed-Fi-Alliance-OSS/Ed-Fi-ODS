// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Autofac;
using EdFi.Ods.Common.InversionOfControl;

namespace EdFi.Ods.Api.NetCore.InversionOfControl
{
    public class AutofacServiceLocator : IServiceLocator
    {
        private readonly Lazy<ILifetimeScope> _container;

        public AutofacServiceLocator(Lazy<ILifetimeScope> container)
        {
            _container = container;
        }

        public object Resolve(Type type) => _container.Value.Resolve(type);

        public T Resolve<T>() => _container.Value.Resolve<T>();
    }
}
