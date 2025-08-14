namespace library_app;

class Program
{
    static List<Book> books = new List<Book>();
    static void Main(string[] args)
    {
        Console.WriteLine("Home Library - Choose an action:");
        Console.WriteLine("1. Add a book");
        Console.WriteLine("2. Remove a book");
        Console.WriteLine("3. List all books");
        Console.WriteLine("4. List books by genre");
        Console.WriteLine("5. Search for a book");
        Console.WriteLine("0. Exit");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddBook();
                break;
            case "2":
                RemoveBook();
                break;
            case "3":
                ListBooks();
                break;
            case "4":
                ListBooksByGenre();
                break;
            case "5":
                SearchBook();
                break;
            case "0":
                Console.WriteLine("Exiting...");
                return;
            default:
                Console.WriteLine("Please select a valid option.");
                break;
        }
    }
}
