// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.LoadTools.Mapping
{
    public class MapperConfiguration
    {
        private readonly Action<IMapperConfigurationExpression> _configurationExpression;
        private readonly List<Map<PropertyInfoEx>> _mappings = new List<Map<PropertyInfoEx>>();

        public MapperConfiguration(Action<IMapperConfigurationExpression> configurationExpression)
        {
            _configurationExpression = configurationExpression;
        }

        public bool ConfigurationIsValid { get; private set; }

        public Mapper CreateMapper()
        {
            if (!ConfigurationIsValid)
            {
                AssertConfigurationIsValid();
            }

            return new Mapper(_mappings);
        }

        public void AssertConfigurationIsValid()
        {
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            _configurationExpression(mapperConfigurationExpression);
            mapperConfigurationExpression.AddMapperConstraints(_mappings);
            ConfigurationIsValid = true;
        }
    }
}
