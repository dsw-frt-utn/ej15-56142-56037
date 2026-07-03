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
        public Dsw2026Ej15DbContext(DbContextOptions<Dsw2026Ej15DbContext> options) : base(options)
        {

        }
    }
}
