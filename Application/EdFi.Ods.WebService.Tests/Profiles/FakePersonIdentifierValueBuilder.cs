// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using EdFi.TestObjects;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public class FakePersonIdentifierValueBuilder : IValueBuilder
    {
        private ConcurrentDictionary<string, int> _numberByPersonType
            = new ConcurrentDictionary<string, int>();

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            string logicalPath = buildContext.LogicalPropertyPath;
            string propertyName = buildContext.GetPropertyName();
            var containingInstance = buildContext.GetContainingInstance();

            int number;
            ValueBuildResult result;

            string identifierPropertyName = propertyName.Contains("USI")
                ? "USI"
                : propertyName.Contains("UniqueId")
                    ? "UniqueId"
                    : string.Empty;

            if (string.IsNullOrEmpty(identifierPropertyName))
            {
                return ValueBuildResult.NotHandled;
            }

            var personType = Regex.Split(propertyName, identifierPropertyName)?[0];

            switch (identifierPropertyName)
            {
                case "USI":
                    var alreadyAssignedUniqueId = GetPropertyValue<string>(containingInstance, personType + "UniqueId");

                    if (alreadyAssignedUniqueId != null)
                    {
                        return ValueBuildResult.WithValue(int.Parse(alreadyAssignedUniqueId.Substring(1)), logicalPath);
                    }

                    number = _numberByPersonType.GetOrAdd(personType, x => 1);
                    result = ValueBuildResult.WithValue(number, logicalPath);
                    _numberByPersonType[personType] = ++number;
                    return result;

                case "UniqueId":
                    var alreadyAssignedUSI = GetPropertyValue<int>(containingInstance, personType + "USI");

                    if (alreadyAssignedUSI != 0)
                    {
                        return ValueBuildResult.WithValue("S" + alreadyAssignedUSI, logicalPath);
                    }

                    number = _numberByPersonType.GetOrAdd(personType, x => 1);
                    result = ValueBuildResult.WithValue("S" + number, logicalPath);
                    _numberByPersonType[personType] = ++number;
                    return result;
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset()
        {
            _numberByPersonType = new ConcurrentDictionary<string, int>();
        }

        public ITestObjectFactory Factory { get; set; }

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
}
