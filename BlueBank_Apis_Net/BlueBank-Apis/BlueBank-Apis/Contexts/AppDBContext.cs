using BlueBank_Apis.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBank_Apis.Contexts
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options)
        {

        }

        public DbSet<Personas> personas { get; set; }
        
    }
}
