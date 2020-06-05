// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Api.NetCore.ModelBinders
{
    public class ResourceAsJsonObjectModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var model = (ResourceAsJsonObject<Guid>) Activator.CreateInstance(bindingContext.ModelType);
            bindingContext.Model = model;

            using var reader = new StreamReader(bindingContext.HttpContext.Request.Body);

            await reader.ReadToEndAsync()
                .ContinueWith(json => model.Data = JObject.Parse(json.Result))
                .ConfigureAwait(false);
        }
    }
}
