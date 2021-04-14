using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

//Last updated: 4-13-2021
//Context file for our database

namespace BYU_FEG.Models
{
    public partial class BYUFEGContext : DbContext
    {

        public BYUFEGContext(DbContextOptions<BYUFEGContext> options)
            : base(options)
        {
        }

        public BYUFEGContext() //Added for RDS
        {

        }

        public static BYUFEGContext Create() //Added for RDS
        {
            return new BYUFEGContext();
        }
        //tables in database
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Burial> Burial { get; set; }
        public virtual DbSet<Byufeg> Byufeg { get; set; }

        public virtual DbSet<UserPermission> UserPermission { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //conection string
                optionsBuilder.UseSqlServer("Data Source=(local);initial catalog=BYUFEG; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Attachment>(entity =>
            {
                //foreign key
                entity.HasOne(d => d.Byufeg)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.ByufegId)
                    .HasConstraintName("FK__Attachmen__Byufe__5CD6CB2B");
            });

            modelBuilder.Entity<Burial>(entity =>
            {
            });

            modelBuilder.Entity<Byufeg>(entity =>
            {
                //foreign key
                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Byufeg)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK__Byufeg__Burial_I__571DF1D5");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
