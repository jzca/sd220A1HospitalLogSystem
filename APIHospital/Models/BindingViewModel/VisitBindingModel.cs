using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIHospital.Models.BindingViewModel
{
    public class VisitBindingModel
    {
        [Required]
        public string Comments { get; set; }
    }
}