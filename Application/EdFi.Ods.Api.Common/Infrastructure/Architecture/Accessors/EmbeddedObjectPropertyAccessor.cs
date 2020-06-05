// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Conventions;
using NHibernate.Properties;

namespace EdFi.Ods.Api.Common.Infrastructure.Architecture.Accessors
{
    public class EmbeddedObjectPropertyAccessor : IPropertyAccessor
    {
        private readonly IPropertyAccessor _accessor = new BasicPropertyAccessor();

        public IGetter GetGetter(Type type, string propertyName)
        {
            return _accessor.GetGetter(type, propertyName + SystemConventions.OneToOneEntityPropertyNameSuffix);
        }

        public ISetter GetSetter(Type type, string propertyName)
        {
            return _accessor.GetSetter(type, propertyName + SystemConventions.OneToOneEntityPropertyNameSuffix);
        }

        public bool CanAccessThroughReflectionOptimizer
        {
            get { return _accessor.CanAccessThroughReflectionOptimizer; }
        }
    }
}
