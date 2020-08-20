// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace EdFi.LoadTools.Mapping
{
    public class Mapper
    {
        private readonly List<Map<PropertyInfoEx>> _mappings;

        internal Mapper(List<Map<PropertyInfoEx>> mappings)
        {
            _mappings = mappings;
        }

        public TTarget Map<TSource, TTarget>(TSource source)
        {
            return (TTarget) Map(source, typeof(TTarget));
        }

        public object Map(object source, Type targetType)
        {
            var target = Activator.CreateInstance(targetType, true);

            foreach (var mapping in _mappings)
            {
                var value = GetDeepValue(source, mapping.Source.Path);
                SetDeepValue(target, mapping.Target.Path, value);
            }

            return target;
        }

        private void SetDeepValue(object component, string propertyPath, object value)
        {
            if (value == null)
            {
                return;
            }

            var path = new Queue<string>(propertyPath.Split(Path.DirectorySeparatorChar));
            var propDesc = TypeDescriptor.GetProperties(component)[path.Dequeue()];

            while (path.Count > 0)
            {
                var tmpComponent = propDesc.GetValue(component);

                if (tmpComponent == null)
                {
                    tmpComponent = Activator.CreateInstance(propDesc.PropertyType);
                    propDesc.SetValue(component, tmpComponent);
                    component = tmpComponent;
                }

                propDesc = TypeDescriptor.GetProperties(component)[path.Dequeue()];
            }

            propDesc.SetValue(component, value);
        }

        private static object GetDeepValue(object component, string propertyPath)
        {
            var path = new Queue<string>(propertyPath.Split(Path.DirectorySeparatorChar));

            while (path.Count > 0 && component != null)
            {
                var list = component as IList;

                if (list != null)
                {
                    if (list.Count > 0)
                    {
                        path.Dequeue();
                        component = list[0];
                    }
                    else
                    {
                        return null;
                    }
                }

                component = TypeDescriptor.GetProperties(component)[path.Dequeue()].GetValue(component);
            }

            return component;
        }
    }
}
