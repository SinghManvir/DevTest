using System;

namespace DeveloperTest.Models
{
    public class BaseJobModel
    {
        public CustomerModel Customer { get; set; }

        public string Engineer { get; set; }

        public DateTime When { get; set; }
    }
}
