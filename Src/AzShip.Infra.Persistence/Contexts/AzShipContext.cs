using AzShip.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzShip.Infra.Persistence.Contexts
{
    public class AzShipContext : DbContext
    {
        public virtual DbSet<Cargo> Cargos { get; set; }

        public AzShipContext()
        {

        }

        public AzShipContext(DbContextOptions<AzShipContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use your own connection string, it's only a test local database
                optionsBuilder.UseSqlServer(@"Server=localhost\VINILOCALDB;
                                              Initial Catalog=local-azship-db;
                                              Persist Security Info=False;
                                              User ID=sa;
                                              Password=Password@123;
                                              MultipleActiveResultSets=False;
                                              Encrypt=False;
                                              TrustServerCertificate=False;
                                              Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>().ToTable("Cargo");
        }
    }
}
