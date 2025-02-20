﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("idanamnesiscreater");

            modelBuilder.HasSequence("idcreater");

            modelBuilder.HasSequence("idtreatmentcreater");

            modelBuilder.Entity("DataAccess.Entities.Analisi", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric")
                        .HasColumnName("id");

                    b.Property<DateOnly>("DataDownoald")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("data_downoald")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<decimal>("IdTreatment")
                        .HasColumnType("numeric")
                        .HasColumnName("id_treatment");

                    b.Property<string>("Wave")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("wave");

                    b.HasKey("Id")
                        .HasName("analisis_pkey");

                    b.HasIndex("IdTreatment");

                    b.ToTable("analisis", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Anamnesi", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('idanamnesiscreater'::regclass)");

                    b.Property<string>("Complaint")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("complaint");

                    b.Property<DateOnly>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<decimal>("IdDoctor")
                        .HasColumnType("numeric")
                        .HasColumnName("id_doctor");

                    b.Property<decimal>("IdPatient")
                        .HasColumnType("numeric")
                        .HasColumnName("id_patient");

                    b.Property<string>("Prediagnosis")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("prediagnosis");

                    b.HasKey("Id")
                        .HasName("anamnesis_pkey");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("anamnesis", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Doctor", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('idcreater'::regclass)");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("fio");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("password");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("qualification");

                    b.HasKey("Id")
                        .HasName("doctor_pkey");

                    b.ToTable("doctor", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Human", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('idcreater'::regclass)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("human_pkey");

                    b.ToTable("human", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Patient", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('idcreater'::regclass)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<string>("Cnils")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cnils");

                    b.Property<char>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("name");

                    b.Property<string>("Omc")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character(16)")
                        .HasColumnName("omc")
                        .IsFixedLength();

                    b.Property<string>("Otchestvo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("otchestvo");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character(10)")
                        .HasColumnName("passport")
                        .IsFixedLength();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("phone_number");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("second_name");

                    b.HasKey("Id")
                        .HasName("patient_pkey");

                    b.ToTable("patient", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<char>("Day")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("day");

                    b.Property<int>("Ward")
                        .HasColumnType("integer")
                        .HasColumnName("ward");

                    b.Property<int>("Time")
                        .HasColumnType("integer")
                        .HasColumnName("time");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<decimal?>("IdPatient")
                        .HasColumnType("numeric")
                        .HasColumnName("id_patient");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.HasKey("Id", "Day", "Ward", "Time")
                        .HasName("place_pkey");

                    b.HasIndex("IdPatient");

                    b.HasIndex("Ward");

                    b.ToTable("place", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Treatment", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasColumnName("id")
                        .HasDefaultValueSql("nextval('idtreatmentcreater'::regclass)");

                    b.Property<string>("Analysis")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("analysis");

                    b.Property<DateOnly>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("diagnosis");

                    b.Property<string>("Drug")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("drug");

                    b.Property<int>("DurationHealth")
                        .HasColumnType("integer")
                        .HasColumnName("duration_health");

                    b.Property<string>("Health")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("health");

                    b.Property<decimal>("IdDoctor")
                        .HasColumnType("numeric")
                        .HasColumnName("id_doctor");

                    b.Property<decimal>("IdPatient")
                        .HasColumnType("numeric")
                        .HasColumnName("id_patient");

                    b.Property<string>("Recomendation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("recomendation");

                    b.HasKey("Id")
                        .HasName("treatment_pkey");

                    b.HasIndex("IdPatient");

                    b.ToTable("treatment", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Ward", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("CountPlace")
                        .HasColumnType("integer")
                        .HasColumnName("count_place");

                    b.Property<char>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("gender");

                    b.HasKey("Id")
                        .HasName("ward_pkey");

                    b.ToTable("ward", (string)null);
                });

            modelBuilder.Entity("DataAccess.Entities.Analisi", b =>
                {
                    b.HasOne("DataAccess.Entities.Treatment", "IdTreatmentNavigation")
                        .WithMany("Analisis")
                        .HasForeignKey("IdTreatment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("analisis_id_treatment_fkey");

                    b.Navigation("IdTreatmentNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.Anamnesi", b =>
                {
                    b.HasOne("DataAccess.Entities.Doctor", "IdDoctorNavigation")
                        .WithMany("Anamnesis")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("anamnesis_id_doctor_fkey");

                    b.HasOne("DataAccess.Entities.Patient", "IdPatientNavigation")
                        .WithMany("Anamnesis")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("anamnesis_id_patient_fkey");

                    b.Navigation("IdDoctorNavigation");

                    b.Navigation("IdPatientNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.Doctor", b =>
                {
                    b.HasOne("DataAccess.Entities.Human", "IdNavigation")
                        .WithOne("Doctor")
                        .HasForeignKey("DataAccess.Entities.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("doctor_id_fkey");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.Patient", b =>
                {
                    b.HasOne("DataAccess.Entities.Human", "IdNavigation")
                        .WithOne("Patient")
                        .HasForeignKey("DataAccess.Entities.Patient", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("patient_id_fkey");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.Place", b =>
                {
                    b.HasOne("DataAccess.Entities.Human", "IdPatientNavigation")
                        .WithMany("Places")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("place_id_patient_fkey");

                    b.HasOne("DataAccess.Entities.Ward", "WardNavigation")
                        .WithMany("Places")
                        .HasForeignKey("Ward")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("place_ward_fkey");

                    b.Navigation("IdPatientNavigation");

                    b.Navigation("WardNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.Treatment", b =>
                {
                    b.HasOne("DataAccess.Entities.Patient", "IdPatientNavigation")
                        .WithMany("Treatments")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("treatment_id_patient_fkey");

                    b.Navigation("IdPatientNavigation");
                });

            modelBuilder.Entity("DataAccess.Entities.Doctor", b =>
                {
                    b.Navigation("Anamnesis");
                });

            modelBuilder.Entity("DataAccess.Entities.Human", b =>
                {
                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Places");
                });

            modelBuilder.Entity("DataAccess.Entities.Patient", b =>
                {
                    b.Navigation("Anamnesis");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("DataAccess.Entities.Treatment", b =>
                {
                    b.Navigation("Analisis");
                });

            modelBuilder.Entity("DataAccess.Entities.Ward", b =>
                {
                    b.Navigation("Places");
                });
#pragma warning restore 612, 618
        }
    }
}
