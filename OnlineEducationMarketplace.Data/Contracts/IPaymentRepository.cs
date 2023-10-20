using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Contracts
{
    public interface IPaymentRepository : IRepositoryBase<Payment>
    {

        IQueryable<Payment> GetAllPayments(bool trackChanges);


        

       
       
        void CreatePayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(Payment payment);

    }
}
