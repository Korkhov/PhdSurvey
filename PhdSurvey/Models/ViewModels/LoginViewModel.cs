using System.ComponentModel.DataAnnotations;

namespace PhdSurvey.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
