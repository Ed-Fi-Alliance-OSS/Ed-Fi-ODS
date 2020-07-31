// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;

namespace EdFi.LoadTools.Mapping
{
    public interface IMapperConfigurationExpression
    {
        IMapperConfigurationExpression CreateMap(Type source, Type target);

        IMapperConfigurationExpression CreateMap<TSource, TTarget>();
    }

    internal interface ICompileMapperConfiguration
    {
        void AddMapperConstraints(List<Map<PropertyInfoEx>> mappings);
    }
}
