using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhdSurvey.Models;

namespace PhdSurvey.Controllers
{
    public class BaseController : Controller
    {
        public PhdSurveyContext _db;

        public BaseController(PhdSurveyContext db)
        {
            _db = db;
        }
    }
}
