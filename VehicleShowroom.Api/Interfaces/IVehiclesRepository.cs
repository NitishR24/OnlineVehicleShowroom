using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleShowroom.Api.Models;

namespace VehicleShowroom.Api.Interfaces
{
    public interface IVehiclesRepository : IGenericRepository<Vehicle>
    {
        Task<IList<Vehicle>> GetVehicleByRating(int rating);
        Task<IList<Vehicle>> GetVehicleByName(string name);
        Task<IList<Vehicle>> GetVehicleByModel(string model);
        Task<IList<Vehicle>> GetVehicleByShowroom(string showroom);
        Task<IList<Vehicle>> GetVehicleByDealerId(int dealerId);

    }
}
