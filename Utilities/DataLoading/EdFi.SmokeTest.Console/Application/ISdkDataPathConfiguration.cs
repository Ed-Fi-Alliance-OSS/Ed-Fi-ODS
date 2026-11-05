// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.SmokeTest.Console.Application
{
    /// <summary>
    ///     Supplies the data-management path segment (OdsApi:DataPath) injected into the new-generator SDK's
    ///     HttpClient BaseAddress. This is intentionally a console-local interface rather than a member on the
    ///     packaged <c>EdFi.LoadTools.Engine.ISdkLibraryConfiguration</c>, to avoid a compatibility break for
    ///     external implementers of that published interface.
    /// </summary>
    public interface ISdkDataPathConfiguration
    {
        string DataPath { get; }
    }
}
