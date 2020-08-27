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
    ///     Build an appropriate Descriptor Namespace. Adjust using command line parameter.
    /// </summary>
    public class DescriptorNamespacePropertyBuilder : BaseBuilder
    {
        private readonly IDestructiveTestConfiguration _configuration;

        public DescriptorNamespacePropertyBuilder(IDestructiveTestConfiguration configuration, IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup)
        {
            _configuration = configuration;
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            var typeName = obj.GetType().Name;

            if (propertyInfo.PropertyType != typeof(string) || !typeName.EndsWith(EdFiConstants.Descriptor)
                                                            || propertyInfo.Name != EdFiConstants.Namespace)
            {
                return false;
            }

            var descriptorUri = !string.IsNullOrEmpty(_configuration.NamespacePrefix)
                ? new Uri(_configuration.NamespacePrefix)
                : EdFiConstants.DefaultDescriptorUri;

            propertyInfo.SetValue(obj, descriptorUri.ToString());

            return true;
        }
    }
}
