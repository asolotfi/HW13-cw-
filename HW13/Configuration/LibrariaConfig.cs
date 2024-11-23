using HW13.Entities;
using HW13.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW13.Configuration
{
    public class LibrariaConfig : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
      
            builder.HasData(new Member
            {
                Id = 1,
                FirstName = "asos",
                LastName = "Lotfi",
                UserName = "asos@",
                password = "123",
                role=RoleEnum.Librarian

            }
         );
            builder.HasData(new Member
            {
                Id = 2,
                FirstName = "ali",
                LastName = "Lotfi",
                UserName = "ali@",
                password = "123",
                role = RoleEnum.Librarian
            }
        );
        }
    }
}
