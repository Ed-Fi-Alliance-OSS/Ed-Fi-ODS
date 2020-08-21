// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using EdFi.Ods.Api.Context;
using EdFi.Ods.Common.Context;
using FakeItEasy;
using FakeItEasy.Sdk;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Tests.EdFi.Common.Context
{
    [TestFixture]
    public class HttpContextStorageTests
    {
        protected class TestObject
        {
            public string Text { get; set; }
        }

        [Test]
        public void Should_Get_Generic_Value_in_HttpContext()
        {
            var key = "testKey";
            var expected = "Some Text";
            var testObject = new TestObject
            {
                Text = expected
            };

            var httpContextAccessor = A.Fake<IHttpContextAccessor>();
            var contextStorage = A.Fake<IContextStorage>();

            httpContextAccessor.HttpContext.Items = new Dictionary<object, object> {{key, testObject}};

            var httpContextStorage = new HttpContextStorage(contextStorage, httpContextAccessor);
            httpContextStorage.SetValue(key, testObject);

            var actual = httpContextStorage.GetValue<TestObject>(key);
            actual.Text.ShouldBe(expected);
        }

        [Test]
        public void Should_SetValue_in_HttpContext()
        {
            var key = "testKey";
            var expected = "Some Text";
            var testObject = new TestObject
            {
                Text = expected
            };

            var httpContextAccessor = A.Fake<IHttpContextAccessor>();
            var contextStorage = A.Fake<IContextStorage>();

            httpContextAccessor.HttpContext.Items = new Dictionary<object, object> {{key, testObject}};

            var httpContextStorage = new HttpContextStorage(contextStorage, httpContextAccessor);
            httpContextStorage.SetValue(key, testObject);

            var actual = httpContextStorage.GetValue<TestObject>(key);
            actual.Text.ShouldBe(expected);
        }
    }
}
#endif
