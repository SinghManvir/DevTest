using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperTest.Models;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomersAsync();

        Task<CustomerModel> GetCustomerAsync(int customerId);

        Task<CustomerModel> CreateCustomerAsync(BaseCustomerModel model);

        Task DeleteCustomerAsync(int customerId);
    }
}
