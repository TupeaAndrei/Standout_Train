using Microsoft.EntityFrameworkCore;
using Standout_Train.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.DAL.Context
{
    public class TrainContext : DbContext
    {
        public TrainContext(DbContextOptions<TrainContext> options) : base(options)
        {

        }

        public DbSet<Achievments> Achievment { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Society> Society {  get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Train> Train { get; set; }
        public DbSet<TrainStation> TrainStation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Tupea",
                    LastName = "Andrei",
                    Age = 22,
                    Adress = "Str Libertatii",
                    LoyaltyPoints = 25,
                    ZipCode = "525200",
                    EmailAdress = "andreichris55@yahoo.com",
                    PhoneNumber = "0746670688"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Papuc",
                    LastName = "Lucian",
                    Age = 21,
                    ZipCode = "535200",
                    Adress = "Strada Iazului",
                    EmailAdress = "papuclucian@gmail.com",
                    PhoneNumber = "0756684988",
                    LoyaltyPoints = 5
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Alexandrescu",
                    LastName = "Catalin",
                    Age = 24,
                    ZipCode = "500100",
                    Adress = "Strada Iuliu Maniu",
                    EmailAdress = "aCatalin@gmail.com",
                    LoyaltyPoints = 0,
                    PhoneNumber = "0756684755"
                });
            modelBuilder.Entity<Achievments>().HasData(
                new Achievments
                {
                    Id = 1,
                    CustomerId = 1,
                    AquiredDate = DateTime.Now,
                    Description = "",
                    Name = "Client Silver"
                },
                new Achievments
                {
                    Id = 2,
                    CustomerId = 2,
                    AquiredDate = new DateTime(2022, 1, 3),
                    Name = "Client Bronze",
                    Description = ""
                }
                );
            modelBuilder.Entity<Society>().HasData(
                new Society
                {
                    Id = 1,
                    Name = "CFRCalatori",
                    Description = "Companie detinuta de statul roman infiintata prin reorganizarea fostului CFR.",
                    Created = new DateTime(1998, 5, 3)
                },
                new Society
                {
                    Id = 2,
                    Name = "Softrans",
                    Description = "Firma este deţinută de producătorul de material rulant Softronic.Întregul material rulant al companiei este produs de firma - mamă.",
                    Created = new DateTime(2002,11,3)
                },
                new Society
                {
                    Id = 3,
                    Name = "Interregional Calatori",
                    Description = "Companie de transport feroviar privata situatie in Transilvania.",
                    Created = new DateTime(2001,6,3)
                },
                new Society
                {
                    Id = 4,
                    Name = "ASTRA TRANS CARPATIC SRL",
                    Description = "Printr-o politică de îmbunătățire a serviciilor ASTRA TRANS CARPATIC SRL va satisface într-o măsură cât mai mare așteptările pasagerilor, prin creșterea calității călătoriei cu trenul, în pas cu evoluția lumii moderne.",
                    Created = new DateTime(2014,1,5)
                });
            modelBuilder.Entity<County>().HasData(
                new County
                {
                    Id = 1,
                    Name = "B (Bucuresti)",
                },
                new County
                {
                    Id = 2,
                    Name = "AB (Alba)"
                },
                new County
                {
                    Id = 3,
                    Name = "AR (Arad)"
                },
                new County
                {
                    Id = 4,
                    Name = "AG (Arges)"
                },
                new County
                {
                    Id = 5,
                    Name = "BC (Bacau)"
                },
                new County
                {
                    Id = 6,
                    Name = "BH (Bihor)"
                },
                new County
                {
                    Id = 7,
                    Name = "BN (Bistrita-Nasaud)"
                },
                new County
                {
                    Id = 8,
                    Name = "BT (Botosani)"
                },
                new County
                {
                    Id = 9,
                    Name = "BV (Brasov)"
                },
                new County
                {
                    Id = 10,
                    Name = "BR (Braila)"
                },
                new County
                {
                    Id = 11,
                    Name = "BZ(Buzau)"
                },
                new County
                {
                    Id = 12,
                    Name = "CS (Caras-Severin)"
                },
                new County
                {
                    Id = 13,
                    Name = "CL (Calarasi)"
                },
                new County
                {
                    Id = 14,
                    Name = "CJ (Cluj)"
                },
                new County
                {
                    Id = 15,
                    Name = "CT (Constanta)"
                },
                new County
                {
                    Id = 16,
                    Name = "CV (Covasna)"
                },
                new County
                {
                    Id = 17,
                    Name = "DB (Dambovita)"
                },
                new County
                {
                    Id = 18,
                    Name = "DJ (Dolj)"
                },
                new County
                {
                    Id = 19,
                    Name = "GL (Galati)"
                },
                new County
                {
                    Id = 20,
                    Name = "GR (Giurgiu)"
                },
                new County
                {
                    Id = 21,
                    Name = "GJ (Gorj)"
                },
                new County
                {
                    Id = 22,
                    Name = "HR (Harghita)"
                },
                new County
                {
                    Id = 23,
                    Name = "HD (Hunedoara)"
                },
                new County
                {
                    Id = 24,
                    Name = "IL (Ialomita)"
                },
                new County
                {
                    Id = 25,
                    Name = "IS (Iasi)"
                },
                new County
                {
                    Id = 26,
                    Name = "MM (Maramures)"
                },
                new County
                {
                    Id = 27,
                    Name = "MS (Mures)"
                },
                new County
                {
                    Id = 28,
                    Name = "NT (Neamt)"
                },
                new County
                {
                    Id = 29,
                    Name = "OT (Olt)"
                },
                new County
                {
                    Id = 30,
                    Name = "PH (Prahova)"
                },
                new County
                {
                    Id = 31,
                    Name = "SM (Satu Mare)"
                },
                new County
                {
                    Id = 32,
                    Name = "SB (Sibiu)"
                },
                new County
                {
                    Id = 33,
                    Name = "SV (Suceava)"
                },
                new County
                {
                    Id = 34,
                    Name = "TR (Teleorman)"
                },
                new County
                {
                    Id = 35,
                    Name = "TM (Timis)"
                },
                new County
                {
                    Id = 36,
                    Name = "TL (Tulcea)"
                },
                new County
                {
                    Id = 37,
                    Name = "VL (Valcea)"
                },
                new County
                {
                    Id = 38,
                    Name = "VS (Vaslui)"
                },
                new County
                {
                    Id = 39,
                    Name = "VN (Vrancea)"
                });
            modelBuilder.Entity<Station>().HasData(
                new Station
                {
                    Id = 1,
                    CountyId = 35,
                    Name = "Anina"
                },
                new Station
                {
                    Id = 2,
                    CountyId = 25,
                    Name = "Banca"
                },
                new Station
                {
                    Id = 3,
                    CountyId = 25,
                    Name = "Bicaz"
                },
                new Station
                {
                    Id = 4,
                    Name = "Botosani",
                    CountyId = 25,
                },
                new Station
                {
                    Id = 5,
                    CountyId = 19,
                    Name = "Asau"
                },
                new Station
                {
                    Id = 6,
                    CountyId = 19,
                    Name = "Barbosi"
                },
                new Station
                {
                    Id = 7,
                    CountyId = 19,
                    Name = "Berca"
                },
                new Station
                {
                    Id = 8,
                    CountyId = 15,
                    Name = "Constanta"
                },
                new Station
                {
                    Id = 9,
                    CountyId = 15,
                    Name = "Costinesti"
                },
                new Station
                {
                    Id = 10,
                    CountyId = 14,
                    Name = "Beius"
                },
                new Station
                {
                    Id = 11,
                    CountyId = 14,
                    Name = "Benesat"
                },
                new Station
                {
                    Id = 12,
                    CountyId = 14,
                    Name = "Boju"
                },
                new Station
                {
                    Id = 13,
                    CountyId = 1,
                    Name = "Azuga"
                },
                new Station
                {
                    Id = 14,
                    CountyId = 1,
                    Name = "Armasesti"
                },
                new Station
                {
                    Id = 15,
                    CountyId = 1,
                    Name = "Bucuresti Baneasa"
                },
                new Station
                {
                    Id = 16,
                    CountyId = 1,
                    Name = "Bucuresti Grivita"
                },
                new Station
                {
                    Id = 17,
                    CountyId = 1,
                    Name = "Bucuresti nord"
                },
                new Station
                {
                    Id = 18,
                    CountyId = 1,
                    Name = "Bucuresti Vest"
                },
                new Station
                {
                    Id = 19,
                    CountyId = 1,
                    Name = "Bucuresti sud"
                },
                new Station
                {
                    Id = 20,
                    CountyId = 9,
                    Name = "Aiud"
                },
                new Station
                {
                    Id = 21,
                    CountyId = 9,
                    Name = "Augustin"
                },
                new Station
                {
                    Id = 22,
                    CountyId = 9,
                    Name = "Brasov"
                },
                new Station
                {
                    Id = 23,
                    CountyId = 9,
                    Name = "Cata"
                },
                new Station
                {
                    Id = 24,
                    CountyId = 9,
                    Name = "Cristian"
                },
                new Station
                {
                    Id = 25,
                    CountyId = 9,
                    Name = "Fagaras"
                },
                new Station
                {
                    Id = 26,
                    CountyId = 9,
                    Name = "Ghimbav"
                }
                );
            modelBuilder.Entity<Train>().HasData(
                new Train
                {
                    Id = 1,
                    Name = "IRN1941",
                    DepartureCity = "Brasov",
                    ArrivalCity = "Bucuresti",
                    DepartureTime = new TimeSpan(1,17,0),
                    ArrivalTime = new TimeSpan(3,58,0),
                    Number = 1941,
                    SocietyId = 3,
                    RouteDistance = 165,
                    Type = "IRN"
                },
                new Train
                {
                    Id = 2,
                    Name = "IRN1932",
                    DepartureCity = "Brasov",
                    ArrivalCity = "Bucuresti",
                    DepartureTime = new TimeSpan(2, 22, 0),
                    ArrivalTime = new TimeSpan(5, 5, 0),
                    Number = 1932,
                    SocietyId = 3,
                    RouteDistance = 165,
                    Type = "IRN"
                },
                 new Train
                 {
                     Id = 3,
                     Name = "IR1734",
                     DepartureCity = "Brasov",
                     ArrivalCity = "Bucuresti",
                     DepartureTime = new TimeSpan(16, 56, 0),
                     ArrivalTime = new TimeSpan(19, 34, 0),
                     Number = 1734,
                     SocietyId = 1,
                     RouteDistance = 166,
                     Type = "IR"
                 },
                 new Train
                 {
                     Id = 4,
                     Name = "R-E11536",
                     DepartureCity = "Brasov",
                     ArrivalCity = "Bucuresti",
                     DepartureTime = new TimeSpan(17, 25, 0),
                     ArrivalTime = new TimeSpan(19, 58, 0),
                     Number = 1136,
                     SocietyId = 4,
                     RouteDistance = 166,
                     Type = "R-E"
                 },
                 new Train
                 {
                     Id = 5,
                     Name = "R-E11538",
                     DepartureCity = "Brasov",
                     ArrivalCity = "Bucuresti",
                     DepartureTime = new TimeSpan(18, 38, 0),
                     ArrivalTime = new TimeSpan(21, 13, 0),
                     Number = 11538,
                     SocietyId = 4,
                     RouteDistance = 166,
                     Type = "R-E"
                 },
                  new Train
                  {
                      Id = 6,
                      Name = "IRN1941",
                      DepartureCity = "Brasov",
                      ArrivalCity = "Constanta",
                      DepartureTime = new TimeSpan(1, 8, 0),
                      ArrivalTime = new TimeSpan(6, 29, 0),
                      Number = 1941,
                      SocietyId = 1,
                      RouteDistance = 383,
                      Type = "IRN"
                  },
                   new Train
                   {
                       Id = 7,
                       Name = "IRN1884",
                       DepartureCity = "Brasov",
                       ArrivalCity = "Constanta",
                       DepartureTime = new TimeSpan(7, 12, 0),
                       ArrivalTime = new TimeSpan(11,32,0),
                       Number = 1884,
                       SocietyId = 1,
                       RouteDistance = 390,
                       Type = "IRN"
                   },
                    new Train
                    {
                        Id = 8,
                        Name = "IRN1741",
                        DepartureCity = "Brasov",
                        ArrivalCity = "Bucuresti",
                        DepartureTime = new TimeSpan(18, 38, 0),
                        ArrivalTime = new TimeSpan(7, 10, 0),
                        Number = 1741,
                        SocietyId = 1,
                        RouteDistance = 649,
                        Type = "IRN"
                    },
                     new Train
                     {
                         Id = 9,
                         Name = "IR1623",
                         DepartureCity = "Bucuresti",
                         ArrivalCity = "Sibiu",
                         DepartureTime = new TimeSpan(9, 55, 0),
                         ArrivalTime = new TimeSpan(15, 41, 0),
                         Number = 1623,
                         SocietyId = 1,
                         RouteDistance = 315,
                         Type = "IR"
                     });

        }
    }
}
