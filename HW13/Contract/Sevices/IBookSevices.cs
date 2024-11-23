using HW13.Entities;

namespace HW13.Contract.Sevices
{
    public interface IBookSevices
    {
        bool BorrowBook(int id);
        List<Book> ShowAll();
        List<Book> getAvailableBooks();
        List<Book> GetListOfUserBooks(int MemberId);
        void GetListOfLibraryBooks();
        bool ReturnBook(int id);
        bool AddBook(string Title, string Author, DateTime Publication_year);
    }
}
