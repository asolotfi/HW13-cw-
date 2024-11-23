using HW13.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW13.Contract.Sevices
{
    public interface ILiberarianSevices
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder.HasData(new Member()
            {
                Id = 2,
                FirstName = "Aso",
                LastName = "Lotfi",
                UserName = "aso@",
                password = "123",
            }
            );
        }
    }
}
