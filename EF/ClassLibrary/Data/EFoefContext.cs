using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ClassLibrary.Data
{
    public class EFoefContext : DbContext
    {
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7B94T84\sqlexpress;Initial Catalog=EFoef;Integrated Security=True");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speler>().ToTable("Spelers");
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<Transfer>().ToTable("Transfers");

            
            modelBuilder.Entity<Transfer>()
                .HasOne(tr => tr._speler)
                .WithOne()
                .HasForeignKey<Transfer>(tr => tr._spelerID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transfer>()
                .HasOne(tr => tr.OudeClub)
                .WithOne()
                .HasForeignKey<Transfer>(tr => tr.TeamIDOud).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transfer>()
                .HasOne(tr => tr.NieuweClub)
                .WithOne()
                .HasForeignKey<Transfer>(tr => tr.TeamIDONieuw).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>()
                .HasMany(te => te._spelers)
                .WithOne(s => s._Team);

            modelBuilder.Entity<Speler>()
                .HasOne(s => s._Team)
                .WithMany(te => te._spelers);

        }
    }
}
