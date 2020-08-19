// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.XmlLookupPipeline;

namespace EdFi.LoadTools
{
    public class XmlLookupApplication
    {
        private readonly IXmlPairsFactory _pairsFactory;
        private readonly XmlLookupPipelineProcessor _xmlLookupPipelineProcessor;
        private readonly XmlLookupToResourceProcessor _xmlLookupToResourceProcessor;
        private readonly XmlToWorkItemsProcessor _xmlToWorkItemsProcessor;

        public XmlLookupApplication(
            IXmlPairsFactory pairsFactory,
            XmlToWorkItemsProcessor xmlToWorkItemsProcessor,
            XmlLookupPipelineProcessor xmlLookupPipelineProcessor,
            XmlLookupToResourceProcessor xmlLookupToResourceProcessor)
        {
            _pairsFactory = pairsFactory;
            _xmlToWorkItemsProcessor = xmlToWorkItemsProcessor;
            _xmlLookupPipelineProcessor = xmlLookupPipelineProcessor;
            _xmlLookupToResourceProcessor = xmlLookupToResourceProcessor;
        }

        public async Task<int> Run()
        {
            // find and resolve lookups to references
            var resolveLookupsPipeline = ResolveLookupsPipeline();

            foreach (var reader in _pairsFactory.GetSources())
            {
                await resolveLookupsPipeline.StartBlock.SendAsync(reader).ConfigureAwait(false);
            }

            resolveLookupsPipeline.StartBlock.Complete();
            await resolveLookupsPipeline.Completion.ConfigureAwait(false);

            // write new xml file with references
            var writeUpdatedXmlPipeline = WriteUpdatedXmlPipeline();

            foreach (var streamPair in _pairsFactory.GetIoPairs())
            {
                await writeUpdatedXmlPipeline.StartBlock.SendAsync(streamPair).ConfigureAwait(false);
            }

            writeUpdatedXmlPipeline.StartBlock.Complete();
            await writeUpdatedXmlPipeline.Completion.ConfigureAwait(false);

            return 0;
        }

        private DataFlowPipeline<XmlReader> ResolveLookupsPipeline()
        {
            var lookupBlock = _xmlToWorkItemsProcessor.CreateBlock();
            var lookupBuffer = new BufferBlock<XmlLookupWorkItem>();
            var lookupPipeline = _xmlLookupPipelineProcessor.CreateBlock();

            lookupBlock.LinkTo(
                lookupBuffer, new DataflowLinkOptions
                              {
                                  PropagateCompletion = true
                              });

            lookupBuffer.LinkTo(
                lookupPipeline, new DataflowLinkOptions
                                {
                                    PropagateCompletion = true
                                });

            return new DataFlowPipeline<XmlReader>(lookupBlock, lookupPipeline.Completion);
        }

        private DataFlowPipeline<XmlIoPair> WriteUpdatedXmlPipeline()
        {
            var copyBuffer = new BufferBlock<XmlIoPair>();
            var copyXmlBlock = _xmlLookupToResourceProcessor.CreateBlock();

            copyBuffer.LinkTo(
                copyXmlBlock, new DataflowLinkOptions
                              {
                                  PropagateCompletion = true
                              });

            return new DataFlowPipeline<XmlIoPair>(copyBuffer, copyXmlBlock.Completion);
        }
    }
}
