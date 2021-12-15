using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinProjectBackend.Models;

namespace XamarinProjectBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CoordInfo> Coordinfo { get; set; }
        public DbSet<CoordInfo2> Coordinfo2 { get; set; }
        public DbSet<ImportedPlaces> importedPlaces{ get; set; }

        public DbSet<AboutUs> aboutUs { get; set; }
    }
}
