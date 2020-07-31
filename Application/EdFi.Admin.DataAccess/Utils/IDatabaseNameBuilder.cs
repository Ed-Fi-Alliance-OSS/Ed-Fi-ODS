// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Admin.DataAccess.Utils
{
    public interface IDatabaseNameBuilder
    {
        string EmptyDatabase { get; }

        string MinimalDatabase { get; }

        string SampleDatabase { get; }

        string DemoSandboxDatabase { get; }

        string SandboxNameForKey(string key);

        string KeyFromSandboxName(string sandboxName);

        string TemplateSandboxNameForKey(string sandboxKey);
    }
}
