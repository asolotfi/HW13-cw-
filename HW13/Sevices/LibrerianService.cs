using HW13.Contract.Repositoris;
using HW13.Contract.Sevices;
using HW13.infrastructure.Repositories;

namespace HW13.Services
{
    public class LibrarianService : ILiberarianSevices
    {
        private readonly ILibrarianRepository _LibrarianRepository;
        public LibrarianService()
        {
            _LibrarianRepository = new LibrerianRepository();
        }
    }
}
