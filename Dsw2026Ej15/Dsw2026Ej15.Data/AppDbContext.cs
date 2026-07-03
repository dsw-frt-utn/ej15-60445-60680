using Dsw2026Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data
{
    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Speciality> Specialities { get; set; }
    }
}
