// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Specifications;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Descriptors
{
    [TestFixture]
    public class DescriptorResolverTests
    {
        private IDescriptorDetailsProvider _descriptorDetailsProvider;
        private IDescriptorMapsProvider _descriptorMapsProvider;
        private DescriptorResolver _resolver;

        [SetUp]
        public void SetUp()
        {
            _descriptorDetailsProvider = A.Fake<IDescriptorDetailsProvider>();
            _descriptorMapsProvider = A.Fake<IDescriptorMapsProvider>();
            _resolver = new DescriptorResolver(_descriptorMapsProvider, _descriptorDetailsProvider);
        }

        [Test]
        public void GetDescriptorId_Should_return_0_When_descriptor_uri_is_null()
        {
            // Act
            var result = _resolver.GetDescriptorId("TestDescriptor", null);
            
            result.ShouldBe(0);
        }

        [Test]
        public void GetUri_Should_return_null_When_descriptorId_is_0()
        {
            // Act
            var result = _resolver.GetUri("TestDescriptor", 0);
            
            result.ShouldBe(null);
        }

        [Test]
        public void GetDescriptorId_Should_return_0_When_descriptor_does_not_exist()
        {
            // Arrange
            var suppliedNamespace = "uri://example.org/test";
            var suppliedCodeValue = "code-value";
            var suppliedUrl = DescriptorHelper.GetUri(suppliedNamespace, suppliedCodeValue);

            var descriptorIdByUri = new ConcurrentDictionary<string, int>
            {
                [suppliedUrl] = 1
            };

            var uriByDescriptorId = new ConcurrentDictionary<int, string>
            {
                [1] = suppliedUrl
            };

            var descriptorMaps = new DescriptorMaps(descriptorIdByUri, uriByDescriptorId);
            A.CallTo(() => _descriptorMapsProvider.GetMaps()).Returns(descriptorMaps);

            var attemptedDescriptorUri = DescriptorHelper.GetUri(suppliedNamespace, "Non-existing-value");
            
            A.CallTo(() => _descriptorDetailsProvider.GetDescriptorDetails("TestDescriptor", attemptedDescriptorUri))
                .Returns(null);

            // Act
            var result = _resolver.GetDescriptorId("TestDescriptor", attemptedDescriptorUri);

            // Assert
            result.ShouldSatisfyAllConditions(

                // Correct value returned from the newly discovered details
                () => result.ShouldBe(default),

                // Non-existing descriptor should not be added to existing dictionaries
                () => descriptorIdByUri.ShouldNotContainKey(attemptedDescriptorUri),
                () => uriByDescriptorId.ShouldNotContainKey(default),
                
                // Must have tried to load descriptor details
                () => A.CallTo(() => _descriptorDetailsProvider.GetDescriptorDetails("TestDescriptor", attemptedDescriptorUri))
                    .MustHaveHappened());
        }

        [Test]
        public void GetDescriptorId_Should_return_DescriptorId_using_only_the_descriptor_map_When_descriptor_is_already_in_descriptor_maps()
        {
            // Arrange
            var suppliedNamespace = "uri://example.org/test";
            var suppliedCodeValue = "code-value";
            var suppliedUrl = DescriptorHelper.GetUri(suppliedNamespace, suppliedCodeValue);

            var descriptorIdByUri = new ConcurrentDictionary<string, int>
            {
                [suppliedUrl] = 1
            };

            var uriByDescriptorId = new ConcurrentDictionary<int, string>
            {
                [1] = suppliedUrl
            };

            var descriptorMaps = new DescriptorMaps(descriptorIdByUri, uriByDescriptorId);
            A.CallTo(() => _descriptorMapsProvider.GetMaps()).Returns(descriptorMaps);

            // Act
            var result = _resolver.GetDescriptorId("TestDescriptor", suppliedUrl);

            // Assert
            result.ShouldSatisfyAllConditions(

                // Correct value returned from the newly discovered details
                () => result.ShouldBe(1),

                // Descriptor details should not be explicitly retrieved
                () => A.CallTo(() => _descriptorDetailsProvider.GetDescriptorDetails(A<string>._, A<string>._))
                    .MustNotHaveHappened());
        }
        
        [Test]
        public void GetDescriptorId_Should_return_DescriptorId_and_add_entry_to_map_When_descriptor_is_not_already_in_descriptor_maps()
        {
            // Arrange
            var suppliedNamespace = "uri://example.org/test";
            var suppliedCodeValue = "code-value";
            var suppliedUrl = DescriptorHelper.GetUri(suppliedNamespace, suppliedCodeValue);

            var descriptorIdByUri = new ConcurrentDictionary<string, int>
            {
                [suppliedUrl] = 1
            };

            var uriByDescriptorId = new ConcurrentDictionary<int, string>
            {
                [1] = suppliedUrl
            };

            var descriptorMaps = new DescriptorMaps(descriptorIdByUri, uriByDescriptorId);
            A.CallTo(() => _descriptorMapsProvider.GetMaps()).Returns(descriptorMaps);

            var newDescriptorDetails = new DescriptorDetails
            {
                DescriptorId = 2,
                Namespace = suppliedNamespace,
                CodeValue = "NewValue",
            };

            string suppliedNewDescriptorUri = DescriptorHelper.GetUri(
                newDescriptorDetails.Namespace,
                newDescriptorDetails.CodeValue);

            A.CallTo(() => _descriptorDetailsProvider.GetDescriptorDetails("TestDescriptor", suppliedNewDescriptorUri))
                .Returns(newDescriptorDetails);

            // Act
            var result = _resolver.GetDescriptorId("TestDescriptor", suppliedNewDescriptorUri);

            // Assert
            result.ShouldSatisfyAllConditions(
                // Correct value returned from the newly discovered details
                () => result.ShouldBe(newDescriptorDetails.DescriptorId),
                // Newly discovered entry added to existing dictionaries
                () => descriptorIdByUri.ShouldContainKey(suppliedNewDescriptorUri),
                () => uriByDescriptorId.ShouldContainKey(2));
        }
        
        
        [Test]
        public void GetUri_Should_return_null_When_descriptor_does_not_exist()
        {
            // Arrange
            var suppliedNamespace = "uri://example.org/test";
            var suppliedCodeValue = "code-value";
            var suppliedUrl = DescriptorHelper.GetUri(suppliedNamespace, suppliedCodeValue);

            var descriptorIdByUri = new ConcurrentDictionary<string, int>
            {
                [suppliedUrl] = 1
            };

            var uriByDescriptorId = new ConcurrentDictionary<int, string>
            {
                [1] = suppliedUrl
            };

            var descriptorMaps = new DescriptorMaps(descriptorIdByUri, uriByDescriptorId);
            A.CallTo(() => _descriptorMapsProvider.GetMaps()).Returns(descriptorMaps);

            var attemptedDescriptorId = 3;
            
            A.CallTo(() => _descriptorDetailsProvider.GetDescriptorDetails("TestDescriptor", attemptedDescriptorId))
                .Returns(null);

            // Act
            var result = _resolver.GetUri("TestDescriptor", attemptedDescriptorId);

            // Assert
            result.ShouldSatisfyAllConditions(

                // Default value (null string) returned
                () => result.ShouldBe(default),

                // Non-existing descriptor should not be added to existing dictionaries
                () => uriByDescriptorId.ShouldNotContainKey(attemptedDescriptorId),

                // Must have tried to load descriptor details
                () => A.CallTo(() => _descriptorDetailsProvider.GetDescriptorDetails("TestDescriptor", attemptedDescriptorId))
                    .MustHaveHappened());
        }
        
        [Test]
        public void GetUri_Should_return_Uri_using_only_the_descriptor_map_When_descriptor_is_already_in_descriptor_maps()
        {
            // Arrange
            var suppliedNamespace = "uri://example.org/test";
            var suppliedCodeValue = "code-value";
            var suppliedUrl = DescriptorHelper.GetUri(suppliedNamespace, suppliedCodeValue);

            var descriptorIdByUri = new ConcurrentDictionary<string, int>
            {
                [suppliedUrl] = 1
            };

            var uriByDescriptorId = new ConcurrentDictionary<int, string>
            {
                [1] = suppliedUrl
            };

            var descriptorMaps = new DescriptorMaps(descriptorIdByUri, uriByDescriptorId);
            A.CallTo(() => _descriptorMapsProvider.GetMaps()).Returns(descriptorMaps);

            // Act
            var result = _resolver.GetUri("TestDescriptor", 1);

            // Assert
            result.ShouldSatisfyAllConditions(

                // Correct value returned from the newly discovered details
                () => result.ShouldBe(suppliedUrl),

                // Descriptor details should not be explicitly retrieved
                () => A.CallTo(() => _descriptorDetailsProvider.GetDescriptorDetails(A<string>._, A<int>._))
                    .MustNotHaveHappened());
        }
        
        [Test]
        public void GetUri_Should_return_Uri_and_add_entry_to_map_When_descriptor_is_not_already_in_descriptor_maps()
        {
            // Arrange
            var suppliedNamespace = "uri://example.org/test";
            var suppliedCodeValue = "valid-uri";
            var suppliedUrl = DescriptorHelper.GetUri(suppliedNamespace, suppliedCodeValue);

            var descriptorIdByUri = new ConcurrentDictionary<string, int>
            {
                [suppliedUrl] = 1
            };

            var uriByDescriptorId = new ConcurrentDictionary<int, string>
            {
                [1] = suppliedUrl
            };

            var descriptorMaps = new DescriptorMaps(descriptorIdByUri, uriByDescriptorId);
            A.CallTo(() => _descriptorMapsProvider.GetMaps()).Returns(descriptorMaps);

            var newDescriptorDetails = new DescriptorDetails
            {
                DescriptorId = 2,
                Namespace = suppliedNamespace,
                CodeValue = "NewValue",
            };

            A.CallTo(() => _descriptorDetailsProvider.GetDescriptorDetails("TestDescriptor", 2))
                .Returns(newDescriptorDetails);

            // Act
            var result = _resolver.GetUri("TestDescriptor", 2);

            // Assert
            result.ShouldSatisfyAllConditions(
                // Correct value returned from the newly discovered details
                () => result.ShouldBe(newDescriptorDetails.Uri),
                // Newly discovered entry added to existing dictionaries
                () => descriptorIdByUri.ShouldContainKey(DescriptorHelper.GetUri(newDescriptorDetails.Namespace, newDescriptorDetails.CodeValue)),
                () => uriByDescriptorId.ShouldContainKey(2));
        }
    }
}