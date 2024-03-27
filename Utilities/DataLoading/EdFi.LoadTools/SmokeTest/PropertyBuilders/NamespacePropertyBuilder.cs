// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     Build an appropriate Namespace. Adjust using command line parameter.
    /// </summary>
    public class NamespacePropertyBuilder : BaseBuilder
    {
        private readonly IDestructiveTestConfiguration _configuration;

        public NamespacePropertyBuilder(IDestructiveTestConfiguration configuration, IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup)
        {
            _configuration = configuration;
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            var typeName = obj.GetType().Name;

            if (propertyInfo.PropertyType != typeof(string) || propertyInfo.Name != EdFiConstants.Namespace)
            {
                return false;
            }

            var namespaceUri = !string.IsNullOrEmpty(_configuration.NamespacePrefix)
                ? new Uri(_configuration.NamespacePrefix)
                : EdFiConstants.DefaultNamespaceUri;

            propertyInfo.SetValue(obj, namespaceUri.ToString());

            return true;
        }
    }
}
