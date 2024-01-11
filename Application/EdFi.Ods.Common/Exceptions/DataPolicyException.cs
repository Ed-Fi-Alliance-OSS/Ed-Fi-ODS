// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

/// <summary>
/// An exception that indicates that a Profile (Data Policy) has prevented the request data from being processed.
/// </summary>
public class DataPolicyException : BadRequestDataException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "policy";
    private const string TitleText = "Data Policy Enforced";

    public DataPolicyException(string detail)
        : base(detail) { }

    public DataPolicyException(string detail, Dictionary<string, string[]> validationErrors)
        : base(detail)
    {
        ((IEdFiProblemDetails)this).ValidationErrors = validationErrors;
    }

    public DataPolicyException(string detail, string[] errors)
        : base(detail)
    {
        ((IEdFiProblemDetails)this).Errors = errors;
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
