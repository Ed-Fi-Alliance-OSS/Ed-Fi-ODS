// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Common.Database.Querying.Dialects;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    [TestFixture]
    public class RelationshipAuthorizationConventionsTests
    {
        [Test]
        public void Should_keep_the_dialect_claims_parameter_name_matched_to_the_authorization_convention()
        {
            // The SQL Server dialect decides whether to land the claims table-valued parameter into a temp table by
            // comparing the IN clause parameter name against its own constant. That constant lives in EdFi.Ods.Common
            // and the convention lives in EdFi.Ods.Api, which cannot reference each other, so the two are joined only
            // by a comment. Renaming either one silently disables the landing for both the resource endpoints and the
            // change query endpoints, with every other test still passing. This assertion is what fails instead.
            SqlServerDialect.ClaimsParameterName.ShouldBe($"@{RelationshipAuthorizationConventions.ClaimsParameterName}");
        }
    }
}
