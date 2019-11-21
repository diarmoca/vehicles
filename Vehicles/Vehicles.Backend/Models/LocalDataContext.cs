using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicles.Domain.Models;

namespace Vehicles.Backend.Models
{
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Vehicles.Common.Models.Vehicle> Vehicles { get; set; }
    }
}