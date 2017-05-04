using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CTDISample.Models
{
    public class CTDIContext : DbContext
    {
        public DbSet<VEHICLE> Vehicles { get; set; }

    }
}