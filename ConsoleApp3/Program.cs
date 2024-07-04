using System.Net.Http.Headers;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            while (true)
            {
                Console.WriteLine("Library Menu:");
                Console.WriteLine("1.Add book");
                Console.WriteLine("2.Search for a book");
                Console.WriteLine("3.Remove book");
                Console.WriteLine("4.All books");
                Console.WriteLine("5.Check for word");
                Console.WriteLine("6.Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBookToLibrary(library);
                        break;
                    case "2":
                        SearchBookInLibrary(library);
                        break;
                    case "3":
                        RemoveBookFromLibrary(library);
                        break;
                    case "4":
                        ListAllBooks(library);
                        break;
                    case "5":
                        CheckBookTitleContainsWord(library);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        static void AddBookToLibrary(Library library)
        {
            Console.Write("Enter the book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter the author's full name: ");
            string authorName = Console.ReadLine();

            Console.Write("Enter the author's email: ");
            string authorEmail = Console.ReadLine();

            Console.Write("Enter the author's gender (M/F): ");
            char authorGender = char.Parse(Console.ReadLine());

            Console.Write("Enter the book price: ");
            double price = double.Parse(Console.ReadLine());

            Author author = new Author(authorName, authorEmail, authorGender);
            Book book = new Book(title, author, price);

            library.AddBook(book);
            Console.WriteLine("Book added successfully.");
        }

        static void SearchBookInLibrary(Library library)
        {
            Console.Write("Enter the book title to search: ");
            string title = Console.ReadLine();

            Book book = library.SearchBookByTitle(title);
            if (book != null)
            {
                Console.WriteLine($"Found: {book}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void RemoveBookFromLibrary(Library library)
        {
            Console.Write("Enter the book title to remove: ");
            string title = Console.ReadLine();

            bool isRemoved = library.RemoveBook(title);
            Console.WriteLine(isRemoved ? "Book removed successfully." : "Book not found.");
        }

        static void ListAllBooks(Library library)
        {
            List<Book> allBooks = library.GetAllBooks();
            if (allBooks.Count > 0)
            {
                Console.WriteLine("All books in the library:");
                foreach (var book in allBooks)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No books in the library.");
            }
        }

        static void CheckBookTitleContainsWord(Library library)
        {
            Console.Write("Enter the word to check in book titles: ");
            string word = Console.ReadLine();

            bool containsWord = library.ContainsTitle(word);
            Console.WriteLine(containsWord ? $"Library contains a book with the word '{word}' in the title." : $"No books found with the word '{word}' in the title.");
        }
    }

}
    public class Author {
        public String fullName { set; get; }
        public string email { set; get; }
        public char gender { set; get; }
        public Author(string fullName, string email, char gender)
        {
            fullName = fullName;
            email = email;
            gender = gender;
        }
        public string tostring()
        {
            return $"Author[name={fullName}],email={email},gender ={gender}]";
        }

    }
    public class Book{
        public String title { set; get; }
        public Author author { set; get; }
        public double price { set; get; }
        public Book(string title,Author author,double price)
        {
            title = title;
            author = author;
            price = price;
        }
    }
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public Book SearchBookByTitle(string title)
        {
            return books.FirstOrDefault(book => book.title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
        public bool RemoveBook(string title)
        {
            var book = SearchBookByTitle(title);
            if (book != null)
            {
                books.Remove(book);
                return true;
            }
            return false;
        }
        public List<Book> GetAllBooks()
        {
            return new List<Book>(books);
        }
        public bool ContainsTitle(string word)
        {
            return books.Any(book => book.title.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        public string ToString()
        {
            return $"Library[{string.Join(", ", books)}]";
        }
    }

