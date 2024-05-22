using ApiFetchers.Models;
using Functions.Models;
using Functions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Services
{
    internal class SolarPowerService : ISolarPowerService
    {
        private static readonly string _PATH = "estimate/watthours/day";
        private readonly HttpClient _httpClient;
        private readonly ILogger<SolarPowerService> _logger;

        public SolarPowerService(HttpClient httpClient, ILogger<SolarPowerService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<string> GetDataAsync(BuildingDTO buildingConfig, CancellationToken ct)
        {
            // fix this
            var _requestPath = _PATH + $"/{buildingConfig.Longitude}/{buildingConfig.Latitude}/{buildingConfig.Declination}/{buildingConfig.Azimuth}/{buildingConfig.PvMaximumPower}";
            _logger.LogDebug($"Fetching data from API: {_requestPath} {_httpClient.BaseAddress}");

            HttpResponseMessage result = await _httpClient.GetAsync(_requestPath, ct);

            string resultContent = await result.Content.ReadAsStringAsync(ct);

            if (!result.IsSuccessStatusCode)
            {
                _logger.LogError($"Error fetching data. Got {result.StatusCode}. Reason: {result.ReasonPhrase}\nDetails: {resultContent}" ?? "Unknown reason.");
            }

            return resultContent;
        }
    }
}
