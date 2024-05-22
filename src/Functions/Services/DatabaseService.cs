using Functions.Data;
using Functions.Models;
using Microsoft.EntityFrameworkCore;
namespace Functions.Services
{
    public class DatabaseService(DatabaseContext db) : IDatabaseService
    {
        public async Task<IEnumerable<BuildingDTO>> GetBuildingDataAsync()
        {
            var buildingDTO = await db.BuildingsConfigurations
                .Select(x => new BuildingDTO
                {
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Declination = 0,
                    Azimuth = x.Azimuth,
                    PvMaximumPower = x.PvMaximumPower
                })
                .ToListAsync();

            return buildingDTO;
        }
    }
}
