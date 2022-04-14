using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Api.Interfaces;
using VehicleShowroom.Api.Models;

namespace VehicleShowroom.Api.Repositories
{
    public class ShowroomRepository : IShowroomsRepository
    {
        private readonly OnlineVehicleShowroomContext _context;

        public ShowroomRepository(OnlineVehicleShowroomContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Showroom entity)
        {
            if (entity == null)
            {
                return false;
            }
            _context.Showrooms.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var showroomInDb = await _context.Showrooms.FindAsync(id);
            if (showroomInDb == null)
            {
                return false;
            }
            _context.Showrooms.Remove(showroomInDb);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Showroom>> GetAllAsync()
        {
            var showroom = await _context.Showrooms.ToListAsync();
            return showroom;
        }

        public async Task<Showroom> GetByIdAsync(int id)
        {
            return await _context.Showrooms.FindAsync(id);
        }

        public async Task<bool> DeleteCustAsync(int id)
        {
            var showroomInDb = await _context.Showrooms.FindAsync(id);
            if (showroomInDb == null)
            {
                return false;
            }
            _context.Showrooms.Remove(showroomInDb);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(int id, Showroom entity)
        {
            var showroomInDb = await _context.Showrooms.FindAsync(id);
            if (showroomInDb == null)
            {
                return false;
            }
            showroomInDb.ShowroomId = entity.ShowroomId;
            showroomInDb.Name = entity.Name;
            showroomInDb.DealerId = entity.DealerId;
            showroomInDb.OwnerName = entity.OwnerName;
            showroomInDb.ContactNo = entity.ContactNo;
            showroomInDb.Address = entity.Address;
            showroomInDb.City = entity.City;
            showroomInDb.State = entity.State;
            showroomInDb.Pincode = entity.Pincode;

            _context.Entry(showroomInDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

