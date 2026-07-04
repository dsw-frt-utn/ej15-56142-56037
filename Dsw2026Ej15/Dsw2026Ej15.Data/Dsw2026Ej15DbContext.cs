using Dsw2026Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data
{
    public class Dsw2026Ej15DbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public Dsw2026Ej15DbContext(DbContextOptions<Dsw2026Ej15DbContext> options): 
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(e =>
            {
                e.ToTable("Doctors");
                e.Property(p => p.Name).HasMaxLength(100).IsRequired();
                e.Property(p => p.LicenseNumber).HasMaxLength(50).IsRequired();
                e.HasIndex(p => p.LicenseNumber).IsUnique();
            });
            
            modelBuilder.Entity<Speciality>(e =>
            {
                e.ToTable("Specialities");
                e.Property(p => p.Name).HasMaxLength(100).IsRequired();
                e.Property(p => p.Description).HasMaxLength(300).IsRequired();
            });

            modelBuilder.Entity<Speciality>().HasData(
               new Speciality { Id = Guid.Parse("8a1f3b78-3f66-4d68-8d6e-1c5b9c7a2f41"), Name = "Cardiología", Description = "Especialidad médica dedicada al diagnóstico, tratamiento y prevención de enfermedades del corazón y del sistema cardiovascular." },
               new Speciality { Id = Guid.Parse("f4d2c9a1-7b3e-4f8d-9c61-2e7a5d8b3c12"), Name = "Pediatría", Description = "Rama de la medicina que se ocupa de la salud integral de niños, niñas y adolescentes." },
               new Speciality { Id = Guid.Parse("c7e8d4b2-5f91-4a37-b8d4-9e2c6f1a7b53"), Name = "Dermatología", Description = "Especialidad enfocada en el estudio, diagnóstico y tratamiento de enfermedades de la piel, cabello y uñas." },
               new Speciality { Id = Guid.Parse("1b9c5d7e-8a42-4f63-9d8e-3c7a1f5b2e64"), Name = "Neurología", Description = "Especialidad médica que trata los trastornos del sistema nervioso central y periférico." },
               new Speciality { Id = Guid.Parse("5e2a8c1d-4b73-4d96-a1f5-7c9b2e6d8a75"), Name = "Traumatología", Description = "Área médica dedicada al diagnóstico y tratamiento de lesiones y enfermedades del sistema musculoesquelético." },
               new Speciality { Id = Guid.Parse("9d4f1a7b-2c85-4e31-b6d7-5a8c3f2e9b86"), Name = "Ginecología", Description = "Especialidad orientada a la salud del aparato reproductor femenino y la prevención de enfermedades asociadas." },
               new Speciality { Id = Guid.Parse("2f7b6c1a-9d34-4a85-b7e2-8c5d1f9a3b97"), Name = "Oftalmología", Description = "Especialidad médica encargada de la prevención, diagnóstico y tratamiento de enfermedades de los ojos y la visión." },
               new Speciality { Id = Guid.Parse("7c3d8e5a-1f62-4b94-a9d3-6e2b7c1f4a08"), Name = "Endocrinología", Description = "Rama de la medicina que estudia y trata trastornos hormonales y enfermedades de las glándulas endocrinas." },
               new Speciality { Id = Guid.Parse("4a6e2b9c-8d15-4f73-b1c8-9e7a3d5f2b19"), Name = "Psiquiatría", Description = "Especialidad médica dedicada al diagnóstico, tratamiento y prevención de trastornos mentales y emocionales." },
               new Speciality { Id = Guid.Parse("6b1f9d3a-5c47-4e82-a7d5-2f8c6b1e3a20"), Name = "Otorrinolaringología", Description = "Especialidad que aborda las enfermedades del oído, nariz, garganta y estructuras relacionadas." }
           );
        }
    }
}
