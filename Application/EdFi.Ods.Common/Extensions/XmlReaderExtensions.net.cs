#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.IO;
using System.Reflection;
using System.Xml;

namespace EdFi.Ods.Common.Extensions
{
    public static class XmlReaderExtensions
    {
        private const long DefaultStreamReaderBufferSize = 1024;

        public static long GetPosition(this XmlReader xr, StreamReader underlyingStreamReader)
        {
            // Get the position of the FileStream
            long fileStreamPos = underlyingStreamReader.BaseStream.Position;

            // Get current XmlReader state
            long xmlReaderBufferLength = GetXmlReaderBufferLength(xr);
            long xmlReaderBufferPos = GetXmlReaderBufferPosition(xr);

            // Get current StreamReader state
            long streamReaderBufferLength = GetStreamReaderBufferLength(underlyingStreamReader);
            int streamReaderBufferPos = GetStreamReaderBufferPos(underlyingStreamReader);
            long preambleSize = GetStreamReaderPreambleSize(underlyingStreamReader);

            // Calculate the actual file position
            long pos = fileStreamPos
                       - (streamReaderBufferLength == DefaultStreamReaderBufferSize
                           ? DefaultStreamReaderBufferSize
                           : 0)
                       - xmlReaderBufferLength
                       + xmlReaderBufferPos + streamReaderBufferPos - preambleSize;

            return pos;
        }

#region Supporting methods

        private static PropertyInfo _xmlReaderBufferSizeProperty;

        private static long GetXmlReaderBufferLength(XmlReader xr)
        {
            if (_xmlReaderBufferSizeProperty == null)
            {
                _xmlReaderBufferSizeProperty = xr.GetType()
                                                 .GetProperty(
                                                      "DtdParserProxy_ParsingBufferLength",
                                                      BindingFlags.Instance | BindingFlags.NonPublic);
            }

            return (int) _xmlReaderBufferSizeProperty.GetValue(xr);
        }

        private static PropertyInfo _xmlReaderBufferPositionProperty;

        private static int GetXmlReaderBufferPosition(XmlReader xr)
        {
            if (_xmlReaderBufferPositionProperty == null)
            {
                _xmlReaderBufferPositionProperty = xr.GetType()
                                                     .GetProperty(
                                                          "DtdParserProxy_CurrentPosition",
                                                          BindingFlags.Instance | BindingFlags.NonPublic);
            }

            return (int) _xmlReaderBufferPositionProperty.GetValue(xr);
        }

        private static PropertyInfo _streamReaderPreambleProperty;

        private static long GetStreamReaderPreambleSize(StreamReader sr)
        {
            if (_streamReaderPreambleProperty == null)
            {
                _streamReaderPreambleProperty = sr.GetType()
                                                  .GetProperty(
                                                       "Preamble_Prop",
                                                       BindingFlags.Instance | BindingFlags.NonPublic);
            }

            return ((byte[]) _streamReaderPreambleProperty.GetValue(sr)).Length;
        }

        private static PropertyInfo _streamReaderByteLenProperty;

        private static long GetStreamReaderBufferLength(StreamReader sr)
        {
            if (_streamReaderByteLenProperty == null)
            {
                _streamReaderByteLenProperty = sr.GetType()
                                                 .GetProperty(
                                                      "ByteLen_Prop",
                                                      BindingFlags.Instance | BindingFlags.NonPublic);
            }

            return (int) _streamReaderByteLenProperty.GetValue(sr);
        }

        private static PropertyInfo _streamReaderBufferPositionProperty;

        private static int GetStreamReaderBufferPos(StreamReader sr)
        {
            if (_streamReaderBufferPositionProperty == null)
            {
                _streamReaderBufferPositionProperty = sr.GetType()
                                                        .GetProperty(
                                                             "CharPos_Prop",
                                                             BindingFlags.Instance | BindingFlags.NonPublic);
            }

            return (int) _streamReaderBufferPositionProperty.GetValue(sr);
        }

#endregion
    }
}
#endif