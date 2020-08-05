// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EdFi.Ods.Common.Expando
{
    /// <summary>
    /// Creates a serializable string/object dictionary that is XML serializable
    /// Encodes keys as element names and values as simple values with a type
    /// attribute that contains an XML type name. Complex names encode the type 
    /// name with type='___namespace.classname' format followed by a standard xml
    /// serialized format. The latter serialization can be slow so it's not recommended
    /// to pass complex types if performance is critical.
    /// </summary>
    [XmlRoot("properties")]
    public class PropertyBag : PropertyBag<object>
    {
        /// <summary>
        /// Creates an instance of a propertybag from an Xml string
        /// </summary>
        /// <param name="xml">Serialize</param>
        /// <returns></returns>
        public new static PropertyBag CreateFromXml(string xml)
        {
            var bag = new PropertyBag();
            bag.FromXml(xml);
            return bag;
        }
    }

    /// <summary>
    /// Creates a serializable string for generic types that is XML serializable.
    /// 
    /// Encodes keys as element names and values as simple values with a type
    /// attribute that contains an XML type name. Complex names encode the type 
    /// name with type='___namespace.classname' format followed by a standard xml
    /// serialized format. The latter serialization can be slow so it's not recommended
    /// to pass complex types if performance is critical.
    /// </summary>
    /// <typeparam name="TValue">Must be a reference type. For value types use type object</typeparam>
    [XmlRoot("properties")]
    public class PropertyBag<TValue> : Dictionary<string, TValue>, IXmlSerializable
    {
        /// <summary>
        /// Not implemented - this means no schema information is passed
        /// so this won't work with ASMX/WCF services.
        /// </summary>
        /// <returns></returns>       
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Serializes the dictionary to XML. Keys are 
        /// serialized to element names and values as 
        /// element values. An xml type attribute is embedded
        /// for each serialized element - a .NET type
        /// element is embedded for each complex type and
        /// prefixed with three underscores.
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            foreach (string key in Keys)
            {
                TValue value = this[key];

                Type type = null;

                if (value != null)
                {
                    type = value.GetType();
                }

                writer.WriteStartElement("item");

                writer.WriteStartElement("key");
                writer.WriteString(key);
                writer.WriteEndElement();

                writer.WriteStartElement("value");
                string xmlType = Utilities.MapTypeToXmlType(type);
                bool isCustom = false;

                // Type information attribute if not string
                if (value == null)
                {
                    writer.WriteAttributeString("type", "nil");
                }
                else if (!string.IsNullOrEmpty(xmlType))
                {
                    if (xmlType != "string")
                    {
                        writer.WriteStartAttribute("type");
                        writer.WriteString(xmlType);
                        writer.WriteEndAttribute();
                    }
                }
                else
                {
                    isCustom = true;

                    xmlType = "___" + value.GetType()
                                           .FullName;

                    writer.WriteStartAttribute("type");
                    writer.WriteString(xmlType);
                    writer.WriteEndAttribute();
                }

                // Serialize simple types with WriteValue
                if (!isCustom)
                {
                    if (value != null)
                    {
                        writer.WriteValue(value);
                    }
                }
                else
                {
                    // Complex types require custom XmlSerializer
                    XmlSerializer ser = new XmlSerializer(value.GetType());
                    ser.Serialize(writer, value);
                }

                writer.WriteEndElement(); // value

                writer.WriteEndElement(); // item
            }
        }

        /// <summary>
        /// Reads the custom serialized format
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            Clear();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "key")
                {
                    string xmlType = null;
                    string name = reader.ReadElementContentAsString();

                    // item element
                    reader.ReadToNextSibling("value");

                    if (reader.MoveToNextAttribute())
                    {
                        xmlType = reader.Value;
                    }

                    if (string.IsNullOrEmpty(xmlType))
                    {
                        xmlType = "string";
                    }

                    reader.MoveToContent();

                    TValue value;
                    string strval = string.Empty;

                    if (xmlType == "nil")
                    {
                        value = default(TValue); // null
                    }

                    // .NET types that don't map to XML we have to manually
                    // deserialize
                    else if (xmlType.StartsWith("___"))
                    {
                        // skip ahead to serialized value element                                                
                        while (reader.Read() && reader.NodeType != XmlNodeType.Element) { }

                        Type type = Utilities.GetTypeFromName(xmlType.Substring(3));
                        XmlSerializer ser = new XmlSerializer(type);
                        value = (TValue) ser.Deserialize(reader);
                    }
                    else
                    {
                        value = (TValue) reader.ReadElementContentAs(Utilities.MapXmlTypeToType(xmlType), null);
                    }

                    Add(name, value);
                }
            }
        }

        /// <summary>
        /// Serializes this dictionary to an XML string
        /// </summary>
        /// <returns>XML String or Null if it fails</returns>
        public string ToXml()
        {
            string xml = null;
            SerializationUtils.SerializeObject(this, out xml);
            return xml;
        }

        /// <summary>
        /// Deserializes from an XML string
        /// </summary>
        /// <param name="xml"></param>
        /// <returns>true or false</returns>
        public bool FromXml(string xml)
        {
            Clear();

            // if xml string is empty we return an empty dictionary                        
            if (string.IsNullOrEmpty(xml))
            {
                return true;
            }

            var result = SerializationUtils.DeSerializeObject(
                xml,
                GetType()) as PropertyBag<TValue>;

            if (result != null)
            {
                foreach (var item in result)
                {
                    Add(item.Key, item.Value);
                }
            }
            else

                // null is a failure
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates an instance of a propertybag from an Xml string
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static PropertyBag<TValue> CreateFromXml(string xml)
        {
            var bag = new PropertyBag<TValue>();
            bag.FromXml(xml);
            return bag;
        }
    }
}
