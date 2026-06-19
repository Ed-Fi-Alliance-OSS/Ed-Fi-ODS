// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        // internal (not private) so the grouping/validation can be exercised directly in unit tests
        // with hand-built API shapes, without those shapes having to live in a scanned "Apis.All"
        // namespace (which would make every other categorizer test fail-fast on them).
        internal static IEnumerable<ResourceApi> BuildResourceApis(Type apiType)
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
            // original behavior. No name-stem matching is needed, so irregular pluralization is fully
            // supported here: e.g. a single-resource PeopleApi with PostPersonAsync / GetPeopleAsync
            // (Person -> People) categorizes correctly because every method goes to the one resource.
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
            //
            // Prefix-matching handles regular pluralization (School/Schools) but NOT irregular plurals
            // (Person/People). If a multi-resource API ever pairs an irregular plural with a homonym, a
            // GET/DELETE stem will not start with its POST stem and will match no resource. Rather than
            // silently drop that method (leaving GetAllMethod/DeleteMethod null and producing a later
            // NRE), we collect every unassigned candidate and fail fast below with diagnostics. (Cached
            // ODS PeopleApi is single-resource and uses the fast path above, so it is unaffected.)
            var groups = resources.Select(_ => new List<MethodInfo>()).ToList();
            var unmatched = new List<MethodInfo>();

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
                else
                {
                    unmatched.Add(method);
                }
            }

            if (unmatched.Count > 0)
            {
                throw new InvalidOperationException(DescribeUnmatchedCandidates(apiType, resources, unmatched));
            }

            for (var i = 0; i < resources.Count; i++)
            {
                yield return new ResourceApi(apiType, resources[i].Model, groups[i]);
            }
        }

        // Builds a diagnostic message naming the API type, every unassigned method (with its derived
        // stem/token) and the resource groups they failed to match, so a categorization failure points
        // straight at the offending generated shape instead of surfacing as a downstream NRE.
        private static string DescribeUnmatchedCandidates(
            Type apiType,
            IReadOnlyList<(Type Model, string Stem, string Token)> resources,
            IReadOnlyList<MethodInfo> unmatched)
        {
            var unmatchedList = string.Join(
                "; ", unmatched.Select(m => $"{m.Name} (stem '{StemOf(m.Name)}', token '{TokenOf(m.Name)}')"));

            var resourceList = string.Join(
                "; ", resources.Select(r => $"{r.Model?.Name} (stem '{r.Stem}', token '{r.Token}')"));

            return
                $"SdkCategorizer could not assign {unmatched.Count} CRUD method(s) to any resource group on "
                + $"multi-resource API type '{apiType.FullName}'. Leaving them unassigned would silently drop "
                + $"resource methods and produce later null-reference failures. Unassigned methods: {unmatchedList}. "
                + $"Known resource groups: {resourceList}. The name-stem matching expects each GET/DELETE stem to "
                + "start with its resource's POST stem; an irregular plural (e.g. Person/People) or an unexpected "
                + "generated method name will trip this.";
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
        // The model type is the per-resource discriminator (e.g. EdFiContact vs HomographContact),
        // supplied by the categorizer. Each verb is resolved WITHIN this resource's method group at
        // construction time and validated, so every method property returns exactly one method (and a
        // mis-categorized group fails fast here, when ResourceApis is enumerated, with a clear message
        // rather than later as a SingleOrDefault throw or a null-reference inside BaseTest).
        public ResourceApi(Type apiType, Type modelType, IEnumerable<MethodInfo> resourceMethods)
        {
            ApiType = apiType;
            ModelType = modelType;

            var methods = resourceMethods as IReadOnlyList<MethodInfo> ?? resourceMethods.ToList();

            if (methods.Count == 0)
            {
                throw new InvalidOperationException(
                    $"SdkCategorizer produced an empty method group for resource "
                    + $"'{Describe(modelType)}' on API type '{Describe(apiType)}'. "
                    + "Every resource must expose at least a POST method.");
            }

            PostMethod = SingleVerb(methods, apiType, modelType, "POST", m => m.Name.StartsWith("Post"));

            if (PostMethod == null)
            {
                throw new InvalidOperationException(
                    $"SdkCategorizer produced a resource group without a POST method for resource "
                    + $"'{Describe(modelType)}' on API type '{Describe(apiType)}'. "
                    + $"Methods in group: {string.Join(", ", methods.Select(m => m.Name))}.");
            }

            GetAllMethod = SingleVerb(
                methods, apiType, modelType, "GET-all",
                m => m.Name.StartsWith("Get")
                     && !m.Name.Contains("ById", StringComparison.CurrentCultureIgnoreCase)
                     && !m.Name.Contains("Partitions", StringComparison.CurrentCultureIgnoreCase));

            GetByIdMethod = SingleVerb(
                methods, apiType, modelType, "GET-by-id",
                m => m.Name.StartsWith("Get") && m.Name.Contains("ById", StringComparison.CurrentCultureIgnoreCase));

            PutMethod = SingleVerb(methods, apiType, modelType, "PUT", m => m.Name.StartsWith("Put"));

            DeleteMethod = SingleVerb(
                methods, apiType, modelType, "DELETE",
                m => m.Name.StartsWith("Delete") && !m.Name.StartsWith("Deletes"));

            _executionMethods = new Dictionary<MethodInfo, MethodInfo>();
            foreach (var canonical in new[] { GetAllMethod, GetByIdMethod, PostMethod, PutMethod, DeleteMethod })
            {
                if (canonical != null)
                {
                    _executionMethods[canonical] = ResolveExecutionMethod(apiType, canonical);
                }
            }
        }

        private readonly Dictionary<MethodInfo, MethodInfo> _executionMethods;

        public Type ApiType { get; }

        public Type ModelType { get; }

        public MethodInfo GetAllMethod { get; }

        public MethodInfo GetByIdMethod { get; }

        public MethodInfo PostMethod { get; }

        public MethodInfo PutMethod { get; }

        public MethodInfo DeleteMethod { get; }

        public string Name => ModelType?.Name;

        // Resolves the single method matching a verb within the group. A read-only verb may be absent
        // (returns null, as before), but a duplicate signals a mis-categorized group and throws with a
        // diagnostic instead of deferring to an opaque SingleOrDefault failure at the call site.
        private static MethodInfo SingleVerb(
            IReadOnlyList<MethodInfo> methods, Type apiType, Type modelType, string verb, Func<MethodInfo, bool> predicate)
        {
            var matches = methods.Where(predicate).ToList();

            if (matches.Count > 1)
            {
                throw new InvalidOperationException(
                    $"SdkCategorizer mapped {matches.Count} {verb} methods to resource "
                    + $"'{Describe(modelType)}' on API type '{Describe(apiType)}': "
                    + $"{string.Join(", ", matches.Select(m => m.Name))}. Exactly one was expected.");
            }

            return matches.Count == 1 ? matches[0] : null;
        }

        // Returns the WithHttpInfo execution companion resolved at construction, or the canonical
        // method itself when none applies (new-generator SDKs, or an unmapped method).
        public MethodInfo GetExecutionMethod(MethodInfo canonicalMethod)
        {
            if (canonicalMethod == null)
            {
                return null;
            }

            return _executionMethods.TryGetValue(canonicalMethod, out var executionMethod)
                ? executionMethod
                : canonicalMethod;
        }

        // Resolves the old-generator async WithHttpInfo companion for a canonical "<stem>Async"
        // method, or returns the canonical method when none qualifies. Strict: same API type, exact
        // candidate name (WithHttpInfoAsync preferred, then AsyncWithHttpInfo), async (Task-returning),
        // non-OrDefault, and an identical positional parameter-type sequence. No broad matching and no
        // synchronous WithHttpInfo variant.
        private static MethodInfo ResolveExecutionMethod(Type apiType, MethodInfo canonicalMethod)
        {
            if (!canonicalMethod.Name.EndsWith("Async", StringComparison.Ordinal))
            {
                return canonicalMethod;
            }

            var stem = canonicalMethod.Name.Substring(0, canonicalMethod.Name.Length - "Async".Length);
            var canonicalParameterTypes = canonicalMethod.GetParameters().Select(p => p.ParameterType).ToArray();

            foreach (var candidateName in new[] { stem + "WithHttpInfoAsync", stem + "AsyncWithHttpInfo" })
            {
                var companion = apiType.GetMethods()
                    .FirstOrDefault(m =>
                        m.Name == candidateName
                        && !m.Name.Contains("OrDefault")
                        && typeof(Task).IsAssignableFrom(m.ReturnType)
                        && ParameterTypesMatch(m, canonicalParameterTypes));

                if (companion != null)
                {
                    return companion;
                }
            }

            return canonicalMethod;
        }

        private static bool ParameterTypesMatch(MethodInfo candidate, IReadOnlyList<Type> canonicalParameterTypes)
        {
            var candidateParameters = candidate.GetParameters();

            if (candidateParameters.Length != canonicalParameterTypes.Count)
            {
                return false;
            }

            for (var i = 0; i < candidateParameters.Length; i++)
            {
                if (candidateParameters[i].ParameterType != canonicalParameterTypes[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static string Describe(Type type) => type?.FullName ?? "(unknown)";
    }
}
