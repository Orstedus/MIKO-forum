using Microsoft.EntityFrameworkCore;
using MIKO.Models.PostsModels;
using MIKO.Models.UserModels;

namespace MIKO.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
