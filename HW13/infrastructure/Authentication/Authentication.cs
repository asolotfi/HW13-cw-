using HW13.Contract.Authentication;
using HW13.Entities;
using HW13.Role;

namespace HW13.infrastructure.Authentication
{
    public class Authentication : IAuthentication
    {
        private readonly AppDbContext _appDbContext;
        public Authentication()
        {
            _appDbContext = new AppDbContext();
        }
        public bool Login(string userName, string password)
        {
            try
            {
                if (_appDbContext.members.Any(x => x.UserName == userName && x.password == password && x.role == RoleEnum.member))
                {
                    InMemoryDB.OnlineMember = GetMember(userName);
                    return true;
                }
                else
                    InMemoryDB.OnlineLibrarian = GetLibrarian(userName);
                return true;
            }
            catch
            {
                throw new NotImplementedException("User not Found");
            }
        }
        public bool Register(string firstname, string lastName, string userName, string password, DateTime RegistrationDate, DateTime ExpiryDate, RoleEnum role)
        {
            if (role == RoleEnum.member)
            {
                var member = new Member()
                {
                    FirstName = firstname,
                    LastName = lastName,
                    UserName = userName,
                    password = password,
                    RegistrationDate = RegistrationDate,
                    ExpiryDate = ExpiryDate,
                    role = role
                };
                _appDbContext.members.Add(member);
                _appDbContext.SaveChanges();
                return true;
            }
            else
            {
                var librerian = new Librarian()
                {
                    FirstName = firstname,
                    LastName = lastName,
                    UserName = userName,
                    Password = password,
                    role = role
                };
                _appDbContext.librarians.Add(librerian);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool userExist(string userName, RoleEnum role)
        {
            if (role == RoleEnum.member)
                return _appDbContext.members.Any(U => U.UserName == userName);
            else
                return _appDbContext.librarians.Any(U => U.UserName == userName);
        }
        public Librarian GetLibrarian(string userName)
        {
            var Librarian = _appDbContext.librarians.FirstOrDefault(U => U.UserName == userName);
            if (Librarian != null)
            {
                return Librarian;
            }
            else
            {
                throw new Exception($"Cannot found User with Username : {userName}");
            }
        }
        public Member GetMember(string userName)
        {
            var member = _appDbContext.members.FirstOrDefault(U => U.UserName == userName);
            if (member != null)
            {
                return member;
            }
            else
            {
                throw new Exception($"Cannot found User with Username : {userName}");
            }
        }
    }
}


