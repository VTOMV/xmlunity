using System;

namespace xmlunitylib
{
    public class XMLPath
    {
        public string XPath { get; set; }

        public string ChildPath { get; set; }

        public XMLPath Child { get; set; }

        public int deepth { get; set; }

        public XMLPath(string xpath)
        {
            try
            {

                if (string.IsNullOrEmpty(xpath))
                {
                    throw new Exception("XPath shoult be not Empty");
                }

                string[] nodepaths = xpath.Split(":");
                this.XPath = nodepaths[0];
                this.deepth = nodepaths.Length;
                if (nodepaths.Length > 1)
                {
                    string strChild = xpath.Remove(0, this.XPath.Length+1);
                    this.ChildPath =strChild;
                    if (!string.IsNullOrEmpty(strChild))
                    {
                        this.Child = new XMLPath(strChild);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public XMLPath(string xpath, XMLPath child = null)
        {
            this.XPath = xpath;
            this.Child = child;
        }

        public bool hasChild()
        {
            return !(this.Child == null || string.IsNullOrEmpty(Child.XPath));
        }

        public string toString()
        {
            return $"{GetFullPath(this)}";
        }


        public string GetFullPath(XMLPath xpath)
        {
            string xtrReturn = xpath.XPath;
            if (xpath.hasChild())
            {
                xtrReturn += $":{GetFullPath(xpath.Child)}";
            }
            return xtrReturn;
        }

        
    }
}
