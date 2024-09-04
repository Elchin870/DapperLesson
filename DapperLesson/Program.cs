using System.Configuration;
using System.Data.SqlClient;
using Dapper;
namespace DapperLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conStr = "Data Source=DESKTOP-HMRVE90;Initial Catalog=Library;Integrated Security=True";
            using var sqlConnection = new SqlConnection();
            Database database = new Database(conStr);
            Backet backet = new Backet();
            bool inMenu = true;
            try
            {
                Console.Write("Enter Student ID: ");
                var id = Console.ReadLine();
                var student = database.Login(Convert.ToInt32(id));
                Console.WriteLine($"Hello {student.LastName} {student.FirstName}");

            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            while (inMenu)
            {
                Console.WriteLine("1)Show All Books");
                Console.WriteLine("2)Show Backet");
                Console.WriteLine("3)Exit");
                Console.Write("Secim edin: ");
                var secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        var books = database.GetAllBooks();
                        foreach (var book in books)
                        {
                            Console.WriteLine($"{book.ID} {book.Name} {book.Quantity}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("1)Add book to backet");
                        Console.WriteLine("2)Exit");
                        Console.Write("Secim edin: ");
                        var book_secim = Console.ReadLine();
                        switch (book_secim)
                        {
                            case "1":
                                Console.Write("Enter name of book: ");
                                var searching_book = Console.ReadLine();
                                var foundBook = database.GetBookByName(searching_book);

                                if (foundBook != null)
                                {
                                    backet.AddBookToBacket(foundBook);
                                }
                                else
                                {
                                    Console.WriteLine("Book not found!");
                                }
                                break;
                            case "2":
                                break;
                            default:
                                Console.WriteLine("Wrong input!");
                                break;
                        }
                        Console.WriteLine();
                        break;
                    case "2":
                        backet.ShowBacket();
                        break;
                    case "3":
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
            }





        }
    }
}
