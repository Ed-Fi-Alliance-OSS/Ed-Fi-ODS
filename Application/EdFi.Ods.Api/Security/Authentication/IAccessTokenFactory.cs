// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.Security.Authentication;

public interface IAccessTokenFactory
{
    Task<AccessToken> CreateAccessTokenAsync(int apiClientId, string scope = null);
}

public record AccessToken(Guid Id, TimeSpan Duration, string Scope)
{
    public Guid Id { get; set; } = Id;

    public TimeSpan Duration { get; set; } = Duration;

    public string Scope { get; set; } = Scope;
}
