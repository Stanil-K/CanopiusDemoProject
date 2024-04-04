using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PaymentRepository
    {
        private readonly AppContext context;


        public PaymentRepository(AppContext _context)
        {
                context = _context;
        }


        public List<Payment> GetAll()
        {
            return context.Payments
                .AsNoTracking()
                .ToList();
        }

        public Payment? GetById(int id) 
        { 
           return context.Payments
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
        }

        public void Update(Payment payment)
        {
            Payment? paymentToUpdate = context.Payments.Find(payment.Id);

            if (paymentToUpdate != null)
            {
                paymentToUpdate.PaymentDate = payment.PaymentDate;
                paymentToUpdate.PaymentAmount = payment.PaymentAmount;
                paymentToUpdate.PolicyID = payment.PolicyID;

                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Payment with {payment.Id} not found");
            }
        }

        public void Delete(int id)
        {
            Payment? paymentToDelete = context.Payments.Find(id);

            if (paymentToDelete != null)
            {
                context.Payments.Remove(paymentToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Payment with {id} not found");
            }
        }
    }
}
