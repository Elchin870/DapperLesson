namespace DapperLesson
{
    internal class Backet
    {
        public List<Book> BooksInBacket { get; set; } = new List<Book>(); 

        public void AddBookToBacket(Book book)
        {
            BooksInBacket.Add(book);
            Console.WriteLine($"Added {book.Name}");
        }

        public void ShowBacket()
        {
            if (BooksInBacket.Count == 0)
            {
                Console.WriteLine("The basket is empty.");
                return;
            }

            foreach (var book in BooksInBacket)
            {
                Console.WriteLine(book.Name);
            }
        }
    }
}
