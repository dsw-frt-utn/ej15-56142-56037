using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string Name { get; init; } = null!;
        public string LicenseNumber { get; init; } = null!;
        public bool IsActive { get; private set; }
        public Guid? SpecialityId { get; set; }
        public Speciality? Speciality { get; private set; }

        public Doctor() 
        { 
        }
        public Doctor (string name, string licenseNumber, Speciality speciality,Guid? id = null) : base (id)
        {
            Name = name;
            LicenseNumber = licenseNumber;
            Speciality = speciality;
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
