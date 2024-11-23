using HW13.Contract.Authentication;
using HW13.infrastructure.Authentication;
using HW13.Role;


namespace HW13.Services
{
    public class AuthenticationService
    {
        private readonly IAuthentication _Authentication;
        public AuthenticationService()
        {
            _Authentication = new Authentication();
        }
        public bool Login(string userName, string password)
        {
            var result = _Authentication.Login(userName, password);
            if (result)
            {
                return result;
            }
            else
            {
                return false;
            }
        }
        public bool Register(string Firstname, string LastName, string userName, string password, DateTime RegistrationDate, DateTime ExpiryDate, RoleEnum role)
        {
            if (_Authentication.userExist(userName, role))
            {
                return false;
            }
            else
            {
                _Authentication.Register(Firstname, LastName, userName, password, RegistrationDate, ExpiryDate, role);
                return true;
            }
        }
    }
}
