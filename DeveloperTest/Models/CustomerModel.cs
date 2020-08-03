using DeveloperTest.Database.Models;

namespace DeveloperTest.Models
{
    public class CustomerModel : BaseCustomerModel
    {
        public int CustomerId;

        public CustomerModel()
        {
        }

        public CustomerModel(Customer customerDb)
        {
            CustomerId = customerDb.CustomerId;
            Name = customerDb.Name;
            Type = customerDb.Type;

        }
    }
}