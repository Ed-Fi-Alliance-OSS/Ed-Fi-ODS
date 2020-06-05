// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models.GraphML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace EdFi.Ods.Api.NetCore.MediaTypeFormatters
{
    public class GraphMLMediaTypeOutputFormatter : TextOutputFormatter
    {
        public GraphMLMediaTypeOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(CustomMediaContentTypes.GraphML));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type) => type == typeof(GraphML);

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var response = context.HttpContext.Response;

            var graphML = context.Object as GraphML;

            if (graphML == null)
            {
                throw new InvalidOperationException($"value is not typeof(Graph)");
            }

            return response.WriteAsync(CreateXml());

            string CreateXml()
            {
                var sb = new StringBuilder();

                sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

                sb.AppendLine(
                    "<graphml xmlns=\"http://graphml.graphdrawing.org/xmlns\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://graphml.graphdrawing.org/xmlns http://graphml.graphdrawing.org/xmlns/1.0/graphml.xsd\">");

                sb.AppendLine($"<graph id=\"{graphML.Id}\" edgedefault=\"directed\">");

                foreach (var node in graphML.Nodes)
                {
                    sb.AppendLine($"<node id=\"{node.Id}\"/>");
                }

                foreach (var edge in graphML.Edges)
                {
                    sb.AppendLine($"<edge source=\"{edge.Source}\" target=\"{edge.Target}\"/>");
                }

                sb.AppendLine("</graph>");
                sb.AppendLine("</graphml>");

                return sb.ToString();
            }
        }
    }
}
