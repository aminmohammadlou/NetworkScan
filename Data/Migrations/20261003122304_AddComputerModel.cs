using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddComputerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComputerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MainBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<int>(type: "int", nullable: false),
                    Vga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpticalDrive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SealNumber1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SealNumber2 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastSecurityUpdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Programs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.ComputerId);
                });

            migrationBuilder.CreateTable(
                name: "HardDisks",
                columns: table => new
                {
                    HardDiskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDisks", x => x.HardDiskId);
                    table.ForeignKey(
                        name: "FK_HardDisks_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "ComputerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_AssetCode",
                table: "Computers",
                column: "AssetCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ComputerName",
                table: "Computers",
                column: "ComputerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MacAddress",
                table: "Computers",
                column: "MacAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_SealNumber1",
                table: "Computers",
                column: "SealNumber1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_SealNumber2",
                table: "Computers",
                column: "SealNumber2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardDisks_ComputerId",
                table: "HardDisks",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_HardDisks_SerialNumber",
                table: "HardDisks",
                column: "SerialNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardDisks");

            migrationBuilder.DropTable(
                name: "Computers");
        }
    }
}
