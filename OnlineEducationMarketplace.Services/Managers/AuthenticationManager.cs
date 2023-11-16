using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services.Managers
{
    public class AuthenticationManager : IAuthenticationService
    {
        
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationManager(
            Data.Contracts.IRepositoryManager repositoryManager,
            IMapper mapper, 
            UserManager<User> userManager, 
            IConfiguration configuration)
        {
            
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistraitonDto)
        {
            var user = _mapper.Map<User>(userForRegistraitonDto);
            var result = await _userManager
                .CreateAsync(user, userForRegistraitonDto.Password);

            if(result.Succeeded) 
                await _userManager.AddToRolesAsync(user, userForRegistraitonDto.Roles);
            return result;
                    
        }
    }
}
