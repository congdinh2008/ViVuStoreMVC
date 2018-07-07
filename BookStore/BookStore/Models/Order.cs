using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
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

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ của bạn.")]
        [MaxLength(150)]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên phường/xã bạn đang ở.")]
        [MaxLength(20)]
        [Display(Name = "Phường/Xã")]
        public string Ward { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên quận/huyện bạn đang ở.")]
        [MaxLength(20)]
        [Display(Name = "Quận/Huyện")]
        public string District { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên thành phố bạn đang ở.")]
        [MaxLength(20)]
        [Display(Name = "Thành Phố")]
        public string City { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại liên hệ của bạn.")]
        [MaxLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số Điện Thoại")]
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
