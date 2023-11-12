using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using webapp.DataModels;

namespace webapp.DB
{
    public class DBC : DbContext
    {
        public IConfiguration _config;
        public DBC(IConfiguration config)

        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }
        public DbSet<UserDataModel> UserDatas { get; set; }
    }
}
