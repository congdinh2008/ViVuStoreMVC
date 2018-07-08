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

        public int NumberOfPages { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string BookDimensions { get; set; }

        public bool IsBookOfTheWeek { get; set; }

        public int Quantity { get; set; }

        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public Guid PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }
    }
}
