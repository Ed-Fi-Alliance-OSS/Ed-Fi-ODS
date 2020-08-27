// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace EdFi.LoadTools.Engine
{
    public class ApiLoaderWorkItem
    {
        private readonly List<IResponse> _responses = new List<IResponse>();

        private byte[] _hash =
            { };
        private XElement _jElement = new XElement("empty");

        public ApiLoaderWorkItem(string sourceFileName, int lineNumber, XElement xElement, int level)
        {
            SourceFileName = sourceFileName;
            LineNumber = lineNumber;
            XElement = xElement;
            Level = level;
        }

        public string ResourceType => XElement.Name.LocalName;

        public string ElementName => XElement.Name.LocalName;

        public byte[] Hash => _hash;

        public string HashString { get; private set; }

        public string SourceFileName { get; }

        public int LineNumber { get; }

        public int Level { get; }

        public string Json => JsonConvert.SerializeXNode(_jElement, Formatting.None, true);

        public bool IsSuccess => Responses.Any(y => y.IsSuccess);

        public IList<IResponse> Responses => _responses;

        public XElement XElement { get; }

        public string ResourceSchemaName
        {
            get
            {
                var elementName = _jElement.Name.LocalName;
                var index = elementName.IndexOf("_", StringComparison.Ordinal);
                return elementName.Substring(0, index);
            }
        }

        public void SetJsonXElement(XElement xElement)
        {
            _jElement = xElement;
        }

        public void AddSubmissionResult(HttpResponseMessage response, int requestNumber)
        {
            var tmpResponse = new Response
                              {
                                  IsSuccess = response.IsSuccessStatusCode, StatusCode = response.StatusCode, Message = response.ReasonPhrase,
                                  Content = response.Content?.ReadAsStringAsync().Result, RequestNumber = requestNumber
                              };

            _responses.Add(tmpResponse);
        }

        public void SetHash(byte[] hash)
        {
            Array.Resize(ref _hash, hash.Length);
            hash.CopyTo(_hash, 0);
            HashString = BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        private class Response : IResponse
        {
            public string Content { get; set; }

            public string Message { get; set; }

            public bool IsSuccess { get; set; }

            public HttpStatusCode StatusCode { get; set; }

            public int RequestNumber { get; set; }
        }
    }
}
