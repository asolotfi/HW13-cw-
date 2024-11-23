using HW13.Entities;
using HW13.Role;

namespace HW13.Contract.Authentication
{
    public interface IAuthentication
    {
        bool Login(string userName, string password);
        bool Register(string Firstname, string LastName, string userName, string password, DateTime RegistrationDate, DateTime ExpiryDate, RoleEnum role);
        Librarian GetLibrarian(string userName);
        Member GetMember(string userName);
        bool userExist(string userName, RoleEnum role);
    }
}
