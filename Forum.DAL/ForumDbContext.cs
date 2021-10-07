using Forum.BL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Forum.DAL
{
    class ForumDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ImageProfile> ImageProfiles { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration appConfig =
               new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false, true).Build();
            string dbConnnString = appConfig.GetConnectionString("ForumDb");
            optionsBuilder.UseSqlServer(dbConnnString);

        }


    }
}
