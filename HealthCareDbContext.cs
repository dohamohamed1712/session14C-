using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_3
{
    public class HealthCareDbContext : DbContext
    {
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Appointment> Appointments => Set<Appointment>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=HealthCareDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(e =>
            {
                e.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Doctor>(e =>
            {
                e.Property(d => d.Name).IsRequired().HasMaxLength(100);
                e.Property(d => d.Specialization).IsRequired().HasMaxLength(100);
            });

            // Appointment (Many-to-Many between Patient and Doctor)
            modelBuilder.Entity<Appointment>(e =>
            {
                e.HasKey(a => new { a.PatientId, a.DoctorId, a.AppointmentDate });

                e.HasOne(a => a.Patient)
                 .WithMany(p => p.Appointments)
                 .HasForeignKey(a => a.PatientId);

                e.HasOne(a => a.Doctor)
                 .WithMany(d => d.Appointments)
                 .HasForeignKey(a => a.DoctorId);
            });
        }
    }
}
