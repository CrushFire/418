using System;
using System.Collections.Generic;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Analisi> Analises { get; set; }

    public virtual DbSet<Anamnesi> Anamneses { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Human> Humans { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Курсовая;Username=postgres;Password=14041404");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analisi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("analisis_pkey");

            entity.ToTable("analisis");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataDownoald)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("data_downoald");
            entity.Property(e => e.IdTreatment).HasColumnName("id_treatment");
            entity.Property(e => e.Wave).HasColumnName("wave");

            entity.HasOne(d => d.IdTreatmentNavigation).WithMany(p => p.Analisis)
                .HasForeignKey(d => d.IdTreatment)
                .HasConstraintName("analisis_id_treatment_fkey");
        });

        modelBuilder.Entity<Anamnesi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("anamnesis_pkey");

            entity.ToTable("anamnesis");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('idanamnesiscreater'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Complaint)
                .HasMaxLength(1000)
                .HasColumnName("complaint");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("date");
            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");
            entity.Property(e => e.IdPatient).HasColumnName("id_patient");
            entity.Property(e => e.Prediagnosis)
                .HasMaxLength(100)
                .HasColumnName("prediagnosis");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Anamnesis)
                .HasForeignKey(d => d.IdDoctor)
                .HasConstraintName("anamnesis_id_doctor_fkey");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.Anamnesis)
                .HasForeignKey(d => d.IdPatient)
                .HasConstraintName("anamnesis_id_patient_fkey");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doctor_pkey");

            entity.ToTable("doctor");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('idcreater'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("fio");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
            entity.Property(e => e.Qualification)
                .HasMaxLength(50)
                .HasColumnName("qualification");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.Id)
                .HasConstraintName("doctor_id_fkey");
        });

        modelBuilder.Entity<Human>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("human_pkey");

            entity.ToTable("human");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('idcreater'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("patient_pkey");

            entity.ToTable("patient");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('idcreater'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Cnils)
                .HasMaxLength(11)
                .HasColumnName("cnils");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Omc)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("omc");
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(25)
                .HasColumnName("otchestvo");
            entity.Property(e => e.Passport)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("passport");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .HasColumnName("phone_number");
            entity.Property(e => e.SecondName)
                .HasMaxLength(25)
                .HasColumnName("second_name");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Patient)
                .HasForeignKey<Patient>(d => d.Id)
                .HasConstraintName("patient_id_fkey");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Day, e.Ward, e.Time }).HasName("place_pkey");

            entity.ToTable("place");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Day)
                .HasMaxLength(1)
                .HasColumnName("day");
            entity.Property(e => e.Ward).HasColumnName("ward");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdPatient).HasColumnName("id_patient");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("place_id_patient_fkey");

            entity.HasOne(d => d.WardNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.Ward)
                .HasConstraintName("place_ward_fkey");
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("treatment_pkey");

            entity.ToTable("treatment");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('idtreatmentcreater'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Analysis).HasColumnName("analysis");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("date");
            entity.Property(e => e.Diagnosis).HasColumnName("diagnosis");
            entity.Property(e => e.Drug).HasColumnName("drug");
            entity.Property(e => e.DurationHealth).HasColumnName("duration_health");
            entity.Property(e => e.Health).HasColumnName("health");
            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");
            entity.Property(e => e.IdPatient).HasColumnName("id_patient");
            entity.Property(e => e.Recomendation).HasColumnName("recomendation");

            entity.HasOne(d => d.IdPatientNavigation).WithMany(p => p.Treatments)
                .HasForeignKey(d => d.IdPatient)
                .HasConstraintName("treatment_id_patient_fkey");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ward_pkey");

            entity.ToTable("ward");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountPlace).HasColumnName("count_place");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
        });
        modelBuilder.HasSequence("idanamnesiscreater");
        modelBuilder.HasSequence("idcreater");
        modelBuilder.HasSequence("idtreatmentcreater");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
