// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.IO;
using EdFi.Ods.Common.Utils.Resources;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Utils.Resources
{
    public class EmbeddedResourceReaderTests
    {
        [TestFixture]
        public class When_resource_exists_and_we_retrieve_the_string
        {
            [Test]
            public void Should_read_entire_resource_content()
            {
                var result = EmbeddedResourceReader.GetResourceString<EmbeddedResourceReaderTests>("IAmAResource.txt");
                result.ShouldBe("I have some content, I promise." + Environment.NewLine + "I am a second line.");
            }
        }

        [TestFixture]
        public class When_resource_exists_and_we_retrieve_the_stream
        {
            [Test]
            public void Should_read_entire_resource_content()
            {
                using (var stream = EmbeddedResourceReader.GetResourceStream<EmbeddedResourceReaderTests>("IAmAResource.txt"))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var result = reader.ReadToEnd();
                        result.ShouldBe("I have some content, I promise." + Environment.NewLine + "I am a second line.");
                    }
                }
            }
        }
    }
}
