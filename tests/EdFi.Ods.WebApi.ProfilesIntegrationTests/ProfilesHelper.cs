// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Standard;
using Newtonsoft.Json;

// ReSharper disable HeapView.ObjectAllocation.Possible
// ReSharper disable HeapView.PossibleBoxingAllocation
namespace EdFi.Ods.WebApi.ProfileSpecFlowTests
{
    public static class ProfilesHelper
    {
        public static TResource CreateResource<TEntity, TResource>(TEntity entity)
            where TResource : new()
        {
            var mapperMethod = GetMapperMethod<TEntity>();
            var resource = new TResource();

            mapperMethod.Invoke(
                null,
                new object[]
                {
                    // ReSharper disable once HeapView.PossibleBoxingAllocation
                    entity,
                    resource,
                    null
                });

            return resource;
        }

        public static TDestination Clone<TSource, TDestination>(TSource source)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                NullValueHandling = NullValueHandling.Include,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            };

            return JsonConvert.DeserializeObject<TDestination>(JsonConvert.SerializeObject(source , serializerSettings), serializerSettings);
        }

        private static MethodInfo GetMapperMethod<TEntity>()
        {
            string entityName = typeof(TEntity).Name;

            string mapperTypeName =
                $"{EdFiConventions.BuildNamespace(Namespaces.Entities.Common.BaseNamespace, EdFiConventions.ProperCaseName)}.{entityName}Mapper";

            // Embedded convention - Mapper type namespace
            var mapperType = Type.GetType($"{mapperTypeName}, {typeof(Marker_EdFi_Ods_Standard).Assembly.GetName().Name}");

            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

            var mapperMethod = mapperType.GetMethod("MapTo", bindingFlags);

            if (mapperMethod != null)
            {
                return mapperMethod;
            }

            mapperMethod = mapperType.GetMethod("MapDerivedTo", bindingFlags);

            if (mapperMethod == null)
            {
                throw new Exception($"Unable to find MapTo or MapDerivedTo method on type '{mapperType.FullName}'.");
            }

            return mapperMethod;
        }
    }
}
