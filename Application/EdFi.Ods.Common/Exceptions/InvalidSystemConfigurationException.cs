// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

public class InvalidSystemConfigurationException : SystemConfigurationException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "invalid";
    private const string TitleText = "Invalid System Configuration";
    private const string DetailText = "The system configuration is invalid. Details are available in the server logs using the supplied correlation id.";

    protected InvalidSystemConfigurationException(string message)
        : base(DetailText, message) { }

    protected InvalidSystemConfigurationException(string message, Exception inner)
        : base(DetailText, message, inner) { }

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
}
