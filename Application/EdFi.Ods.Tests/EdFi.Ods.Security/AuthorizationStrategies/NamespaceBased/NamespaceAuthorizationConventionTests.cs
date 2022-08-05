// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased;

[TestFixture]
public class NamespaceAuthorizationConventionTests
{
    [Test]
    public void When_getting_namespace_property_from_a_resource_with_no_Namespace_related_properties()
    {
        var actualException = Should.Throw<Exception>(
            () => NamespaceAuthorizationConvention.GetNamespacePropertyName(
                "abc.def",
                new[]
                {
                    "Hello",
                    "World"
                }));

        actualException.Message.ShouldBe(
            "There is no Namespace-based property in the 'abc.def' resource to use for Namespace-based authorization.");
    }

    [Test]
    public void When_getting_namespace_property_from_a_resource_with_just_a_Namespace_property()
    {
        string actualName = NamespaceAuthorizationConvention.GetNamespacePropertyName(
            "abc.def",
            new[]
            {
                "Hello",
                "Namespace",
                "World"
            });

        actualName.ShouldBe("Namespace");
    }
    
    [Test]
    public void When_getting_namespace_property_from_a_resource_with_a_Namespace_property_and_multiple_Namespace_suffixed_properties()
    {
        string actualName = NamespaceAuthorizationConvention.GetNamespacePropertyName(
            "abc.def",
            new[]
            {
                "Hello",
                "Namespace",
                "World",
                "AnotherNamespace",
                "YetAnotherNamespace",
            });

        actualName.ShouldBe("Namespace");
    }

    [Test]
    public void When_getting_namespace_property_from_a_resource_with_no_Namespace_property_and_one_Namespace_suffixed_properties()
    {
        string actualName = NamespaceAuthorizationConvention.GetNamespacePropertyName(
            "abc.def",
            new[]
            {
                "Hello",
                "AnotherNamespace",
                "World",
            });
        
        actualName.ShouldBe("AnotherNamespace");
    }
    
    [Test]
    public void When_getting_namespace_property_from_a_resource_with_no_Namespace_property_and_multiple_Namespace_suffixed_properties()
    {
        var actualException = Should.Throw<Exception>(() => NamespaceAuthorizationConvention.GetNamespacePropertyName(
            "abc.def",
            new[]
            {
                "Hello",
                "AnotherNamespace",
                "YetAnotherNamespace",
                "World",
            }));
        
        actualException.Message.ShouldBe("Unable to definitively identify a Namespace-based property in the 'abc.def' resource to use for Namespace-based authorization.");
    }
}
