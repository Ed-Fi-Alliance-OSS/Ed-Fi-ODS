// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using EdFi.Ods.Common.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EdFi.Ods.Common.Models.Domain
{
    public class PropertyType
    {
        public PropertyType(DbType dbType, int maxLength = 0, int precision = 0, int scale = 0, bool isNullable = false)
        {
            if (maxLength != 0 && (precision != 0 || scale != 0))
            {
                throw new BadRequestException("Either maxLength or precision/scale can have non-zero values, but not both.");
            }

            if (maxLength < 0)
            {
                throw new BadRequestException("maxLength must be a value greater than 0.");
            }

            MaxLength = maxLength;

            if (precision != 0 || scale != 0)
            {
                ValidatePrecisionAndScale(precision, scale);
                Precision = precision;
                Scale = scale;
            }

            DbType = dbType;
            IsNullable = isNullable;
        }

        public bool IsNullable { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DbType DbType { get; }

        public int Precision { get; }

        public int Scale { get; }

        public int MaxLength { get; }

        private static void ValidatePrecisionAndScale(int precision, int scale)
        {
            if (precision <= 0)
            {
                throw new BadRequestException($"Precision must be a positive value (was '{precision}').");
            }

            if (scale < 0)
            {
                throw new BadRequestException($"Scale must be non-negative value (was '{scale}').");
            }

            if (scale != 0 && precision == 0)
            {
                throw new BadRequestException("Precision must be supplied if a Scale is supplied.");
            }

            if (scale > precision)
            {
                throw new BadRequestException($"Scale ('{scale}') cannot be larger than the Precision ('{precision}').");
            }
        }
    }
}
