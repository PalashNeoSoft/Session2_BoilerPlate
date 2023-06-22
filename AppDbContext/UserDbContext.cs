using Microsoft.EntityFrameworkCore;
using Session2_BoilerPlate.Models;

namespace Session2_BoilerPlate.AppDbContext
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> Context) : base(Context)
        {

        }
        public DbSet<UserModel> users { get; set; }
    }
}
