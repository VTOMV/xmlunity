using System;
using System.Xml;


namespace xmlunitylib
{
    public static class XMLExtentions
    {
        public static bool ExistisPaths(this XmlDocument xdoc, XMLPath xpath)
        {
            bool exists = true;
            if (xpath.hasChild())
            {
                var childXmlNode =  xdoc.DocumentElement.SelectSingleNode(xpath.XPath);                
                exists =(childXmlNode==null?false:childXmlNode.ExistisPaths(xpath.Child));
            }
            else
            {
                exists = xdoc.DocumentElement.SelectNodes(xpath.XPath).Count > 0;
            }

            return exists;
        }

        public static bool ExistisPaths(this XmlElement xele, XMLPath xpath)
        {
            bool exists = true;
            if (xpath.hasChild())
            {
                var childXmlNode =  xele.SelectSingleNode(xpath.XPath);                
                exists =(childXmlNode==null?false: childXmlNode.ExistisPaths(xpath.Child));
            }
            else
            {
                exists = xele.SelectNodes(xpath.XPath).Count > 0;
            }

            return exists;
        }


        public static bool ExistisPaths(this XmlNode xnode, XMLPath xpath)
        {
            bool exists = true;
            if (xpath.hasChild())
            {
                var childXmlNode =  xnode.SelectSingleNode(xpath.XPath);                
                exists = (childXmlNode==null?false:childXmlNode.ExistisPaths(xpath.Child));
                Console.WriteLine($"{xpath.XPath}:{(childXmlNode==null?"":childXmlNode.InnerXml)}");
            }
            else
            {
                exists = xnode.SelectNodes(xpath.XPath).Count > 0;
            }

            return exists;
        }
    
        public static  XmlNodeList? SelectNodes(this XmlDocument xodc,XMLPath xpath){
            return xodc.SelectNodes(xpath.toString());
        } 
    }
}