using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Dsw2026Ej15.Domain.Exceptions;

namespace Dsw2026Ej15.Api.Controllers
{
    public class DoctorsController : AppController
    {
        private readonly IPersistence _persistence;
        public DoctorsController(IPersistence persistence)
        {
            _persistence = persistence;
        }

        [HttpPost("doctors")]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorModel.Request request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenseNumber))
                throw new ValidationException("Nombre y Matricula son requeridos");

            var speciality = _persistence.GetSpecialityById(request.SpecialityId);
            if (speciality == null)
                throw new ValidationException("Especialidad no existe");
            var doctor = new Doctor(request.Name, request.LicenseNumber, speciality);
            _persistence.SaveDoctor(doctor);

            return StatusCode(201);
        }
        [HttpGet("doctors")]
        public IActionResult GetDoctors()
        {
            var doctors = _persistence.GetActiveDoctors();
            return Ok(doctors);
        }
        [HttpGet("doctors/{id}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = _persistence.GetDoctorById(id);

            if (doctor is null || !doctor.IsActive)
                return NotFound();

            var response = new DoctorModel.Response(
                doctor.Name,
                doctor.LicenseNumber,
                doctor.Speciality?.Name ?? string.Empty
            );
            return Ok(response);
        }

        [HttpDelete("doctors/{id}")]
        public IActionResult DeactivateDoctor(Guid id)
        {
            var doctor = _persistence.GetDoctorById(id);

            if (doctor is null || !doctor.IsActive)
                return NotFound();

            doctor.Deactivate();

            return NoContent();
        }
    }
}

