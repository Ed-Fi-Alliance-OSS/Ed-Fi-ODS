// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Threading;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Security.Authorization.Repositories;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Security.Container.Installers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization.Repositories
{
    [TestFixture]
    public class SecurityComponentsInstallerTest
    {
        [TestFixture]
        [Ignore("Cannot be executed since SecurityComponentsInstaller doesn't install the decorators right now.")]
        public class When_resolving_authorization_decorators
        {
            [SetUp]
            public void SetUp()
            {
                var container = new WindsorContainerEx();
                container.Install(new SecurityComponentsInstaller());

                container.Register(
                    Component
                       .For(typeof(IGetEntityByKey<>))
                       .ImplementedBy(typeof(DecoratedGetEntityByKey<>))
                       .OnCreate((kernel, item) => DecoratedGetEntityByKeyInstance = (DecoratedGetEntityByKey<Student>) item));

                container.Register(
                    Component
                       .For(typeof(IRelationshipsAuthorizationContextDataProvider<>))
                       .ImplementedBy(typeof(RelationshipsAuthorizationContextDataProviderStub<>)) //,
                );

                resolvedIGetEntityByKey = container.Resolve<IGetEntityByKey<Student>>();
            }

            private IGetEntityByKey<Student> resolvedIGetEntityByKey;
            private DecoratedGetEntityByKey<Student> DecoratedGetEntityByKeyInstance;

            [Test]
            public void Resolved_object_should_be_the_decorator_()
            {
                resolvedIGetEntityByKey.ShouldBeOfType(typeof(GetEntityByKeyAuthorizationDecorator<Student>));
            }

            [Test]
            public void When_invoking_the_service_the_decorator_should_pass_control_to_the_decorated_object()
            {
                resolvedIGetEntityByKey.GetByKeyAsync(new Student(), CancellationToken.None).GetResultSafely();
                DecoratedGetEntityByKeyInstance.WasCalled.ShouldBeTrue();
            }
        }
    }

    internal class DecoratedGetEntityByKey<T> : IGetEntityByKey<T>
        where T : IDateVersionedEntity, IHasIdentifier
    {
        public bool WasCalled { get; set; }

        public Task<T> GetByKeyAsync(T specification, CancellationToken cancellationToken)
        {
            WasCalled = true;
            
            return Task.FromResult(specification);
        }
    }

    internal class RelationshipsAuthorizationContextDataProviderStub<T>
        : IRelationshipsAuthorizationContextDataProvider<T, RelationshipsAuthorizationContextData>
    {
        public RelationshipsAuthorizationContextData GetContextData(T resource)
        {
            return new RelationshipsAuthorizationContextData();
        }

        public RelationshipsAuthorizationContextData GetContextData(object resource)
        {
            return new RelationshipsAuthorizationContextData();
        }

        /// <summary>
        /// Gets the properties that are relevant for relationship-based authorization.
        /// </summary>
        /// <returns>The names of the properties to be used for the authorization context.</returns>
        public string[] GetAuthorizationContextPropertyNames()
        {
            throw new NotImplementedException();
        }
    }
}
