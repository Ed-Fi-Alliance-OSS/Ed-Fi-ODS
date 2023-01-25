// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Entities.NHibernate.EducationContentAggregate.EdFi;
using EdFi.TestFixture;
using FakeItEasy;
using NHibernate;
using NHibernate.Context;
using NHibernate.Engine;
using NHibernate.Id;
using NHibernate.Metadata;
using NHibernate.Persister.Entity;
using NHibernate.Type;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Infrastructure.Repositories
{
    [TestFixture]
    public class CreateEntity : TestFixtureBase
    {
        public class When_creating_entity_with_string_id : TestFixtureBase
        {
            private ISessionFactoryImplementor _sessionFactory;
            private IEnumerable<IEntityValidator> _validators;

            protected override void Arrange()
            {
                _sessionFactory = GetSessionFactoryStub();
                _validators = Stub<IEnumerable<IEntityValidator>>();
                var metadata = A.Fake<IClassMetadata>(x => x.Implements<IEntityPersister>());

                A.CallTo(() => _sessionFactory.GetClassMetadata(typeof(EducationContent)))
                                  .Returns(metadata);

                A.CallTo(() => metadata.HasIdentifierProperty)
                                  .Returns(true);

                A.CallTo(() => ((IEntityPersister)metadata).IdentifierGenerator)
                                  .Returns(new Assigned());

                var fakeType = GetITypeStub();

                A.CallTo(() => metadata.IdentifierType)
                                  .Returns(fakeType);

                A.CallTo(() => metadata.GetIdentifier(A<EducationContent>._))
                                  .Returns(null);

                A.CallTo(() => metadata.IdentifierPropertyName)
                                  .Returns("ContentIdentifier");
            }

            protected override void Act()
            {
                var createEntity = new CreateEntity<EducationContent>(
                    _sessionFactory,
                    _validators);

                createEntity.CreateAsync(
                    new EducationContent { ContentIdentifier = null }, 
                    false, 
                    CancellationToken.None).Wait();
            }

            [Assert]
            public void Should_return_expected_exception_when_id_is_missing()
            {
                Assert.That(
                    ActualException.InnerException,
                    Is.TypeOf(typeof(BadRequestException)));

                Assert.That(
                    ActualException.InnerException.Message,
                    Is.EqualTo("Value for resource's identifier property 'ContentIdentifier' is required."));
            }
        }

        private static ISessionFactoryImplementor GetSessionFactoryStub()
        {
            var sessionFactoryStub = A.Fake<ISessionFactoryImplementor>();
            var sessionStub = A.Fake<ISession>();

            A.CallTo(() => sessionStub.SessionFactory)
                              .Returns(sessionFactoryStub);

            A.CallTo(() => sessionStub.IsOpen)
                              .Returns(true);

            A.CallTo(() => sessionFactoryStub.OpenSession())
                              .Returns(sessionStub);

            A.CallTo(() => sessionFactoryStub.CurrentSessionContext)
                              .Returns(new ThreadStaticSessionContext(sessionFactoryStub));

            A.CallTo(() => sessionFactoryStub.GetCurrentSession())
                              .Returns(sessionStub);

            return sessionFactoryStub;
        }

        private static IType GetITypeStub()
        {
            var typeStub = A.Fake<IType>();
            A.CallTo(() => typeStub.ReturnedClass)
                              .Returns(typeof(string));

            return typeStub;
        }
    }
}
