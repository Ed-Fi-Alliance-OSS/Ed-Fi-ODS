// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Linq;

namespace EdFi.Ods.CodeGen.Extensions
{
    public static class PathHelper
    {
        public static string GetProjectNameFromProjectPath(string projectPath)
        {
            //Split project path and obtain final segment. (Project Name) 
            //eg EdFi.Ods.Standard or EdFi.Ods.Extensions.TalentMgmt)
            return
                projectPath.TrimEnd(Path.DirectorySeparatorChar)
                    .Split(Path.DirectorySeparatorChar)
                    .Last();
        }
    }
}
