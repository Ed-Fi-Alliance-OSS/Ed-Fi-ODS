﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Common.Dependencies
{
    /// <summary>
    /// Provides static references to the specific services used by the generated artifacts.
    /// </summary>
    public static class GeneratedArtifactStaticDependencies
    {
        private static Lazy<IAuthorizationContextProvider> _authorizationContextProvider;
        private static Lazy<IResourceModelProvider> _resourceModelProvider;
        private static Lazy<IETagProvider> _etagProvider;

        private static Lazy<IDomainModelProvider> _domainModelProvider;
        private static Lazy<IContextProvider<ProfileContentTypeContext>> _profileContentTypeContextProvider;
        private static Lazy<IDatabaseEngineSpecificEqualityComparerProvider<string>> _databaseEngineSpecificStringComparerProvider;

        public static IAuthorizationContextProvider AuthorizationContextProvider => _authorizationContextProvider?.Value;
        public static IResourceModelProvider ResourceModelProvider => _resourceModelProvider?.Value;
        public static IETagProvider ETagProvider => _etagProvider?.Value;

        public static IDomainModelProvider DomainModelProvider => _domainModelProvider?.Value;
        public static IContextProvider<ProfileContentTypeContext> ProfileContentTypeContextProvider => _profileContentTypeContextProvider?.Value;
        public static IDatabaseEngineSpecificEqualityComparerProvider<string> DatabaseEngineSpecificStringComparerProvider => _databaseEngineSpecificStringComparerProvider?.Value;

        /// <summary>
        /// Provides a mechanism for providing resolution of container managed components (intended for use only
        /// during container initialization or testing).
        /// </summary>
        public static class Resolvers
        {
            public static void Set(Func<IAuthorizationContextProvider> resolver)
            {
                _authorizationContextProvider = new Lazy<IAuthorizationContextProvider>(resolver);
            }

            public static void Set(Func<IResourceModelProvider> resolver)
            {
                _resourceModelProvider = new Lazy<IResourceModelProvider>(resolver);
            }

            public static void Set(Func<IETagProvider> resolver)
            {
                _etagProvider = new Lazy<IETagProvider>(resolver);
            }

            public static void Set(Func<IDomainModelProvider> resolver)
            {
                _domainModelProvider = new Lazy<IDomainModelProvider>(resolver);
            }

            public static void Set(Func<IContextProvider<ProfileContentTypeContext>> resolver)
            {
                _profileContentTypeContextProvider = new Lazy<IContextProvider<ProfileContentTypeContext>>(resolver);
            }

            public static void Set(Func<IDatabaseEngineSpecificEqualityComparerProvider<string>> resolver)
            {
                _databaseEngineSpecificStringComparerProvider = new Lazy<IDatabaseEngineSpecificEqualityComparerProvider<string>>(resolver);
            }
        }
    }
}
