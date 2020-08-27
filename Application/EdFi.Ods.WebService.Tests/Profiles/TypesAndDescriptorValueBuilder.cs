// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Specifications;
using EdFi.TestObjects;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public abstract class FakeLookupIdValueBuilderBase : IValueBuilder
    {
        private readonly string _propertySuffix;

        private ConcurrentDictionary<string, int> _numberByTypeName
            = new ConcurrentDictionary<string, int>();

        protected FakeLookupIdValueBuilderBase(string propertySuffix)
        {
            _propertySuffix = propertySuffix;
        }

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            string propertyName = buildContext.GetPropertyName();
            string logicalPath = buildContext.LogicalPropertyPath;

            var containingInstance = buildContext.GetContainingInstance();

            if (propertyName.EndsWith(_propertySuffix))
            {
                var descriptorValue = EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                    $"uri://ed-fi.org/{propertyName}",
                    propertyName.Substring(0, 1));

                var alreadyAssignedId = GetPropertyValue<int>(containingInstance, propertyName + "Id");

                // If already assigned, build new value based on existing Id
                if (alreadyAssignedId != 0)
                {
                    return ValueBuildResult.WithValue(descriptorValue + alreadyAssignedId, logicalPath);
                }

                string key = ProcessPathForLeafCollectionCounterResetBehavior(logicalPath);
                int number = _numberByTypeName.GetOrAdd(logicalPath, x => 1);
                var result = ValueBuildResult.WithValue(descriptorValue + number++, logicalPath);
                _numberByTypeName[key] = number;
                return result;
            }

            if (propertyName.EndsWith(_propertySuffix + "Id"))
            {
                string valuePropertyName = propertyName.TrimSuffix("Id");
                string valueLogicalPath = logicalPath.TrimSuffix("Id");

                string alreadyAssignedValue = GetPropertyValue<string>(containingInstance, valuePropertyName);

                // If already assigned, extract Id from the value
                if (alreadyAssignedValue != null)
                {
                    return ValueBuildResult.WithValue(Convert.ToInt32(alreadyAssignedValue.Last()), logicalPath);
                }

                string key = ProcessPathForLeafCollectionCounterResetBehavior(valueLogicalPath);
                int number = _numberByTypeName.GetOrAdd(key, x => 1);
                var result = ValueBuildResult.WithValue(number++, logicalPath);
                _numberByTypeName[key] = number;
                return result;
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset()
        {
            _numberByTypeName = new ConcurrentDictionary<string, int>();
        }

        public ITestObjectFactory Factory { get; set; }

        private string ProcessPathForLeafCollectionCounterResetBehavior(string logicalPropertyPath)
        {
            // This method ensures that the value builders will restart each leaf collection with an index of 1.

            var parts = logicalPropertyPath.Split('[');

            string lastPart = parts[parts.Length - 1];

            parts[parts.Length - 1] = Regex.Replace(lastPart, @"[0-9]+\]", "n]");

            return string.Join("[", parts);
        }

        private static T GetPropertyValue<T>(object instance, string propertyName)
        {
            try
            {
                T value = (T) instance.GetType()
                                      .GetProperty(propertyName)
                                      .GetValue(instance);

                return value;
            }
            catch
            {
                return default(T);
            }
        }
    }

    public class FakeEdFiTypeValueBuilder : FakeLookupIdValueBuilderBase
    {
        public FakeEdFiTypeValueBuilder()
            : base("Type") { }
    }

    public class FakeEdFiDescriptorValueBuilder : FakeLookupIdValueBuilderBase
    {
        public FakeEdFiDescriptorValueBuilder()
            : base("Descriptor") { }
    }
}
