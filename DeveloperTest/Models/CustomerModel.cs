using System;
using System.Linq;
using DeveloperTest.Database.Models;

namespace DeveloperTest.Models
{
    public class CustomerModel : BaseCustomerModel
    {
        public int CustomerId { get; set; }

        public CustomerModel()
        {
        }

        public CustomerModel(Customer customerDb)
        {
            if (customerDb == null) throw new ArgumentNullException(nameof(customerDb));

            CustomerId = customerDb.CustomerId;
            Name = customerDb.Name;
            Type = customerDb.Type;
            Jobs = customerDb.Jobs?.Select(x => new JobModel
            {
                Engineer = x.Engineer,
                JobId = x.JobId,
                When = x.When
            }).ToList();
        }
    }
}