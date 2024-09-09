using HMS.Enums;
using HMS.Extensions;
using HMS.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Numerics;
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

                },
                new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Ali Khan",
    ContactNumber = "03123456789",
    Email = "ali.khan@gmail.com",
    Age = 45,
    Address = new Address {
        state = "Sindh",
        street = "10th Avenue",
        city = "Karachi",
        country = "Pakistan",
        zipcode = "75270"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(5), // Adjusted for a discharge date 5 days later
    AdmissionDate = DateTime.Now.AddDays(-10), // Adjusted for an admission date 10 days earlier
    Gender = Gender.Male
},
                new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Ali Khan",
    ContactNumber = "03123456789",
    Email = "ali.khan@gmail.com",
    Age = 45,
    Address = new Address {
        state = "Sindh",
        street = "10th Avenue",
        city = "Karachi",
        country = "Pakistan",
        zipcode = "75270"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(5),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-10),
    Gender = Gender.Male
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Fatima Bibi",
    ContactNumber = "03214567890",
    Email = "fatima.bibi@gmail.com",
    Age = 34,
    Address = new Address {
        state = "Punjab",
        street = "12th Street",
        city = "Faisalabad",
        country = "Pakistan",
        zipcode = "38000"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(7),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-12),
    Gender = Gender.Female
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Hamza Sheikh",
    ContactNumber = "03056789012",
    Email = "hamza.sheikh@gmail.com",
    Age = 29,
    Address = new Address {
        state = "Khyber Pakhtunkhwa",
        street = "3rd Avenue",
        city = "Peshawar",
        country = "Pakistan",
        zipcode = "25000"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(3),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-7),
    Gender = Gender.Male
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Ayesha Noor",
    ContactNumber = "03456789023",
    Email = "ayesha.noor@gmail.com",
    Age = 40,
    Address = new Address {
        state = "Punjab",
        street = "15th Road",
        city = "Rawalpindi",
        country = "Pakistan",
        zipcode = "46000"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(4),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-8),
    Gender = Gender.Female
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Bilal Ahmed",
    ContactNumber = "03567890123",
    Email = "bilal.ahmed@gmail.com",
    Age = 38,
    Address = new Address {
        state = "Sindh",
        street = "7th Street",
        city = "Hyderabad",
        country = "Pakistan",
        zipcode = "71000"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(2),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-5),
    Gender = Gender.Male
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Sara Qureshi",
    ContactNumber = "03678901234",
    Email = "sara.qureshi@gmail.com",
    Age = 31,
    Address = new Address {
        state = "Punjab",
        street = "20th Lane",
        city = "Multan",
        country = "Pakistan",
        zipcode = "60000"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(6),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-11),
    Gender = Gender.Female
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Zain Ali",
    ContactNumber = "03789012345",
    Email = "zain.ali@gmail.com",
    Age = 27,
    Address = new Address {
        state = "Balochistan",
        street = "9th Street",
        city = "Quetta",
        country = "Pakistan",
        zipcode = "87300"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(8),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-13),
    Gender = Gender.Male
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Mariam Khan",
    ContactNumber = "03890123456",
    Email = "mariam.khan@gmail.com",
    Age = 36,
    Address = new Address {
        state = "Punjab",
        street = "2nd Avenue",
        city = "Sialkot",
        country = "Pakistan",
        zipcode = "51310"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(9),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-14),
    Gender = Gender.Female
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Ahmed Raza",
    ContactNumber = "03901234567",
    Email = "ahmed.raza@gmail.com",
    Age = 32,
    Address = new Address {
        state = "Khyber Pakhtunkhwa",
        street = "6th Street",
        city = "Abbottabad",
        country = "Pakistan",
        zipcode = "22010"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(10),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-15),
    Gender = Gender.Male
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Nida Javed",
    ContactNumber = "03012345678",
    Email = "nida.javed@gmail.com",
    Age = 28,
    Address = new Address {
        state = "Sindh",
        street = "5th Road",
        city = "Sukkur",
        country = "Pakistan",
        zipcode = "65200"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(7),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-9),
    Gender = Gender.Female
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Usman Tariq",
    ContactNumber = "03123456789",
    Email = "usman.tariq@gmail.com",
    Age = 39,
    Address = new Address {
        state = "Punjab",
        street = "3rd Lane",
        city = "Gujranwala",
        country = "Pakistan",
        zipcode = "52250"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(4),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-6),
    Gender = Gender.Male
},

new Patient {
    Id = GuidExtensions.NewGuid(),
    Name = "Hina Shahid",
    ContactNumber = "03234567890",
    Email = "hina.shahid@gmail.com",
    Age = 33,
    Address = new Address {
        state = "Punjab",
        street = "8th Street",
        city = "Bahawalpur",
        country = "Pakistan",
        zipcode = "63100"
    },
    DoctorId = GuidExtensions.NewGuid(),
    DiscahrgeDate = DateTime.Now.AddDays(3),  // Corrected here
    AdmissionDate = DateTime.Now.AddDays(-8),
    Gender = Gender.Female
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
                },
                new Doctore
                {
                    Id = GuidExtensions.NewGuid(),
                    Name = "Talha",
                    Specialization = Specialization.Psychiatry,
                    Experience = 10,
                    ContactNumber = "03257515675",
                    Email = "Hameed@gmail.com",
                    DepartmentId = Guid.NewGuid()
                },
                new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Talha",
    Specialization = Specialization.Psychiatry,
    Experience = 10,
    ContactNumber = "03257515675",
    Email = "Hameed@gmail.com",
    DepartmentId = Guid.NewGuid()
},
new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Ayesha",
    Specialization = Specialization.Cardiology,
    Experience = 8,
    ContactNumber = "03331234567",
    Email = "Ayesha123@gmail.com",
    DepartmentId = Guid.NewGuid()
},
new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Usman",
    Specialization = Specialization.Psychiatry,
    Experience = 5,
    ContactNumber = "03451234567",
    Email = "UsmanD@gmail.com",
    DepartmentId = Guid.NewGuid()
},
new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Fatima",
    Specialization = Specialization.Neurology,
    Experience = 12,
    ContactNumber = "03131234567",
    Email = "FatimaN@gmail.com",
    DepartmentId = Guid.NewGuid()
},
new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Ahmed",
    Specialization = Specialization.Orthopedics,
    Experience = 7,
    ContactNumber = "03011234567",
    Email = "AhmedO@gmail.com",
    DepartmentId = Guid.NewGuid()
},
new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Sana",
    Specialization = Specialization.Neurology,
    Experience = 6,
    ContactNumber = "03351234567",
    Email = "SanaP@gmail.com",
    DepartmentId = Guid.NewGuid()
},
new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Hamza",
    Specialization = Specialization.GeneralMedicine,
    Experience = 9,
    ContactNumber = "03421234567",
    Email = "HamzaO@gmail.com",
    DepartmentId = Guid.NewGuid()
},
new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Sara",
    Specialization = Specialization.Radiology,
    Experience = 11,
    ContactNumber = "03111234567",
    Email = "SaraR@gmail.com",
    DepartmentId = Guid.NewGuid()
},
new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Ali",
    Specialization = Specialization.Neurology,
    Experience = 4,
    ContactNumber = "03091234567",
    Email = "AliU@gmail.com",
    DepartmentId = Guid.NewGuid()
},
new Doctore
{
    Id = GuidExtensions.NewGuid(),
    Name = "Zainab",
    Specialization = Specialization.Cardiology,
    Experience = 15,
    ContactNumber = "03231234567",
    Email = "ZainabG@gmail.com",
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