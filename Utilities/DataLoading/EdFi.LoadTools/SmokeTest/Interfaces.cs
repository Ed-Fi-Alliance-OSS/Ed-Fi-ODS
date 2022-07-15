// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;
using Swashbuckle.Swagger;

namespace EdFi.LoadTools.SmokeTest
{
    public interface ITest
    {
        Task<bool> PerformTest();
    }

    public interface IResourceApi
    {
        Type ApiType { get; }

        Type ModelType { get; }

        string Name { get; }

        MethodInfo GetAllMethod { get; }

        MethodInfo GetByIdMethod { get; }

        MethodInfo PostMethod { get; }

        MethodInfo PutMethod { get; }

        MethodInfo DeleteMethod { get; }
    }

    public interface ISdkCategorizer
    {
        IEnumerable<Type> ApiTypes { get; }

        IEnumerable<Type> ModelTypes { get; }

        IEnumerable<Type> ApiModelTypes { get; }

        IEnumerable<IResourceApi> ResourceApis { get; }
    }

    public interface IModelDependencySort
    {
        IEnumerable<IResourceApi> OrderedApis();

        IEnumerable<Type> OrderedModels();
    }

    public interface ITestGenerator
    {
        IEnumerable<ITest> GenerateTests();
    }

    public interface ITestFactory<TKey, TValue> : IList<Func<TKey, TValue>>
        where TValue : ITest { }

    public interface IDependenciesSorter : IReadOnlyDictionary<Type, Func<IEnumerable<Dependency>, IEnumerable<Dependency>>>
    { }

    public interface IPropertyBuilder
    {
        /// <summary>
        ///     Apply an appropriate value the the property of the supplied object
        /// </summary>
        /// <param name="obj">The object with a property</param>
        /// <param name="propertyInfo">information about the property</param>
        /// <returns>true if the property was populated</returns>
        bool BuildProperty(object obj, PropertyInfo propertyInfo);
    }

    public interface IPropertyInfoMetadataLookup
    {
        Parameter GetMetadata(PropertyInfo propInfo);
    }
}
