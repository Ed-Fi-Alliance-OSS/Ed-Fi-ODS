// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.IdentityValueMappers;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.WebService.Tests._Installers;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.WebService.Tests.IdentityValueMappers
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_retrieving_all_the_Student_identity_value_mappings
        : TestFixtureBase
    {
        private IEnumerable<PersonIdentifiersValueMap> _actualStudentIdentifiers;
        private IEnumerable<PersonIdentifiersValueMap> _actualStaffIdentifiers;
        private IEnumerable<PersonIdentifiersValueMap> _actualParentIdentifiers;

        private IWindsorContainer _container;
        
        protected override void Arrange()
        {
            InitializeIoC();
        }

        private void InitializeIoC()
        {
            _container = new WindsorContainerEx();

            // Apply connection string resolution conventions
            _container.AddFacility<DatabaseConnectionStringProviderFacility>();

            _container.Register(
                Component.For<IDatabaseConnectionStringProvider>()
                    .Named("IDatabaseConnectionStringProvider.Ods")
                    .Instance(
                        new LiteralDatabaseConnectionStringProvider(
                            GlobalDatabaseSetupFixture.PopulatedDatabaseConnectionString)));

            _container.Install(new LegacyEdFiOdsNHibernateInstaller());
            _container.Install(new LegacyEdFiOdsApiInstaller());

            // Configure NHibernate
#pragma warning disable 618
            _container.Register(Component.For<IOrmMappingFileDataProvider>()
                .UsingFactoryMethod(kernel => new OrmMappingFileDataProvider(kernel.Resolve<IAssembliesProvider>(), DatabaseEngine.SqlServer, "EdFi.Ods.Standard"))
            );

            _container.Register(Component.For<IAssembliesProvider>().ImplementedBy<AssembliesProvider>());

            new LegacyNHibernateConfigurator().Configure(_container);
#pragma warning restore 618
            
            _container.Register(
                Component.For<ICacheProvider>()
                    .ImplementedBy<MemoryCacheProvider>());
        }
        
        protected override void Act()
        {
            var provider = _container.Resolve<IPersonIdentifiersProvider>();

            _actualStudentIdentifiers = provider.GetAllPersonIdentifiers("Student").Result;
            _actualStaffIdentifiers = provider.GetAllPersonIdentifiers("Staff").Result;
            _actualParentIdentifiers = provider.GetAllPersonIdentifiers("Parent").Result;
            
            // This statement throws an exception
            var ignoredDueToException = provider.GetAllPersonIdentifiers("NonPersonType").Result;
        }

        [Assert]
        public void Should_load_some_Student_identity_mappings()
        {
            Assert.That(_actualStudentIdentifiers, Has.Count.GreaterThan(0));
        }

        [Assert]
        public void Should_load_some_Staff_identity_mappings()
        {
            Assert.That(_actualStaffIdentifiers, Has.Count.GreaterThan(0));
        }
        
        [Assert]
        public void Should_load_some_Parent_identity_mappings()
        {
            Assert.That(_actualParentIdentifiers, Has.Count.GreaterThan(0));
        }

        [Assert]
        public void Should_load_USIs_and_UniqueIds_but_no_Ids_for_each_value_mapping()
        {
            var allIdentifierValueMaps = _actualStudentIdentifiers
                .Concat(_actualStaffIdentifiers)
                .Concat(_actualParentIdentifiers);

            foreach (var valueMap in allIdentifierValueMaps)
            {
                valueMap.Id.ShouldBe(new Guid());
                valueMap.Usi.ShouldBeGreaterThan(0);
                valueMap.UniqueId.Length.ShouldBeGreaterThan(0);
            }
        }

        [Assert]
        public void Should_throw_an_exception_for_an_invalid_person_type_indicating_that_the_Person_type_specified_is_invalid()
        {
            Assert.That(ActualException, Is.TypeOf<AggregateException>());

            var innerException = (ActualException as AggregateException)
                ?.Flatten()
                .InnerException;

            innerException.ShouldSatisfyAllConditions(
                    () => innerException.ShouldBeOfType<ArgumentException>(),
                    () => innerException?.Message.ShouldContain("Invalid person type"));
        }
    }
}
