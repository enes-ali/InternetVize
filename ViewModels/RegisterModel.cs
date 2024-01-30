using System.ComponentModel.DataAnnotations;

namespace MessagingApp.ViewModels
{
    public class RegisterModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email giriniz!")]
        public string Email { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Kullanıcı adı giriniz!")]
        public string UserName { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "İsim soyisim giriniz!")]
        public string Name { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre giriniz!")]
        public string Password { get; set; }

        [Display(Name = "Admin mi")]
        public bool IsAdmin { get; set; } = false;
    }
}
