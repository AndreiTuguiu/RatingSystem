//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using RatingSystem.Models;

//#nullable disable

//namespace RatingSystem.Data
//{
//    public partial class RatingDbContext : DbContext
//    {
//        public RatingDbContext(DbContextOptions<RatingDbContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<ConferenceXAtendee> ConferenceXAtendees { get; set; }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

//            modelBuilder.Entity<ConferenceXAtendee>(entity =>
//            {

//                entity.ToTable("ConferenceXAttendee");
//                entity.Property(e => e.AttendeeEmail)
//                   .IsRequired()
//                   .HasMaxLength(50);

//                entity.Property(e => e.ConferenceId)
//                    .IsRequired();

//                entity.Property(e => e.StatusId)
//                    .IsRequired();

//                entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");

//            });
//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RatingSystem.Models;


#nullable disable

namespace RatingSystem.Data
{
    public partial class RatingDbContext : DbContext
    {

        public RatingDbContext(DbContextOptions<RatingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<ConferenceXAttendee> ConferenceXattendees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Conference>(entity =>
            {
               

                entity.ToTable("Conference");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OrganizerEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<ConferenceXAttendee>(entity =>
            {
              entity.HasKey(c => new { c. Id});

                entity.ToTable("ConferenceXAttendee");

                entity.Property(e => e.AttendeeEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
