


namespace Vehicles.Domain.Models
{
    using System.Data.Entity;
    using Vehicles.Common.Models;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
