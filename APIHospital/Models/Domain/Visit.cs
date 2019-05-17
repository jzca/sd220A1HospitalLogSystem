﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHospital.Models.Domain
{
    public class Visit
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}