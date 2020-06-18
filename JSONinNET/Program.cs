using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JSONinNET
{
    class Program
    {
        public class Book
        {
            public Book() //an empty constructor for Deserialization
            {

            }


            public Book(int id, string titel, string description, params string[] genres)
            {
                Id = id;
                Titel = titel;
                Description = description;
                Genres = genres;
            }

            public int Id { get; set; }

            public string Titel { get; set; }

            public string Description { get; set; }

            private IEnumerable<string> Genres { get; set; }


            static void Main(string[] args) //Add --> References --> System.Web.Extensions
            {
                var jsonNet = @"
                            {
                            ""ID"":1,
                            ""Decsription"": ""Book about something""
                            }
                            ";

                //JASON.NET --> add NUget json.net
                var bookDeserialize = JsonConvert.DeserializeObject<Book>(jsonNet);
                Console.WriteLine(bookDeserialize);


                //Book
                var book = new Book(1, "Highlights", "Folk book", "History", "Adventure");

                //Serialize
                var serializer = new JavaScriptSerializer();

                var json = serializer.Serialize(book);

                //Deserialize
                var book2 = serializer.Deserialize<Book>(json);

                //Console.WriteLine(json);




                //Dictionary
                var dictionary = new Dictionary<string, int>();

                for (int i = 0; i < 10; i++)
                {
                    dictionary["key - 1" + i] = i;
                }

                Console.WriteLine(serializer.Serialize(dictionary));

                var books = new List<Book>();

                for (int i = 0; i < 15; i++)
                {
                    books.Add(new Book(1, "Book - " + i, "Description of Book - " + 1));
                }

                var jsonBooks = JsonConvert.SerializeObject(books, Formatting.Indented);

                Console.WriteLine(jsonBooks);
            }
        }
    }
}
