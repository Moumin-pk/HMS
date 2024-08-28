using HMS.Models;

namespace HMS.Abstraction
{
    public interface IPatientServices
    {
        List<Patient> GetPatients();
        void AddPatient(Patient patient);

        void RemovePatient(Patient patient);
        void RemovePatient(Guid Id);
        Patient GetPatientById(Guid Id);
    }
}
