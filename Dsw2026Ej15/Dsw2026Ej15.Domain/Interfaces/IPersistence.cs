using System;
using System.Collections.Generic;
using System.Text;
using Dsw2026Ej15.Domain.Entities;


namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        public IEnumerable<Doctor> GetAllDoctors();
        Doctor? GetDoctorById(Guid id);
        Speciality? GetSpecialityById(Guid id);
        void SaveDoctor(Doctor doctor);
    }
}
