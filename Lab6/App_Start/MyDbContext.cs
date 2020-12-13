using Lab6.Models;
using System.Data.Entity;

namespace Lab6.App_Start
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=labs") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Stadium> Stadia { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
    }
}