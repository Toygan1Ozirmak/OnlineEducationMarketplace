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
            FindAll(trackChanges).OrderBy(x => x.TransactionId);

        public IQueryable<Payment> GetPaymentByCourseId(int courseId, bool trackChanges) =>
            FindByCondition(x => x.CourseId.Equals(courseId), trackChanges);

        public IQueryable<Payment> GetPaymentByUserId(int userId, bool trackChanges) =>
            FindByCondition(x => x.UserId.Equals(userId), trackChanges);

        public IQueryable<Payment> GetPaymentByTransactionDate(DateTime transactionDate, bool trackChanges) =>
            FindByCondition(x => x.TransactionDate.Equals(transactionDate), trackChanges);


        public void CreatePayment(Payment payment) => Create(payment);

        public void DeletePayment(Payment payment) => Delete(payment);

        public void UpdatePayment(Payment payment) => Update(payment);
    }
}
