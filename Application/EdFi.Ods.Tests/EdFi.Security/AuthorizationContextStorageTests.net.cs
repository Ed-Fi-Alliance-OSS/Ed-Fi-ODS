// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Security
{
    [TestFixture]
    public class AuthorizationContextProviderTests
    {
        public class When_calling_the_VerifyContextSet_method_with_no_action_stored_in_the_current_context
            : ScenarioFor<AuthorizationContextProvider>
        {
            protected override void Arrange()
            {
                // Set the "resource" context only
                var contextStorage = new HashtableContextStorage();
                contextStorage.SetValue(AuthorizationContextKeys.Resource, new[] {"Some Resource"});
                
                Given<IContextStorage>(contextStorage);
            }

            protected override void Act()
            {
                SystemUnderTest.VerifyAuthorizationContextExists();
            }

            [Assert]
            public void Should_throw_an_AuthorizationContextException_with_action_in_the_message()
            {
                ActualException.ShouldBeExceptionType<AuthorizationContextException>();
                ActualException.Message.ShouldContain("action");
            }
        }

        public class When_calling_the_VerifyContextSet_method_with_no_resource_stored_in_the_current_context
            : ScenarioFor<AuthorizationContextProvider>
        {
            protected override void Arrange()
            {
                // Set the "action" context only
                var contextStorage = new HashtableContextStorage();
                contextStorage.SetValue(AuthorizationContextKeys.Action, "Some Action");

                Given<IContextStorage>(contextStorage);
            }

            protected override void Act()
            {
                SystemUnderTest.VerifyAuthorizationContextExists();
            }
            
            [Assert]
            public void Should_throw_an_AuthorizationContextException_with_action_in_the_message()
            {
                ActualException.ShouldBeExceptionType<AuthorizationContextException>();
                ActualException.Message.ShouldContain("resource");
            }
        }
        
        public class When_calling_the_VerifyContextSet_method_with_resource_stored_as_empty_array_in_the_current_context
            : ScenarioFor<AuthorizationContextProvider>
        {
            protected override void Arrange()
            {
                var contextStorage = new HashtableContextStorage();
                contextStorage.SetValue(AuthorizationContextKeys.Resource, new string[0]);
                contextStorage.SetValue(AuthorizationContextKeys.Action, "Some Action");
                
                Given<IContextStorage>(contextStorage);
            }

            protected override void Act()
            {
                SystemUnderTest.VerifyAuthorizationContextExists();
            }

            [Assert]
            public void Should_throw_an_AuthorizationContextException_with_action_in_the_message()
            {
                ActualException.ShouldBeExceptionType<AuthorizationContextException>();
                ActualException.Message.ShouldContain("resource");
            }
        }

        public class When_calling_the_VerifyContextSet_method_with_a_valid_context
            : ScenarioFor<AuthorizationContextProvider>
        {
            protected override void Arrange()
            {
                var contextStorage = new HashtableContextStorage();
                contextStorage.SetValue(AuthorizationContextKeys.Resource, new[] {"Some Resource"});
                contextStorage.SetValue(AuthorizationContextKeys.Action, "Some Action");
                
                Given<IContextStorage>(contextStorage);
            }

            protected override void Act()
            {
                SystemUnderTest.VerifyAuthorizationContextExists();
            }
            
            [Test]
            public void Should_not_throw_an_AuthorizationContextException()
            {
                ActualException.ShouldBeNull();
            }
        }
    }
}
