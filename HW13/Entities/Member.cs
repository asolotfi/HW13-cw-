using HW13.Role;

namespace HW13.Entities
{
    public class Member
    {
        public Member()
        {
        }
        //Fluent API
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? password { get; set; }
        public string? UserName { get; set; }
        public List<Book>? Books { get; set; } = new();
        public DateTime? ExpiryDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public RoleEnum role { get;set; }
    }
}
