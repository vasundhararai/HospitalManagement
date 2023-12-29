using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class AccountDocSignUpController : Controller
    {
        public IActionResult Index()
        {
            DoctorDal obj = new DoctorDal();
            List<Doctor> doctors = obj.GetDoctor(connstring);
            return View(doctors);
        }

        [HttpGet]
        public IActionResult Signup()
        {
            var model = new SignUpDoctor();
            model.SpecialistIn = "";
            model.Gender = "";
            return View(model);
        }

        private IConfiguration _configuration;
        string connstring = "";
        public AccountDocSignUpController(IConfiguration configuration)
        {
            _configuration = configuration;
            connstring = _configuration.GetConnectionString("dbconn").ToString();
        }


        [HttpPost]
        public IActionResult Signup(SignUpDoctor signUpDoctor)
        {
            if (ModelState.IsValid)  // when form has no validation error
            {
                //submitting form values to database
                DoctorDal doctorDAL = new DoctorDal();
                doctorDAL.RegisterDoctor(signUpDoctor, connstring);
                return RedirectToAction("Index");
                //return Redirect("https://localhost:7204/DoctorDB");
            }

            return View();
        }
    }

}
