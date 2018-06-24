using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViVuStoreMVC.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public string ImageThumbnailUrl { get; set; }

        public int TotalPages { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string BookDimensions { get; set; }

        public bool IsBookOfTheWeek { get; set; }

        public bool InStock { get; set; }

        public Guid PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
