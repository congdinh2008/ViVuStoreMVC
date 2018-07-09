using BookStore.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Cần nhập tựa sách")]
        [Display(Name = "Tựa Sách")]
        [MaxLength(200, ErrorMessage = "Tựa sách dài không quá 200 ký tự")]
        [Remote("CheckIfBookTitleAlreadyExists","BookManagement", ErrorMessage ="Tựa sách này đã có sẵn!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Cần nhập mô tả sách")]
        [Display(Name = "Mô Tả")]
        [MaxLength(2000, ErrorMessage = "Mô tả sách không dài quá 2000 ký tự")]
        [MinLength(20, ErrorMessage = "Mô tả sách không ngắn hơn 20 ký tự")]
        public string Description { get; set; }

        [Display(Name = "Ảnh Bìa")]
        [ValidUrl(ErrorMessage = "Đây không phải là một đường link ảnh.")]
        public string ImageThumbnailUrl { get; set; }

        [Required(ErrorMessage = "Cần nhập số trang")]
        [Display(Name = "Số Trang")]
        public int NumberOfPages { get; set; }

        [Required(ErrorMessage = "Cần nhập giá sách")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Cần nhập ngày xuất bản")]
        [Display(Name = "Ngày Xuất Bản")]
        public DateTimeOffset ReleaseDate { get; set; }

        [Required(ErrorMessage = "Cần nhập kích thước sách")]
        [Display(Name = "Kích Thước")]
        public string BookDimensions { get; set; }

        [Display(Name ="Sách Hay Trong Tuần?")]
        [DefaultValue(false)]
        public bool IsBookOfTheWeek { get; set; }

        [Display(Name = "Số Lượng")]
        [DefaultValue(0)]
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

        public virtual List<BookReview> BookReviews { get; set; }
    }
}
