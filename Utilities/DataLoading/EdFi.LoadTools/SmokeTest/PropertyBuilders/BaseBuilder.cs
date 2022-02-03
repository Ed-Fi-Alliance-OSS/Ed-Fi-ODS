// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using EdFi.LoadTools.Common;
using log4net;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public abstract class BaseBuilder : IPropertyBuilder
    {
        protected static readonly Random Random = new Random(1);
        private readonly IPropertyInfoMetadataLookup _metadataLookup;

        protected virtual ILog Log => LogManager.GetLogger(GetType().Name);

        protected virtual string RandomTestString => BuildRandomString(6);

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

        protected static string BuildRandomString(int length)
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
    }
}
