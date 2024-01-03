using WebApplication2.Models;

namespace WebApplication2.Databases
{
    public class BooksRepository : IBooksRepository
    {
        //private List<Book> bookList = new List<Book>
        //{
        //    new Book(1, "The Catcher in the Rye", "J.D. Salinger"),
        //    new Book(2, "To Kill a Mockingbird", "Harper Lee"),
        //    new Book(3, "1984", "George Orwell"),
        //    new Book(4, "The Great Gatsby", "F. Scott Fitzgerald"),
        //    new Book(5, "Moby-Dick", "Herman Melville"),
        //    new Book(6, "Pride and Prejudice", "Jane Austen"),
        //    new Book(7, "The Lord of the Rings", "J.R.R. Tolkien"),
        //    new Book(8, "One Hundred Years of Solitude", "Gabriel García Márquez"),
        //    new Book(9, "The Hobbit", "J.R.R. Tolkien"),
        //    new Book(10, "Brave New World", "Aldous Huxley"),
        //    new Book(11, "The Chronicles of Narnia", "C.S. Lewis"),
        //    new Book(12, "The Shining", "Stephen King"),
        //    new Book(13, "Harry Potter and the Sorcerer's Stone", "J.K. Rowling"),
        //    new Book(14, "The Hitchhiker's Guide to the Galaxy", "Douglas Adams"),
        //    new Book(15, "The Alchemist", "Paulo Coelho")
        //};

        private readonly ApplicationDbContext _applicationDbContext;
        public BooksRepository() { }
        public BooksRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<Book> GetAll()
        {
            return _applicationDbContext.Books.ToList();
        }

        public void InsertBook(Book book)
        {
            _applicationDbContext.Books.Add(book);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            var bookFromDb = _applicationDbContext.Books.FirstOrDefault(b => b.Id == book.Id);

            if (bookFromDb == null)
            {
                throw new ArgumentException($"Book with ID {book.Id} was not found in database");
            }

            if (!string.IsNullOrEmpty(book.Author))
            {
                bookFromDb.Author = book.Author;
            }
            if (!string.IsNullOrEmpty(book.Title))
            {
                bookFromDb.Title = book.Title;
            }
            _applicationDbContext.SaveChanges();
        }

        public void RemoveBook(int id)
        {
            var bookFromDb = _applicationDbContext.Books.FirstOrDefault(b => b.Id == id);
            _applicationDbContext.Books.Remove(bookFromDb);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateTitle(int id, string title)
        {
            var bookFromDb = _applicationDbContext.Books.FirstOrDefault(b => b.Id == id);

            if (bookFromDb == null)
            {
                throw new ArgumentException($"Book with ID {id} was not found in database");
            }

            bookFromDb.Title = title;
            _applicationDbContext.SaveChanges();
        }
    }
}
