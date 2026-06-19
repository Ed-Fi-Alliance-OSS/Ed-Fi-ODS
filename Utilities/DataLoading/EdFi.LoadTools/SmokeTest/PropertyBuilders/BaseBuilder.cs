// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using EdFi.LoadTools.Engine;
using log4net;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public abstract class BaseBuilder : IPropertyBuilder
    {
        protected static readonly Random Random = new Random(1);
        private const int DefaultNumericFallbackStart = 1;
        private int _defaultNumericFallbackValue = DefaultNumericFallbackStart;
        private readonly int _defaultNumericFallbackMax;
        private readonly int _defaultStringLength = 7;
        private readonly IPropertyInfoMetadataLookup _metadataLookup;

        protected virtual ILog Log => LogManager.GetLogger(GetType().Name);

        protected BaseBuilder(
            IPropertyInfoMetadataLookup metadataLookup,
            int defaultNumericFallbackMax = DestructiveTestConfigurationDefaults.DefaultNumericFallbackMax)
        {
            _metadataLookup = metadataLookup;
            _defaultNumericFallbackMax = defaultNumericFallbackMax > 0
                ? defaultNumericFallbackMax
                : DestructiveTestConfigurationDefaults.DefaultNumericFallbackMax;
        }

        bool IPropertyBuilder.BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            var result = BuildProperty(obj, propertyInfo);

            if (result)
            {
                Log.Debug(propertyInfo.Name);
            }

            return result;
        }

        public abstract bool BuildProperty(object obj, PropertyInfo propertyInfo);

        protected string BuildRandomString(int length)
        {
            // NOTE: replaced the original method as this was causing the same string to be used,
            // instead of a random string as what the method implied. We may want to revert
            // if necessary in the future.
            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new StringBuilder(length);
            using (var rng = RandomNumberGenerator.Create())
            {
                int count = (int)Math.Ceiling(Math.Log(alphabet.Length, 2) / 8.0);
                Debug.Assert(count <= sizeof(uint));
                int offset = BitConverter.IsLittleEndian ? 0 : sizeof(uint) - count;
                int max = (int)(Math.Pow(2, count * 8) / alphabet.Length) * alphabet.Length;
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (res.Length < length)
                {
                    rng.GetBytes(uintBuffer, offset, count);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    if (num < max)
                    {
                        res.Append(alphabet[(int)(num % alphabet.Length)]);
                    }
                }
            }
            return res.ToString();
        }

        protected string BuildRandomString(PropertyInfo propertyInfo)
        {
            var parameter = _metadataLookup.GetMetadata(propertyInfo);
            var length = Math.Max(parameter.Schema.MinLength.HasValue ? parameter.Schema.MinLength.Value: 0, _defaultStringLength);
            length = Math.Min(parameter.Schema.MaxLength.HasValue ? parameter.Schema.MaxLength.Value : _defaultStringLength, length);
            return BuildRandomString(length);
        }

        protected bool IsTypeMatch<T>(PropertyInfo propertyInfo)
            where T : struct
        {
            var propertyType = propertyInfo.PropertyType;
            return typeof(T?) == propertyType || typeof(T) == propertyType;
        }

        protected bool IsRequired(PropertyInfo propertyInfo)
        {
            var parameter = _metadataLookup.GetMetadata(propertyInfo);

            return parameter.Required;
        }

        /// <summary>
        ///     Returns true only when OpenAPI publishes a <c>Maximum</c> that actually parses. This mirrors what
        ///     <see cref="BuildRandomNumber" /> can honor: a parseable maximum produces a bounded or max-only value,
        ///     whereas a min-only, empty, or unparseable bound falls back to the generic numeric range. Callers that
        ///     need to know whether deferring to the generic numeric builder will respect a real ceiling should use
        ///     this rather than treating any non-empty bound string as published bounds.
        /// </summary>
        protected bool HasParseableMaximum(PropertyInfo propertyInfo)
        {
            var schema = _metadataLookup.GetMetadata(propertyInfo).Schema;

            return schema != null
                   && !string.IsNullOrEmpty(schema.Maximum)
                   && decimal.TryParse(schema.Maximum, out _);
        }

        /// <summary>
        ///     Attempts to read a published <c>Minimum</c> that parses, clamped to the int range used by the numeric
        ///     builders. Returns false for empty or unparseable minimums so callers can fall back to their own range.
        /// </summary>
        protected bool TryGetParseableMinimum(PropertyInfo propertyInfo, out int minimum)
        {
            minimum = 0;

            var schema = _metadataLookup.GetMetadata(propertyInfo).Schema;

            if (schema == null
                || string.IsNullOrEmpty(schema.Minimum)
                || !decimal.TryParse(schema.Minimum, out var value))
            {
                return false;
            }

            minimum = (int)decimal.Max(decimal.Min(value, int.MaxValue), int.MinValue);
            return true;
        }

        protected int BuildRandomNumber(PropertyInfo propertyInfo)
        {
            var parameter = _metadataLookup.GetMetadata(propertyInfo);

            // In Microsoft. OpenApi v2.x, Minimum and Maximum are strings
            decimal minValue = 0;
            decimal maxValue = 0;
            var hasMinimum = !string.IsNullOrEmpty(parameter.Schema.Minimum) && decimal.TryParse(parameter.Schema.Minimum, out minValue);
            var hasMaximum = !string.IsNullOrEmpty(parameter.Schema.Maximum) && decimal.TryParse(parameter.Schema.Maximum, out maxValue);

            if (hasMinimum && hasMaximum)
            {
                var min = decimal.Max(minValue, int.MinValue);
                var max = decimal.Min(maxValue, int.MaxValue);

                return Random.Next((int)min, (int)max);
            }
            else if (hasMinimum)
            {
                var min = decimal.Max(minValue, NextDefaultNumericFallback());

                return (int)min;
            }
            else if (hasMaximum)
            {
                return (int)decimal.Min(maxValue, int.MaxValue);
            }
            else
            {
                return NextDefaultNumericFallback();
            }
        }

        private int NextDefaultNumericFallback()
        {
            var value = _defaultNumericFallbackValue;

            _defaultNumericFallbackValue = _defaultNumericFallbackValue >= _defaultNumericFallbackMax
                ? DefaultNumericFallbackStart
                : _defaultNumericFallbackValue + 1;

            return value;
        }
    }
}
