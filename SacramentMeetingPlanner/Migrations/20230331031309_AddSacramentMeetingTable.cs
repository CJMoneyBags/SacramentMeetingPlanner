using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddSacramentMeetingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SacramentMeeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConductingLeaderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningHymn = table.Column<int>(type: "int", nullable: false),
                    SacramentHymn = table.Column<int>(type: "int", nullable: false),
                    IntermediateHymnOrMusicalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingHymn = table.Column<int>(type: "int", nullable: false),
                    OpeningPrayerPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClosingPrayerPerson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentMeeting", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SacramentMeeting");
        }
    }
}
