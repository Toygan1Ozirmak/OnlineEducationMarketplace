using Microsoft.AspNetCore.Identity;
using OnlineEducationMarketplace.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistraitonDto);

        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthDto);

        Task<string> CreateToken();

        //Task LogoutAsync(Guid userId);
    }
}
