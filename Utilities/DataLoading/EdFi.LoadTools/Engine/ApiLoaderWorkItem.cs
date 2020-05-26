// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
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
        private int _level = 0;

        public ApiLoaderWorkItem(string interchangeName, string sourceFileName, XElement xElement, int level)
        {
            InterchangeName = interchangeName;
            SourceFileName = sourceFileName;
            XElement = xElement;
            _level = level;
        }

        public int Level => _level;
        public string ResourceType => XElement.Name.LocalName;

        public string ElementName => XElement.Name.LocalName;

        public byte[] Hash => _hash;

        public string HashString { get; private set; }

        public string InterchangeName { get; }

        public string SourceFileName { get; }

        public string Json => JsonConvert.SerializeXNode(_jElement, Formatting.None, true);

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

        public void AddSubmissionResult(HttpResponseMessage response)
        {
            var tmpResponse = new Response
                              {
                                  IsSuccess = response.IsSuccessStatusCode, StatusCode = response.StatusCode, ErrorMessage = response.ReasonPhrase,
                                  Content = response.Content?.ReadAsStringAsync().Result
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

            public string ErrorMessage { get; set; }

            public bool IsSuccess { get; set; }

            public HttpStatusCode StatusCode { get; set; }
        }
    }
}
