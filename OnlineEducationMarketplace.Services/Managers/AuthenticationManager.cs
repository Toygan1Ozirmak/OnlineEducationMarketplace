using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineEducationMarketplace.Entity.DTOs;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Entity.Exceptions;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static OnlineEducationMarketplace.Entity.Exceptions.NotFoundException;

namespace OnlineEducationMarketplace.Services.Managers
{
    public class AuthenticationManager : IAuthenticationService
    {
        
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private User _user;

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

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthDto)
        {
            _user = await _userManager.FindByNameAsync(userForAuthDto.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user,userForAuthDto.Password));

            if (!result)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions); 
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }
    }
}
