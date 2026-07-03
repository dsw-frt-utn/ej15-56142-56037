using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Dsw2026Ej15.Domain.Exceptions;
using System.Linq;

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

            var speciality = await _persistence.GetSpecialityById(request.SpecialityId);
            if (speciality == null)
                throw new ValidationException("Especialidad no existe");
            var doctor = new Doctor(request.Name, request.LicenseNumber, speciality);
            await _persistence.SaveDoctor(doctor);

            return StatusCode(201);
        }
        [HttpGet("doctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _persistence.GetAllDoctors();
            return Ok(doctors.Select(d => new DoctorModel.Response(
                d.Id,
                d.Name,
                d.LicenseNumber,
                d.Speciality?.Name ?? string.Empty
                )));
        }
        [HttpGet("doctors/{id}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = await GetDoctor(id);

            var response = new DoctorModel.Response(
                doctor.Id,
                doctor.Name,
                doctor.LicenseNumber,
                doctor.Speciality?.Name ?? string.Empty
            );
            return Ok(response);
        }

        [HttpDelete("doctors/{id}")]
        public async Task<IActionResult> DeactivateDoctor(Guid id)
        {
            var doctor = await GetDoctor(id);

            doctor.Deactivate();
            await _persistence.UpdateDoctor(doctor);
            return NoContent();
        }
            private async Task<Doctor> GetDoctor(Guid id)
        {
            return await _persistence.GetDoctorById(id) ?? throw new EntityNotFoundException("Médico no encontrado");
        }
    }
}

