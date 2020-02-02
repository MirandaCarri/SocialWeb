using Microsoft.EntityFrameworkCore;
using SocialWebApp.API.Models;

namespace SocialWebApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Value> Values{ get;set;}

        public DbSet<User> Users {get; set;}

        public DbSet<Photo> Photos {get;set;}
        public DbSet<Message> Messages {get;set;}

    //create a migration for this
         protected override void OnModelCreating(ModelBuilder builder)
         {
        //     builder.Entity<Like>()
        //         .HasKey(k => new { k.LikerId, k.LikeeId });

        //     builder.Entity<Like>()
        //         .HasOne(u => u.Likee)
        //         .WithMany(u => u.Likers)
        //         .HasForeignKey(u => u.LikeeId)
        //         .OnDelete(DeleteBehavior.Restrict);
            
        //      builder.Entity<Like>()
        //         .HasOne(u => u.Liker)
        //         .WithMany(u => u.Likee)
        //         .HasForeignKey(u => u.LikerId)
        //         .OnDelete(DeleteBehavior.Restrict);


             builder.Entity<Message>()
                 .HasOne(u => u.Sender)
                 .WithMany(u => u.MessageSent)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                 .HasOne(u => u.Recipient)
                 .WithMany(u => u.MessageRecieved)
                 .OnDelete(DeleteBehavior.Restrict);


         }
    }
}