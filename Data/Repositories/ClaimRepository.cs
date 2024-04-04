using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ClaimRepository
    {

        private readonly AppContext context;

        public ClaimRepository(AppContext _context)
        {
            context = _context;
        }

        public List<Claim> GetAll()
        {
            return context.Claims
                .AsNoTracking()
                .ToList();
        }

        public Claim? GetById(int id)
        {
            return context.Claims
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Claim claim)
        {
            context.Claims.Add(claim);
            context.SaveChanges();
        }

        public void Update(Claim claim)
        {
           Claim? claimToUpdate = context.Claims.Find(claim.Id);

            if (claimToUpdate != null)
            {
                claimToUpdate.ClaimDescription = claim.ClaimDescription;
                claimToUpdate.ClaimAmount = claim.ClaimAmount;
                claimToUpdate.ClaimStatus = claim.ClaimStatus;
                claimToUpdate.DateOfClaim = claim.DateOfClaim;
                
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Claim with {claim.Id} not found");
            }
        }

        public void Delete(int id)
        {
            Claim? claimToDelete = context.Claims.Find(id);

            if (claimToDelete != null)
            {
                context.Claims.Remove(claimToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Claim with {id} not found");
            }
        }

        public List<Claim> AllClaimsWithDistinctStatus()
        {
            return context.Claims
                    .AsNoTracking()
                    .GroupBy(c => c.ClaimStatus)
                    .Select(g => g.First())
                    .ToList();
        }
    }
}
