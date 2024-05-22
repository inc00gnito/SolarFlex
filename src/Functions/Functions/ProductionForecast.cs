using System;
using ApiFetchers.Models;
using Azure;
using Functions.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Functions.Functions
{
    public class ProductionForecast
    {
        private readonly ILogger _logger;
        private readonly IDatabaseService _dbService;
        private readonly ISolarPowerService _solarPowerService;

        public ProductionForecast(ILoggerFactory loggerFactory, IDatabaseService dbService, ISolarPowerService solarPowerService)
        {
            _logger = loggerFactory.CreateLogger<ProductionForecast>();
            _dbService = dbService;
            _solarPowerService = solarPowerService;
        }

        [Function("ProductionForecast")]
        public async Task Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer, CancellationToken ct)
        {
            try
            {
                // Get required Building stuff to call apis
                var buildings = await _dbService.GetBuildingDataAsync();
                foreach (var building in buildings)
                {
                    _logger.LogInformation("Building: {Latitude}, {Longitude}, {Azimuth}, {PvMaximumPower}.", building.Latitude, building.Longitude, building.Azimuth, building.PvMaximumPower);
                    // call SolarPowerService to get the forecast
                    var spResponse = _solarPowerService.GetDataAsync(building, ct);
                    var spResult = JsonConvert.DeserializeObject<SolarPowerResult>(spResponse.Result);
                    _logger.LogInformation(spResult.Result.ToString());
                    // call WindApi to get wind
                    // do forecast stuff
                    // save forecast to database
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error while executinng ProductionForecast function: {ex.Message}");
            }

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"SolarPowerForecast function ended at: {DateTime.Now}");
                _logger.LogInformation($"Next function execution at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
