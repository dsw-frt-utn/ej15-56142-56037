using Dsw2026Ej15.Data.Dtos;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using System.Numerics;
using System.Text.Json;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence
    {
        private List<Speciality> _specialities = [];
        private List<Doctor> _doctors = [];

        public PersistenceInMemory()
        {
            LoadSpecialities();
        }

        public async Task SaveDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
            await Task.CompletedTask;
        }

        public async Task<Speciality?> GetSpecialityById(Guid id)
        {
            return await Task.FromResult(_specialities.FirstOrDefault(e => e.Id == id));
        }

        public async Task<Doctor?> GetDoctorById(Guid id)
        {
            return await Task.FromResult(_doctors.FirstOrDefault(d => d.Id == id));
        }

        private void LoadSpecialities()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Sources", "specialities.json");
                var json = File.ReadAllText(jsonPath);
                var specialities = JsonSerializer.Deserialize<List<SpecialityDto>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? [];
                _specialities = [.. specialities.Select(s => new Speciality(s.Name, s.Description, s.Id))];
            }
            catch (Exception)
            {

            }
        }

        public async Task<IEnumerable<Doctor>> GetActiveDoctors()
        {
            return await Task.FromResult(_doctors.Where(d => d.IsActive));
        }
    }
}

