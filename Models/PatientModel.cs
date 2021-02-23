using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCore.Models
{
    public class PatientModel
    {
        [Required]
        [RegularExpression("^[a-z]{1,10}$")]
        public string PatientName { get; set; }

        [Required]
        public List<Problem> Problems { get; set; }
    }
    public class Problem
    {
        public int id { get; set; }
        public string PatientProblem { get; set; }

        public PatientModel Patient { get; set; }
    }
}
