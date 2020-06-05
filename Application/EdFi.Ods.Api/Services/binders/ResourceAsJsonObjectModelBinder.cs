// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using EdFi.Ods.Api.Common.Models;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Api.Services.Binders
{
    public class ResourceAsJsonObjectModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var model = (ResourceAsJsonObject<Guid>) Activator.CreateInstance(bindingContext.ModelType);
            bindingContext.Model = model;

            // Deserialize the JSON body, synchronously
            actionContext.ControllerContext.Request.Content.ReadAsStringAsync()
                         .ContinueWith(
                              json => model.Data = JObject.Parse(json.Result),
                              TaskContinuationOptions.ExecuteSynchronously)
                         .Wait();

            return true;
        }
    }
}
