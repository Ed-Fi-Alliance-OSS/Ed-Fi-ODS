// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

/// <summary>
/// An exception that indicates that a Profile (Data Policy) has prevented the request data from being processed.
/// </summary>
public class DataPolicyException : BadRequestException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "data-policy";
    private const string TitleText = "Data Policy Enforced";
    private const string DefaultDetail =
        "The resource cannot be saved because a data policy has been applied to the request that prevents it.";

    private const string ResourceMessageFormat =
        "The Profile definition for '{0}' excludes (or does not include) one or more required data elements needed to create the resource.";

    private const string ResourceChildMessageFormat =
        "The Profile definition for '{0}' excludes (or does not include) one or more required data elements needed to create a child item of type '{1}' in the resource.";
    
    public DataPolicyException(string profileName)
        : base(DefaultDetail)
    {
        this.SetErrors(string.Format(ResourceMessageFormat, profileName));
    }

    public DataPolicyException(string profileName, string childTypeName)
        : base(DefaultDetail)
    {
        this.SetErrors(string.Format(ResourceChildMessageFormat, profileName, childTypeName));
    }
    
    // ---------------------------
    //  Boilerplate for overrides
    // ---------------------------
    public override string Title { get => TitleText; }

    protected override IEnumerable<string> GetTypeParts()
    {
        foreach (var part in base.GetTypeParts())
        {
            yield return part;
        }

        yield return TypePart;
    }
    // ---------------------------
}
