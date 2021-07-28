using Lulus.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Models.Users
{
    public class CustomRegister: RegisterRequest
    {
        public string ConfirmPassword { get; set; }
    }
}
