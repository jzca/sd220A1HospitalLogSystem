using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIHospital.Models.BindingViewModel
{
    public class PatientBindingModel
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public bool HasInsurance { get; set; }
    }
}