using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhdSurvey.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Answers { get; set; }
        public DateTime Created { get; set; }

        public virtual User User { get; set; }
    }
}
