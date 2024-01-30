using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MessagingApp.Models
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>()
                        .HasOne(m => m.SentBy)
                        .WithMany(t => t.SentMessages)
                        .HasForeignKey(m => m.SentById)
                        .IsRequired();

            modelBuilder.Entity<Message>()
                        .HasOne(m => m.Reciver)
                        .WithMany(t => t.ReceivedMessages)
                        .HasForeignKey(m => m.ReciverId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Group> Groups { get; set; }
    }
}
