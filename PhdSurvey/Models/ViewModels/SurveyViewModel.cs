using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhdSurvey.Models.ViewModels
{
    public class SurveyViewModel
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
