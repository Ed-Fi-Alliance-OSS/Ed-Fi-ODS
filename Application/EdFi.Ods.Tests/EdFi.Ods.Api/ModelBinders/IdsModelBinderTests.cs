// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using EdFi.Ods.Api.ModelBinders;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using EdFi.Ods.Api.Common.Models.Requests.Students.EdFi;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi
{
    [TestFixture]
    public class IdsModelBinderTests
    {
        [Test]
        public void Should_Ignore_Trailing_Commas_In_Input_Guid_String()
        {
            var guidString = string.Format("{0},{1},", Guid.NewGuid(), Guid.NewGuid());

            var bindingContext = A.Fake<ModelBindingContext>();

            RouteValueDictionary keyValuePairs = new RouteValueDictionary();
            keyValuePairs.Add("id", guidString);
            bindingContext.ActionContext.RouteData = new RouteData(keyValuePairs);

            A.CallTo(() => bindingContext.ModelType).Returns(typeof(StudentGetByIds));
            var sut = new IdsModelBinder();
            Task result = sut.BindModelAsync(bindingContext);
            result.IsCompleted.ShouldBeTrue();
        }

        [Test]
        public void Should_Return_False_If_Id_Value_not_Set_in_Route()
        {
            var bindingContext = A.Fake<ModelBindingContext>();

            RouteValueDictionary keyValuePairs = new RouteValueDictionary();
            bindingContext.ActionContext.RouteData = new RouteData(keyValuePairs);
            var sut = new IdsModelBinder();
            Task result = sut.BindModelAsync(bindingContext);
            result.IsCompleted.ShouldBeTrue();
        }
    }
}
#endif