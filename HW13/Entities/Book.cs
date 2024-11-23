using System.ComponentModel.DataAnnotations;

namespace HW13.Entities
{
    public class Book
    {
        public Book()
        {
            
        }
        public Book(string title, string author, DateTime publication_year)
        {
            this.Title = title;
            this.Author = author;
            this.PublicationYear = publication_year;
            IsBorrowed = false;
        }
        //Data Annotation
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Author { get; set; }
        public DateTime PublicationYear { get; set; }
        public bool IsBorrowed { get; set; }
        public int? MemberId { get;set; }
        public Member Member { get; set; } 
    }
}
