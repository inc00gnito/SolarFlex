using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Functions.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingsConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    GridConnectionPower = table.Column<float>(type: "real", nullable: false),
                    EnergyPricesId = table.Column<int>(type: "integer", nullable: false),
                    FlatCount = table.Column<int>(type: "integer", nullable: false),
                    FlatMaxPower = table.Column<float>(type: "real", nullable: false),
                    CommunalDayPower = table.Column<decimal>(type: "numeric", nullable: false),
                    CommunalNightPower = table.Column<decimal>(type: "numeric", nullable: false),
                    PvMaximumPower = table.Column<float>(type: "real", nullable: false),
                    MountAngle = table.Column<float>(type: "real", nullable: false),
                    Azimuth = table.Column<float>(type: "real", nullable: false),
                    WindTurbineMinPowerSpeed = table.Column<decimal>(type: "numeric", nullable: false),
                    WindTurbineMinPower = table.Column<decimal>(type: "numeric", nullable: false),
                    WindTurbineTypicalPowerSpeed = table.Column<decimal>(type: "numeric", nullable: false),
                    WindTurbineTypicalPower = table.Column<decimal>(type: "numeric", nullable: false),
                    WindTurbineMaxPowerSpeed = table.Column<decimal>(type: "numeric", nullable: false),
                    WindTurbineMaxPower = table.Column<decimal>(type: "numeric", nullable: false),
                    BatteryCapacity = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingsConfigurations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingsConfigurations");
        }
    }
}
