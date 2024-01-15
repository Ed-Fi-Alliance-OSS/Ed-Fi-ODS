﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Globalization;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Exceptions;

namespace EdFi.Ods.Api.Providers
{
    public class ETagProvider : IETagProvider
    {
        public string GetETag(object entity)
        {
            if (entity == null)
            {
                return null;
            }

            // Handle entities
            if (entity is IDateVersionedEntity versionEntity)
            {
                var dateToGenerateEtagFrom = versionEntity.LastModifiedDate;

                if (dateToGenerateEtagFrom == default(DateTime))
                {
                    return null;
                }

                // Utc - No conversion is performed.
                // Local - The current DateTime object is converted to UTC.
                // Unspecified - The current DateTime object is assumed to be a local time, and the conversion is performed as if Kind were Local.
                // See https://docs.microsoft.com/en-us/dotnet/api/system.datetime.touniversaltime?view=netframework-4.5#System_DateTime_ToUniversalTime
                var standardizedEtagDateTime = dateToGenerateEtagFrom.ToUniversalTime();

                return standardizedEtagDateTime.ToBinary()
                                               .ToString(CultureInfo.InvariantCulture);
            }

            // Handle resources
            if (entity is IHasETag resourceEntity)
            {
                return resourceEntity.ETag;
            }

            // Handle date values
            if (entity is DateTime dateValue)
            {
                // Utc - No conversion is performed.
                // Local - The current DateTime object is converted to UTC.
                // Unspecified - The current DateTime object is assumed to be a local time, and the conversion is performed as if Kind were Local.
                // See https://docs.microsoft.com/en-us/dotnet/api/system.datetime.touniversaltime?view=netframework-4.5#System_DateTime_ToUniversalTime
                var standardizedEtagDateTime = dateValue.ToUniversalTime();

                return standardizedEtagDateTime.ToBinary()
                                               .ToString(CultureInfo.InvariantCulture);
            }

            // Handle guids
            if (entity is Guid guidValue)
            {
                return guidValue.ToString("N");
            }

            // Handle strings
            var stringValue = entity as string;

            if (!string.IsNullOrEmpty(stringValue))
            {
                return stringValue;
            }

            throw new Exception($"Unsupported type for ETag determination: '{entity.GetType().Name}'");
        }

        public DateTime GetDateTime(string etag)
        {
            if (!string.IsNullOrWhiteSpace(etag) && long.TryParse(etag, out long result))
            {
                try
                {
                    return DateTime.FromBinary(result);
                }
                catch (Exception ex)
                {
                    throw new BadRequestParameterException(
                        "An invalid value was provided for use in detecting changes applied by other users.",
                        new[] { "An invalid ETag value was provided that could not be processed back into a Date/Time value." },
                        ex);
                }
            }

            return default(DateTime);
        }
    }
}
