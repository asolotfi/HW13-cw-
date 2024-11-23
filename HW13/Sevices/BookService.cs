using HW13.Contract.Repositoris;
using HW13.Contract.Sevices;
using HW13.Entities;
using HW13.infrastructure.Repositories;

namespace HW13.Services
{
    public class BookService : IBookSevices
    {
        private readonly IBookRepository _BookRepository;
        public BookService()
        {
            _BookRepository = new BookRepository();
        }
        public bool AddBook(string Title, string Author, DateTime Publication_year)
        {
            _BookRepository.AddBook(Title, Author, Publication_year);
            return true;
        }
        public bool BorrowBook(int id)
        {
            if (_BookRepository.BorrowBook(id))
            {
                return true;
            }
            else
                return false;
        }
        public List<Book> getAvailableBooks()
        {
            return _BookRepository.getAvailableBooks();
        }
        public void GetListOfLibraryBooks()
        {
            throw new NotImplementedException();
        }
        public List<Book> GetListOfUserBooks(int MemberId)
        {
          return  _BookRepository.GetListOfUserBooks(MemberId);
        }
        public bool ReturnBook(int id)
        {
            if (_BookRepository.ReturnBook(id))
            {
                return true;
            }
            else
                return false;
        }
        public List<Book> ShowAll()
        {
            return _BookRepository.ShowAll();
        }
    }
}
