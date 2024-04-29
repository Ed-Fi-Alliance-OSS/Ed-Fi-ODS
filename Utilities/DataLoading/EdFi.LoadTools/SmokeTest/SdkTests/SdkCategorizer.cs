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

        public IEnumerable<Type> ApiModelTypes => ApiTypes.Select(
            x => x.GetMethods()
                  .Single(
                       m => typeof(IRestResponse).IsAssignableFrom(m.ReturnType)
                            && m.Name.StartsWith("Post")
                            // ODS-3845: Exclude methods from other resources folded into the class by the SDK code generation process
                            && !Regex.IsMatch(m.Name, @"_\d+"))
                  .GetParameters().First().ParameterType);

        public IEnumerable<IResourceApi> ResourceApis => ApiTypes.Select(x => new ResourceApi(x));
    }

    public class ResourceApi : IResourceApi
    {
        public ResourceApi(Type apiType)
        {
            ApiType = apiType;
        }

        private IEnumerable<MethodInfo> RestMethods => ApiType.GetMethods().Where(
                                                                   x =>
                                                                       x.Name.EndsWith("HttpInfo", StringComparison.CurrentCultureIgnoreCase)
                                                                       && !x.Name.EndsWith(
                                                                           "AsyncWithHttpInfo", StringComparison.CurrentCultureIgnoreCase)
                                                                       // ODS-3845: Exclude methods from other resources folded into the class by the SDK code generation process
                                                                       && !Regex.IsMatch(x.Name, @"_\d+"))
                                                              .ToArray();

        private IEnumerable<MethodInfo> GetMethods => RestMethods.Where(m => m.Name.StartsWith("Get"));

        public Type ApiType { get; }

        public Type ModelType => PostMethod?.GetParameters().First().ParameterType;

        public MethodInfo GetAllMethod => GetMethods.SingleOrDefault(m => m.Name.EndsWith("WithHttpInfo") && !m.Name.Contains("Async") && !m.Name.Contains("ById"));

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
                    string methodsList = string.Join(
                        Environment.NewLine,
                        methods.Select(m => JsonConvert.SerializeObject(m, Formatting.Indented)));

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