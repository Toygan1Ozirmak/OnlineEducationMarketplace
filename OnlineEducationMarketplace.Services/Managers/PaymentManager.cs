using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Entity.Entities;
using OnlineEducationMarketplace.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Services
{
    public class PaymentManager : IPaymentService
    {
        private readonly IRepositoryManager _manager;
        public PaymentManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
    }
}
