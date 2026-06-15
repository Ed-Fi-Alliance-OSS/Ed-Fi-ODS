// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    public class SdkCategorizer : ISdkCategorizer
    {
        private readonly Type[] _apiTypes;
        private readonly Type[] _modelTypes;

        public SdkCategorizer(ISdkLibraryFactory sdkLibraryFactory)
        {
            var exportedTypes = sdkLibraryFactory.SdkLibrary.GetExportedTypes();

            _apiTypes = exportedTypes.Where(
                                           x => x.Namespace != null
                                                && !x.IsInterface
                                                && x.Namespace.Contains("Apis.All")
                                                && !x.Name.Contains("TypesApi"))
                                      .ToArray();

            _modelTypes = exportedTypes.Where(
                x => x.Namespace != null
                     && !x.IsInterface
                     && x.Namespace.Contains(
                         "Models.All")).ToArray();

            if (_apiTypes.Length == 0 || _modelTypes.Length == 0)
            {
                var allNamespaces = exportedTypes
                    .Where(t => t.Namespace != null)
                    .Select(t => t.Namespace)
                    .Distinct()
                    .OrderBy(ns => ns)
                    .ToList();

                var diagnosticInfo = string.Join(Environment.NewLine,
                    new[]
                    {
                        $"SDK Assembly: {sdkLibraryFactory.SdkLibrary.FullName}",
                        $"Total exported types: {exportedTypes.Length}",
                        $"API types found: {_apiTypes.Length}",
                        $"Model types found: {_modelTypes.Length}",
                        $"Available namespaces in assembly:",
                    }.Concat(allNamespaces.Select(ns => $"  - {ns}")));

                throw new InvalidOperationException(
                    $"Could not find expected API or Model types in SDK assembly. " +
                    $"Expected namespaces containing 'Apis.All' and 'Models.All'.{Environment.NewLine}{diagnosticInfo}");
            }
        }

        public IEnumerable<Type> ApiTypes => _apiTypes;

        public IEnumerable<Type> ModelTypes => _modelTypes;

        // A single generated API class can expose more than one resource: openapi-generator names the
        // class from the OpenAPI tag, and a homonym extension (e.g. Homograph) puts its homonym resource
        // on the core resource's tag. So one ContactsApi can carry both Contact and HomographContact. We
        // therefore emit one IResourceApi per RESOURCE, not per API type.
        public IEnumerable<IResourceApi> ResourceApis => ApiTypes
            .SelectMany(BuildResourceApis)
            .Where(api => !string.IsNullOrEmpty(api.Name)) // Filter out APIs without names
            .ToList();

        private static IEnumerable<ResourceApi> BuildResourceApis(Type apiType)
        {
            var candidates = apiType.GetMethods()
                .Where(m =>
                    m.Name.EndsWith("Async", StringComparison.CurrentCultureIgnoreCase)
                    && !m.Name.Contains("OrDefault") // Exclude OrDefault variants
                    && !m.Name.Contains("WithHttpInfo") // Exclude old-generator WithHttpInfo companions
                    && !m.IsSpecialName
                    && IsCrudVerb(m.Name))
                .ToList();

            // Each resource is anchored on its POST method: the POST parameter carries the resource model
            // type, which is the discriminator the rest of the tooling keys on. (Read-only resources have
            // no POST and no resolvable model type; they are filtered out by the Name check, as before.)
            var resources = candidates
                .Where(m => m.Name.StartsWith("Post"))
                .Select(post => (
                    Model: post.GetParameters().FirstOrDefault()?.ParameterType,
                    Stem: StemOf(post.Name),
                    Token: TokenOf(post.Name)))
                .Where(resource => resource.Model != null)
                .ToList();

            if (resources.Count == 0)
            {
                yield break;
            }

            // Common case: a single resource per API type. Assign every method to it, preserving the
            // original behavior (no name-stem matching needed, so no risk with irregular pluralization).
            if (resources.Count == 1)
            {
                yield return new ResourceApi(apiType, resources[0].Model, candidates);
                yield break;
            }

            // Multi-resource (homonym) API type: assign each method to the resource it belongs to. The
            // model type is only present on POST/PUT signatures, so GET/DELETE are matched by name using
            // the openapi-generator's "_N" homonym suffix (token) plus the resource name-stem. POST and
            // DELETE are singular while GET is plural, so we match on stem PREFIX (longest stem wins) to
            // bridge the singular/plural difference and disambiguate stems that are prefixes of others.
            var groups = resources.Select(_ => new List<MethodInfo>()).ToList();

            foreach (var method in candidates)
            {
                var methodStem = StemOf(method.Name);
                var methodToken = TokenOf(method.Name);

                var bestIndex = -1;
                var bestStemLength = -1;

                for (var i = 0; i < resources.Count; i++)
                {
                    var resource = resources[i];

                    if (resource.Token == methodToken
                        && methodStem.StartsWith(resource.Stem, StringComparison.Ordinal)
                        && resource.Stem.Length > bestStemLength)
                    {
                        bestIndex = i;
                        bestStemLength = resource.Stem.Length;
                    }
                }

                if (bestIndex >= 0)
                {
                    groups[bestIndex].Add(method);
                }
            }

            for (var i = 0; i < resources.Count; i++)
            {
                yield return new ResourceApi(apiType, resources[i].Model, groups[i]);
            }
        }

        private static bool IsCrudVerb(string name) =>
            name.StartsWith("Post")
            || name.StartsWith("Put")
            || (name.StartsWith("Delete") && !name.StartsWith("Deletes"))
            || (name.StartsWith("Get")
                && (name.Contains("ById", StringComparison.CurrentCultureIgnoreCase)
                    || !name.Contains("Partitions", StringComparison.CurrentCultureIgnoreCase)));

        private static string VerbOf(string name)
        {
            if (name.StartsWith("Post")) return "Post";
            if (name.StartsWith("Put")) return "Put";
            if (name.StartsWith("Delete")) return "Delete";
            if (name.StartsWith("Get")) return "Get";
            return string.Empty;
        }

        // The openapi-generator's homonym disambiguator: a trailing "_N" segment (e.g. PostContact_0Async).
        private static string TokenOf(string name)
        {
            var stem = StripAsyncSuffix(name);
            var match = Regex.Match(stem, @"_(\d+)$");
            return match.Success ? match.Value : string.Empty;
        }

        // The resource name shared by a resource's methods, e.g. "Contacts" for GetContactsAsync /
        // GetContactsById_0Async after removing the verb, the "_N" token, the "Async" suffix and the
        // "ById" marker.
        private static string StemOf(string name)
        {
            var stem = StripAsyncSuffix(name);

            var token = TokenOf(name);
            if (token.Length > 0)
            {
                stem = stem.Substring(0, stem.Length - token.Length);
            }

            var verb = VerbOf(name);
            if (verb.Length > 0 && stem.StartsWith(verb))
            {
                stem = stem.Substring(verb.Length);
            }

            return stem.Replace("ById", string.Empty);
        }

        private static string StripAsyncSuffix(string name) =>
            name.EndsWith("Async", StringComparison.CurrentCultureIgnoreCase)
                ? name.Substring(0, name.Length - "Async".Length)
                : name;
    }

    public class ResourceApi : IResourceApi
    {
        private readonly List<MethodInfo> _methods;

        public ResourceApi(Type apiType, Type modelType, IEnumerable<MethodInfo> resourceMethods)
        {
            ApiType = apiType;
            ModelType = modelType;
            _methods = resourceMethods as List<MethodInfo> ?? resourceMethods.ToList();
        }

        public Type ApiType { get; }

        // The model type is the per-resource discriminator (e.g. EdFiContact vs HomographContact),
        // supplied by the categorizer. Each method property resolves WITHIN this resource's method
        // group, so every verb returns exactly one method.
        public Type ModelType { get; }

        public MethodInfo GetAllMethod => _methods.SingleOrDefault(
            m => m.Name.StartsWith("Get")
                 && !m.Name.Contains("ById", StringComparison.CurrentCultureIgnoreCase)
                 && !m.Name.Contains("Partitions", StringComparison.CurrentCultureIgnoreCase));

        public MethodInfo GetByIdMethod => _methods.SingleOrDefault(
            m => m.Name.StartsWith("Get") && m.Name.Contains("ById", StringComparison.CurrentCultureIgnoreCase));

        public MethodInfo PostMethod => _methods.SingleOrDefault(m => m.Name.StartsWith("Post"));

        public MethodInfo PutMethod => _methods.SingleOrDefault(m => m.Name.StartsWith("Put"));

        public MethodInfo DeleteMethod => _methods.SingleOrDefault(
            m => m.Name.StartsWith("Delete") && !m.Name.StartsWith("Deletes"));

        public string Name => ModelType?.Name;
    }
}
