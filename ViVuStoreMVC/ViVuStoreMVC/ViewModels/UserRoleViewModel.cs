using System;
using System.Collections.Generic;
using ViVuStoreMVC.Auth;

namespace ViVuStoreMVC.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<ApplicationUser>();
        }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
