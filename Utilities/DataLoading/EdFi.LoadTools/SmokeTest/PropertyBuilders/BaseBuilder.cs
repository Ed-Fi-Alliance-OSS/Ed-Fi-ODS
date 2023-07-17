// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using log4net;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public abstract class BaseBuilder : IPropertyBuilder
    {
        protected static readonly Random Random = new Random(1);
        private int _counter = 50; // Start from 50 to not collide with existing EdOrgIds if running over the populated template
        private readonly int _defaultStringLength = 7;
        private readonly IPropertyInfoMetadataLookup _metadataLookup;

        protected virtual ILog Log => LogManager.GetLogger(GetType().Name);

        protected BaseBuilder(IPropertyInfoMetadataLookup metadataLookup)
        {
            _metadataLookup = metadataLookup;
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
            var length = Math.Max(parameter.minLength.HasValue ? parameter.minLength.Value: 0, _defaultStringLength);
            length = Math.Min(parameter.maxLength.HasValue ? parameter.maxLength.Value : _defaultStringLength, length);
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

            return parameter.required.HasValue && parameter.required.Value;
        }

        protected int BuildRandomNumber(PropertyInfo propertyInfo)
        {
            var parameter = _metadataLookup.GetMetadata(propertyInfo);
            
            if (parameter.minimum.HasValue && parameter.maximum.HasValue)
            {
                return Random.Next((int)parameter.minimum.Value, (int)parameter.maximum.Value);
            }
            else if (parameter.minimum.HasValue)
            {
                // Temporary fix to issue dscribed in ODS-5935
                var minVal = (int)parameter.minimum.Value == 0 ? _counter++ : (int)parameter.minimum.Value;
                return minVal;
            }
            else if(parameter.maximum.HasValue)
            {
                return (int)parameter.maximum.Value;
            }
            else
            {
                return _counter++;
            }
        }
    }
}
