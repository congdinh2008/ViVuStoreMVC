using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ViVuStoreMVC.Auth
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(50, ErrorMessage ="Họ tên không quá 50 ký tự.")]
        [Display(Name ="Họ Tên")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Giới Tính")]
        public Sex Sex { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Tên thành phố không quá 20 ký tự.")]
        [Display(Name = "Thành Phố")]
        public string City { get; set; }

        [MaxLength(20, ErrorMessage = "Tên quận/huyện không quá 20 ký tự.")]
        [Display(Name = "Quận/Huyện")]
        public string District { get; set; }

        [MaxLength(20, ErrorMessage = "Tên phường/xã không quá 20 ký tự.")]
        [Display(Name = "Phường/Xã")]
        public string Ward { get; set; }

        [MaxLength(20, ErrorMessage = "Địa chỉ dài không quá 100 ký tự.")]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Sinh Nhật")]
        public DateTimeOffset DateOfBirth { get; set; }
    }

    public enum Sex
    {
        Male = 0,
        Female = 1
    }
}
