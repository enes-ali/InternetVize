﻿namespace MessagingApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get;  } = new List<User>();
        public ICollection<Message> Messages { get; } = new List<Message>();
    }
}
