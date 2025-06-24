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
            _apiTypes = sdkLibraryFactory.SdkLibrary.GetExportedTypes().Where(
                                           x => x.Namespace != null
                                                && !x.IsInterface
                                                && x.Namespace.Contains("Apis.All")
                                                && !x.Name.Contains("TypesApi"))
                                      .ToArray();

            _modelTypes = sdkLibraryFactory.SdkLibrary.GetExportedTypes().Where(
                x => x.Namespace != null
                     && !x.IsInterface
                     && x.Namespace.Contains(
                         "Models.All")).ToArray();
        }

        public IEnumerable<Type> ApiTypes => _apiTypes;

        public IEnumerable<Type> ModelTypes => _modelTypes;

        public IEnumerable<Type> ApiModelTypes => ApiTypes.Select(x =>
        {
            // Find all Post methods with IRestResponse return type
            var postMethods = x.GetMethods()
                .Where(m => typeof(IRestResponse).IsAssignableFrom(m.ReturnType)
                            && m.Name.StartsWith("Post")
                            // ODS-3845: Exclude methods from other resources folded into the class by the SDK code generation process
                            && !Regex.IsMatch(m.Name, @"_\d+"))
                .ToArray();

            var method = postMethods.Length == 1
                ? postMethods[0]
                : postMethods.Where(m => !Regex.IsMatch(m.Name, @"_[a-zA-Z]")).SingleOrDefault();

            if (method == null)
                throw new InvalidOperationException($"No suitable Post method found for type {x.Name}");

            return method.GetParameters().First().ParameterType;
        });

        public IEnumerable<IResourceApi> ResourceApis => ApiTypes.Select(x => new ResourceApi(x));
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
                        x.Name.EndsWith("HttpInfo", StringComparison.CurrentCultureIgnoreCase)
                        && !x.Name.EndsWith("AsyncWithHttpInfo", StringComparison.CurrentCultureIgnoreCase)
                        // ODS-3845: Exclude methods from other resources folded into the class by the SDK code generation process
                        && !Regex.IsMatch(x.Name, @"_\d+"))
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
                    m.Name.EndsWith("WithHttpInfo", StringComparison.CurrentCultureIgnoreCase)
                    && !m.Name.EndsWith("ByIdWithHttpInfo", StringComparison.CurrentCultureIgnoreCase));

                var getByIdMethods = FilterByVerb("Get", m =>
                    m.Name.EndsWith("ByIdWithHttpInfo", StringComparison.CurrentCultureIgnoreCase));

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
                    m.Name.EndsWith("WithHttpInfo")
                    && !m.Name.Contains("Async")
                    && !m.Name.Contains("ById")
                    && !m.Name.Contains("Partitions"));

        public MethodInfo GetByIdMethod => GetMethods.SingleOrDefault(m => m.Name.EndsWith("ByIdWithHttpInfo"));

        public MethodInfo PostMethod
        {
            get
            {
                var methods = RestMethods
                    .Where(m => m.Name.StartsWith("Post") && m.Name.EndsWith("WithHttpInfo"))
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

        public MethodInfo PutMethod => RestMethods.SingleOrDefault(m => m.Name.StartsWith("Put") && m.Name.EndsWith("WithHttpInfo"));

        public MethodInfo DeleteMethod => RestMethods.SingleOrDefault(m => m.Name.StartsWith("Delete") && !m.Name.Contains("Deletes") && m.Name.EndsWith("WithHttpInfo"));

        public string Name => ModelType?.Name;
    }
}
