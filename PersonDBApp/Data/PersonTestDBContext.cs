using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonDBApp.Models;


#nullable disable

namespace PersonDBApp.Data
{
    public partial class PersonTestDBContext : DbContext
    {
        public PersonTestDBContext()
        {
        }

        public PersonTestDBContext(DbContextOptions<PersonTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonPhoneTb> PersonPhoneTbs { get; set; }
        public virtual DbSet<YoungPerson> YoungPeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PersonTestDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasIndex(e => e.DateOfBirth, "idx_age");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EyeColor)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PersonPhoneTb>(entity =>
            {
                entity.ToTable("PersonPhoneTB");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PersonPhoneTbs)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person");
            });

            modelBuilder.Entity<YoungPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("YoungPeople");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
