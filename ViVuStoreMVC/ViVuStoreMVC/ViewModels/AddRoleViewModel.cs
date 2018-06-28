using System.ComponentModel.DataAnnotations;

namespace ViVuStoreMVC.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Vai Trò")]
        public string Name { get; set; }
    }
}
