// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
//
// Source: https://github.com/npgsql/npgsql (adapted for Npgsql 9.x/10.x API)
// This provides compatibility for legacy DateTime/TimeSpan behavior where
// DATE and TIME PostgreSQL types return DateTime/TimeSpan instead of DateOnly/TimeOnly

#nullable enable
#pragma warning disable CS8618, CS8603, CS8604, CS8632 // Nullable reference type warnings
#pragma warning disable NPG9001 // Type is for evaluation purposes only

using System;
using Npgsql;
using Npgsql.Internal;
using Npgsql.Internal.Postgres;
using NpgsqlTypes;

namespace EdFi.Ods.Common.Infrastructure.Compatibility
{
    // NOTE: This implementation is adapted from Npgsql documentation
    // See: https://www.npgsql.org/doc/release-notes/10.0.html#date-and-time-are-now-mapped-to-dateonly-and-timeonly
    public class LegacyDateAndTimeResolverFactory : PgTypeInfoResolverFactory
    {
        public override IPgTypeInfoResolver CreateResolver() => new Resolver();
        public override IPgTypeInfoResolver CreateArrayResolver() => new ArrayResolver();
        public override IPgTypeInfoResolver CreateRangeResolver() => new RangeResolver();
        public override IPgTypeInfoResolver CreateRangeArrayResolver() => new RangeArrayResolver();
        public override IPgTypeInfoResolver CreateMultirangeResolver() => new MultirangeResolver();
        public override IPgTypeInfoResolver CreateMultirangeArrayResolver() => new MultirangeArrayResolver();

        const string Date = "pg_catalog.date";
        const string Time = "pg_catalog.time";
        const string DateRange = "pg_catalog.daterange";
        const string DateMultirange = "pg_catalog.datemultirange";

        class Resolver : IPgTypeInfoResolver
        {
            TypeInfoMappingCollection? _mappings;
            protected TypeInfoMappingCollection Mappings => _mappings ??= AddMappings(new());

            public PgTypeInfo? GetTypeInfo(Type? type, DataTypeName? dataTypeName, PgSerializerOptions options)
                => type == typeof(object) ? Mappings.Find(type, dataTypeName, options) : null;

            static TypeInfoMappingCollection AddMappings(TypeInfoMappingCollection mappings)
            {
                mappings.AddStructType<DateTime>(Date,
                    static (options, mapping, _) => options.GetTypeInfo(typeof(DateTime), new DataTypeName(mapping.DataTypeName))!,
                    matchRequirement: MatchRequirement.DataTypeName);

                mappings.AddStructType<TimeSpan>(Time,
                    static (options, mapping, _) => options.GetTypeInfo(typeof(TimeSpan), new DataTypeName(mapping.DataTypeName))!,
                    isDefault: true);

                return mappings;
            }
        }

        sealed class ArrayResolver : Resolver, IPgTypeInfoResolver
        {
            TypeInfoMappingCollection? _mappings;
            new TypeInfoMappingCollection Mappings => _mappings ??= AddMappings(new(base.Mappings));

            public new PgTypeInfo? GetTypeInfo(Type? type, DataTypeName? dataTypeName, PgSerializerOptions options)
                => type == typeof(object) ? Mappings.Find(type, dataTypeName, options) : null;

            static TypeInfoMappingCollection AddMappings(TypeInfoMappingCollection mappings)
            {
                mappings.AddStructArrayType<DateTime>(Date);
                mappings.AddStructArrayType<TimeSpan>(Time);

                return mappings;
            }
        }

        class RangeResolver : IPgTypeInfoResolver
        {
            TypeInfoMappingCollection? _mappings;
            protected TypeInfoMappingCollection Mappings => _mappings ??= AddMappings(new());

            public PgTypeInfo? GetTypeInfo(Type? type, DataTypeName? dataTypeName, PgSerializerOptions options)
                => type == typeof(object) ? Mappings.Find(type, dataTypeName, options) : null;

            static TypeInfoMappingCollection AddMappings(TypeInfoMappingCollection mappings)
            {
                mappings.AddStructType<NpgsqlRange<DateTime>>(DateRange,
                    static (options, mapping, _) => options.GetTypeInfo(typeof(NpgsqlRange<DateTime>), new DataTypeName(mapping.DataTypeName))!,
                    matchRequirement: MatchRequirement.DataTypeName);

                return mappings;
            }
        }

        sealed class RangeArrayResolver : RangeResolver, IPgTypeInfoResolver
        {
            TypeInfoMappingCollection? _mappings;
            new TypeInfoMappingCollection Mappings => _mappings ??= AddMappings(new(base.Mappings));

            public new PgTypeInfo? GetTypeInfo(Type? type, DataTypeName? dataTypeName, PgSerializerOptions options)
                => type == typeof(object) ? Mappings.Find(type, dataTypeName, options) : null;

            static TypeInfoMappingCollection AddMappings(TypeInfoMappingCollection mappings)
            {
                mappings.AddStructArrayType<NpgsqlRange<DateTime>>(DateRange);

                return mappings;
            }
        }

        class MultirangeResolver : IPgTypeInfoResolver
        {
            TypeInfoMappingCollection? _mappings;
            protected TypeInfoMappingCollection Mappings => _mappings ??= AddMappings(new());

            public PgTypeInfo? GetTypeInfo(Type? type, DataTypeName? dataTypeName, PgSerializerOptions options)
                => type == typeof(object) ? Mappings.Find(type, dataTypeName, options) : null;

            static TypeInfoMappingCollection AddMappings(TypeInfoMappingCollection mappings)
            {
                mappings.AddType<NpgsqlRange<DateTime>[]>(DateMultirange,
                    static (options, mapping, _) => options.GetTypeInfo(typeof(NpgsqlRange<DateTime>[]), new DataTypeName(mapping.DataTypeName))!,
                    matchRequirement: MatchRequirement.DataTypeName);

                return mappings;
            }
        }

        sealed class MultirangeArrayResolver : MultirangeResolver, IPgTypeInfoResolver
        {
            TypeInfoMappingCollection? _mappings;
            new TypeInfoMappingCollection Mappings => _mappings ??= AddMappings(new(base.Mappings));

            public new PgTypeInfo? GetTypeInfo(Type? type, DataTypeName? dataTypeName, PgSerializerOptions options)
                => type == typeof(object) ? Mappings.Find(type, dataTypeName, options) : null;

            static TypeInfoMappingCollection AddMappings(TypeInfoMappingCollection mappings)
            {
                mappings.AddArrayType<NpgsqlRange<DateTime>[]>(DateMultirange);

                return mappings;
            }
        }
    }
}

#pragma warning restore NPG9001
#pragma warning restore CS8618, CS8603, CS8604, CS8632
