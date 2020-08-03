using System.Collections.Generic;

namespace DeveloperTest.Models
{
    public class BaseCustomerModel
    {
        public string Name { get; set; }

        public CustomerType Type { get; set; }

        public ICollection<JobModel> Jobs { get; set; }
    }
}
