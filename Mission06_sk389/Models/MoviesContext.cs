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
        public DbSet<Category> Categories { get; set; }

        //Seed data
        protected override void OnModelCreating (ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );
        }
        
    }
}
