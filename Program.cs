namespace library_app;
using System.IO;
using System.Text.Json;

class Program
{
    static string filePath = "books.json";
    static List<Book> books = new List<Book>();
    static void Main(string[] args)
    {
        LoadBooksFromFile();
        bool exit = false;

        Console.WriteLine("Home Library - Choose an action.");
        Console.WriteLine("1. Add a book");
        Console.WriteLine("2. Remove a book");
        Console.WriteLine("3. List all books");
        Console.WriteLine("4. List books by genre");
        Console.WriteLine("5. Search for a book");
        Console.WriteLine("0. Exit");

        while (!exit)
        {
            Console.Write("Enter your choice: ");
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
                    SaveBooksToFile();
                    Console.WriteLine("Exiting and saving books to file.");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
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
    static void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        Console.WriteLine("List of all books:");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Title} by {book.Author}, {book.YearPublished}, Genre: {book.Genre}");
        }
    }
    static void ListBooksByGenre()
    {
        Console.Write("Enter genre to filter by: ");
        string genre = Console.ReadLine();
        var filteredBooks = books.Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();

        if (filteredBooks.Count == 0)
        {
            Console.WriteLine("No books found in this genre.");
            return;
        }

        Console.WriteLine($"Books in genre '{genre}':");
        foreach (var book in filteredBooks)
        {
            Console.WriteLine($"{book.Title} by {book.Author}, {book.YearPublished}");
        }
    }
    static void SearchBook()
    {
        Console.Write("Enter book title to search: ");
        string title = Console.ReadLine();
        var foundBooks = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundBooks.Count == 0)
        {
            Console.WriteLine("No books found with that title.");
            return;
        }

        Console.WriteLine("Search results:");
        foreach (var book in foundBooks)
        {
            Console.WriteLine($"{book.Title} by {book.Author}, {book.YearPublished}, Genre: {book.Genre}");
        }
    }
    static void SaveBooksToFile()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(books, options);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving books to file: {ex.Message}");
        }
    }
    static void LoadBooksFromFile()
    {
        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading books from file: {ex.Message}");
            }
        }
    }
}
