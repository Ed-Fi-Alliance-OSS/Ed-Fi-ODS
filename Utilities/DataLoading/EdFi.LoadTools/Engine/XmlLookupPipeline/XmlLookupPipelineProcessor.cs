// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    public class XmlLookupPipelineProcessor
    {
        private readonly ILookupPipelineStep[] _lookupPipelineSteps;

        public XmlLookupPipelineProcessor(ILookupPipelineStep[] lookupPipelineSteps)
        {
            _lookupPipelineSteps = lookupPipelineSteps;
        }

        public ITargetBlock<XmlLookupWorkItem> CreateBlock()
        {
            return new ActionBlock<XmlLookupWorkItem>(x => RunPipelineForWorkItem(x));
        }

        public bool RunPipelineForWorkItem(XmlLookupWorkItem item)
        {
            return _lookupPipelineSteps.All(s => s.Process(item).Result);
        }
    }
}
