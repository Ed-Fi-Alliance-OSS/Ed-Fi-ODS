// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using static EdFi.LoadTools.Engine.ExtensionMethods;

namespace EdFi.LoadTools.Mapping
{
    public class Map<T>
    {
        public Map(T source, T target)
        {
            Source = source;
            Target = target;
        }

        public T Source { get; }

        public T Target { get; }
    }

    public class WeightedMap<T> : Map<T>
    {
        public WeightedMap(T source, T target, double weight)
            : base(source, target)
        {
            Weight = weight;
        }

        public double Weight { get; }
    }

    public class PropertyInfoEx
    {
        public string Path { get; set; }

        public PropertyInfo PropertyInfo { get; set; }
    }

    public class MapperConfigurationExpression : IMapperConfigurationExpression, ICompileMapperConfiguration
    {
        private static readonly string[] ExcludedTypeNames =
        {
            "Link"
        };

        public MapperConfigurationExpression()
        {
            TypeMappings = new List<Map<Type>>();
        }

        private List<Map<Type>> TypeMappings { get; }

        public void AddMapperConstraints(List<Map<PropertyInfoEx>> mappings)
        {
            foreach (var mapping in TypeMappings)
            {
                var sourcePropertyInfos = new List<PropertyInfoEx>(GetRecursiveProperties(mapping.Source));
                var targetPropertyInfos = new List<PropertyInfoEx>(GetRecursiveProperties(mapping.Target));

                var orderedMappings = (from s in sourcePropertyInfos
                                       from t in targetPropertyInfos
                                       select new WeightedMap<PropertyInfoEx>(s, t, PropertyMatchWeights(s, t).Sum()))
                                     .OrderByDescending(x => x.Weight)
                                     .ToList();

                while (orderedMappings.Any())
                {
                    var topMapping = orderedMappings.First();
                    mappings.Add(topMapping);
                    orderedMappings.RemoveAll(m => m.Source == topMapping.Source || m.Target == topMapping.Target);
                }
            }
        }

        public IMapperConfigurationExpression CreateMap(Type source, Type target)
        {
            TypeMappings.Add(new Map<Type>(source, target));
            return this;
        }

        public IMapperConfigurationExpression CreateMap<TSource, TTarget>()
        {
            return CreateMap(typeof(TSource), typeof(TTarget));
        }

        private static IEnumerable<double> PropertyMatchWeights(PropertyInfoEx source, PropertyInfoEx target)
        {
            var matchingFunctions = new Func<PropertyInfoEx, PropertyInfoEx, double>[]
                                    {
                                        (s, t) => s.PropertyInfo.Name.PercentMatchTo(t.PropertyInfo.Name), (s, t) => s.Path.PercentMatchTo(t.Path)

                                        // more functions here if needed...
                                    };

            return matchingFunctions.Select(
                f =>
                    AreMatchingSimpleTypes(source.PropertyInfo.PropertyType, target.PropertyInfo.PropertyType)
                        ? f(source, target)
                        : 0.0);
        }

        private static IEnumerable<PropertyInfoEx> GetRecursiveProperties(Type type, string path = "")
        {
            foreach (var propertyInfo in type.GetProperties())
            {
                if (ExcludedTypeNames.Contains(propertyInfo.PropertyType.Name))
                {
                    continue;
                }

                if (propertyInfo.PropertyType.IsPrimitiveType())
                {
                    yield return
                        new PropertyInfoEx
                        {
                            Path = Path.Combine(path, propertyInfo.Name), PropertyInfo = propertyInfo
                        };
                }
                else
                {
                    foreach (
                        var childPropertyInfo in
                        GetRecursiveProperties(propertyInfo.PropertyType, Path.Combine(path, propertyInfo.Name))
                    )
                    {
                        yield return childPropertyInfo;
                    }
                }
            }
        }
    }
}
