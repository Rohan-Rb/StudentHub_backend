using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Models
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Events> Events
        {
            get;
            set;
        }

        public DbSet<Roles> Roles
        {
            get;
            set;
        }

        public DbSet<Users> Users
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
        public DbSet<Job> Job
        {
            get;
            set;
        }
    }
}
