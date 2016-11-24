using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhdSurvey.Models
{

    public class User
    {
        public User()
        {
            Surveys = new List<Survey>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
