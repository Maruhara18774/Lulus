using Lulus.BAL.Catalog.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lulus.BAL.Catalog.Users.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(LoginRequest request);

        Task<string> Register(RegisterRequest request);
    }
}
