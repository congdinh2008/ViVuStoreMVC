using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ViVuStoreMVC.Components
{
    public class AdminMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<AdminMenuItem> { new AdminMenuItem()
                {
                    DisplayValue = "Tài Khoản",
                    ActionValue = "UserManagement"

                },
                new AdminMenuItem()
                {
                    DisplayValue = "Vai Trò",
                    ActionValue = "RoleManagement"
                }};

            return View(menuItems);
        }
    }

    public class AdminMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }
}
