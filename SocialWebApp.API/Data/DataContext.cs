using Microsoft.EntityFrameworkCore;
using SocialWebApp.API.Models;

namespace SocialWebApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet <Value> Values{ get;set;}
    }
}