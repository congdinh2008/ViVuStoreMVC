using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Vai Trò")]
        public string Name { get; set; }
    }
}
