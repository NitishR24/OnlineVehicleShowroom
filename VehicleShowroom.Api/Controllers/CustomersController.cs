using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Api.Interfaces;
using VehicleShowroom.Api.Models;

namespace VehicleShowroom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                var customer = await _customerRepository.GetAllAsync();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error: {ex.Message}");
            }
        }

        [HttpGet("GetCustomersById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var vehicle = await _customerRepository.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost("AddNewCustomer")]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            await _customerRepository.CreateAsync(customer);
            return Ok(customer);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int? id, [FromBody] Customer customer)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var result = await _customerRepository.UpdateAsync(id.Value, customer);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var result = await _customerRepository.DeleteAsync(id.Value);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
