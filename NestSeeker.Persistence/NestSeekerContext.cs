﻿using Microsoft.EntityFrameworkCore;
using NestSeeker.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NestSeeker.Persistence
{
    public class NestSeekerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Data.Model.Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Requests> Request { get; set; }
        public DbSet<MyFavourites> MyFavourite { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<BHKType> BHKTypes { get; set; }
        public DbSet<Document> Documents { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=SNEHAL-PC\\SQLEXPRESS02\\MYSQLSERVER;Initial Catalog=NestSeekerDatabase; Integrated Security=True";
  
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //for User 
            modelBuilder.Entity<User>().Property(b => b.FirstName).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<User>().Property(b => b.LastName).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<User>().Property(b => b.Address).HasColumnType("varchar(500)").IsRequired();
            modelBuilder.Entity<User>().Property(b => b.City).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(b => b.Pin).HasColumnType("varchar(6)").IsRequired();
            modelBuilder.Entity<User>().Property(b => b.Mobile).HasColumnType("varchar(20)").IsRequired();
            modelBuilder.Entity<User>().Property(b => b.Email).HasColumnType("varchar(200)").IsRequired();
           
            //for Role
            modelBuilder.Entity<Role>().Property(b => b.Name).HasColumnType("varchar(200)").IsRequired();
           
            //For UserRole
            modelBuilder.Entity<UserRole>().HasOne(b => b.User).WithMany(b => b.UsersRoles).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRole>().HasOne(b => b.Role).WithMany(b => b.UserRoles).HasForeignKey(b => b.RoleId).OnDelete(DeleteBehavior.NoAction);
           
            //for Property
            modelBuilder.Entity<Data.Model.Property>().Property(b => b.Address).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Data.Model.Property>().Property(b => b.City).HasColumnType("varchar(20)").IsRequired();
            modelBuilder.Entity<Data.Model.Property>().Property(b => b.Amenities).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Data.Model.Property>().Property(b => b.ConstructionYear).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<Data.Model.Property>().Property(b => b.Landmarks).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Data.Model.Property>().Property(b => b.Parking).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Data.Model.Property>().Property(b => b.State).HasColumnType("varchar(100)").IsRequired();

            modelBuilder.Entity<Data.Model.Property>().HasOne<PropertyType>(pt => pt.PropertyTypes).WithMany(p => p.Property).HasForeignKey(pt => pt.PropertyType).OnDelete(DeleteBehavior.NoAction);
        
            modelBuilder.Entity<Data.Model.Property>().HasOne<BHKType>(pt => pt.BHKType).WithMany(p => p.Property).HasForeignKey(pt => pt.BHKTypeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Data.Model.Property>().HasOne<Status>(pt => pt.Status).WithMany(p => p.Property).HasForeignKey(pt => pt.StatusId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Data.Model.Property>().HasOne<UserRole>(pt => pt.UserRole).WithMany(p => p.Property).HasForeignKey(pt => pt.OwnerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Data.Model.Property>().HasOne<Direction>(pt => pt.Direction).WithMany(p => p.Property).HasForeignKey(pt => pt.DirectionId).OnDelete(DeleteBehavior.NoAction);
            
            //For PropertyType
            modelBuilder.Entity<PropertyType>().Property(b => b.Description).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<PropertyType>().Property(b => b.Name).HasColumnType("varchar(150)").IsRequired();


            //for MyFavourites
            modelBuilder.Entity<MyFavourites>().HasOne<UserRole>(mf => mf.UserRole).WithMany(p => p.MyFavourites).HasForeignKey(mf => mf.UserRoleId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MyFavourites>().HasOne<Data.Model.Property>(mf => mf.Property).WithMany(p => p.MyFavourites).HasForeignKey(mf => mf.PropertyId).OnDelete(DeleteBehavior.NoAction);

            //For Requests
            modelBuilder.Entity<Requests>().Property(b => b.Rate).HasColumnType("decimal(14,2)").IsRequired();
            modelBuilder.Entity<Requests>().Property(b => b.AmountRequested).HasColumnType("decimal(14,2)").IsRequired();
            modelBuilder.Entity<Requests>().Property(b => b.AvailiableOn).HasDefaultValueSql("getdate()").IsRequired();
            modelBuilder.Entity<Requests>().Property(b => b.DateAdded).HasDefaultValueSql("getdate()").IsRequired();
            modelBuilder.Entity<Requests>().HasOne<Data.Model.Property>(r => r.Property).WithMany(p => p.Request).HasForeignKey(r => r.PropertyId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Requests>().HasOne<Data.Model.TransactionType>(r => r.TransactionTypes).WithMany(p => p.Request).HasForeignKey(r => r.TransactionType).OnDelete(DeleteBehavior.NoAction);

            //For Direction
            modelBuilder.Entity<Direction>().Property(b => b.Name).HasColumnType("varchar(100)").IsRequired();

            //For Status
            modelBuilder.Entity<Status>().Property(b => b.Name).HasColumnType("varchar(100)").IsRequired();

            //For BHK Type
            modelBuilder.Entity<BHKType>().Property(b => b.Name).HasColumnType("varchar(100)").IsRequired();

            //For Transaction Type
            modelBuilder.Entity<TransactionType>().Property(b => b.Name).HasColumnType("varchar(50)").IsRequired();

            //For Documents
            modelBuilder.Entity<Document>().Property(b => b.Name).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Document>().HasOne(b => b.Property).WithMany(b => b.Documents).HasForeignKey(b => b.PropertyId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Document>().Property(dc => dc.Value).IsRowVersion();

        }

        /*private bool HasForeignKey(Func<object, object> p)
        {
            throw new NotImplementedException();
        }*/
    }
}

