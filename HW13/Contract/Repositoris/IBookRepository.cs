using HW13.Entities;

namespace HW13.Contract.Repositoris
{
    public interface IBookRepository
    {
        bool BorrowBook(int id);
        List<Book> getAvailableBooks();
        List<Book> ShowAll();
        List<Book> GetListOfUserBooks(int MemberId);
        Book GetBookById(int id);
        bool ReturnBook(int id);
        bool AddBook(string Title, string Author, DateTime Publication_year);
    }
}
