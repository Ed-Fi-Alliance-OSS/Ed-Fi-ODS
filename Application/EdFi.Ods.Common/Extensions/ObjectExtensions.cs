// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using EdFi.Ods.Common.Exceptions;
using log4net;

namespace EdFi.Ods.Common.Extensions
{
    public static class ObjectExtensions
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ObjectExtensions));

        public static IDictionary<string, object> ToDictionary(
            this object instance,
            Func<PropertyDescriptor, object, bool> selector = null)
        {
            // Default selector
            if (selector == null)
            {
                selector = (descriptor, o) => true;
            }

            var dictionary = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

            if (instance != null)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(instance))
                {
                    object value = null;

                    try
                    {
                        value = descriptor.GetValue(instance);
                    }
                    catch (Exception ex)
                    {
                        _logger.Debug(ex.Message);

                        // ODS-1943 PropertyDescriptors GetValue method wrapping the ArgumentException with TargetInvocationException,
                        // which is abstracting the actual exception.
                        // c.f. https://referencesource.microsoft.com/#System/compmod/system/componentmodel/ReflectPropertyDescriptor.cs,3b48df1474c54332
                        if (ex is TargetInvocationException && ex.InnerException is ArgumentException)
                        {
                            throw new BadRequestException(ex.Message, ex.InnerException);
                        }

                        throw;
                    }

                    if (selector(descriptor, value))
                    {
                        dictionary.Add(descriptor.Name, value);
                    }
                }
            }

            return dictionary;
        }

        public static void FromDictionary(
            this object instance,
            IDictionary<string, object> values,
            Func<PropertyDescriptor, object, bool> selector = null)
        {
            if (selector == null)
            {
                selector = (descriptor, o) => true;
            }

            if (instance == null)
            {
                return;
            }

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(instance))
            {
                object value;

                if (values.TryGetValue(descriptor.Name, out value) && selector(descriptor, value))
                {
                    descriptor.SetValue(instance, value);
                }
            }
        }
    }
}
