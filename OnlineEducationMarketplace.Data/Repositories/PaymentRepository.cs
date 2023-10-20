using OnlineEducationMarketplace.Data.Contracts;
using OnlineEducationMarketplace.Data.NewFolder;
using OnlineEducationMarketplace.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationMarketplace.Data.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Payment> GetAllPayments(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x => x.PaymentId);

       

        public IQueryable<Payment> GetPaymentByUserId(int userId, bool trackChanges) =>
            FindByCondition(x => x.UserId.Equals(userId), trackChanges);

        


        public void CreatePayment(Payment payment) => Create(payment);

        public void DeletePayment(Payment payment) => Delete(payment);

        public void UpdatePayment(Payment payment) => Update(payment);

       
    }
}
