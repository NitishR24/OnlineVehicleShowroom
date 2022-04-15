using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Api.Interfaces;
using VehicleShowroom.Api.Models;

namespace VehicleShowroom.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OnlineVehicleShowroomContext _context;

        public CustomerRepository(OnlineVehicleShowroomContext context)
        {
            _context = context;
        }
            
        public async Task<bool> CreateAsync(Customer entity)
        {
            if (entity == null)
            {
                return false;
            }
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var custInDb = await _context.Customers.FindAsync(id);
            if (custInDb == null)
            {
                return false;
            }
            _context.Customers.Remove(custInDb);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            var customer = await _context.Customers.ToListAsync();
            return customer;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<bool> DeleteCustAsync(int id)
        {
            var custInDb = await _context.Customers.FindAsync(id);
            if (custInDb == null)
            {
                return false;
            }
            _context.Customers.Remove(custInDb);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(int id, Customer entity)
        {
            var custInDb = await _context.Customers.FindAsync(id);
            if (custInDb == null)
            {
                return false;
            }
            custInDb.CustomerName = entity.CustomerName;
            custInDb.Gender = entity.Gender;
            custInDb.ContactNo = entity.ContactNo;
            custInDb.Email = entity.Email;
            custInDb.Address = entity.Address;
            custInDb.City = entity.City;
            custInDb.State = entity.State;
            custInDb.Pincode = entity.Pincode;
            custInDb.UserId = entity.UserId;
            custInDb.Password = entity.Password;
            _context.Entry(custInDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
