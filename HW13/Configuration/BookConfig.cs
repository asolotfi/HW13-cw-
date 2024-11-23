using HW13.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW13.Configuration
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(b => b.Member).WithMany(x => x.Books).HasForeignKey(x => x.MemberId);
            builder.HasData(new Book
            {
                Id = 1,
                Title = "Asp",
                Author = "Roza",
                PublicationYear = DateTime.Now,
                IsBorrowed = true,
                MemberId = 1
            }
            );
            builder.HasData(new Book
            {
                Id = 2,
                Title = "C#",
                Author = "Reza",
                PublicationYear = DateTime.Now,
                IsBorrowed = true,
                MemberId = 1
            }
            );
            builder.HasData(new Book
            {
                Id = 3,
                Title = "sql",
                Author = "Zahra",
                PublicationYear = DateTime.Now,
                IsBorrowed = false,
                MemberId = null
            }
            );

        }
    }
}
