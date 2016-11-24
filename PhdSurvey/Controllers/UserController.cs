using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PhdSurvey.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace PhdSurvey.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public UserController(PhdSurveyContext db) : base(db) { }

        public int CurrentUserId
        {
            get
            {
                return Convert.ToInt32(User.Claims.FirstOrDefault(m => m.Type == "UserId").Value);
            }
        }

        public IActionResult Index()
        {
            var user = _db.Users.Include(m => m.Surveys).Single(m => m.Id == CurrentUserId);
            return View(user);
        }

        [HttpGet]
        public IActionResult FemaleMainSurvey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FemaleMainSurvey(FemaleMainSurvey survey)
        {
            _db.Users.First(m => m.Id == CurrentUserId).Surveys.Add(new Survey()
            {
                Type = "FemaleMainSurvey",
                Answers = JsonConvert.SerializeObject(survey),
                Created = DateTime.UtcNow
            });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MaleMainSurvey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MaleMainSurvey(MaleMainSurvey survey)
        {
            _db.Users.First(m => m.Id == CurrentUserId).Surveys.Add(new Survey()
            {
                Type = "MaleMainSurvey",
                Answers = JsonConvert.SerializeObject(survey),
                Created = DateTime.UtcNow
            });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult FamilyDrawing(string gender)
        {
            ViewData["Gender"] = gender;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FamilyDrawing(string gender, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var blobClient = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=pregnancyphdsurvey;AccountKey=J/9J6zFsAfcRlOfTa3UNc7BfIlel7gSM3QOc+mlKlJCXHVCZPhQR6a26jkUHZ/iCfg9ih0e9xdRU5AxIofNvKw==").CreateCloudBlobClient();
                var container = blobClient.GetContainerReference("user" + CurrentUserId);
                await container.CreateIfNotExistsAsync();
                var blob = container.GetBlockBlobReference(gender);
                using (var stream = file.OpenReadStream())
                {
                    await blob.UploadFromStreamAsync(stream);
                }

                _db.Users.Single(m => m.Id == CurrentUserId).Surveys.Add(new Survey()
                {
                    Created = DateTime.UtcNow,
                    Type = gender + "FamilyDrawing",
                    Answers = ""
                });
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewData["RequiredField"] = "Это поле не заполнено";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Survey(string type, string gender)
        {
            ViewData["Gender"] = gender;
            if (type == "CondonSurvey")
            {
                type = gender + type;
            }
            var survey = Globals.Surveys.FirstOrDefault(m => m.Type == type);
            if (survey == null)
            {
                RedirectToAction("Index");
            }
            return View(survey);
        }

        [HttpPost]
        public void Survey(string type, string gender, List<int> answers)
        {
            if (_db.Users.Include(m => m.Surveys).Single(m => m.Id == CurrentUserId).Surveys.Any(m => m.Type == (type.ToLower().Contains("male") ? "" : gender) + type))
            {
                return;
            }
            _db.Users.Single(m => m.Id == CurrentUserId).Surveys.Add(new Survey()
            {
                Created = DateTime.UtcNow,
                Type = (type.ToLower().Contains("male") ? "" : gender) + type,
                Answers = JsonConvert.SerializeObject(answers)
            });
            _db.SaveChanges();
        }

        [HttpGet]
        public IActionResult Result(string type, string gender)
        {
            var survey = _db.Surveys.SingleOrDefault(m => m.User.Id == CurrentUserId && m.Type == (type.ToLower().Contains("male") ? "" : gender) + type);

            if (survey == null)
            {
                return RedirectToAction("Index");
            }

            if (type == "CondonSurvey")
            {
                type = gender + type;
            }

            switch (type)
            {
                case "DinerSurvey":
                    {
                        var result = SurveyProcessing.Diner(survey);
                        ViewData["Type"] = result.Item1;
                        ViewData["Description"] = result.Item2;
                    }
                    break;
                case "AlyoshinaSurvey":
                    {
                        var result = SurveyProcessing.Alyoshina(survey);
                        ViewData["Type"] = result.Item1;
                        ViewData["Description"] = result.Item2;
                    }
                    break;
                case "DobryakovaSurvey":
                    {
                        var result = SurveyProcessing.Dobryakova(survey);
                        ViewData["Type"] = result.Item1;
                        ViewData["Description"] = result.Item2;
                    }
                    break;
                case "RiffSurvey":
                    {
                        var result = SurveyProcessing.Riff(survey);
                        ViewData["Type"] = result.Item1;
                        ViewData["Description"] = result.Item2;
                    }
                    break;
                case "FemaleCondonSurvey":
                    {
                        var result = SurveyProcessing.FemaleCondon(survey);
                        ViewData["Type"] = result.Item1;
                        ViewData["Description"] = result.Item2;
                    }
                    break;
                case "MaleCondonSurvey":
                    {
                        var result = SurveyProcessing.MaleCondon(survey);
                        ViewData["Type"] = result.Item1;
                        ViewData["Description"] = result.Item2;
                    }
                    break;
            }

            return View();
        }
    }
}
