using Microsoft.EntityFrameworkCore;
using MS.InfrastructureLayer.Configurations;
using MS.InfrastructureLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.InfrastructureLayer.Context
{
    public class MSContext : DbContext
    {
        public MSContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfigurations).Assembly);
        }
        public DbSet<Student> Students { get; set; }
    }
}
