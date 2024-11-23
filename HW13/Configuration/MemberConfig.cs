using HW13.Entities;
using HW13.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW13.Configuration
{
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.HasData(new Member()
            {
                Id = 1,
                FirstName = "Asrin",
                LastName = "Lotfi",
                UserName = "asrin@",
                password = "123",
                ExpiryDate = DateTime.Now,
                RegistrationDate= DateTime.Now,
                role = RoleEnum.member
            }
            );
            builder.HasData(new Member()
            {
                Id = 2,
                FirstName = "Aso",
                LastName = "Lotfi",
                UserName = "aso@",
                password = "123",
                ExpiryDate = DateTime.Now,
                RegistrationDate = DateTime.Now,
                role = RoleEnum.member
            }
        );
        }
    }
}
