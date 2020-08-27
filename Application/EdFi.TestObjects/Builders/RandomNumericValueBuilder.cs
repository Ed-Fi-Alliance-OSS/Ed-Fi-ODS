// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;

namespace EdFi.TestObjects.Builders
{
    public class RandomNumericValueBuilder : IValueBuilder
    {
        private readonly Random _random = new Random();

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (!buildContext.TargetType.IsValueType)
            {
                return ValueBuildResult.NotHandled;
            }

            if (buildContext.TargetType != typeof(ushort)
                && buildContext.TargetType != typeof(uint)
                && buildContext.TargetType != typeof(ulong)
                && buildContext.TargetType != typeof(byte)
                && buildContext.TargetType != typeof(sbyte)
                && buildContext.TargetType != typeof(short)
                && buildContext.TargetType != typeof(int)
                && buildContext.TargetType != typeof(long)
                && buildContext.TargetType != typeof(decimal)
                && buildContext.TargetType != typeof(double)
                && buildContext.TargetType != typeof(float))
            {
                return ValueBuildResult.NotHandled;
            }

            var value = GetRandomValue(buildContext.TargetType);
            return ValueBuildResult.WithValue(value, buildContext.LogicalPropertyPath);
        }

        public void Reset() { }

        public ITestObjectFactory Factory { get; set; }

        private object GetRandomValue(Type targetType)
        {
            if (targetType == typeof(ushort))
            {
                return _random.Next(1, ushort.MaxValue + 1);
            }

            if (targetType == typeof(uint))
            {
                byte[] buffer = new byte[sizeof(uint)];
                _random.NextBytes(buffer);
                return BitConverter.ToUInt32(buffer, 0);
            }

            if (targetType == typeof(ulong))
            {
                byte[] buffer = new byte[sizeof(ulong)];
                _random.NextBytes(buffer);
                return BitConverter.ToUInt64(buffer, 0);
            }

            if (targetType == typeof(byte))
            {
                byte[] buffer = new byte[sizeof(byte)];
                _random.NextBytes(buffer);
                return buffer[0];
            }

            if (targetType == typeof(sbyte))
            {
                byte[] buffer = new byte[sizeof(uint)];
                _random.NextBytes(buffer);
                return (sbyte) buffer[0];
            }

            if (targetType == typeof(short))
            {
                byte[] buffer = new byte[sizeof(short)];
                _random.NextBytes(buffer);
                return BitConverter.ToInt16(buffer, 0);
            }

            if (targetType == typeof(int))
            {
                return _random.Next(1, int.MaxValue);
            }

            if (targetType == typeof(long))
            {
                byte[] buffer = new byte[sizeof(long)];
                _random.NextBytes(buffer);
                return BitConverter.ToInt64(buffer, 0);
            }

            if (targetType == typeof(decimal))
            {
                // GKM: Full 64-bit based range isn't really necessary, and it's causing problems with SQL Server.  Changed to 32-bit.
                byte[] buffer = new byte[sizeof(int)];
                _random.NextBytes(buffer);

                var numericPortion = BitConverter.ToInt32(buffer, 0);
                var decimalPortion = _random.Next(1, 10000) / 10000m;

                return numericPortion + decimalPortion;
            }

            if (targetType == typeof(double))
            {
                byte[] buffer = new byte[sizeof(double)];
                _random.NextBytes(buffer);
                return BitConverter.ToDouble(buffer, 0);
            }

            if (targetType == typeof(float))
            {
                byte[] buffer = new byte[sizeof(float)];
                _random.NextBytes(buffer);
                return BitConverter.ToSingle(buffer, 0);
            }

            throw new NotSupportedException(
                string.Format(
                    "'{0}' is not an explicitly supported numeric type.  Did you try to add support for it but forget to add explicit logic for generating a random value of this type?",
                    targetType.Name));
        }
    }
}
