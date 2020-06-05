// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EdFi.Ods.Api.NetCore.ModelBinders
{
    public class IdsModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // Quit with empty model if the route's id wasn't provided
            if (!bindingContext.ActionContext.RouteData.Values.TryGetValue("id", out object idsValue))
            {
                return Task.CompletedTask;
            }

            var model = (IHasIdentifiers<Guid>) Activator.CreateInstance(bindingContext.ModelType);
            bindingContext.Model = model;

            // Convert object to string for parsing
            string idsText = idsValue.ToString();

            // Assign Guids from text provided
            model.Ids = idsText
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => new Guid(t))
                .ToList();

            return Task.CompletedTask;
        }
    }
}
