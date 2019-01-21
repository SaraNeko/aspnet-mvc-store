using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inlämmningsuppgift_ASP.NET_MVC.ViewModels
{
    public class AccountIndexViewModel
    {
        public AccountIndexViewModel()
        {
            Accounts = new List<AccountListViewModel>();
        }
        public class AccountListViewModel
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public bool EmailConfirmed { get; set; }
            public string PasswordHash { get; set; }
            public string SecurityStamp { get; set; }
            public string PhoneNumber { get; set; }
            public bool PhoneNumberConfirmed { get; set; }
            public bool TwoFactorEnabled { get; set; }
            public DateTime? LockoutEndDateUtc { get; set; }
            public bool LockoutEnabled { get; set; }
            public int AccessFailedCount { get; set; }
            public string UserName { get; set; }
        }
        public List<AccountListViewModel> Accounts { get; set; }

        public string CurrentSort { get; set; }
    }
}