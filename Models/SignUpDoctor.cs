using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class SignUpDoctor
    {
        [Required(ErrorMessage = "Please enter your Firstname")]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter your Lastname")]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please select your Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        public List<SelectListItem> Genderlist { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Select", Text = "Select" },
            new SelectListItem { Value = "Male", Text = "Male" },
            new SelectListItem { Value = "Female", Text = "Female" }
        };

        [Required(ErrorMessage = "Please enter your Mobile number")]
        [RegularExpression("\\+?\\d[\\d -]{8,12}\\d", ErrorMessage = "Please enter correct Mobile number")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please enter your Registered Id")]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "Registered Id")]
        public string RegisteredId { get; set; }

        [Required(ErrorMessage = "Please select your Speciality")]
        [Display(Name = "Specialist In")]
        public string SpecialistIn { get; set; }

        public List<SelectListItem> Specializationlist { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Select", Text = "Select" },
            new SelectListItem { Value = "Cardiologist", Text = "Cardiologist" },
            new SelectListItem { Value = "Dentist", Text = "Dentist" },
            new SelectListItem { Value = "Gynecologist", Text = "Gynecologist"  },
            new SelectListItem { Value = "Orthopeadic", Text = "Orthopeadic"},
            new SelectListItem { Value = "Psychiatrist", Text = "Psychiatrist"},
            new SelectListItem { Value = "Neurologist", Text = "Neurologist"}

        };

        [Required(ErrorMessage = "Please enter your City")]
        [StringLength(20, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your State")]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        [StringLength(60, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Zip code")]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "ZIP code")]

        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Please upload your Photo")]
        [Display(Name = "Upload photo")]
        [DataType(DataType.Upload)]
        public string UploadPhoto { get; set; }

        [Required(ErrorMessage = "Please upload your Certificate")]
        [Display(Name = "Upload Certificate")]
        [DataType(DataType.Upload)]
        public string UploadCertificate { get; set; }

        [Required(ErrorMessage = "Please upload Patient review Video")]
        [Display(Name = "Patient Review Video ")]
        [DataType(DataType.Upload)]
        public string PatientReviewVideo { get; set; }

        [Required(ErrorMessage = "Please enter your EmailID")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter your correct Email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
