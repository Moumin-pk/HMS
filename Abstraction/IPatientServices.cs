using HMS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace HMS.Abstraction
{
    public interface IPatientServices
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task AddPatient(Patient patient);
        Task softDelete(Guid id);
        public Task<Patient> GetPatientById(Guid id);
        //public Task<Patient?> GetPatientById(Guid Id);
        Task  RemovePatient(Guid id);
        public Task UpdatePatient(Patient patient);
        public Task<IActionResult> Details(Guid id);
        public int PatientCount();

        List<SelectListItem> GetGender();


    }
}
