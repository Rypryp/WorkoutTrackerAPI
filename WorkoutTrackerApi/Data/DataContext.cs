using System;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutTrackerApi.Models.Identity;

namespace WorkoutTrackerApi.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToContainer("Users");
            modelBuilder.Entity<IdentityUser>().HasPartitionKey(c => c.Email);

            modelBuilder.Entity<IdentityUser>()
                .Property(b => b.ConcurrencyStamp)
                .IsETagConcurrency();

            modelBuilder.Entity<IdentityRole>()
                .Property(b => b.ConcurrencyStamp)
                .IsETagConcurrency();

            modelBuilder.Entity<RefreshToken>().ToContainer("RefreshTokens");


        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
