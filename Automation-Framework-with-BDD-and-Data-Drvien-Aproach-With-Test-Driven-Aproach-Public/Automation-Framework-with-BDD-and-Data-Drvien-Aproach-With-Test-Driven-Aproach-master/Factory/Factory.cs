using Dependency_Verification.Locators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dependency_Verification.Factory
{
    class Factory
    {
       static ElementFactories elementFactories;

        public void xmlloader()
        {
            string path = "Repos\\2022\\Dependency Verification\\Locators\\Locators.xml";
            using (StreamReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ElementFactories));
                elementFactories = (ElementFactories)serializer.Deserialize(reader);
            }
        }
        public ElementFactories g_elementFactories()
        {
            return elementFactories;
        }


        public Element fetch_Element(String module_name)
        {
        String module = module_name.Split('_')[0];
        return elementFactories.Module.First(m => m.Name == module).Element.First(e => e.Keyword ==module_name);     
        }
    }



    /*
    <? xml version="1.0" encoding="utf-8" ?>
<ElementFactories>
<Module name = "Page" value="locator of page">
	<Elemente keyword = "btn" locatore="Button Value"/>
	<Elemente keyword = "btn2" locatore="Button Value2"/>
</Module>
<Module name = "Page1" value="locator of page">
	<Elemente keyword = "btn3" locatore="Button Value3"/>
	<Elemente keyword = "btn4" locatore="Button Value4"/>
</Module>
	</ElementFactories>

    */


}
