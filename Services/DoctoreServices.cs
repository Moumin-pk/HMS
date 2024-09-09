using HMS.Abstraction;
using HMS.Data.Models;
using HMS.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Numerics;

namespace HMS.Services
{
    public class DoctoreServices : IDoctoreServices
    {
        private readonly HmsContext _hmscontext;

        public DoctoreServices(HmsContext hmscontext)
        {
            _hmscontext = hmscontext;
        }

        //  Get all Data or applay filter only display list if IsDeleted =  to False
        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        
        {
            var doctors = await _hmscontext.Doctors.ToListAsync();
            return doctors.Where(d => d.IsDeleted == false);
        }

        //  Get DoctorebyId or return the model
        public async Task<Doctor> GetDoctoreById(Guid id)
        {
            var doctor = await _hmscontext.Doctors.FirstOrDefaultAsync(f => f.Id == id);
            return doctor;
        }

        //  Add new 
        public async Task AddDoctore(Doctor doctor)
        {
            _hmscontext.Doctors.Add(doctor);
            _hmscontext.SaveChanges();
        }

        // update the Doctore throw model 

        public void UpdateDoctore(Doctor doctor)
        {
            _hmscontext.Doctors.Update(doctor);
            _hmscontext.SaveChanges();
        }


        

        // Soft Delete a doctore by its ID
        //  so its softDelete Method  change isDeleted is Equal to True
        public async Task softDelete(Guid id)
        {
            var doctore = await GetDoctoreById(id);
            if (doctore != null)
            {
                doctore.IsDeleted = true;
                _hmscontext.Doctors.Update(doctore);
                _hmscontext.SaveChanges();
            }
        }

        // so its Method is used to display the enum in the dropdown
            public List<SelectListItem> GetDoctorSpecialties()
            {
                var specialties = Enum.GetValues(typeof(Specialization))
                    .Cast<Specialization>()
                    .Select(s => new SelectListItem
                    {
                        Value = ((int)s).ToString(),// Convert enum to its numeric value and then to string
                        Text = s.ToString() // Display the name of the enum value
                    }).ToList();

                return specialties;
            }

        public Task<List<Doctor>> GetAllDoctore()
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
