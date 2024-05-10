// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

public class KeyChangeNotSupportedException : BadRequestDataException
{
    private const string TypePart = "key-change-not-supported";
    private const string DetailTextFormat =
        "Identifying values for the {0} item cannot be changed. Delete and recreate the item instead.";
    private const string TitleText = "Key Change Not Supported";

    public KeyChangeNotSupportedException(string entityName)
        : base(string.Format(DetailTextFormat, entityName)) { }
    
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
