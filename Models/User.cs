using Microsoft.AspNetCore.Identity;

namespace MessagingApp.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Message> SentMessages { get; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; } = new List<Message>();

        public ICollection<Group> Groups { get; } = new List<Group>();
    }
}
