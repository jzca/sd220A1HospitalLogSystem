using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHospital.Models.BindingViewModel
{
    public class VisitViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int PatientId { get; set; }
    }
}