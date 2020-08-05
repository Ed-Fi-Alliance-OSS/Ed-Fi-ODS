// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Services.Binders
{
    public class IdsModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            object idsValue;

            // Quit with empty model if the route's id wasn't provided
            if (!actionContext.ControllerContext.RouteData.Values.TryGetValue("id", out idsValue))
            {
                return false;
            }

            var model = (IHasIdentifiers<Guid>) Activator.CreateInstance(bindingContext.ModelType);
            bindingContext.Model = model;

            // Convert object to string for parsing
            string idsText = idsValue.ToString();

            // Assign Guids from text provided
            model.Ids =
                (from t in idsText.Split(
                     new[]
                     {
                         ','
                     },
                     StringSplitOptions.RemoveEmptyEntries)
                 select new Guid(t))
               .ToList();

            return true;
        }
    }
}
