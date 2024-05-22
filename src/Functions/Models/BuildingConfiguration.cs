using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Models
{
    public class BuildingConfiguration
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float GridConnectionPower { get; set; }
        public int EnergyPricesId { get; set; }
        public int FlatCount { get; set; }
        public float FlatMaxPower { get; set; }
        public decimal CommunalDayPower { get; set; }
        public decimal CommunalNightPower { get; set; }
        public float PvMaximumPower { get; set; }
        public float MountAngle { get; set; }
        public float Azimuth { get; set; }
        public decimal WindTurbineMinPowerSpeed { get; set; }
        public decimal WindTurbineMinPower { get; set; }
        public decimal WindTurbineTypicalPowerSpeed { get; set; }
        public decimal WindTurbineTypicalPower { get; set; }
        public decimal WindTurbineMaxPowerSpeed { get; set; }
        public decimal WindTurbineMaxPower { get; set; }
        public decimal BatteryCapacity { get; set; }

    }
    public class BuildingDTO
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float Declination { get; set; }
        public float Azimuth { get; set; }
        public float PvMaximumPower { get; set; }
    }
}
