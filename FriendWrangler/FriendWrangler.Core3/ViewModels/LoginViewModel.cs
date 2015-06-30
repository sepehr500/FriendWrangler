using FriendWrangler.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendWrangler.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public async Task Login()
        {
            if (string.IsNullOrEmpty(Username))
            {
                throw new Exception("Username empty.");
            }
            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("Password empty.");
            }

            IsBusy = true;
            try
            {
                settings.User = await service.Login(Username, Password);
                settings.Save();
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
