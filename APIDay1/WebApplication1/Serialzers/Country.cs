using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WebApplication1.Models
{
    public partial class Country:IXmlSerializable
    {
        public Country() { }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            id = reader.ReadElementContentAsDecimal();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Id", id.ToString());
            writer.WriteElementString("Name",name);
        }
    }
}