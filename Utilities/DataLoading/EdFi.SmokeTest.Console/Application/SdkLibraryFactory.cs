// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Reflection;
using EdFi.LoadTools.Engine;

namespace EdFi.SmokeTest.Console.Application
{
    public class SdkLibraryFactory : ISdkLibraryFactory
    {
        public SdkLibraryFactory(ISdkLibraryConfiguration configuration)
        {
            SdkLibrary = Assembly.LoadFrom(configuration.Path);
        }

        public Assembly SdkLibrary { get; }
    }
}
