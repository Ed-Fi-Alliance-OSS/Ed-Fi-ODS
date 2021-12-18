// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware
{
    [TestFixture]
    public class ExplicitProfileMiddlewareTests
    {
        [SetUp]
        public void SetUp()
        {
            _apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();
            _schemaNameMapProvider = A.Fake<ISchemaNameMapProvider>();
            _profileResourceModelProvider = A.Fake<IProfileResourceModelProvider>();
            _apiSettings = new ApiSettings { Mode = ApiMode.YearSpecific.Value };

            var profileDefinition = XElement.Parse(
                @"
                            <Profile name='Test-Profile'>
                                <Resource name='Student' logicalSchema='Ed-Fi'>
                                    <ReadContentType memberSelection='IncludeOnly'>
                                        <Property name='KeyProperty1' />
                                    </ReadContentType>
                                    <WriteContentType memberSelection='IncludeOnly'>
                                        <Property name='KeyProperty1' />
                                    </WriteContentType>
                                </Resource>
                            </Profile>");

            var resourceModel = new ResourceModel(
                CreateValidDomainModel()
                    .Build());

            var profileResourceModel = new ProfileResourceModel(resourceModel, profileDefinition);

            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByUriSegment(EdFiConventions.UriSegment))
                .Returns(
                    resourceModel.SchemaNameMapProvider.GetSchemaMapByUriSegment(EdFiConventions.UriSegment));

            A.CallTo(() => _profileResourceModelProvider.GetProfileResourceModel(A<string>._))
                .Returns(profileResourceModel);

            _sut = new ExplicitProfilesMiddleware(
                _apiKeyContextProvider,
                _schemaNameMapProvider,
                _profileResourceModelProvider,
                _apiSettings);

            static DomainModelBuilder CreateValidDomainModel()
            {
                var entityDefinitions = new[]
                {
                    new EntityDefinition(
                        EdFiConventions.PhysicalSchemaName,
                        "Student",
                        new[]
                        {
                            new EntityPropertyDefinition(
                                "KeyProperty1",
                                new PropertyType(DbType.Int32),
                                null,
                                true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK",
                                new[]
                                {
                                    "KeyProperty1",
                                    "KeyProperty2"
                                },
                                isPrimary: true)
                        },
                        true),
                    new EntityDefinition(
                        EdFiConventions.PhysicalSchemaName,
                        "Collection1Item",
                        new[]
                        {
                            new EntityPropertyDefinition(
                                "KeyProperty1",
                                new PropertyType(DbType.Int32),
                                null,
                                true),
                            new EntityPropertyDefinition(
                                "KeyProperty2",
                                new PropertyType(DbType.Int32),
                                null,
                                true)
                        },
                        new[]
                        {
                            new EntityIdentifierDefinition(
                                "PK",
                                new[]
                                {
                                    "KeyProperty1",
                                    "KeyProperty2"
                                },
                                isPrimary: true)
                        },
                        true)
                };

                var associationDefinitions = new[]
                {
                    new AssociationDefinition(
                        new FullName(EdFiConventions.PhysicalSchemaName, "FK_StudentCollection"),
                        Cardinality.OneToZeroOrMore,
                        new FullName(EdFiConventions.PhysicalSchemaName, "Student"),
                        new[]
                        {
                            new EntityPropertyDefinition(
                                "KeyProperty1",
                                new PropertyType(DbType.Int32),
                                null,
                                true)
                        },
                        new FullName(EdFiConventions.PhysicalSchemaName, "Collection1Item"),
                        new[]
                        {
                            new EntityPropertyDefinition(
                                "KeyProperty1",
                                new PropertyType(DbType.Int32),
                                null,
                                true)
                        },
                        isIdentifying: true,
                        isRequired: true)
                };

                var aggredateDefinitions = new[]
                {
                    new AggregateDefinition(
                        new FullName(EdFiConventions.PhysicalSchemaName, "Student"),
                        new[] { new FullName(EdFiConventions.PhysicalSchemaName, "Collection1Item") })
                };

                // schema names do not match the names on the AggregateDefinition
                var schemaDefinition = new SchemaDefinition(
                    EdFiConventions.LogicalName,
                    EdFiConventions.PhysicalSchemaName);

                var modelDefinitions = new DomainModelDefinitions(
                    schemaDefinition,
                    aggredateDefinitions,
                    entityDefinitions,
                    associationDefinitions);

                var domainModelDefinitionsProvider = A.Fake<IDomainModelDefinitionsProvider>();

                A.CallTo(() => domainModelDefinitionsProvider.GetDomainModelDefinitions())
                    .Returns(modelDefinitions);

                DomainModelBuilder builder = new DomainModelBuilder();

                builder.AddDomainModelDefinitionsList(
                    new List<DomainModelDefinitions> { domainModelDefinitionsProvider.GetDomainModelDefinitions() });

                return builder;
            }
        }

        private ISchemaNameMapProvider _schemaNameMapProvider;
        private IProfileResourceModelProvider _profileResourceModelProvider;
        private ApiSettings _apiSettings;
        private IApiKeyContextProvider _apiKeyContextProvider;
        private ExplicitProfilesMiddleware _sut;

        [Test]
        public async Task Should_do_nothing_for_delete_request()
        {
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = HttpMethods.Delete,
                    Path = new PathString("/data/v3/2021/ed-fi/students?limit=2")
                }
            };

            await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .MustNotHaveHappened();

            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByUriSegment(A<string>._))
                .MustNotHaveHappened();

            A.CallTo(() => _profileResourceModelProvider.GetProfileResourceModel(A<string>._))
                .MustNotHaveHappened();
        }

        [Test]
        public async Task Should_do_nothing_for_patch_request()
        {
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = HttpMethods.Patch,
                    Path = new PathString("/data/v3/2021/ed-fi/students?limit=2")
                }
            };

            await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .MustNotHaveHappened();

            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByUriSegment(A<string>._))
                .MustNotHaveHappened();

            A.CallTo(() => _profileResourceModelProvider.GetProfileResourceModel(A<string>._))
                .MustNotHaveHappened();
        }

        [Test]
        public async Task Should_do_nothing_for_non_data_management_request()
        {
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = HttpMethods.Get,
                    Path = new PathString("/metadata/2021/xsd/ed-fi/Ed-Fi-Core.xsd")
                }
            };

            await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .MustNotHaveHappened();

            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByUriSegment(A<string>._))
                .MustNotHaveHappened();

            A.CallTo(() => _profileResourceModelProvider.GetProfileResourceModel(A<string>._))
                .MustNotHaveHappened();
        }

        [Test]
        public async Task
            Should_do_apply_correct_content_type_for_a_vendor_with_profile_on_a_get_for_a_resource_with_query_string()
        {
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = HttpMethods.Get,
                    Path = new PathString("/data/v3/2021/ed-fi/students?limit=2")
                }
            };

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .Returns(CreateApiKeyContext(new[] { "Test-Profile" }));

            await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .MustHaveHappened();

            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByUriSegment(A<string>._))
                .MustHaveHappened();

            A.CallTo(() => _profileResourceModelProvider.GetProfileResourceModel(A<string>._))
                .MustHaveHappened();

            httpContext.Request.ContentType.ShouldBe(
                "application/vnd.ed-fi.student.test-profile.readable+json");
        }

        [Test]
        public async Task
            Should_do_apply_correct_content_type_for_a_vendor_with_profile_on_a_get_for_a_resource_without_query_string()
        {
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = HttpMethods.Get,
                    Path = new PathString("/data/v3/2021/ed-fi/students")
                }
            };

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .Returns(CreateApiKeyContext(new[] { "Test-Profile" }));

            await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .MustHaveHappened();

            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByUriSegment(A<string>._))
                .MustHaveHappened();

            A.CallTo(() => _profileResourceModelProvider.GetProfileResourceModel(A<string>._))
                .MustHaveHappened();

            httpContext.Request.ContentType.ShouldBe(
                "application/vnd.ed-fi.student.test-profile.readable+json");
        }

        [Test]
        public async Task
            Should_do_apply_correct_content_type_for_a_vendor_with_profile_on_a_put_for_a_resource()
        {
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = HttpMethods.Put,
                    Path = new PathString("/data/v3/2021/ed-fi/students/1234")
                }
            };

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .Returns(CreateApiKeyContext(new[] { "Test-Profile" }));

            await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .MustHaveHappened();

            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByUriSegment(A<string>._))
                .MustHaveHappened();

            A.CallTo(() => _profileResourceModelProvider.GetProfileResourceModel(A<string>._))
                .MustHaveHappened();

            httpContext.Request.ContentType.ShouldBe(
                "application/vnd.ed-fi.student.test-profile.writable+json");
        }

        [Test]
        public async Task
            Should_do_apply_correct_content_type_for_a_vendor_with_profile_on_a_post_for_a_resource()
        {
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = HttpMethods.Post,
                    Path = new PathString("/data/v3/2021/ed-fi/students")
                }
            };

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .Returns(CreateApiKeyContext(new[] { "Test-Profile" }));

            await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .MustHaveHappened();

            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByUriSegment(A<string>._))
                .MustHaveHappened();

            A.CallTo(() => _profileResourceModelProvider.GetProfileResourceModel(A<string>._))
                .MustHaveHappened();

            httpContext.Request.ContentType.ShouldBe(
                "application/vnd.ed-fi.student.test-profile.writable+json");
        }

        [Test]
        public async Task
            Should_return_bad_request_for_multiple_profiles_for_a_vendor()
        {
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = HttpMethods.Get,
                    Path = new PathString("/data/v3/2021/ed-fi/students")
                }
            };

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .Returns(
                    CreateApiKeyContext(
                        new[]
                        {
                            "Test-Profile",
                            "Profile-2"
                        }));

            await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext())
                .MustHaveHappened();

            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByUriSegment(A<string>._))
                .MustNotHaveHappened();

            A.CallTo(() => _profileResourceModelProvider.GetProfileResourceModel(A<string>._))
                .MustNotHaveHappened();

            httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status400BadRequest);
        }

        private ApiKeyContext CreateApiKeyContext(IEnumerable<string> profiles = null)
            => new ApiKeyContext(
                "apiKey",
                "claimset",
                new[] { 1 },
                new[] { "uri://ed-fi.org" },
                profiles,
                null,
                null,
                null);
    }
}
