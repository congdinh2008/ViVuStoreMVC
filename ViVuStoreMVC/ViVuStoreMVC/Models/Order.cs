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

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [MaxLength(150)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [MaxLength(150)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your postal code")]
        [Display(Name = "Postal code")]
        [DataType(DataType.PostalCode)]
        [StringLength(10, MinimumLength = 4)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [MaxLength(20)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [MaxLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "The email address is not entered in a correct format")]
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
