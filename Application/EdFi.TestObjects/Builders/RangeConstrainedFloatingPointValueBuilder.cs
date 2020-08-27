// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.TestObjects._Extensions;

namespace EdFi.TestObjects.Builders
{
    public class RangeConstrainedFloatingPointValueBuilder : IValueBuilder
    {
        private const int DefaultScale = 3;
        private readonly Dictionary<Tuple<decimal, decimal>, decimal> nextValueByRange = new Dictionary<Tuple<decimal, decimal>, decimal>();

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            // TODO: Confirm this as obsolete behavior due to build context's TargetType now returning the underlying type
            //if (buildContext.TargetType.IsGenericType
            //    && buildContext.TargetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            //{
            //    // Reassign the nullable type to the underlying target type
            //    buildContext.TargetType = Nullable.GetUnderlyingType(buildContext.TargetType);
            //}

            if (buildContext.TargetType != typeof(decimal)
                && buildContext.TargetType != typeof(double)) // TODO: GKM - because SDK uses doubles. Not a great choice.
            {
                return ValueBuildResult.NotHandled;
            }

            if (buildContext.ContainingType == null)
            {
                return ValueBuildResult.NotHandled;
            }

            var propertyName = buildContext.LogicalPropertyPath.Split('.')
                                           .Last();

            var propertyInfo = buildContext.ContainingType.GetPublicProperties()
                                           .SingleOrDefault(p => p.Name == propertyName);

            var attribute = Factory.CustomAttributeProvider.GetCustomAttributes(propertyInfo, typeof(RangeAttribute), false)
                                   .Cast<RangeAttribute>()
                                   .FirstOrDefault();

            if (attribute == null)
            {
                return ValueBuildResult.NotHandled;
            }

            var valueAsDecimal = GetNextValue(Convert.ToDecimal(attribute.Minimum), Convert.ToDecimal(attribute.Maximum));

            object valueAsObject = 0;

            if (buildContext.TargetType == typeof(double))
            {
                valueAsObject = Convert.ToDouble(valueAsDecimal);
            }
            else if (buildContext.TargetType == typeof(decimal))
            {
                valueAsObject = valueAsDecimal;
            }
            else
            {
                // This should never happen, but guard against future changes falling through.
                throw new InvalidOperationException(
                    string.Format(
                        "Type '{0}' should never have been handled by the '{1}' value builder.",
                        buildContext.TargetType.Name,
                        GetType()
                           .Name));
            }

            return ValueBuildResult.WithValue(valueAsObject, buildContext.LogicalPropertyPath);
        }

        public void Reset() { }

        public ITestObjectFactory Factory { get; set; }

        protected virtual decimal GetNextValue(decimal min, decimal max)
        {
            var key = Tuple.Create(min, max);

            decimal delta = GetDelta(min, max);
            decimal value;

            if (!nextValueByRange.ContainsKey(key))
            {
                value = min;
            }
            else
            {
                value = nextValueByRange[key];
            }

            nextValueByRange[key] = value + delta;

            // Skip the default value
            if (value == 0)
            {
                value = GetNextValue(min, max);
            }

            // Rollover after the max value
            if (value > max)
            {
                nextValueByRange.Remove(key);
                value = GetNextValue(min, max);
            }

            if (value < min || value > max)
            {
                throw new Exception(string.Format("DEBUG: '{0}' is not between '{1}' and '{2}'.", value, min, max));
            }

            return value;
        }

        private decimal GetDelta(decimal min, decimal max)
        {
            return 1 / (decimal) Math.Pow(10, GetScale(min, max));
        }

        protected int GetScale(decimal min, decimal max)
        {
            string[] minParts = (min - Math.Floor(min)).ToString()
                                                       .Split('.');

            string[] maxParts = (max - Math.Floor(max)).ToString()
                                                       .Split('.');

            int scale = Math.Max(
                minParts.Length == 1
                    ? 0
                    : minParts[1]
                       .Length,
                maxParts.Length == 1
                    ? 0
                    : maxParts[1]
                       .Length);

            if (scale == 0)
            {
                return DefaultScale;
            }

            return scale;
        }
    }

    // TODO: Need unit tests
    public class RangeConstrainedRandomFloatingPointValueBuilder : RangeConstrainedFloatingPointValueBuilder
    {
        // TODO: Refactor to use IRandom, and inject through constructor
        private readonly Random _random = new Random();

        protected override decimal GetNextValue(decimal min, decimal max)
        {
            double randomNumber = _random.NextDouble();

            var newValue = ((double) max - (double) min) * randomNumber + (double) min;

            int scale = GetScale(min, max);

            var result = (decimal) Math.Round(newValue, scale);

            if (result < min || result > max)
            {
                throw new Exception(string.Format("DEBUG: '{0}' is not between '{1}' and '{2}'.", result, min, max));
            }

            return result;
        }
    }
}
