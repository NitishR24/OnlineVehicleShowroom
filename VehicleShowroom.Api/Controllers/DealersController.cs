using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Api.Models;

namespace VehicleShowroom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly OnlineVehicleShowroomContext _context = null;

        public DealersController(OnlineVehicleShowroomContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllDealers")]
        public IActionResult GetAll()
        {
            return Ok(_context.Dealers.ToList());
        }

        [HttpGet("GetDealersById/{id}")]
        public IActionResult GetByld(int id)
        {
            var dealers = _context.Dealers.Find(id);
            if (dealers == null)
            {
                return NotFound();
            }
            return Ok(dealers);
        }
        [HttpPost("CreateDealer")]
        public IActionResult CreateNewDealer(Dealer dealer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Dealers.Add(dealer);
            _context.SaveChanges();
            return Created("GetDealerById", dealer);
        }
        [HttpPut("UpdateDealer")]
        public IActionResult UpdateDealer(int id, Dealer dealer)
        {
            var dealerInDb = _context.Dealers.Find(id);
            if (dealerInDb == null)
            {
                return NotFound();
            }
            dealerInDb.DealerName = dealer.DealerName;
            dealerInDb.State = dealer.State;
            dealerInDb.City = dealer.City;
            dealerInDb.State = dealer.State;
            dealerInDb.ContactNo = dealer.ContactNo;
            dealerInDb.Address = dealer.Address;
            dealerInDb.CompanyName = dealer.CompanyName;

            _context.Entry(dealerInDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("DeleteDealerById/{id}")]
        public async Task<IActionResult> DeleteDealer(int id)
        {
            var dealer = await _context.Dealers.FindAsync(id);
            if (dealer == null)
            {
                return NotFound();
            }

            _context.Dealers.Remove(dealer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
 }
