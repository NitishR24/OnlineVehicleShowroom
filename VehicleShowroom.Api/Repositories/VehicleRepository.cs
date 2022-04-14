using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Api.Interfaces;
using VehicleShowroom.Api.Models;

namespace VehicleShowroom.Api.Repositories
{
    public class VehicleRepository : IVehiclesRepository
    {
            private readonly OnlineVehicleShowroomContext _context;

            public VehicleRepository(OnlineVehicleShowroomContext context)
            {
                _context = context;
            }

            public async Task<bool> CreateAsync(Vehicle entity)
            {
                if (entity == null)
                {
                    return false;
                }
                _context.Vehicles.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var vehicleInDb = await _context.Vehicles.FindAsync(id);
                if (vehicleInDb == null)
                {
                    return false;
                }
                _context.Vehicles.Remove(vehicleInDb);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<IList<Vehicle>> GetAllAsync()
            {
                var vehicle = await _context.Vehicles.ToListAsync();
                return vehicle;
            }

            public async Task<Vehicle> GetByIdAsync(int id)
            {
                return await _context.Vehicles.FindAsync(id);
            }

            public async Task<bool> DeleteCustAsync(int id)
            {
                var vehicleInDb = await _context.Vehicles.FindAsync(id);
                if (vehicleInDb == null)
                {
                    return false;
                }
                _context.Vehicles.Remove(vehicleInDb);
                await _context.SaveChangesAsync();
                return true;
            }
            public async Task<bool> UpdateAsync(int id, Vehicle entity)
            {
                var vehicleInDb = await _context.Vehicles.FindAsync(id);
                if (vehicleInDb == null)
                {
                    return false;
                }
                vehicleInDb.VehicleName = entity.VehicleName;
                vehicleInDb.Rating = entity.Rating;
                vehicleInDb.Cost = entity.Cost;
                vehicleInDb.Description = entity.Description;
                vehicleInDb.TotalStock = entity.TotalStock;
                vehicleInDb.Dealer = entity.Dealer;
                vehicleInDb.DealerId = entity.DealerId;
                vehicleInDb.VehicleId = entity.VehicleId;
                vehicleInDb.VehicleModel = entity.VehicleModel;
                
              
                _context.Entry(vehicleInDb).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }

        public async Task<IList<Vehicle>> GetVehicleByRating(int rating)
        {
            var vehicle = await _context.Vehicles.Where(x => x.Rating == rating).ToListAsync();
            return vehicle;
        }

        public async Task<IList<Vehicle>> GetVehicleByName(string name)
        {
            var vehicle = await _context.Vehicles.Where(x => x.VehicleName == name).ToListAsync();
            return vehicle;
        }

        public async Task<IList<Vehicle>> GetVehicleByModel(string model)
        {
            var vehicle = await _context.Vehicles.Where(x => x.VehicleModel == model).ToListAsync();
            return vehicle;
        }

        public Task<IList<Vehicle>> GetVehicleByShowroom(string showroom)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Vehicle>> GetVehicleByDealerId(int dealerId)
        {
            var vehicle = await _context.Vehicles.Where(x => x.DealerId == dealerId).ToListAsync();
            return vehicle;
        }
    }
}
