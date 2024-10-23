using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CompeteNow.Profile.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CompeteNow.Profile.Infrastructure
{
    public class profileDbContext : DbContext
    {
        // For a example, if you have a model called Sample Model

        // public DbSet<SampleModel> SampleModels { get; set; }
        //public DbSet<Author> Authors { get; set; }

        public profileDbContext(DbContextOptions<profileDbContext> options) : base(options)
        {

        }

        public profileDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=tcp:competenewserver.database.windows.net,1433;Initial Catalog=competenew;Persist Security Info=False;User ID=tharusha;Password=dinuth@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}