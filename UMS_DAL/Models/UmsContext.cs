using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UMS_DAL.Models;

public partial class UmsContext : DbContext
{
    public UmsContext()
    {
    }

    public UmsContext(DbContextOptions<UmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-N2JM0CV;Database=UMS;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity.ToTable("BUILDING");

            entity.Property(e => e.BuildingId).HasColumnName("BUILDING_ID");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(50)
                .HasColumnName("BUILDING_NAME");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.ToTable("FACULTY");

            entity.Property(e => e.FacultyId).HasColumnName("FACULTY_ID");
            entity.Property(e => e.DeanName)
                .HasMaxLength(50)
                .HasColumnName("DEAN_NAME");
            entity.Property(e => e.FacultyName)
                .HasMaxLength(50)
                .HasColumnName("FACULTY_NAME");
        });

        modelBuilder.Entity<Floor>(entity =>
        {
            entity.ToTable("FLOOR");

            entity.Property(e => e.FloorId)
                .ValueGeneratedNever()
                .HasColumnName("FLOOR_ID");
            entity.Property(e => e.BuildingId).HasColumnName("BUILDING_ID");
            entity.Property(e => e.FloorName)
                .HasMaxLength(50)
                .HasColumnName("FLOOR_NAME");

            entity.HasOne(d => d.Building).WithMany(p => p.Floors)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FLOOR_BUILDING");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GENDER");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.GenderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("GENDER_ID");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.ToTable("MAJOR");

            entity.Property(e => e.MajorId).HasColumnName("MAJOR_ID");
            entity.Property(e => e.FacultyId).HasColumnName("FACULTY_ID");
            entity.Property(e => e.MajorName)
                .HasMaxLength(50)
                .HasColumnName("MAJOR_NAME");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Majors)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MAJOR_FACULTY");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("ROOM");

            entity.Property(e => e.RoomId).HasColumnName("ROOM_ID");
            entity.Property(e => e.FloorId).HasColumnName("FLOOR_ID");
            entity.Property(e => e.RoomCapacity)
                .HasMaxLength(50)
                .HasColumnName("ROOM_CAPACITY");
            entity.Property(e => e.RoomName)
                .HasMaxLength(50)
                .HasColumnName("ROOM_NAME");

            entity.HasOne(d => d.Floor).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.FloorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_FLOOR");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
