// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Dynamic;
using EdFi.LoadTools.ApiClient;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class UtilitiesTests
    {
        private readonly dynamic _foo = new ExpandoObject();
        private string _json;

        [OneTimeSetUp]
        public void Setup()
        {
            _foo.Bar = new ExpandoObject();
            _foo.Bar.FirstName = "Test";
            _foo.Bar.LastName = "User";
            _foo.Bar.Spaces = "This string has spaces";
            _foo.Bar.Birthdate = new DateTime(2000, 11, 28);
            _json = Convert.ToString(JObject.FromObject(_foo));
            Console.WriteLine(_json);
        }

        [Test]
        public void ShouldConvertJsonToQueryString()
        {
            var queryStr = Utilities.ConvertJsonToQueryString(_json);
            Console.WriteLine(queryStr);
            Assert.IsTrue(queryStr.Contains("FirstName=Test"));
            Assert.IsTrue(queryStr.Contains("LastName=User"));
            Assert.IsTrue(queryStr.Contains("Spaces=This%20string%20has%20spaces"));
            Assert.IsTrue(queryStr.Contains("Birthdate=11%2F28%2F2000"));
        }
    }
}
