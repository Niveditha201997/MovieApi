using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;

namespace MovieData
{
        public class AllDbContext :DbContext
        {
            public AllDbContext()
            {
            }

        public AllDbContext(DbContextOptions<AllDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Theatre> theatre { get; set; }
        public DbSet<ShowTimings> showTimings { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Location> locations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data source=VDC01LTC2013;Initial Catalog=MovieProjectDb; Integrated Security=True;");
        }
    }
}
