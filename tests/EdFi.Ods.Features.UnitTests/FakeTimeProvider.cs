// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Utils;

namespace EdFi.Ods.Features.UnitTests;

// This class will be obsolete with .NET 8 and should be replaced using the one in Microsoft.Extensions.Time.Testing.
public class FakeTimeProvider : TimeProvider
{
    private DateTimeOffset _dateTimeOffset;

    public FakeTimeProvider()
    {
        _dateTimeOffset = DateTimeOffset.Now;
    }
    
    public FakeTimeProvider(DateTimeOffset dateTimeOffset)
    {
        _dateTimeOffset = dateTimeOffset;
    }

    public void Advance(TimeSpan amount)
    {
        _dateTimeOffset = _dateTimeOffset.Add(amount);
    }

    public void SetUtcNow(DateTimeOffset dateTimeOffset)
    {
        _dateTimeOffset = dateTimeOffset;
    }
    
    public override DateTime GetUtcNow() => _dateTimeOffset.DateTime;
}
