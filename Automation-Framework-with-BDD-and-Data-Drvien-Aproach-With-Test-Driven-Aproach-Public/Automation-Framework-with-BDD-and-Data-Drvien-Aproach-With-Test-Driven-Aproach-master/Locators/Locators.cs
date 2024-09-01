using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dependency_Verification.Locators
{

    [XmlRoot(ElementName = "Element")]
    public class Element
    {
        [XmlAttribute(AttributeName = "keyword")]
        public string Keyword { get; set; }
        [XmlAttribute(AttributeName = "locator")]
        public string Locator { get; set; }
    }

    [XmlRoot(ElementName = "Module")]
    public class Module
    {
        [XmlElement(ElementName = "Element")]
        public List<Element> Element { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "ElementFactories")]
    public class ElementFactories
    {
        [XmlElement(ElementName = "Module")]
        public List<Module> Module { get; set; }
    }
}
