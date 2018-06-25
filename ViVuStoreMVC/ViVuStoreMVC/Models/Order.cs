using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViVuStoreMVC.Models
{
    public class Order
    {
        [Key]
        [BindNever]
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đầy đủ họ tên của bạn.")]
        [Display(Name = "Họ Tên")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Postal Code.")]
        [Display(Name = "Postal code")]
        [DataType(DataType.PostalCode)]
        [StringLength(10, MinimumLength = 4)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ của bạn.")]
        [MaxLength(150)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên phường bạn đang ở.")]
        [MaxLength(20)]
        [Display(Name = "Ward")]
        public string Ward { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên phường bạn đang ở.")]
        [MaxLength(20)]
        [Display(Name = "District")]
        public string District { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên thành phố bạn đang ở.")]
        [MaxLength(20)]
        [Display(Name= "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại liên hệ của bạn.")]
        [MaxLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Địa chỉ email của bạn không hợp lệ, vui lòng nhập lại")]
        [MaxLength(50)]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTimeOffset OrderedDate { get; set; }

        public List<OrderDetail> OrderLines { get; set; }
    }
}
