using System.ComponentModel.DataAnnotations;

namespace MessagingApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        [DataType(DataType.Date)]
        public DateTime sentAt { get; set; }

        public string SentById { get; set; }
        public User SentBy { get; set; } 
        
        public string? ReciverId {  get; set; }
        public User? Reciver {  get; set; }
        
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
