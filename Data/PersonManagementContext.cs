using Microsoft.EntityFrameworkCore;
using PersonManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Data
{
    public class PersonManagementContext : DbContext
    {
        public PersonManagementContext(DbContextOptions<PersonManagementContext> options) : base(options)
        {
        }
            public DbSet<Department> Department { get; set; }
            public DbSet<Person> Person { get; set; }
            public DbSet<Position> Position { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Position>().ToTable("Position");
        }
    }
}
