using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BYU_FEG.Models
{
    public partial class BYUFEGContext : DbContext
    {

        public BYUFEGContext(DbContextOptions<BYUFEGContext> options)
            : base(options)
        {
        }

        public BYUFEGContext() //add this change
        {

        }

        public static BYUFEGContext Create() //Add this change
        {
            return new BYUFEGContext();
        }

        //public virtual DbSet<Activity> Activity { get; set; }
        //public virtual DbSet<ActivityToPerson> ActivityToPerson { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Burial> Burial { get; set; }
        public virtual DbSet<Byufeg> Byufeg { get; set; }

        public virtual DbSet<UserPermission> UserPermission { get; set; }
        //public virtual DbSet<Person> Person { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(local);initial catalog=BYUFEG; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Activity>(entity =>
            //{
            //    entity.Property(e => e.ActivityId).ValueGeneratedNever();
            //});

            //modelBuilder.Entity<ActivityToPerson>(entity =>
            //{
            //    entity.Property(e => e.ActivityToPersonId).ValueGeneratedNever();

            //    entity.HasOne(d => d.Activity)
            //        .WithMany(p => p.ActivityToPerson)
            //        .HasForeignKey(d => d.ActivityId)
            //        .HasConstraintName("FK__ActivityT__Activ__534D60F1");

            //    entity.HasOne(d => d.Person)
            //        .WithMany(p => p.ActivityToPerson)
            //        .HasForeignKey(d => d.PersonId)
            //        .HasConstraintName("FK__ActivityT__Perso__5441852A");
            //});

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.AttachmentId).ValueGeneratedNever();

                entity.HasOne(d => d.Byufeg)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.ByufegId)
                    .HasConstraintName("FK__Attachmen__Byufe__5CD6CB2B");
            });

            modelBuilder.Entity<Burial>(entity =>
            {
                entity.Property(e => e.BurialId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Byufeg>(entity =>
            {
                entity.Property(e => e.ByufegId).ValueGeneratedNever();

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Byufeg)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK__Byufeg__Burial_I__571DF1D5");
            });

            //modelBuilder.Entity<Person>(entity =>
            //{
            //    entity.Property(e => e.PersonId).ValueGeneratedNever();
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
