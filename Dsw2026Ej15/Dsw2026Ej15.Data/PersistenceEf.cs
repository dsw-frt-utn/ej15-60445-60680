using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data
{
    public class PersistenceEf : IPersistence
    {
        private readonly AppDbContext _context;

        public PersistenceEf(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            var doctors = _context.Doctors.ToList();
            return doctors;
        }

        public Doctor? GetDoctorById(Guid id)
        {
            return _context.Doctors.SingleOrDefault(d => d.Id == id);
        }

        public Speciality? GetSpecialityById(Guid id)
        {
            Speciality? speciality = _context.Specialities.FirstOrDefault(s => s.Id == id);
            return speciality;
        }

        public void SaveDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
    }
}
