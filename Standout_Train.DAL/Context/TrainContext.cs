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

        }
    }
}
