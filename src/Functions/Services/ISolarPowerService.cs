using Functions.Models;

namespace Functions.Services
{
    public interface ISolarPowerService
    {
        Task<string> GetDataAsync(BuildingDTO parameters, CancellationToken ct);
    }
}
