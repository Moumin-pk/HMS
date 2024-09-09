using HMS.Abstraction;
using HMS.Data;
using HMS.Extensions;
using HMS.Models;

namespace HMS.Services
{
    public class PatientServices : IPatientServices
    {
        public static List<Patient> _patients = Seeds.SeedPatient();

        public List<Patient> GetPatients()
        {
            return _patients;
        }

        public Patient? GetPatientById(Guid Id)
        {
            return _patients.FirstOrDefault(p => p.Id == Id);   
        }

        public void AddPatient(Patient patient)
        {
            
            patient.Id = GuidExtensions.NewGuid();
            _patients.Add(patient);
        }

        public void RemovePatient(Patient patient)
        {
            _patients.Remove(patient);
        }

        public void RemovePatient(Guid Id)
        {
            Patient? patient = GetPatientById(Id);
            RemovePatient(patient);
        }
    }
}
