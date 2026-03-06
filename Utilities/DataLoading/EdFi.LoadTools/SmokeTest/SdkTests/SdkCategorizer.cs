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
using Newtonsoft.Json;
using RestSharp.Portable;

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

        public IEnumerable<IResourceApi> ResourceApis => ApiTypes
            .Select(x => new ResourceApi(x))
            .Where(api => !string.IsNullOrEmpty(api.Name)) // Filter out APIs without names
            .ToList();
    }

    public class ResourceApi : IResourceApi
    {
        public ResourceApi(Type apiType)
        {
            ApiType = apiType;
        }

        private IEnumerable<MethodInfo> RestMethods
        {
            get
            {
                var methods = ApiType.GetMethods()
                    .Where(x =>
                        x.Name.EndsWith("Async", StringComparison.CurrentCultureIgnoreCase)
                        && !x.Name.Contains("_")
                        && !x.Name.Contains("OrDefault") // Exclude OrDefault variants
                        && !x.IsSpecialName)
                    .ToList();

                IEnumerable<MethodInfo> FilterByVerb(string verb, Func<MethodInfo, bool> additionalFilter = null)
                {
                    var verbMethods = methods
                        .Where(m => m.Name.StartsWith(verb, StringComparison.CurrentCultureIgnoreCase) && (additionalFilter == null || additionalFilter(m)))
                        .ToList();

                    if (verbMethods.Count > 1)
                    {
                        verbMethods = verbMethods
                            .Where(m => !Regex.IsMatch(m.Name, @"_[a-zA-Z]"))
                            .ToList();
                    }

                    return verbMethods;
                }

                // GET methods: split into non-ById and ById
                var getNonByIdMethods = FilterByVerb("Get", m =>
                    !m.Name.Contains("ById", StringComparison.CurrentCultureIgnoreCase)
                    && !m.Name.Contains("Partitions", StringComparison.CurrentCultureIgnoreCase));

                var getByIdMethods = FilterByVerb("Get", m =>
                    m.Name.Contains("ById", StringComparison.CurrentCultureIgnoreCase));

                // Other verbs
                var postMethods = FilterByVerb("Post");
                var putMethods = FilterByVerb("Put");
                var deleteMethods = FilterByVerb("Delete");
                var deletesMethods = FilterByVerb("Deletes");

                return postMethods
                    .Concat(getNonByIdMethods)
                    .Concat(getByIdMethods)
                    .Concat(putMethods)
                    .Concat(deleteMethods)
                    .Concat(deletesMethods)
                    .Distinct()
                    .ToArray();
            }
        }

        private IEnumerable<MethodInfo> GetMethods => RestMethods.Where(m => m.Name.StartsWith("Get"));

        public Type ApiType { get; }

        public Type ModelType => PostMethod?.GetParameters().First().ParameterType;

        public MethodInfo GetAllMethod
            => GetMethods.SingleOrDefault(
                m =>
                    !m.Name.Contains("ById")
                    && !m.Name.Contains("Partitions"));

        public MethodInfo GetByIdMethod => GetMethods.SingleOrDefault(
            m => m.Name.Contains("ById", StringComparison.CurrentCultureIgnoreCase));

        public MethodInfo PostMethod
        {
            get
            {
                var methods = RestMethods
                    .Where(m => m.Name.StartsWith("Post"))
                    .ToArray();

                // Detect multiple matching methods, and report details
                if (methods.Length > 1)
                {
                    var serializerSettings = new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };

                    string methodsList = string.Join(
                        Environment.NewLine,
                        methods.Select(m => JsonConvert.SerializeObject(m, Formatting.Indented, serializerSettings)));

                    string message = $"Multiple matching Post methods were found on type '{ApiType.FullName}'. Candidates are:{Environment.NewLine}{methodsList}";

                    throw new Exception(message);
                }

                return methods.SingleOrDefault();
            }
        }

        public MethodInfo PutMethod => RestMethods.SingleOrDefault(m => m.Name.StartsWith("Put"));

        public MethodInfo DeleteMethod => RestMethods.SingleOrDefault(
            m => m.Name.StartsWith("Delete") && !m.Name.Contains("Deletes"));

        public string Name => ModelType?.Name;
    }
}
