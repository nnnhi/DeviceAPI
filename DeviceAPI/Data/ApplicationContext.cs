using System;
using DeviceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relation>()
                .HasKey(o => new { o.FromId, o.ToId });


            modelBuilder.Entity<Relation>()
             .HasOne(e => e.DeviceTo)
             .WithMany(e => e.RelatedFromDevices)
             .HasForeignKey(e => e.ToId);

            modelBuilder.Entity<Relation>()
    .HasOne(e => e.DeviceFrom)
    .WithMany(e => e.RelatedToDevices)
    .HasForeignKey(e => e.FromId);

        }


        public DbSet<Device> Devices { get; set; }
        public DbSet<Relation> Relations { get; set; }
    }
}
