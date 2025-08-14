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
    static void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author: ");
        string author = Console.ReadLine();
        Console.Write("Enter year published: ");
        int yearPublished = int.Parse(Console.ReadLine());
        Console.Write("Enter genre: ");
        string genre = Console.ReadLine();

        books.Add(new Book { Title = title, Author = author, YearPublished = yearPublished, Genre = genre });
        Console.WriteLine("Book added successfully.");
    }
    static void RemoveBook()
    {
        Console.Write("Enter book title to remove: ");
        string title = Console.ReadLine();
        var bookToRemove = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Book removed successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
}
