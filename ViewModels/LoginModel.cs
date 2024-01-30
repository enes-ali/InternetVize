using System.ComponentModel.DataAnnotations;

namespace MessagingApp.ViewModels
{
    public class LoginModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email giriniz!")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre giriniz!")]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }
    }
}
