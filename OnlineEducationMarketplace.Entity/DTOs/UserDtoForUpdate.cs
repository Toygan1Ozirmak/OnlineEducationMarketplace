﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Entity.DTOs
{
    public record UserDtoForUpdate(int UserId, String FirstName, String LastName, String Email, String Password, String UserName, int RoleId, String UserBio)
    {
        //public int UserId { get; init; }
        //public string FirstName { get; init; }
        //public string LastName { get; init; }
        //public string Email { get; init; }
        //public string Password { get; init; }
        //public string UserName { get; init; }

        //public int RoleId { get; init; }

        //public string UserBio { get; init; }
    }
}
