using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;


namespace XMLparser
{
    class XMLparser
    {
        static void Main()
        {
            string input_path = "../../catalog.xml";
            string output_path = "../../output.xml";
            var books = readfromXML(input_path);
            writeToXML(output_path, books);

        }


        private static List<Book> readfromXML(string path)
        {
            using (XmlReader reader = XmlReader.Create(path))
            {
                var Books = new List<Book>();
                Book book = null;
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
                                if (book != null)
                                {
                                    Books.Add(book);
                                }
                                book = new Book();
                                // Detect this article element.
                                Console.WriteLine("Start <book> element.");

                                // Search for the attribute id on this current node.
                                string id = reader["id"];
                                if (id != null)
                                {
                                    book.id = id;
                                    Console.WriteLine("  Book ID: " + id);
                                }
                                break;
                            case "title":
                                if (reader.Read())
                                {
                                    book.title = reader.Value.Trim();
                                    Console.WriteLine("    Book title: " + reader.Value.Trim());
                                }
                                break;
                            case "author":
                                if (reader.Read())
                                {
                                    book.author = reader.Value.Trim();
                                    Console.WriteLine("    Book author: " + reader.Value.Trim());
                                }
                                break;
                            case "genre":
                                if (reader.Read())
                                {
                                    book.genre = reader.Value.Trim();
                                    Console.WriteLine("    Book genre: " + reader.Value.Trim());
                                }
                                break;
                            case "price":
                                if (reader.Read())
                                {
                                    book.price = reader.Value.Trim();
                                    Console.WriteLine("    Book price: " + reader.Value.Trim());
                                }
                                break;
                            case "publish_date":
                                if (reader.Read())
                                {
                                    book.publish_date = reader.Value.Trim();
                                    Console.WriteLine("    Book publish date: " + reader.Value.Trim());
                                }
                                break;
                            case "description":
                                if (reader.Read())
                                {
                                    book.description = reader.Value.Trim();
                                    Console.WriteLine("    Book description: " + reader.Value.Trim());
                                }
                                break;
                        }
                    }

                }

                return Books;
            }
        }

        private static void writeToXML(string path, List<Book> books)
        {

            XElement catalog = new XElement("catalog");
            foreach (var book in books)
            {
                catalog.Add(new XElement("book", new XAttribute("id", book.id),
                                            new XElement("author", book.author),
                                            new XElement("title", book.title),
                                            new XElement("genre", book.genre),
                                            new XElement("price", book.price),
                                            new XElement("publish_date", book.publish_date),
                                            new XElement("description", book.description)
                                            ));
            }

            XDocument xDoc = new XDocument(catalog);
            xDoc.Save(path);
        }
    }
}
