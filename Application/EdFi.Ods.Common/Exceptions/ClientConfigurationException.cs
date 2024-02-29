// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

public class ClientConfigurationException : InternalServerErrorException
{
    private const string TypePart = "client-configuration";
    private const string TitleText = "Client Configuration";

    public new const string DefaultDetail = "The security configuration for the caller is invalid.";

    public ClientConfigurationException(string detail, string error)
        : base(detail, error)
    {
        if (error != null)
        {
            this.SetErrors(error);
        }
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
