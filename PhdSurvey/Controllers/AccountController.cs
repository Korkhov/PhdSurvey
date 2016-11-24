using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PhdSurvey.Models;
using PhdSurvey.Models.ViewModels;
using System.Security.Claims;

namespace PhdSurvey.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(PhdSurveyContext db) : base(db) { }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (_db.Users.Any(m => m.Email == model.Email))
            {
                ModelState.AddModelError("NotUnique", "Пользователь с такой электронной почтой уже зарегистрирован");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = model.Email,
                    Password = model.Password.EncryptSHA512(),
                    Created = DateTime.UtcNow
                };
                _db.Users.Add(user);
                _db.SaveChanges();

                var claims = new List<Claim>()
                    {
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("Email", user.Email)
                    };
                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "local"));

                await HttpContext.Authentication.SignInAsync(
                    "CookieAuthenticationInstance",
                    principal,
                    new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties()
                    {
                        IsPersistent = false
                    });

                if (string.IsNullOrWhiteSpace(returnUrl))
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(m => m.Email == model.Email && m.Password == model.Password.EncryptSHA512());
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("Email", user.Email)
                    };
                    var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "local"));

                    await HttpContext.Authentication.SignInAsync(
                        "CookieAuthenticationInstance",
                        principal,
                        new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties()
                        {
                            IsPersistent = model.RememberMe
                        });

                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Непровильный email или пароль.");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync("CookieAuthenticationInstance");
            return RedirectToAction("Index", "Home");

        }
    }
}
