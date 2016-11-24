using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhdSurvey.Models.ViewModels;

namespace PhdSurvey.Models
{
    public class Globals
    {
        public const string ChooseTemplate = "Выберете один из пунктов:";
        public const string RequiredErrorTemplate = "Это поле является обязательным";
        public static List<SurveyViewModel> Surveys { get; set; }
    }
}
