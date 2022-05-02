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
    }
}
