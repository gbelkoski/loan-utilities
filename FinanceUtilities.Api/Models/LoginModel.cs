using System.ComponentModel.DataAnnotations;

namespace FinanceUtilities.Api.Models
{
    public class LoginModel
    {
        [Display(Name = "Корисничко име")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Лозинка")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}