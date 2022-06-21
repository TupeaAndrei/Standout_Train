using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Standout_Train.DAL.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AquiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Society",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Society", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AqquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TrainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteDistance = table.Column<double>(type: "float", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainStation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    TrainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainStation", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Achievment",
                columns: new[] { "Id", "AquiredDate", "CustomerId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 24, 17, 1, 37, 680, DateTimeKind.Local).AddTicks(2360), 1, "", "Client Silver" },
                    { 2, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "", "Client Bronze" }
                });

            migrationBuilder.InsertData(
                table: "County",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "B (Bucuresti)" },
                    { 2, "AB (Alba)" },
                    { 3, "AR (Arad)" },
                    { 4, "AG (Arges)" },
                    { 5, "BC (Bacau)" },
                    { 6, "BH (Bihor)" },
                    { 7, "BN (Bistrita-Nasaud)" },
                    { 8, "BT (Botosani)" },
                    { 9, "BV (Brasov)" },
                    { 10, "BR (Braila)" },
                    { 11, "BZ(Buzau)" },
                    { 12, "CS (Caras-Severin)" },
                    { 13, "CL (Calarasi)" },
                    { 14, "CJ (Cluj)" },
                    { 15, "CT (Constanta)" },
                    { 16, "CV (Covasna)" },
                    { 17, "DB (Dambovita)" },
                    { 18, "DJ (Dolj)" },
                    { 19, "GL (Galati)" },
                    { 20, "GR (Giurgiu)" },
                    { 21, "GJ (Gorj)" },
                    { 22, "HR (Harghita)" },
                    { 23, "HD (Hunedoara)" },
                    { 24, "IL (Ialomita)" },
                    { 25, "IS (Iasi)" },
                    { 26, "MM (Maramures)" },
                    { 27, "MS (Mures)" },
                    { 28, "NT (Neamt)" },
                    { 29, "OT (Olt)" },
                    { 30, "PH (Prahova)" },
                    { 31, "SM (Satu Mare)" },
                    { 32, "SB (Sibiu)" },
                    { 33, "SV (Suceava)" },
                    { 34, "TR (Teleorman)" },
                    { 35, "TM (Timis)" },
                    { 36, "TL (Tulcea)" },
                    { 37, "VL (Valcea)" },
                    { 38, "VS (Vaslui)" },
                    { 39, "VN (Vrancea)" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Adress", "Age", "EmailAdress", "FirstName", "LastName", "LoyaltyPoints", "PhoneNumber", "ZipCode" },
                values: new object[] { 1, "Str Libertatii", 22, "andreichris55@yahoo.com", "Tupea", "Andrei", 25, "0746670688", "525200" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Adress", "Age", "EmailAdress", "FirstName", "LastName", "LoyaltyPoints", "PhoneNumber", "ZipCode" },
                values: new object[,]
                {
                    { 2, "Strada Iazului", 21, "papuclucian@gmail.com", "Papuc", "Lucian", 5, "0756684988", "535200" },
                    { 3, "Strada Iuliu Maniu", 24, "aCatalin@gmail.com", "Alexandrescu", "Catalin", 0, "0756684755", "500100" }
                });

            migrationBuilder.InsertData(
                table: "Society",
                columns: new[] { "Id", "Created", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Companie detinuta de statul roman infiintata prin reorganizarea fostului CFR.", "CFRCalatori" },
                    { 2, new DateTime(2002, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Firma este deţinută de producătorul de material rulant Softronic.Întregul material rulant al companiei este produs de firma - mamă.", "Softrans" },
                    { 3, new DateTime(2001, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Companie de transport feroviar privata situatie in Transilvania.", "Interregional Calatori" },
                    { 4, new DateTime(2014, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Printr-o politică de îmbunătățire a serviciilor ASTRA TRANS CARPATIC SRL va satisface într-o măsură cât mai mare așteptările pasagerilor, prin creșterea calității călătoriei cu trenul, în pas cu evoluția lumii moderne.", "ASTRA TRANS CARPATIC SRL" }
                });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "CountyId", "Name" },
                values: new object[,]
                {
                    { 1, 35, "Anina" },
                    { 2, 25, "Banca" },
                    { 3, 25, "Bicaz" },
                    { 4, 25, "Botosani" },
                    { 5, 19, "Asau" },
                    { 6, 19, "Barbosi" },
                    { 7, 19, "Berca" },
                    { 8, 15, "Constanta" },
                    { 9, 15, "Costinesti" },
                    { 10, 14, "Beius" },
                    { 11, 14, "Benesat" },
                    { 12, 14, "Boju" },
                    { 13, 1, "Azuga" },
                    { 14, 1, "Armasesti" },
                    { 15, 1, "Bucuresti Baneasa" },
                    { 16, 1, "Bucuresti Grivita" },
                    { 17, 1, "Bucuresti nord" },
                    { 18, 1, "Bucuresti Vest" },
                    { 19, 1, "Bucuresti sud" },
                    { 20, 9, "Aiud" },
                    { 21, 9, "Augustin" },
                    { 22, 9, "Brasov" },
                    { 23, 9, "Cata" },
                    { 24, 9, "Cristian" },
                    { 25, 9, "Fagaras" },
                    { 26, 9, "Ghimbav" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievment");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Society");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Train");

            migrationBuilder.DropTable(
                name: "TrainStation");
        }
    }
}
