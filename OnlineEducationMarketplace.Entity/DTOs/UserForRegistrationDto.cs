using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public record UserForRegistrationDto
    {
        public String FirstName { get; init; }

        public String LastName { get; init; }

        [Required(ErrorMessage = "Username is required.")]
        public String UserName { get; init; }

        public String Email { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; init; }

        public string UserBio { get; init; }

        public ICollection<string> Roles { get; set; }
    }
}
