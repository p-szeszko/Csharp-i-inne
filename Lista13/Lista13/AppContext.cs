using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lista13
{
    public class AppContext:DbContext
    {

        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
       
        public DbSet<DataModel> Data { get; set; }
    }
    
}
