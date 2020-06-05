// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.Metadata.Providers;
using System.Web.Http.ModelBinding;
using System.Web.Http.Routing;
using EdFi.Ods.Api.Common.Models.Requests.Students.EdFi;
using EdFi.Ods.Api.Services.Binders;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi
{
    [TestFixture]
    public class IdsModelBinderTests
    {
        [Test]
        public void Should_Ignore_Trailing_Commas_In_Input_Guid_String()
        {
            var guidString = string.Format("{0},{1},", Guid.NewGuid(), Guid.NewGuid());
            var controllerContext = new HttpControllerContext();

            var routeDictionary = new HttpRouteValueDictionary(
                new Dictionary<string, object>
                {
                    {
                        "id", guidString
                    }
                });

            controllerContext.RouteData = new HttpRouteData(new HttpRoute(), routeDictionary);

            var actionContext = new HttpActionContext
                                {
                                    ControllerContext = controllerContext
                                };

            var bindingContext = new ModelBindingContext
                                 {
                                     ModelMetadata = new ModelMetadata(
                                         new EmptyModelMetadataProvider(),
                                         typeof(object),
                                         () => new object(),
                                         typeof(StudentGetByIds),
                                         "foo")
                                 };

            var sut = new IdsModelBinder();
            var result = sut.BindModel(actionContext, bindingContext);
            result.ShouldBeTrue();
        }

        [Test]
        public void Should_Return_False_If_Id_Value_not_Set_in_Route()
        {
            var controllerContext = new HttpControllerContext();
            var routeDictionary = new HttpRouteValueDictionary(new Dictionary<string, object>());
            controllerContext.RouteData = new HttpRouteData(new HttpRoute(), routeDictionary);

            var actionContext = new HttpActionContext
                                {
                                    ControllerContext = controllerContext
                                };

            var bindingContext = new ModelBindingContext
                                 {
                                     ModelMetadata = new ModelMetadata(
                                         new EmptyModelMetadataProvider(),
                                         typeof(object),
                                         () => new object(),
                                         typeof(StudentGetByIds),
                                         "foo")
                                 };

            var sut = new IdsModelBinder();
            var result = sut.BindModel(actionContext, bindingContext);
            result.ShouldBeFalse();
        }
    }
}
