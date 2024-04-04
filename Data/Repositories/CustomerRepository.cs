using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CustomerRepository
    {
        private readonly AppContext context;


        public CustomerRepository(AppContext _context)
        {
                context = _context;
        }

        public List<Customer> GetAll()
        {
            return context.Customers
                .AsNoTracking()
                .ToList();
        }

        public Customer? GetById(int id)
        {
            return context.Customers
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            Customer? customerToUpdate = context.Customers.Find(customer.Id);

            if (customerToUpdate != null)
            {
                customerToUpdate.Name = customer.Name;
                customerToUpdate.Address = customer.Address;
                customerToUpdate.Email = customer.Email;
                customerToUpdate.Phone = customer.Phone;
                customerToUpdate.DateofBirth = customer.DateofBirth;

                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Customer with {customer.Id} not found");
            }
        }

        public void Delete(int id)
        {
            Customer? customerToDelete = context.Customers.Find(id);

            if (customerToDelete != null)
            {
                context.Customers.Remove(customerToDelete);
                context.SaveChanges();
            }
        }

        public List<int> GetAllCustomerId()
        {
            return context.Customers
                .AsNoTracking()
                .Select(c => c.Id)
                .ToList();
        }
    }
}
