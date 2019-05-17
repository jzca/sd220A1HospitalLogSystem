using AutoMapper;
using APIHospital.Models;
using APIHospital.Models.BindingViewModel;
using APIHospital.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseholdBudgeterAPI.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Patient, PatientBindingModel>().ReverseMap();
                cfg.CreateMap<Patient, PatientViewModel>().ReverseMap();
                cfg.CreateMap<Visit, VisitBindingModel>().ReverseMap();
                cfg.CreateMap<Visit, VisitViewModel>().ReverseMap();
            });
        }
    }
}