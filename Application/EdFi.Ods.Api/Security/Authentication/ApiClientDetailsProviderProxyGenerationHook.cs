// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using Castle.DynamicProxy;
using EdFi.Common.Security;

namespace EdFi.Ods.Api.Security.Authentication
{
    /// <summary>
    /// Keeps the API client lookup by key out of the interceptors applied to <see cref="IApiClientDetailsProvider" />,
    /// so that a changed secret is read from the Admin database on every token request instead of from the cache.
    /// </summary>
    public class ApiClientDetailsProviderProxyGenerationHook : IProxyGenerationHook
    {
        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return !(methodInfo.DeclaringType == typeof(IApiClientDetailsProvider)
                && methodInfo.Name == nameof(IApiClientDetailsProvider.GetApiClientDetailsForKeyAsync));
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo) { }

        public void MethodsInspected() { }

        // Castle reuses generated proxy types only when the hooks are equal
        public override bool Equals(object obj) => obj is ApiClientDetailsProviderProxyGenerationHook;

        public override int GetHashCode() => typeof(ApiClientDetailsProviderProxyGenerationHook).GetHashCode();
    }
}
