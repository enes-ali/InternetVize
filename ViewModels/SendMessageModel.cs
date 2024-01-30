using System.ComponentModel.DataAnnotations;

namespace MessagingApp.ViewModels
{
    public class SendMessageModel
    {
        [Display(Name = "Mesajınız")]
        [Required(ErrorMessage = "Mesaj girmelisiniz")]
        public string Message { get; set; }

        [Display(Name = "Göndermek istediğiniz kişi")]
        [Required(ErrorMessage = "Kişi Seçiniz")]
        public string ReceiverId { get; set; }
    }
}
