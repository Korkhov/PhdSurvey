using System.ComponentModel.DataAnnotations;

namespace PhdSurvey.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите email")]
        [EmailAddress(ErrorMessage = "Email не валидный")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, ErrorMessage = "{0} должен содержать минимум {2} и максимум {1} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
