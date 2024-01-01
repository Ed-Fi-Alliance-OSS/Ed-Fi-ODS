// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class SystemConfigurationException : InternalServerErrorException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "configuration";
    private const string TitleText = "System Configuration Error";

    public SystemConfigurationException(string detail, string message)
        : base(detail, message) { }

    public SystemConfigurationException(string detail, string message, Exception innerException)
        : base(detail, message, innerException) { }

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
