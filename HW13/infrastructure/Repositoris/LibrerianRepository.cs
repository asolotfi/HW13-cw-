using HW13.Contract.Repositoris;

namespace HW13.infrastructure.Repositories
{
    public class LibrerianRepository : ILibrarianRepository
    {
        private readonly AppDbContext _appDbContext;
        public LibrerianRepository()
        {
            _appDbContext = new AppDbContext();
        }
    }
}
