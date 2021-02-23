using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCore.Dal;
using MVCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class PatientAPI : ControllerBase
    {
        // GET: api/<PatientAPI>


        // GET api/<PatientAPI>/5
        [HttpGet]
        public IActionResult Get(string PatientName)
        {
            PatientDal dal = new PatientDal();
            List<PatientModel> search = (from temp in dal.PatientModels
                                         where temp.PatientName == PatientName
                                         select temp)
                                         .ToList<PatientModel>();
            return Ok(search);
        }

        // POST api/<PatientAPI>
        [HttpPost]
        public IActionResult Post([FromBody] PatientModel obj)
        {
            // Create object of context
            var context = new ValidationContext(obj, null, null);
            // Fill the errors
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, result, true);

            if (result.Count == 0)
            {
                PatientDal dal = new PatientDal();
                dal.Database.EnsureCreated();
                dal.Add(obj);
                dal.SaveChanges();
                List<PatientModel> recs = dal.PatientModels.ToList<PatientModel>();
                return StatusCode(200, recs);             //Json(recs)
            }
            else
            {
                return StatusCode(500, result);                      //Json(result)
            }
        }

        // PUT api/<PatientAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
