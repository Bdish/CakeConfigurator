using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CakeConfiguratorDB : DbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitCode> Codes { get; set; }
        public DbSet<UnitName> Names { get; set; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
        public DbSet<UnitPrice> Prices { get; set; }
        public DbSet<UnitType> Types { get; set; }
        public DbSet<QuantityInUnit> QuantityInUnits { get; set; }

        public CakeConfiguratorDB() : base("DbConnection")
        {
                       
        }
  
    }
}
