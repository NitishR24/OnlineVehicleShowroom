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
    public class VehiclesController : ControllerBase
    {
            private readonly IVehiclesRepository _vehicleRepository ;

            public VehiclesController(IVehiclesRepository vehicleRepository)
            {
                _vehicleRepository = vehicleRepository;
            }

        [HttpGet("GetAllVehicles")]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                var customers = await _vehicleRepository.GetAllAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error: {ex.Message}");
            }
        }

        [HttpGet("GetVehicleById/{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost("AddNewVehicle")]
        public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
        {
            await _vehicleRepository.CreateAsync(vehicle);
            return Ok(vehicle);
        }

        [HttpPut("UpdateVehicle/{id}")]
        public async Task<IActionResult> UpdateVehicle(int? id, [FromBody] Vehicle vehicle)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var result = await _vehicleRepository.UpdateAsync(id.Value, vehicle);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
            }

        [HttpDelete("DeleteVehicle/{id}")]
        public async Task<IActionResult> DeleteVehicle(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var result = await _vehicleRepository.DeleteAsync(id.Value);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("GetVehiclesByRating")]
        public async Task<IActionResult> GetVehiclesByRating(int rating)
        {
            var vehicle = await _vehicleRepository.GetVehicleByRating(rating);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
        [HttpGet("GetVehiclesByName")]
        public async Task<IActionResult> GetVehiclesByName(string name)
        {
            var vehicle = await _vehicleRepository.GetVehicleByName(name);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
        [HttpGet("GetVehiclesByModel")]
        public async Task<IActionResult> GetVehiclesByModel(string model)
        {
            var vehicle = await _vehicleRepository.GetVehicleByModel(model);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
        [HttpGet("GetVehiclesByShowroom")]
        public async Task<IActionResult> GetVehiclesByShowroom(string showroom)
        {
            var vehicle = await _vehicleRepository.GetVehicleByShowroom(showroom);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
        [HttpGet("GetVehiclesByDealerId")]
        public async Task<IActionResult> GetVehiclesByDealerId(int dealerId)
        {
            var vehicle = await _vehicleRepository.GetVehicleByDealerId(dealerId);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
    }
    }
