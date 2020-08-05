// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Conventions
{
    public static class EdFiConventions
    {
        private static readonly ConcurrentDictionary<Assembly, bool> _isProfileAssemblyByAssembly =
            new ConcurrentDictionary<Assembly, bool>();

        public static string LogicalName => "Ed-Fi";

        public static string PhysicalSchemaName => "edfi";

        public static string ProperCaseName => "EdFi";

        public static string UriSegment => "ed-fi";

        public static string OrganizationCode => UriSegment;

        public static string OpenApiMetadataRouteNamePrefix => "OpenApiMetadata";

        public static string GetOpenApiMetadataRouteName(string name) => $"{OpenApiMetadataRouteNamePrefix}{name}";

        public static bool IsStandardAssembly(this Assembly assembly) => assembly.GetName()
                                                                                 .Name.IsStandardAssembly();

        public static bool IsStandardAssembly(this string assemblyName) => assemblyName == Namespaces.Standard.BaseNamespace;

        public static bool IsProfileAssembly(Assembly assembly) => _isProfileAssemblyByAssembly.GetOrAdd(
            assembly,
            assembly.FullName.Contains(".Profiles.")
            && assembly.GetManifestResourceNames()
                       .Any(x => x.EndsWithIgnoreCase("profiles.xml")));

        public static bool IsEdFiPhysicalSchemaName(string schema) => PhysicalSchemaName.Equals(schema);

        /// <summary>
        /// Applies proper case naming conventions to namespace and object provided.
        /// </summary>
        /// <param name="baseNamespace">The base namespace upon which to build the full namespace.</param>
        /// <param name="schemaProperCaseName">The proper case name representation of the schema.</param>
        /// <param name="className">The name of the entity or resource class.</param>
        /// <param name="isExtensionObject">Indicates if this is an extension object</param>
        /// <returns>fully-qualified namespace</returns>
        public static string BuildNamespace(
            string baseNamespace,
            string schemaProperCaseName,
            string className = null,
            bool isExtensionObject = false)
        {
            var objectNameSegment = className == null
                ? string.Empty
                : $".{className}";

            return isExtensionObject
                ? $"{baseNamespace}.{schemaProperCaseName}{objectNameSegment}"
                : $"{baseNamespace}{objectNameSegment}.{schemaProperCaseName}";
        }

        // Standard Resource
        // ----------------------------------------------------------
        // EdFi.Ods.Api.Models.Resources . School                 .  EdFi    .              (null)                        .         (null)
        //    {ResourceBaseNamespace}    . {ResourceName}         . {Schema} .          {ProfileNamespaceSegment}         . {ProfileNamespaceBaseChildrenContext}

        // Extension Resources
        // ----------------------------------------------------------
        // EdFi.Ods.Api.Models.Resources . Applicant              .  Talent  .              (null)                        .         (null)                        .   (null)   .       null
        //    {ResourceBaseNamespace}    . {ResourceName}         . {Schema} .          {ProfileNamespaceSegment}         . {ProfileNamespaceBaseChildrenContext} . Extensions . {ExtensionSchema}

        // Resource Extensions
        // ----------------------------------------------------------
        // EdFi.Ods.Api.Models.Resources . Student                .  EdFi    .              (null)                        .         (null)                        . Extensions .    GrandBend
        //    {ResourceBaseNamespace}    . {ResourceName}         . {Schema} .          {ProfileNamespaceSegment}         . {ProfileNamespaceBaseChildrenContext} . Extensions . {ExtensionSchema}

        // Profile-based namespace, with Profile base class context
        // ----------------------------------------------------------
        // EdFi.Ods.Api.Models.Resources . EducationOrganization  .   EdFi   . Test_Profile_Resource_IncludeOnly_Writable .          School
        //    {ResourceBaseNamespace}    . {ResourceName}         . {Schema} .          {ProfileNamespaceSegment}         . {ProfileNamespaceBaseChildrenContext}

        // Profile-based namespace
        // ----------------------------------------------------------
        // EdFi.Ods.Api.Models.Resources . School                 . EdFi     . Test_Profile_Resource_IncludeOnly_Writable .         (null)
        //    {ResourceBaseNamespace}    . {ResourceName}         . {Schema} .          {ProfileNamespaceSegment}         . {ProfileNamespaceBaseChildrenContext}

        /// <summary>
        /// Gets the full namespace for the specified resource's classes.
        /// </summary>
        /// <param name="resourceSchemaProperCaseName"></param>
        /// <param name="resourceName"></param>
        /// <param name="profileNamespaceName"></param>
        /// <param name="profileReadableWritableContext"></param>
        /// <param name="profileNamespaceBaseChildrenConcreteContext"></param>
        /// <param name="resourceExtensionSchemaProperCaseName">For resource extensions, the schema proper case name of the extension.</param>
        /// <returns>The full namespace for the specified resource's classes.</returns>
        public static string CreateResourceNamespace(
            string resourceSchemaProperCaseName,
            string resourceName,
            string profileNamespaceName = null,
            string profileReadableWritableContext = null,
            string profileNamespaceBaseChildrenConcreteContext = null,
            string resourceExtensionSchemaProperCaseName = null)
        {
            if (resourceSchemaProperCaseName == null)
            {
                throw new ArgumentNullException(nameof(resourceSchemaProperCaseName));
            }

            if (resourceName == null)
            {
                throw new ArgumentNullException(nameof(resourceName));
            }

            string profileNamespaceSegment = string.Empty;

            if (!string.IsNullOrWhiteSpace(profileNamespaceName))
            {
                profileNamespaceSegment = "." + profileNamespaceName;
            }

            if (!string.IsNullOrWhiteSpace(profileReadableWritableContext))
            {
                profileNamespaceSegment += profileReadableWritableContext;
            }

            if (!string.IsNullOrWhiteSpace(profileNamespaceBaseChildrenConcreteContext))
            {
                if (string.IsNullOrWhiteSpace(profileNamespaceName))
                {
                    throw new Exception(
                        $"{nameof(profileNamespaceBaseChildrenConcreteContext)} was supplied without a value for {nameof(profileNamespaceName)}.");
                }

                profileNamespaceSegment += "." + profileNamespaceBaseChildrenConcreteContext.TrimStart('.');
            }

            string extensionNamespaceSegment = null;

            if (resourceExtensionSchemaProperCaseName != null)
            {
                extensionNamespaceSegment = ".Extensions." + resourceExtensionSchemaProperCaseName;
            }

            // NOTE: This will return a more sensible namespace, but will break Resources.generated.cs files due to non-calculated relative namespaces that used embedded ordering of the segments
            //return $"{Namespaces.Resources.BaseNamespace}.{resourceSchemaProperCaseName}.{resourceName}{profileNamespaceSegment}{extensionNamespaceSegment}";

            return
                $"{Namespaces.Resources.BaseNamespace}.{resourceName}.{resourceSchemaProperCaseName}{profileNamespaceSegment}{extensionNamespaceSegment}";
        }

        /// <summary>
        /// Applies proper case naming conventions to namespace and object provided.
        /// </summary>
        /// <param name="resource">The name of the entity or resource class.</param>
        /// <param name="profileNamespaceName">The profile name represented as an identifier to be used in a .NET namespace, if applicable.</param>
        /// <param name="profileReadableWritableContext"></param>
        /// <param name="profileNamespaceBaseChildrenConcreteContext">The concrete resource context to be applied to a base resource's child classes, if applicable.</param>
        /// <param name="extensionSchemaProperCaseName"></param>
        /// <returns>fully-qualified namespace</returns>
        public static string CreateResourceNamespace(
            Resource resource,
            string profileNamespaceName = null,
            string profileReadableWritableContext = null,
            string profileNamespaceBaseChildrenConcreteContext = null,
            string extensionSchemaProperCaseName = null)
        {
            return CreateResourceNamespace(

                // Resource context
                resource.SchemaProperCaseName,
                resource.Name,

                // Profile namespace
                profileNamespaceName,
                profileReadableWritableContext,
                profileNamespaceBaseChildrenConcreteContext,

                // Resource extensions context
                extensionSchemaProperCaseName);
        }

        public static string GetResourceInterfaceName(
            this ResourceClassBase resourceClassBase,
            string schemaProperCaseName,
            bool isProfilesContext,
            bool isExtension)
        {
            return isProfilesContext || isExtension
                ? $"{Namespaces.Entities.Common.RelativeNamespace}.{schemaProperCaseName}.I{resourceClassBase.Name}"
                : $"I{resourceClassBase.Name}";
        }

        public static bool IsEdFiEntity(this Type type)
        {
            return type.FullName.StartsWith(Namespaces.Entities.NHibernate.BaseNamespace);
        }

        public static bool IsEdFiResourceClass(this Type type)
        {
            return type.FullName.StartsWith(Namespaces.Resources.BaseNamespace);
        }

        public static string TypeNameFromTypeFullName(string typeFullName)
        {
            return typeFullName.Split('.')
                               .Last();
        }
        
        private static readonly string[] _profileSuffixes = {"_Readable", "_Writable"};
        
        /// <summary>
        /// Gets the resource claim URIs for the specified named API resource (i.e. not a ODS-based data resource) using the new and legacy API claims URI conventions.
        /// </summary>
        /// <param name="resourceName">The name of the API resource for which to build the full resource URI.</param>
        /// <returns>The API resource claim URIs.</returns>
        public static string[] GetApiResourceClaimUris(string resourceName)
        {
            Preconditions.ThrowIfNull(resourceName, nameof(resourceName));
            
            return new[]
            {
                // New format for API resources
                CreateApiResourceClaimUri(resourceName),

                // Legacy format used for API resources
                CreateDomainsResourceClaimUri(resourceName),
            };
        }
        
        /// <summary>
        /// Gets the claim URI for the supplied resource name, based on the convention of the camel-cased resource name as a suffix on the Ed-Fi resource URI base value with the "domains" URI segment.
        /// </summary>
        /// <param name="resourceName">The name of the resource for which to build the full resource URI.</param>
        /// <returns>The convention-based URI for the resource.</returns>
        private static string CreateDomainsResourceClaimUri(string resourceName)
        {
            return CreateSegmentedClaimUri("domains", resourceName);
        }

        /// <summary>
        /// Gets the claim URI for the supplied resource name, based on the convention of the camel-cased resource name as a suffix on the Ed-Fi resource URI base value with the "api" URI segment.
        /// </summary>
        /// <param name="resourceName">The name of the resource for which to build the full resource URI.</param>
        /// <returns>The convention-based URI for the resource.</returns>
        private static string CreateApiResourceClaimUri(string resourceName)
        {
            return CreateSegmentedClaimUri("api", resourceName);
        }

        private static string CreateSegmentedClaimUri(string uriSegment, string resourceName)
        {
            return $"{EdFiOdsResourceClaimBaseUri}/{uriSegment}/{resourceName.ToCamelCase()}"; 
        }

        /// <summary>
        /// Gets the base URI used to represent a resource claim in the Ed-Fi security database.
        /// </summary>
        public static string EdFiOdsResourceClaimBaseUri => "http://ed-fi.org/ods/identity/claims";
    }
}
