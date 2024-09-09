using HMS.Abstraction;
using HMS.Data.Models;
using HMS.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Xml.Linq;
namespace HMS.Services
{
    public class PatientServices : IPatientServices

    {

        private readonly HmsContext _hmsContext;

        public PatientServices(HmsContext hmsContext)
        {
            _hmsContext = hmsContext;
        }


        //  Get all Patient list
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patient = await _hmsContext.Patients.ToListAsync();
            return patient.Where(d => d.IsActive == false);

        }

        // Add Patient 
        public async Task AddPatient(Patient patient)
        {
            _hmsContext.Patients.Add(patient);
            _hmsContext.SaveChanges();
        }


        // Soft Delete a Patient by its ID
        //  so its softDelete Method  change isDeleted is Equal to True
        public async Task softDelete(Guid id)
        {
            var patient = await GetPatientById(id);
            if (patient != null)
            {
                patient.IsActive = true;
                _hmsContext.Patients.Update(patient);
                _hmsContext.SaveChanges();
            }
        }

        

        // Update or save 
        public async Task UpdatePatient(Patient patient)
        {
            try
            {
                var existingPatient = await _hmsContext.Patients.FirstOrDefaultAsync(a => a.Id == patient.Id);
                if (existingPatient != null)
                {
                    // Update the properties of the existing patient
                    existingPatient.Name = patient.Name;
                    existingPatient.Age = patient.Age;
                    //existingPatient.Address = patient.Address;
                    existingPatient.Gender = patient.Gender;
                    existingPatient.ContactNumber = patient.ContactNumber;
                    existingPatient.Email = patient.Email;
                    existingPatient.AdmissionDate = patient.AdmissionDate;
                    existingPatient.DischargeDate = patient.DischargeDate;


                    _hmsContext.Patients.Update(existingPatient);
                    await _hmsContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }


        // Get Patientby id
        public async Task<Patient> GetPatientById(Guid id)
        {
            var Patient = _hmsContext.Patients.FirstOrDefault(x => x.Id == id);
            return Patient;
        }

        // enum for Gender
        // to display in  Dropdown
        public List<SelectListItem> GetGender()
        {
            var Gender = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(s => new SelectListItem
                {
                    Value = ((int)s).ToString(),// Convert enum to its numeric value and then to string
                    Text = s.ToString() // Display the name of the enum value
                }).ToList();

            return Gender;
        }


        public Task<IActionResult> Details(Guid id)
        {
            throw new NotImplementedException();
        }

        


        // count the Total Patient
        public int PatientCount()
        {
            return _hmsContext.Patients.Count();
        }

        public Task RemovePatient(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
