using MvcAppSearch.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcAppSearch.Form
{
    public class DRdb : DbContext
    {
        public DbSet<Inmate> Inmates { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Officer> Officers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}