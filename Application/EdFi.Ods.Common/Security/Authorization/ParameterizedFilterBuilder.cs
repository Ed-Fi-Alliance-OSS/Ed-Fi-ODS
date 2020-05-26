// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;

namespace EdFi.Ods.Common.Security.Authorization
{
    public class ParameterizedFilterBuilder
    {
        public IDictionary<string, IDictionary<string, object>> Value { get; } = new Dictionary<string, IDictionary<string, object>>();

        public FilterDescriptor Filter(string filterName)
        {
            if (!Value.ContainsKey(filterName))
            {
                Value[filterName] = new Dictionary<string, object>();
            }

            return new FilterDescriptor(filterName, Value);
        }
    }

    public class FilterDescriptor
    {
        private readonly string _filterName;

        public FilterDescriptor(string filterName, IDictionary<string, IDictionary<string, object>> filters)
        {
            _filterName = filterName;
            Value = filters;
        }

        public IDictionary<string, IDictionary<string, object>> Value { get; }

        public FilterDescriptor Set(string parameterName, object parameterValue)
        {
            Value[_filterName][parameterName] = parameterValue;

            return this;
        }
    }
}
