using System;
using System.Xml;
using xmlunitylib;

namespace xmltest
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("test.xml");

            Console.WriteLine(xdoc.InnerXml);
            XMLPath xpath = new XMLPath("LinkData:Data:UserA");
            var xnode_t = xdoc.DocumentElement.SelectNodes("LinkData:Data");
            Console.WriteLine(xnode_t);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"XPath:{xpath.toString()},{xpath.deepth},{xpath.ChildPath}");

            XmlNode xnode = xdoc.DocumentElement.GetElementsByTagName("LinkData")[0];

            Console.WriteLine(xnode.InnerXml);

            XmlNode xnodeData = xnode.SelectSingleNode("Data");
            Console.WriteLine(xnodeData.InnerXml);

            Console.WriteLine(xdoc.ExistisPaths(xpath));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
