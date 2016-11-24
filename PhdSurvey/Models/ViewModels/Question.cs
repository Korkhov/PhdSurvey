using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhdSurvey.Models.ViewModels
{
    public class Question
    {
        public string Description { get; set; }
        public List<string> Answers { get; set; }
    }
}
