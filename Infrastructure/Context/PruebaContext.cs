using Domain.Entities;
using Infrastructure.Base;
using Infrastructure.Seedings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Context
{
    public class PruebaContext : DbContextBase
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.HasDefaultSchema("prueba");


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {

                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            }

            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique(true);
            modelBuilder.Entity<User>().HasData(Seed.users);
            modelBuilder.Entity<Person>().HasData(Seed.persons);

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=toor;");
            //optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=prueba;User Id=sa;Password=4015594Wae;");
            optionsBuilder.UseSqlServer(@"Data Source=142.93.117.217;Initial Catalog=prueba;persist security info=True;user id=sa;password=4015594Wae");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { set; get; }

        public DbSet<Person> Persons { set; get; }



    }
}
