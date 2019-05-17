using AutoMapper;
using AutoMapper.QueryableExtensions;
using APIHospital.Models;
using APIHospital.Models.BindingViewModel;
using APIHospital.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;

namespace APIHospital.Controllers
{
    [Authorize]

    //Route: api/{controller}/{action}/{id}
    public class PatientController : ApiController
    {
        private readonly ApplicationDbContext DbContext;

        public PatientController()
        {
            DbContext = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var model = DbContext
                .Patients
                .ProjectTo<PatientViewModel>()
                .ToList();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var patientModel = DbContext.Patients.Where(p => p.Id == id)
                            .ProjectTo<PatientViewModel>()
                            .FirstOrDefault();

            if (patientModel == null)
            {
                return NotFound();
            }


            return Ok(patientModel);
        }

        [HttpPost]
        public IHttpActionResult Create(PatientBindingModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = Mapper.Map<Patient>(model);
            DbContext.Patients.Add(patient);
            DbContext.SaveChanges();

            var patientModel = Mapper.Map<PatientViewModel>(patient);

            return Ok(patientModel);
        }

        [HttpPut]
        public IHttpActionResult Edit(int id, PatientBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = DbContext.Patients.Where(p => p.Id == id).FirstOrDefault();

            if (patient == null)
            {
                return NotFound();
            }

            Mapper.Map(model, patient);

            DbContext.SaveChanges();

            var patientModel = Mapper.Map<PatientViewModel>(patient);

            return Ok(patientModel);
        }
        
        [HttpPost]
        public IHttpActionResult RecordVisit(int id, VisitBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = DbContext.Patients.Where(p => p.Id == id).FirstOrDefault();

            if (patient == null)
            {
                return NotFound();
            }

            var visit = Mapper.Map<Visit>(model);
            visit.Date = DateTime.Now;
            visit.PatientId = id;

            patient.Visits.Add(visit);
            DbContext.SaveChanges();

            var visitModel = Mapper.Map<VisitViewModel>(visit);
            return Ok(visitModel);

        }
    }
}
