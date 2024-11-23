using HW13.Contract.Repositoris;
using HW13.Entities;
using Microsoft.EntityFrameworkCore;

namespace HW13.infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;
        public BookRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public bool AddBook(string Title, string Author, DateTime Publication_year)
        {
            Book book = new Book(Title, Author, Publication_year);
            _appDbContext.books.Add(book);
            _appDbContext.SaveChanges();
            return true;
        }
        public bool BorrowBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                int MemberId = InMemoryDB.OnlineMember.Id;
                Member member = _appDbContext.members.Where(M => M.Id == MemberId).FirstOrDefault();
                if (member != null)
                {
                    book.MemberId = MemberId;
                    book.IsBorrowed = true;
                    _appDbContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            return false;
        }
        public List<Book> getAvailableBooks()
        {
            List<Book> books = _appDbContext.books.AsNoTracking().Where(b => b.IsBorrowed == false).ToList();
            return books;
        }
        public Book GetBookById(int id)
        {
            return _appDbContext.books.FirstOrDefault(B => B.Id == id);
        }
        public List<Book> GetListOfUserBooks(int MemberId)
        {
            List<Book> books = _appDbContext.members.Where(M => M.Id == MemberId).SelectMany(x => x.Books).ToList();
            return books;
        }
        public bool ReturnBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                Member member = _appDbContext.members.AsNoTracking().Where(M => M.Id == InMemoryDB.OnlineMember.Id).Include(x => x.Books).FirstOrDefault();
                if (member != null)
                {
                    var book1 = _appDbContext.books.Where(B => B.Id == id).FirstOrDefault();
                    book.IsBorrowed = false;
                    var book2 = member.Books.Where(b => b.Id == id).FirstOrDefault();
                    book.MemberId = null;
                    _appDbContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            return false;
        }
        public List<Book> ShowAll()
        {
            return _appDbContext.books.AsNoTracking().ToList();
        }
    }
}
