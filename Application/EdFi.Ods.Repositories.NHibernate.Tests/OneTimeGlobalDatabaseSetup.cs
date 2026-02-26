// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Infrastructure.Compatibility;
using Npgsql;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [SetUpFixture]
    public class OneTimeGlobalDatabaseSetup : OneTimeGlobalDatabaseSetupBase
    {
        public static OneTimeGlobalDatabaseSetup Instance { get; private set; }

        public OneTimeGlobalDatabaseSetup()
        {
            Instance = this;
        }

        protected override string DatabaseCopyPrefix
        {
            get => "EdFiOdsRepositoriesNHibernateTests";
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Configure Npgsql for .NET 10+ DateOnly/TimeOnly compatibility
            // Npgsql 10.0+ maps SQL DATE to DateOnly by default, but NHibernate expects DateTime
            // See: https://www.npgsql.org/doc/release-notes/10.0.html
            #pragma warning disable CS0618 // GlobalTypeMapper is obsolete but required for NHibernate compatibility
            #pragma warning disable NPG9001 // Type is for evaluation purposes only and is subject to change or removal in future updates
            NpgsqlConnection.GlobalTypeMapper.AddTypeInfoResolverFactory(new LegacyDateAndTimeResolverFactory());
            #pragma warning restore NPG9001
            #pragma warning restore CS0618

        }
    }
}
