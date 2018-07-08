using System;
using System.ComponentModel.DataAnnotations;
using ViVuStoreMVC.Auth;

namespace ViVuStoreMVC.ViewModels
{
    public class EditUserViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên đầy đủ.")]
        [Display(Name = "Họ Tên")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Giới Tính")]
        public Sex Sex { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh nhật.")]
        [Display(Name = "Sinh Nhật")]
        [DataType(DataType.Date)]
        public DateTimeOffset DateOfBirth { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Tên thành phố dài không quá 20 ký tự.")]
        [Display(Name = "Thành Phố")]
        public string City { get; set; }

        [MaxLength(100, ErrorMessage = "Địa chỉ dài không quá 100 ký tự.")]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
