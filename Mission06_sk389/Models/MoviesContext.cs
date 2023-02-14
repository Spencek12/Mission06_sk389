using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission06_sk389.Models
{
    public class MoviesContext : DbContext
    {
        //Constructor
        public MoviesContext (DbContextOptions<MoviesContext> options): base(options)
        {
            //Leave blank for now
        }

        public DbSet <ApplicationResponse> Responses { get; set; }
        
    }
}
