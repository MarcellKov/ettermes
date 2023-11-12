using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using webapp.DataModels;

namespace webapp.DB
{
    public class DBC : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Userdb");
        }
        public DbSet<UserDataModel> UserDatas { get; set; }
    }
}
