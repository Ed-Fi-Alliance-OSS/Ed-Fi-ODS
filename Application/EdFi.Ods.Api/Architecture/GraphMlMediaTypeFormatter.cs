// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models.GraphML;

namespace EdFi.Ods.Api.Architecture
{
    public class GraphMLMediaTypeFormatter : XmlMediaTypeFormatter
    {
        public GraphMLMediaTypeFormatter()
        {
            SupportedMediaTypes.Clear();
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(CustomMediaContentTypes.GraphML));

            MediaTypeMappings.Add(
                new RequestHeaderMapping(
                    "Accept", CustomMediaContentTypes.GraphML, StringComparison.InvariantCultureIgnoreCase, false, CustomMediaContentTypes.GraphML));

            DefaultMediaType.MediaType = CustomMediaContentTypes.GraphML;
        }

        public override bool CanReadType(Type type) => false;

        public override bool CanWriteType(Type type) => type == typeof(GraphML);

        private string CreateXml(GraphML graphML)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

            sb.AppendLine(
                "<graphml xmlns=\"http://graphml.graphdrawing.org/xmlns\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://graphml.graphdrawing.org/xmlns http://graphml.graphdrawing.org/xmlns/1.0/graphml.xsd\">");

            sb.AppendLine($"<graph id=\"{graphML.Id}\" edgedefault=\"directed\">");

            foreach (GraphMLNode node in graphML.Nodes)
            {
                sb.AppendLine($"<node id=\"{node.Id}\"/>");
            }

            foreach (GraphMLEdge edge in graphML.Edges)
            {
                sb.AppendLine($"<edge source=\"{edge.Source}\" target=\"{edge.Target}\"/>");
            }

            sb.AppendLine("</graph>");
            sb.AppendLine("</graphml>");

            return sb.ToString();
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext,
                                                CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var graph = value as GraphML;

            if (graph == null)
            {
                throw new InvalidOperationException($"value is not typeof(Graph)");
            }

            try
            {
                var xmlWriterSettings = new XmlWriterSettings
                                        {
                                            Async = true, Encoding = Encoding.UTF8, Indent = true
                                        };

                var t = new Task(
                    () =>
                    {
                        var doc = new XmlDocument();
                        doc.LoadXml(CreateXml(graph));

                        using (var xmlWriter = XmlWriter.Create(writeStream, xmlWriterSettings))
                        {
                            doc.WriteTo(xmlWriter);
                        }
                    });

                t.Start();
                t.Wait(cancellationToken);

                return t;
            }
            catch (Exception)
            {
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext, cancellationToken);
            }
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
            => WriteToStreamAsync(type, value, writeStream, content, transportContext, new CancellationToken());
    }
}
