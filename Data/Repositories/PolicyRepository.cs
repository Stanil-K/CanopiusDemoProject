using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PolicyRepository
    {
        private readonly AppContext context;

        public PolicyRepository(AppContext _context)
        {
             context = _context;
        }

        public List<Policy> GetAll()
        {
            return context.Policies
                .Include(p => p.Customer)
                .AsNoTracking()
                .ToList();
        }

        public Policy? GetById(int id) 
        {
            return context.Policies
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Policy policy)
        {
            context.Policies.Add(policy);
            context.SaveChanges();
        }

        public void Update(Policy policy)
        {
            Policy? policyToUpdate = context.Policies.Find(policy.Id);

            if (policyToUpdate != null)
            {
                policyToUpdate.PolicyType = policy.PolicyType;
                policyToUpdate.StartDate = policy.StartDate;
                policyToUpdate.EndDate = policy.EndDate;
                policyToUpdate.CustomerId = policy.CustomerId;
                policyToUpdate.PremiumAmount = policy.PremiumAmount;

                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Policy with {policy.Id} not found");
            }
        }

        public void Delete(int id)
        {
            Policy? policyToDelete = context.Policies.Find(id);

            if (policyToDelete != null)
            {
                context.Policies.Remove(policyToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Policy with {id} not found");
            }
        }

        public List<int> GetCustomerIds()
        {
            return context.Policies
                .AsNoTracking()
                .Select(p => p.CustomerId)
                .ToList();
        }
    }
}
