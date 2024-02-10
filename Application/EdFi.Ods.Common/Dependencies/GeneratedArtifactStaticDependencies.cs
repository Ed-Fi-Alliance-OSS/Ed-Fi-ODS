// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Security;
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
        private static Lazy<IProfileResourceModelProvider> _profileResourceModelProvider;
        private static Lazy<IDomainModelProvider> _domainModelProvider;
        private static Lazy<IETagProvider> _etagProvider;
        private static Lazy<IMappingContractProvider> _mappingContractProvider;
        private static Lazy<IContextProvider<ProfileContentTypeContext>> _profileContentTypeContextProvider;
        private static Lazy<IContextProvider<UniqueIdLookupsByUsiContext>> _uniqueIdLookupsContextProvider;
        private static Lazy<IContextProvider<UsiLookupsByUniqueIdContext>> _usiLookupsContextProvider;
        private static Lazy<IContextProvider<DataPolicyException>> _dataPolicyExceptionContextProvider;
        private static Lazy<StringComparer> _databaseEngineSpecificStringComparer;
        private static Lazy<IDescriptorResolver> _descriptorResolver;

        public static IAuthorizationContextProvider AuthorizationContextProvider => _authorizationContextProvider?.Value;
        public static IResourceModelProvider ResourceModelProvider => _resourceModelProvider?.Value;
        public static IProfileResourceModelProvider ProfileResourceModelProvider => _profileResourceModelProvider?.Value;
        public static IDomainModelProvider DomainModelProvider => _domainModelProvider?.Value;
        public static IETagProvider ETagProvider => _etagProvider?.Value;
        public static IMappingContractProvider MappingContractProvider => _mappingContractProvider?.Value;
        public static IContextProvider<ProfileContentTypeContext> ProfileContentTypeContextProvider => _profileContentTypeContextProvider?.Value;
        public static IContextProvider<UniqueIdLookupsByUsiContext> UniqueIdLookupsByUsiContextProvider => _uniqueIdLookupsContextProvider?.Value;
        public static IContextProvider<UsiLookupsByUniqueIdContext> UsiLookupsByUniqueIdContextProvider => _usiLookupsContextProvider?.Value;
        public static IContextProvider<DataPolicyException> DataPolicyExceptionContextProvider => _dataPolicyExceptionContextProvider?.Value;
        public static StringComparer DatabaseEngineSpecificStringComparer => _databaseEngineSpecificStringComparer?.Value;
        public static IDescriptorResolver DescriptorResolver => _descriptorResolver?.Value;

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

            public static void Set(Func<IProfileResourceModelProvider> resolver)
            {
                _profileResourceModelProvider = new Lazy<IProfileResourceModelProvider>(resolver);
            }

            public static void Set(Func<IDomainModelProvider> resolver)
            {
                _domainModelProvider = new Lazy<IDomainModelProvider>(resolver);
            }

            public static void Set(Func<IETagProvider> resolver)
            {
                _etagProvider = new Lazy<IETagProvider>(resolver);
            }
            
            public static void Set(Func<IMappingContractProvider> resolver)
            {
                _mappingContractProvider = new Lazy<IMappingContractProvider>(resolver);
            }

            public static void Set(Func<IContextProvider<ProfileContentTypeContext>> resolver)
            {
                _profileContentTypeContextProvider = new Lazy<IContextProvider<ProfileContentTypeContext>>(resolver);
            }

            public static void Set(Func<IContextProvider<UniqueIdLookupsByUsiContext>> resolver)
            {
                _uniqueIdLookupsContextProvider = new Lazy<IContextProvider<UniqueIdLookupsByUsiContext>>(resolver);
            }

            public static void Set(Func<IContextProvider<UsiLookupsByUniqueIdContext>> resolver)
            {
                _usiLookupsContextProvider = new Lazy<IContextProvider<UsiLookupsByUniqueIdContext>>(resolver);
            }

            public static void Set(Func<IContextProvider<DataPolicyException>> resolver)
            {
                _dataPolicyExceptionContextProvider = new Lazy<IContextProvider<DataPolicyException>>(resolver);
            }

            public static void Set(Func<StringComparer> resolver)
            {
                _databaseEngineSpecificStringComparer = new Lazy<StringComparer>(resolver);
            }

            public static void Set(Func<IDescriptorResolver> resolver)
            {
                _descriptorResolver = new Lazy<IDescriptorResolver>(resolver);
            }
        }
    }
}
