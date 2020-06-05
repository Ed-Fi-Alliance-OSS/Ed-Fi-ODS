// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;

namespace EdFi.Ods.CodeGen.Generators
{
    // TODO: remove when NET48 is removed from the ODS/API
    public class LegacyControllers : ControllersBase
    {
        protected override void Configure()
        {
            BaseNamespaceName = Namespaces.Api.Controllers;
            RequestBaseNamespaceName = Namespaces.Requests.RelativeNamespace;
        }
    }
}
