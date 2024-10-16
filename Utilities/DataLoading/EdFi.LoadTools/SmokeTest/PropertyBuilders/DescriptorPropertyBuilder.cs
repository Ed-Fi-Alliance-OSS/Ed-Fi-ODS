// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using EdFi.LoadTools.Common;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     Lookup a descriptor property from a real property
    /// </summary>
    public class DescriptorPropertyBuilder : BaseBuilder
    {
        private readonly Dictionary<string, List<object>> _resultsDictionary;
        private readonly List<string> _schemaNames;

        public DescriptorPropertyBuilder(
            Dictionary<string, List<object>> resultsDictionary,
            IPropertyInfoMetadataLookup metadataLookup,
            List<string> schemaNames = null)
            : base(metadataLookup)
        {
            _resultsDictionary = resultsDictionary;
            _schemaNames = schemaNames;
        }

        private static bool IsDescriptorProperty(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType == typeof(string)
                   && Regex.IsMatch(propertyInfo.Name, @"[dD]escriptor$");
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType != typeof(string))
            {
                return false;
            }

            if (!IsDescriptorProperty(propertyInfo))
            {
                return false;
            }

            var lookup = GetLookup(propertyInfo);

            if (lookup == null)
            {
                return false;
            }

            string codeValue = lookup.GetType()
                .GetProperty(EdFiConstants.CodeValue)
                .GetValue(lookup).ToString();

            var uri = lookup.GetType()
                .GetProperty(EdFiConstants.Namespace)
                .GetValue(lookup);

            var descriptorValue = uri != null &&  !string.IsNullOrEmpty(uri.ToString())
                ? new Uri(new Uri(uri.ToString()), $"#{codeValue}")
                : new Uri(EdFiConstants.DefaultNamespaceUri, $"{propertyInfo.Name}#{codeValue}");

            propertyInfo.SetValue(obj, descriptorValue.ToString());
            return true;
        }

        private object GetLookup(PropertyInfo propertyInfo)
        {
            return propertyInfo.PossiblePropertyNames(_schemaNames)
                .Select(
                    n =>
                    {
                        // check to see if the results contains the descriptor
                        if (_resultsDictionary.ContainsKey(n))
                        {
                            return _resultsDictionary[n]
                                .FirstOrDefault();
                        }

                        // check to see if there is an edfi specific version of the descriptor
                        if (_resultsDictionary.ContainsKey("EdFi" + n))
                        {
                            return _resultsDictionary["EdFi" + n]
                                .FirstOrDefault();
                        }

                        return null;
                    })
                .FirstOrDefault(
                    x => x?.GetType()
                             .GetProperty(EdFiConstants.CodeValue) != null
                         && x.GetType()
                             .GetProperty(EdFiConstants.ShortDescription) != null);
        }
    }
}
