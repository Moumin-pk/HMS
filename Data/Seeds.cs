using HMS.Enums;
using HMS.Extensions;
using HMS.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static HMS.Models.Address;

namespace HMS.Data
{
    public class Seeds
    {
        // Seed Memeber Data
        public static List<Member> SeadMember()
        {
            var list = new List<Member>
            {
                new Member
                {
                    Id = 1,
                    Name = "Moumin Ahmad",
                    Email = "offical.moumin@gmail.com"
                }
            };
            return list;
        }


        // Seed Department Data
        public static List<Department> SeedDepartment()
        {

            var list = new List<Department>
            {
                new Department{
                Id = GuidExtensions.NewGuid(),
                ContactNumber = "030456789",
                HeadOfDepartment =  "Lahore",
                Name = "Cardiology",



                }

            };

            return list;

        }


        // Seed Patient Data
        public static List<Patient> SeedPatient()
        {
            List<Patient> list = new List<Patient>
            {
                new Patient {


                    Id = GuidExtensions.NewGuid() ,
                    Name = "Hamza",
                    ContactNumber = "03047137578",
                    Email = "hamza@gmail.com",
                    Age = 30,
                    Address = new Address {
                        state = "Punjab",
                        street = "5 street",
                        city = "Lahore",
                        country = "Pakistan",
                        zipcode ="5469"
                    },
                    DoctorId = GuidExtensions.NewGuid(),
                    DiscahrgeDate = DateTime.Now,
                    AdmissionDate = DateTime.Now,
                    Gender = Gender.Male

                },
                new Patient {


                    Id = GuidExtensions.NewGuid() ,
                    Name = "sehar",
                    ContactNumber = "03047137578",
                    Email = "sehar@gmail.com",
                    Age = 30,
                    Address = new Address {
                        state = "Punjab",
                        street = "5 street",
                        city = "Lahore",
                        country = "Pakistan",
                        zipcode ="5469"
                    },
                    DoctorId = GuidExtensions.NewGuid(),
                    DiscahrgeDate = DateTime.Now,
                    AdmissionDate = DateTime.Now,
                    Gender = Gender.Male

                }
            };
            return list;

        }



        // Seed Doctore Data
        public static List<Doctore> SeedDoctore()
        {
            var list = new List<Doctore>
            {
                new Doctore
                {
                    Id = GuidExtensions.NewGuid(),
                    Name = "Hameed",
                    Specialization = Specialization.Neurology,
                    Experience = 5,
                    ContactNumber = "03257515675",
                    Email = "Hameed@gmail.com",
                    DepartmentId = Guid.NewGuid()
                }
            };

            return list;
        }



        public static List<Appointment> SeedAppointment()
        {
            var list = new List<Appointment>
            {
                new Appointment
                {
                    Id= GuidExtensions.NewGuid(),
                    PatientId= Guid.NewGuid(),
                    DoctoreId= Guid.NewGuid(),
                    AppointmentDate= DateTime.Now,
                    Purpose = "Digestive Problem",
                    IsCompleted= false,
                }
            };

            return list;
        }


        public static List<Billing> SeedBilling()
        {
            var list = new List<Billing>
            {
                new Billing
                {

                    Id = GuidExtensions.NewGuid(),
                    PatientId = Guid.NewGuid(),
                    DoctoreId = Guid.NewGuid(),
                    BillingDate = DateTime.Now,
                    Amount = 2000,
                    IsPaid = false,
                }

            };
            return list;
        }



    }


}