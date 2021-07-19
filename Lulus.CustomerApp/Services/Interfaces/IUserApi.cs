using Lulus.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lulus.CustomerApp.Services.Interfaces
{
    public interface IUserApi
    {
        public Task<string> Login(LoginRequest request);
    }
}
