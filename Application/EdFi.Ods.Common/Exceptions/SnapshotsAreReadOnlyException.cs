// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Common.Exceptions;

public class SnapshotsAreReadOnlyException : EdFiProblemDetailsExceptionBase
{
    // Fields containing override values for Problem Details
    private const string TypePart = "snapshots:method-not-allowed";
    private const string TitleText = "Method Not Allowed with Snapshots";

    private const int StatusValue = StatusCodes.Status405MethodNotAllowed;

    private const string DefaultDetail = "An attempt was made to modify data in a Snapshot, but this data is read-only.";

    public SnapshotsAreReadOnlyException()
        : base(DefaultDetail, DefaultDetail) { }

    // ---------------------------
    //  Boilerplate for overrides
    // ---------------------------
    public override string Title { get => TitleText; }

    public override int Status { get => StatusValue; }
    
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
