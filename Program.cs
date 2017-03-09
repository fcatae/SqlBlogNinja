using System;
using System.Xml.Linq;

namespace sqlninja
{
    class Program
    {
        static void Main(string[] args)
        {
            string FILE_WORDPRESS_XML = "input\\sqlblogninja.wordpress.xml";

            Console.WriteLine("Hello World!");

            var document = XDocument.Load(FILE_WORDPRESS_XML);
            
            
        }
    }
}
