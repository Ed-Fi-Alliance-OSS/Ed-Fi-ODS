// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Metadata.Composites;

public class CompositeCategory
{
    /// <summary>
    /// Initializes a new instance of the <see cref="T:CompositeCategory"/> class.
    /// </summary>
    public CompositeCategory(string organizationCode, string name, string displayName)
    {
        OrganizationCode = organizationCode;
        Name = name;
        DisplayName = displayName;
    }

    public CompositeCategory(string organizationCode, string name)
    {
        OrganizationCode = organizationCode;
        Name = name;
    }

    public string OrganizationCode { get; }

    public string Name { get; }

    public string DisplayName { get; }
}