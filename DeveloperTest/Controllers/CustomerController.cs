using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerService.GetCustomersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BaseCustomerModel model)
        {
            if (model.Name.Length < 5)
            {
                return BadRequest("Name must be at least 5 characters.");
            }

            var customer = await _customerService.CreateCustomerAsync(model);

            return Created($"customer/{customer}", customer);
        }
    }
}