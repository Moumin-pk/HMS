using HMS.Data; // Ensure you have access to the Seeds class
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;

namespace HMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // In-memory storage for visit counts
        private static int _homePageVisitCount = 0;

        // Access static lists from Seeds class
        private static readonly List<Patient> _patients = Seeds.SeedPatient() ?? new List<Patient>();
        private static readonly List<Doctore> _doctors = Seeds.SeedDoctore() ?? new List<Doctore>();
        private static readonly List<Member> _members = Seeds.SeadMember() ?? new List<Member>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                // Increment home page visit count
                _homePageVisitCount++;

                // Pass counts to the view
                ViewBag.VisitCount = _homePageVisitCount;
                ViewBag.PatientCount = _patients.Count;
                ViewBag.DoctorCount = _doctors.Count;
                ViewBag.MemberCount = _members.Count;

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return View("Error");
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Aboutme()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
