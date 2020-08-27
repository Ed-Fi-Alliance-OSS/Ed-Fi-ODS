// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Xml.Schema;
using log4net;

namespace EdFi.LoadTools.Engine.Factories
{
    public class SchemaSetFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SchemaSetFactory).Name);

        private readonly XsdStreamsRetriever _streamsRetriever;

        public SchemaSetFactory(XsdStreamsRetriever streamsRetriever)
        {
            _streamsRetriever = streamsRetriever;
        }

        public XmlSchemaSet GetSchemaSet()
        {
            var streams = _streamsRetriever.GetStreams();
            var set = new XmlSchemaSet();
            var schemas = streams.Select(x => XmlSchema.Read(x, (s, e) => { Log.Error(e); }));

            foreach (var schema in schemas)
            {
                set.Add(schema);
            }

            set.Compile();
            return set;
        }
    }
}
