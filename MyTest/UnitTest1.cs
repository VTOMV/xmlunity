using NUnit.Framework;
using xmlunitylib;
using System.Xml;
using System;

namespace mytest
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("test.xml");

            Console.WriteLine(xdoc.InnerXml);
            XMLPath xpath = new XMLPath("Root");

            Console.WriteLine($"XPath:{xpath.toString()}");
            Assert.Pass();
        }
    }
}