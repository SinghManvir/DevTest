using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync()
        {
            return await _dbContext.Customers.Select(x => new CustomerModel(x)).ToListAsync();
        }

        public async Task<CustomerModel> GetCustomerAsync(int customerId)
        {
            var customerDb = await _dbContext.Customers.SingleOrDefaultAsync(x => x.CustomerId == customerId);
            return new CustomerModel(customerDb);
        }

        public async Task<CustomerModel> CreateCustomerAsync(BaseCustomerModel model)
        {
            var newCustomer = _dbContext.Customers.Add(new Customer
            {
                Name = model.Name,
                Type = model.Type
            });

            await _dbContext.SaveChangesAsync();

            return new CustomerModel(newCustomer.Entity);
        }

        public Task DeleteCustomerAsync(int customerId)
        {
            return Task.FromResult(
                _dbContext.Customers.Remove(new Customer {CustomerId = customerId})
            );
        }
    }
}