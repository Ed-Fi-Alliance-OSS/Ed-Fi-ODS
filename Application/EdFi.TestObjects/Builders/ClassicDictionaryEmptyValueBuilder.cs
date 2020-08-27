// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections;
using System.Collections.Generic;

namespace EdFi.TestObjects.Builders
{
    public class ClassicDictionaryEmptyValueBuilder : IValueBuilder
    {
        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType != typeof(IDictionary))
            {
                return ValueBuildResult.NotHandled;
            }

            return ValueBuildResult.WithValue(new Dictionary<string, object>(), buildContext.LogicalPropertyPath);
        }

        public void Reset() { }

        public ITestObjectFactory Factory { get; set; }
    }
}
