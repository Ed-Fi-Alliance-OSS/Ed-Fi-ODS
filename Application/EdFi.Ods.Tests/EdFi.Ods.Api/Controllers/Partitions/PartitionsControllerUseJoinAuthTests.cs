// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using EdFi.Ods.Api.Controllers.Partitions.Controllers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers.Partitions;

[TestFixture]
public class PartitionsControllerUseJoinAuthTests
{
    [TestCase("useJoinAuth", "yes")]
    [TestCase("useJoinAuth", "true")]
    public async Task Should_ignore_the_removed_useJoinAuth_parameter(string name, string value)
    {
        var personTypesProvider = A.Fake<IPersonTypesProvider>();
        A.CallTo(() => personTypesProvider.PersonTypes).Returns(Array.Empty<string>());

        // With no resource in the context, a request that gets past the parameters ends in a 404 before any database work
        var resourceContextProvider = A.Fake<IContextProvider<DataManagementResourceContext>>();
        A.CallTo(() => resourceContextProvider.Get()).Returns(null);

        var controller = new PartitionsController(
            A.Fake<DbProviderFactory>(),
            resourceContextProvider,
            A.Fake<IOdsDatabaseConnectionStringProvider>(),
            A.Fake<ILogContextAccessor>(),
            A.Fake<IPartitionsQueryBuilderProvider>(),
            personTypesProvider,
            A.Fake<IContextProvider<UsiLookupsByUniqueIdContext>>(),
            A.Fake<IContextualPersonUsisResolver>());

        var result = await controller.Get(
            null,
            new UrlQueryParametersRequest(),
            new Dictionary<string, string> { [name] = value });

        result.ShouldBeAssignableTo<IStatusCodeActionResult>().StatusCode.ShouldBe(StatusCodes.Status404NotFound);
        A.CallTo(() => resourceContextProvider.Get()).MustHaveHappened();
    }
}
