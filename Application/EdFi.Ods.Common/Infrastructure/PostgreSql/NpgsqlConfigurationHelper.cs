// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Infrastructure.Configuration;
using Npgsql;

namespace EdFi.Ods.Common.Infrastructure.PostgreSql
{
    /// <summary>
    /// Provides configuration utilities for Npgsql driver.
    /// </summary>
    public static class NpgsqlConfigurationHelper
    {
        private static bool _isConfigured = false;

        /// <summary>
        /// Configures Npgsql for .NET 10+ DateOnly/TimeOnly and legacy timestamp compatibility.
        /// This method is idempotent and can be called multiple times safely.
        /// </summary>
        public static void ConfigureLegacyDateTimeSupport()
        {
            if (_isConfigured) return;

            // Configure Npgsql for .NET 10+ DateOnly/TimeOnly and legacy timestamp compatibility
            // - Npgsql 10.0+ maps SQL DATE to DateOnly by default, but NHibernate expects DateTime
            // - Enables legacy timestamp behavior for DateTime/DateTimeOffset mapping
            // See: https://www.npgsql.org/doc/release-notes/10.0.html
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            #pragma warning disable CS0618 // GlobalTypeMapper is obsolete but required for NHibernate compatibility
            #pragma warning disable NPG9001 // Type is for evaluation purposes only and is subject to change or removal in future updates
            NpgsqlConnection.GlobalTypeMapper.AddTypeInfoResolverFactory(new LegacyDateAndTimeResolverFactory());
            #pragma warning restore NPG9001
            #pragma warning restore CS0618

            _isConfigured = true;
        }
    }
}
