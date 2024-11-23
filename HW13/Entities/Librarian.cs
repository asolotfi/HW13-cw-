using HW13.Role;

namespace HW13.Entities
{
    public class Librarian
    {
        public Librarian()
        {
        }
        //Fluent API
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public RoleEnum role { get; set; }
    }
}
