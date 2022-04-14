using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Api.Interfaces;
using VehicleShowroom.Api.Models;

namespace VehicleShowroom.Api.Repositories
{
    public class DealerRepository : IDealersRepository
    {
        private readonly OnlineVehicleShowroomContext _context;

        public DealerRepository(OnlineVehicleShowroomContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Dealer entity)
        {
            if (entity == null)
            {
                return false;
            }
            _context.Dealers.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dealerInDb = await _context.Dealers.FindAsync(id);
            if (dealerInDb == null)
            {
                return false;
            }
            _context.Dealers.Remove(dealerInDb);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Dealer>> GetAllAsync()
        {
            var dealer = await _context.Dealers.ToListAsync();
            return dealer;
        }

        public async Task<Dealer> GetByIdAsync(int id)
        {
            return await _context.Dealers.FindAsync(id);
        }

        public async Task<bool> DeleteCustAsync(int id)
        {
            var dealerInDb = await _context.Dealers.FindAsync(id);
            if (dealerInDb == null)
            {
                return false;
            }
            _context.Dealers.Remove(dealerInDb);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(int id, Dealer entity)
        {
            var dealerInDb = await _context.Dealers.FindAsync(id);
            if (dealerInDb == null)
            {
                return false;
            }
            dealerInDb.DealerName = entity.DealerName;
            dealerInDb.CompanyName = entity.CompanyName;
            dealerInDb.Address = entity.Address;
            dealerInDb.ContactNo = entity.ContactNo;
            dealerInDb.City = entity.City;
            dealerInDb.State = entity.State;
            dealerInDb.DealerId = entity.DealerId;
            dealerInDb.Pincode = entity.Pincode;
            dealerInDb.UserId = entity.UserId;
            dealerInDb.Password = entity.Password;

            _context.Entry(dealerInDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
