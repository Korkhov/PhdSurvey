using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhdSurvey.Models.ViewModels
{
    public class Algorithm
    {
        public List<int> ForwardScale { get; set; }
        public List<int> BackScale { get; set; }
        public List<int> ScoreForAnswer { get; set; }
    }
}
