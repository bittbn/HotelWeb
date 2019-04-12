using HotelWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Context
{
    public class HotelDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentType> ApartmentTypes { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<UserVisitor> UserVisitors { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }
    }
}
