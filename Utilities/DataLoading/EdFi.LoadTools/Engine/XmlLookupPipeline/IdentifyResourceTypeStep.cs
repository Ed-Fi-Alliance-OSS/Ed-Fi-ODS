// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EdFi.LoadTools.Common;
using EdFi.Ods.Common.Inflection;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    public class IdentifyResourceTypeStep : ILookupPipelineStep
    {
        private readonly Regex _lookupRegex = new Regex(Constants.LookupRegex);

        public Task<bool> Process(XmlLookupWorkItem item)
        {
            var match = _lookupRegex.Match(item.LookupXElement.Name.LocalName);

            if (!match.Success)
            {
                return Task.FromResult(false);
            }

            item.ResourceName = match.Groups["TypeName"].Value;
            item.IdentityName = $"{item.ResourceName}Identity";
            item.LookupName = $"{item.ResourceName}Lookup";
            item.JsonResourceName = Inflector.MakePlural(Inflector.MakeInitialLowerCase(item.ResourceName));
            item.JsonModelName = Inflector.MakeInitialLowerCase(item.ResourceName);
            return Task.FromResult(true);
        }
    }
}
