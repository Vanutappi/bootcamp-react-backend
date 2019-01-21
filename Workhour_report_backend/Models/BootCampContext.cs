using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Workhour_report_backend.Models
{
    public partial class BootCampContext : DbContext
    {
        public BootCampContext()
        {
        }

        public BootCampContext(DbContextOptions<BootCampContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Workhours> Workhours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=;Database=;user id=;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("Department_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("Employee_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Employees_Departments");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).HasColumnName("Project_ID");

                entity.Property(e => e.ProjectName)
                    .HasColumnName("Project_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Workhours>(entity =>
            {
                entity.HasKey(e => e.WorkhourId);

                entity.Property(e => e.WorkhourId).HasColumnName("Workhour_ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ProjectId).HasColumnName("Project_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Workhours)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Workhours_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Workhours)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Workhours_Projects");
            });
        }
    }
}
