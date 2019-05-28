using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLparser
{
    class Program
    {
        static void Main()
        {
            // Create an XML reader for this file.
            using (XmlReader reader = XmlReader.Create("../../catalog.xml"))
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "catalog":
                                // Detect this element.
                                Console.WriteLine("Start <catalog> element.");
                                break;
                            case "book":
                                // Detect this article element.
                                Console.WriteLine("Start <book> element.");

                                // Search for the attribute name on this current node.
                                string attribute = reader["id"];
                                if (attribute != null)
                                {
                                    Console.WriteLine("  Book ID: " + attribute);
                                }
                                break;
                            case "title":
                                if (reader.Read())
                                {
                                    Console.WriteLine("    Book title: " + reader.Value.Trim());
                                }
                                break;
                            case "author":
                                if (reader.Read())
                                {
                                    Console.WriteLine("    Book author: " + reader.Value.Trim());
                                }
                                break;
                            case "genre":
                                if (reader.Read())
                                {
                                    Console.WriteLine("    Book genre: " + reader.Value.Trim());
                                }
                                break;
                            case "price":
                                if (reader.Read())
                                {
                                    Console.WriteLine("    Book price: " + reader.Value.Trim());
                                }
                                break;
                            case "publish_date":
                                if (reader.Read())
                                {
                                    Console.WriteLine("    Book publish date: " + reader.Value.Trim());
                                }
                                break;
                            case "description":
                                if (reader.Read())
                                {
                                    Console.WriteLine("    Book description: " + reader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
