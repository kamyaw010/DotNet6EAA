﻿using Microsoft.EntityFrameworkCore;
using Business.Departments;
using Business.Users;
using Business.Base;

namespace Data.EF
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Payslip> Payslips { get; set; }
        public EFContext() { } // for EF power tool
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(); // for EF power tool
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<BaseEntity>(
            //        eb =>
            //        {
            //            eb.Ignore(c => c.Events);
            //        });
            //modelBuilder.Entity<RootEntity>().Ignore(c => c.Events);
            modelBuilder.Ignore<RootEntity>().Ignore<BaseDomainEvent>();

            modelBuilder.Entity<User>().HasIndex(b => b.UserName).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(b => b.Name).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}