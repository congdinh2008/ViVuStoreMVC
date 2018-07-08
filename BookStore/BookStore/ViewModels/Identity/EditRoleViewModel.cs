using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class EditRoleViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập vai trò cho tài khoản")]
        [Display(Name = "Vai Trò")]
        public string Name { get; set; }

        public List<string> Users { get; set; }
    }
}
